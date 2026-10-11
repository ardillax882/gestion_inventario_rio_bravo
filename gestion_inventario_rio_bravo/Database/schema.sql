-- =============================================================================
-- Sistema de Inventario Río Bravo - Esquema PostgreSQL (Supabase)
-- Fuente: Docs/REQUERIMIENTOS.md §6 (modelo) y §7 (reglas de negocio)
--
-- Ejecutar completo en el SQL Editor de Supabase. Es seguro re-ejecutarlo
-- solo sobre una BD vacía; para cambios posteriores crear scripts de migración.
--
-- Folios: el id de cada documento ES su folio correlativo (RN-11).
--         Se muestra con prefijo en la app: SOL-000123, DES-000045, OC-..., VEN-...
-- Stock:  material.stock_actual solo lo modifica el trigger de
--         movimiento_inventario (RN-05) y nunca puede quedar negativo (RN-04).
-- =============================================================================

BEGIN;

-- Las tablas del proyecto anterior (modelo incorrecto, ver REQUERIMIENTOS.md §2) se ELIMINAN
-- con sus datos, por decisión del responsable (2026-10-11). Se reconocen porque les falta una
-- columna del modelo nuevo, así una tabla nueva nunca se borra al re-ejecutar el script.
-- DROP TABLE también elimina sus secuencias e índices (ej. usuario_pkey), que chocarían con los nuevos.
DO $$
DECLARE
    v_tabla TEXT; v_columna TEXT;
BEGIN
    FOR v_tabla, v_columna IN VALUES
        ('solicitud', 'id_obra'), ('usuario', 'password_hash'), ('material', 'nombre'),
        ('obra', 'superficie_m2'), ('proveedor', 'activo'),
        ('ordencompra', NULL), ('detalleorden', NULL), ('movimientoinventario', NULL)
    LOOP
        CONTINUE WHEN to_regclass('public.' || v_tabla) IS NULL;
        CONTINUE WHEN v_columna IS NOT NULL AND EXISTS (
            SELECT 1 FROM information_schema.columns
             WHERE table_schema = 'public' AND table_name = v_tabla AND column_name = v_columna);
        EXECUTE format('DROP TABLE public.%I CASCADE', v_tabla);
    END LOOP;
END $$;

-- -----------------------------------------------------------------------------
-- Maestros
-- -----------------------------------------------------------------------------

CREATE TABLE usuario (
    id_usuario     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    rut            VARCHAR(12)  NOT NULL UNIQUE,
    nombre         VARCHAR(100) NOT NULL,
    email          VARCHAR(100) NOT NULL UNIQUE,
    password_hash  VARCHAR(255) NOT NULL,
    rol            VARCHAR(20)  NOT NULL CHECK (rol IN ('Gerente', 'Jefe_Compras', 'Bodeguero')),
    activo         BOOLEAN      NOT NULL DEFAULT TRUE
);

CREATE TABLE proveedor (
    id_proveedor       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    rut                VARCHAR(12)  NOT NULL UNIQUE,
    razon_social       VARCHAR(100) NOT NULL,
    contacto_telefono  VARCHAR(20),
    email              VARCHAR(100),
    activo             BOOLEAN      NOT NULL DEFAULT TRUE
);

CREATE TABLE cliente (
    id_cliente  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    rut         VARCHAR(12)  NOT NULL UNIQUE,
    nombre      VARCHAR(100) NOT NULL,
    telefono    VARCHAR(20),
    email       VARCHAR(100)
);

CREATE TABLE categoria (
    id_categoria  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre        VARCHAR(50) NOT NULL UNIQUE,
    prefijo       CHAR(3)     NOT NULL UNIQUE,   -- para códigos de material: RAD-001
    orden         INT         NOT NULL UNIQUE    -- orden en el formulario impreso
);

CREATE TABLE material (
    id_material      INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    codigo           VARCHAR(20)   NOT NULL UNIQUE,
    nombre           VARCHAR(100)  NOT NULL,
    descripcion      VARCHAR(150),
    unidad_medida    VARCHAR(20)   NOT NULL CHECK (unidad_medida IN
                        ('un', 'kg', 'm', 'm2', 'rollo', 'caja', 'saco', 'barra', 'plancha',
                         'litro', 'galón', 'tarro', 'tineta', 'juego', 'kit')),
    id_categoria     INT           REFERENCES categoria,  -- categoría por defecto (RN-10)
    stock_actual     NUMERIC(12,2) NOT NULL DEFAULT 0 CHECK (stock_actual >= 0),   -- RN-04
    stock_minimo     NUMERIC(12,2) NOT NULL DEFAULT 0 CHECK (stock_minimo >= 0),
    precio_unitario  NUMERIC(12,2) NOT NULL DEFAULT 0 CHECK (precio_unitario >= 0), -- P-02 pendiente
    activo           BOOLEAN       NOT NULL DEFAULT TRUE
);

CREATE TABLE obra (
    id_obra                 INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre_obra             VARCHAR(100)  NOT NULL,
    superficie_m2           NUMERIC(6,2)  CHECK (superficie_m2 > 0),
    direccion               VARCHAR(150),
    beneficiario            VARCHAR(100),             -- P-04 pendiente
    maestro                 VARCHAR(100),
    presupuesto_materiales  NUMERIC(14,2) NOT NULL DEFAULT 0 CHECK (presupuesto_materiales >= 0),
    estado                  VARCHAR(20)   NOT NULL DEFAULT 'En_planificacion'
                               CHECK (estado IN ('En_planificacion', 'En_ejecucion', 'Finalizada'))
);

-- -----------------------------------------------------------------------------
-- Compras
-- -----------------------------------------------------------------------------

CREATE TABLE orden_compra (
    id_orden       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_proveedor   INT           NOT NULL REFERENCES proveedor,
    id_usuario     INT           NOT NULL REFERENCES usuario,
    fecha_emision  TIMESTAMP     NOT NULL DEFAULT now(),
    estado         VARCHAR(10)   NOT NULL DEFAULT 'Pendiente'
                      CHECK (estado IN ('Pendiente', 'Recibida', 'Cancelada')),
    total          NUMERIC(14,2) NOT NULL DEFAULT 0
);

CREATE TABLE detalle_orden (
    id_detalle       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_orden         INT           NOT NULL REFERENCES orden_compra ON DELETE CASCADE,
    id_material      INT           NOT NULL REFERENCES material,
    cantidad         NUMERIC(12,2) NOT NULL CHECK (cantidad > 0),
    precio_unitario  NUMERIC(12,2) NOT NULL CHECK (precio_unitario >= 0)
);

-- -----------------------------------------------------------------------------
-- Solicitudes (la planilla) y despachos (cada columna "Fecha")
-- -----------------------------------------------------------------------------

CREATE TABLE solicitud (
    id_solicitud        INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_obra             INT          NOT NULL REFERENCES obra,
    id_usuario          INT          NOT NULL REFERENCES usuario,   -- quien la registra
    fecha_solicitud     TIMESTAMP    NOT NULL DEFAULT now(),
    estado              VARCHAR(20)  NOT NULL DEFAULT 'Pendiente'
                           CHECK (estado IN ('Pendiente', 'Aprobada', 'Rechazada',
                                             'Despachada_parcial', 'Despachada_total')),
    id_usuario_aprueba  INT          REFERENCES usuario,
    fecha_aprobacion    TIMESTAMP,
    motivo_rechazo      VARCHAR(200),
    equipo_trompo       BOOLEAN      NOT NULL DEFAULT FALSE,        -- P-03 pendiente
    equipo_placa        BOOLEAN      NOT NULL DEFAULT FALSE,
    equipo_bano         BOOLEAN      NOT NULL DEFAULT FALSE,
    observaciones       VARCHAR(300),
    CHECK (estado <> 'Rechazada' OR motivo_rechazo IS NOT NULL)
);

CREATE TABLE detalle_solicitud (
    id_detalle_solicitud  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_solicitud          INT           NOT NULL REFERENCES solicitud ON DELETE CASCADE,
    id_material           INT           NOT NULL REFERENCES material,
    id_categoria          INT           NOT NULL REFERENCES categoria,  -- sección del formulario (RN-10)
    cantidad_solicitada   NUMERIC(12,2) NOT NULL CHECK (cantidad_solicitada > 0),
    UNIQUE (id_solicitud, id_material, id_categoria)
);

CREATE TABLE despacho (
    id_despacho    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_solicitud   INT          NOT NULL REFERENCES solicitud,
    id_usuario     INT          NOT NULL REFERENCES usuario,   -- bodeguero que entrega
    fecha_hora     TIMESTAMP    NOT NULL DEFAULT now(),
    recibido_por   VARCHAR(100),
    observaciones  VARCHAR(300)
);

CREATE TABLE detalle_despacho (
    id_detalle_despacho   INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_despacho           INT           NOT NULL REFERENCES despacho ON DELETE CASCADE,
    id_detalle_solicitud  INT           NOT NULL REFERENCES detalle_solicitud,
    cantidad              NUMERIC(12,2) NOT NULL CHECK (cantidad > 0)
);

-- -----------------------------------------------------------------------------
-- Ventas a terceros
-- -----------------------------------------------------------------------------

CREATE TABLE venta (
    id_venta    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_cliente  INT           NOT NULL REFERENCES cliente,
    id_usuario  INT           NOT NULL REFERENCES usuario,
    fecha       TIMESTAMP     NOT NULL DEFAULT now(),
    total       NUMERIC(14,2) NOT NULL DEFAULT 0,
    estado      VARCHAR(10)   NOT NULL DEFAULT 'Emitida' CHECK (estado IN ('Emitida', 'Anulada'))
);

CREATE TABLE detalle_venta (
    id_detalle_venta  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_venta          INT           NOT NULL REFERENCES venta ON DELETE CASCADE,
    id_material       INT           NOT NULL REFERENCES material,
    cantidad          NUMERIC(12,2) NOT NULL CHECK (cantidad > 0),
    precio_venta      NUMERIC(12,2) NOT NULL CHECK (precio_venta >= 0)
);

-- -----------------------------------------------------------------------------
-- Kardex: solo inserción (RN-09). Cada fila tiene exactamente su documento de origen.
-- -----------------------------------------------------------------------------

CREATE TABLE movimiento_inventario (
    id_movimiento    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    id_material      INT           NOT NULL REFERENCES material,
    tipo             VARCHAR(16)   NOT NULL CHECK (tipo IN
                        ('ENTRADA_COMPRA', 'SALIDA_DESPACHO', 'SALIDA_VENTA', 'AJUSTE_ENTRADA', 'AJUSTE_SALIDA')),
    cantidad         NUMERIC(12,2) NOT NULL CHECK (cantidad > 0),
    precio_unitario  NUMERIC(12,2) NOT NULL CHECK (precio_unitario >= 0),  -- valor al momento
    fecha_hora       TIMESTAMP     NOT NULL DEFAULT now(),
    id_usuario       INT           NOT NULL REFERENCES usuario,
    id_obra          INT           REFERENCES obra,
    id_orden         INT           REFERENCES orden_compra,
    id_despacho      INT           REFERENCES despacho,
    id_venta         INT           REFERENCES venta,
    motivo           VARCHAR(200),
    CHECK (
        (tipo = 'ENTRADA_COMPRA'  AND id_orden    IS NOT NULL AND id_despacho IS NULL AND id_venta IS NULL) OR
        (tipo = 'SALIDA_DESPACHO' AND id_despacho IS NOT NULL AND id_obra IS NOT NULL AND id_orden IS NULL AND id_venta IS NULL) OR
        (tipo = 'SALIDA_VENTA'    AND id_venta    IS NOT NULL AND id_orden IS NULL AND id_despacho IS NULL) OR
        (tipo IN ('AJUSTE_ENTRADA', 'AJUSTE_SALIDA') AND motivo IS NOT NULL
                                  AND id_orden IS NULL AND id_despacho IS NULL AND id_venta IS NULL)
    )
);

CREATE INDEX ix_mov_material ON movimiento_inventario (id_material, fecha_hora);
CREATE INDEX ix_mov_obra     ON movimiento_inventario (id_obra) WHERE id_obra IS NOT NULL;
CREATE INDEX ix_det_desp_det ON detalle_despacho (id_detalle_solicitud);

-- Actualiza el stock en la misma transacción que el movimiento (RN-05).
-- Si el stock quedaría negativo, el CHECK de material aborta toda la operación (RN-04).
-- SECURITY DEFINER: el usuario de la app no tiene permiso para escribir stock_actual;
-- solo esta función (dueña: postgres) puede hacerlo.
CREATE FUNCTION fn_aplicar_movimiento() RETURNS trigger
    SECURITY DEFINER SET search_path = public AS $$
BEGIN
    UPDATE material
       SET stock_actual = stock_actual
           + CASE WHEN NEW.tipo IN ('ENTRADA_COMPRA', 'AJUSTE_ENTRADA') THEN NEW.cantidad ELSE -NEW.cantidad END
     WHERE id_material = NEW.id_material;
    RETURN NEW;
END $$ LANGUAGE plpgsql;

CREATE TRIGGER trg_aplicar_movimiento
    AFTER INSERT ON movimiento_inventario
    FOR EACH ROW EXECUTE FUNCTION fn_aplicar_movimiento();

-- Los movimientos no se editan ni borran (RN-09).
CREATE FUNCTION fn_movimiento_inmutable() RETURNS trigger
    SET search_path = public AS $$
BEGIN
    RAISE EXCEPTION 'Los movimientos de inventario no se modifican ni eliminan; registre un ajuste.';
END $$ LANGUAGE plpgsql;

CREATE TRIGGER trg_movimiento_inmutable
    BEFORE UPDATE OR DELETE ON movimiento_inventario
    FOR EACH ROW EXECUTE FUNCTION fn_movimiento_inmutable();

-- Saldo por línea de solicitud (para el formulario y RN-06/RN-07).
CREATE VIEW v_saldo_solicitud AS
SELECT ds.id_detalle_solicitud,
       ds.id_solicitud,
       ds.id_material,
       ds.id_categoria,
       ds.cantidad_solicitada,
       COALESCE(SUM(dd.cantidad), 0)                          AS cantidad_despachada,
       ds.cantidad_solicitada - COALESCE(SUM(dd.cantidad), 0) AS saldo
  FROM detalle_solicitud ds
  LEFT JOIN detalle_despacho dd ON dd.id_detalle_solicitud = ds.id_detalle_solicitud
 GROUP BY ds.id_detalle_solicitud;

-- -----------------------------------------------------------------------------
-- Datos iniciales: categorías estándar (REQUERIMIENTOS.md §8.3)
-- -----------------------------------------------------------------------------

INSERT INTO categoria (orden, nombre, prefijo) VALUES
    ( 1, 'Radier',                 'RAD'),
    ( 2, 'Maderas',                'MAD'),
    ( 3, 'Techumbre',              'TEC'),
    ( 4, 'Revestimiento exterior', 'REX'),
    ( 5, 'Revestimiento interior', 'RIN'),
    ( 6, 'Cerámicas',              'CER'),
    ( 7, 'Puertas',                'PUE'),
    ( 8, 'Ventanas',               'VEN'),
    ( 9, 'Molduras',               'MOL'),
    (10, 'Pinturas',               'PIN'),
    (11, 'Sala de baño',           'BAN'),
    (12, 'Canales',                'CAN'),
    (13, 'Gasfitería',             'GAS'),
    (14, 'Red de gas',             'RGA'),
    (15, 'Terminaciones',          'TER'),
    (16, 'Otros',                  'OTR');

-- -----------------------------------------------------------------------------
-- Seguridad (RNF-02)
--
-- La aplicación se conecta con el usuario limitado app_riobravo, nunca con postgres.
-- Aquí se crea SIN contraseña (NOLOGIN). La contraseña se asigna aparte, a mano,
-- en el SQL Editor de Supabase (no se guarda en git):
--     ALTER ROLE app_riobravo WITH LOGIN PASSWORD 'una-clave-larga-y-aleatoria';
-- -----------------------------------------------------------------------------

DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'app_riobravo') THEN
        CREATE ROLE app_riobravo NOLOGIN;
    END IF;
END $$;

GRANT USAGE ON SCHEMA public TO app_riobravo;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO app_riobravo;

-- Maestros y encabezados: se crean y editan (se desactivan con "activo"), no se borran.
GRANT SELECT, INSERT, UPDATE ON usuario, proveedor, cliente, categoria, obra, orden_compra, solicitud, venta
    TO app_riobravo;

-- Líneas editables mientras el documento está en borrador.
GRANT SELECT, INSERT, UPDATE, DELETE ON detalle_orden, detalle_solicitud TO app_riobravo;

-- Despachos y líneas de venta son definitivos: solo se registran (una venta se anula con su estado).
GRANT SELECT, INSERT ON despacho, detalle_despacho, detalle_venta TO app_riobravo;

-- Material: la app nunca escribe stock_actual (lo hace solo el trigger, RN-05).
GRANT SELECT ON material TO app_riobravo;
GRANT INSERT (codigo, nombre, descripcion, unidad_medida, id_categoria, stock_minimo, precio_unitario, activo),
      UPDATE (codigo, nombre, descripcion, unidad_medida, id_categoria, stock_minimo, precio_unitario, activo)
    ON material TO app_riobravo;

-- Kardex: solo inserción (RN-09).
GRANT SELECT, INSERT ON movimiento_inventario TO app_riobravo;
GRANT SELECT ON v_saldo_solicitud TO app_riobravo;

-- Row Level Security activado en todas las tablas: solo app_riobravo tiene acceso
-- (postgres, dueño de las tablas, y las funciones SECURITY DEFINER no se ven afectados).
DO $$
DECLARE t TEXT;
BEGIN
    FOREACH t IN ARRAY ARRAY['usuario', 'proveedor', 'cliente', 'categoria', 'material', 'obra',
                             'orden_compra', 'detalle_orden', 'solicitud', 'detalle_solicitud',
                             'despacho', 'detalle_despacho', 'venta', 'detalle_venta', 'movimiento_inventario']
    LOOP
        EXECUTE format('ALTER TABLE %I ENABLE ROW LEVEL SECURITY', t);
        EXECUTE format('CREATE POLICY app_riobravo_acceso ON %I TO app_riobravo USING (true) WITH CHECK (true)', t);
    END LOOP;
END $$;

-- La vista se evalúa con los permisos y RLS de quien consulta, no del dueño.
ALTER VIEW v_saldo_solicitud SET (security_invoker = true);

-- Las funciones de trigger no se llaman directamente (los triggers se ejecutan igual sin EXECUTE).
-- PostgreSQL da EXECUTE a PUBLIC por defecto: se quita para que la API de Supabase no las exponga.
REVOKE EXECUTE ON FUNCTION fn_aplicar_movimiento(), fn_movimiento_inmutable() FROM PUBLIC;

-- Supabase expone el esquema public por su API REST a los roles anon/authenticated.
-- Este sistema no usa esa API: se les quita todo acceso, también a tablas futuras.
DO $$
BEGIN
    IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'anon') THEN
        REVOKE ALL ON ALL TABLES    IN SCHEMA public FROM anon, authenticated;
        REVOKE ALL ON ALL SEQUENCES IN SCHEMA public FROM anon, authenticated;
        REVOKE ALL ON ALL FUNCTIONS IN SCHEMA public FROM anon, authenticated;
        ALTER DEFAULT PRIVILEGES IN SCHEMA public REVOKE ALL ON TABLES    FROM anon, authenticated;
        ALTER DEFAULT PRIVILEGES IN SCHEMA public REVOKE ALL ON SEQUENCES FROM anon, authenticated;
        ALTER DEFAULT PRIVILEGES IN SCHEMA public REVOKE ALL ON FUNCTIONS FROM anon, authenticated;
    END IF;
END $$;

COMMIT;
