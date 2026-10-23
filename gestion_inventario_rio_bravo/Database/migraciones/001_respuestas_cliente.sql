-- =============================================================================
-- Migración 001 · Respuestas del cliente (Docs/Preguntas importantes Rio Bravo.md, 2026-10-14)
--
-- Ejecutar UNA vez en el SQL Editor de Supabase (producción) como postgres.
-- Una BD nueva no la necesita: Database/schema.sql ya incluye estos cambios.
--
--  - Sin ventas a terceros: se eliminan cliente, venta, detalle_venta y SALIDA_VENTA.
--  - Beneficiario (titular del subsidio): RUT y teléfono.
--  - Devoluciones de obra: AJUSTE_ENTRADA con id_obra (AJUSTE_SALIDA no lleva obra).
--  - Equipos prestados (trompo, placa, baño químico): tabla prestamo_equipo.
--  - Categoría "Otros" pasa a "Electricidad" (tubería eléctrica = partida eléctrica).
-- =============================================================================

BEGIN;

-- Seguridad: no borrar ventas si alguien alcanzó a registrar alguna.
DO $$
BEGIN
    IF EXISTS (SELECT 1 FROM venta) OR EXISTS (SELECT 1 FROM cliente)
       OR EXISTS (SELECT 1 FROM movimiento_inventario WHERE tipo = 'SALIDA_VENTA') THEN
        RAISE EXCEPTION 'Hay ventas o clientes registrados: revisar antes de eliminar las tablas.';
    END IF;
END $$;

-- Ventas
ALTER TABLE movimiento_inventario DROP CONSTRAINT IF EXISTS movimiento_inventario_check;
ALTER TABLE movimiento_inventario DROP CONSTRAINT IF EXISTS movimiento_inventario_tipo_check;
ALTER TABLE movimiento_inventario DROP COLUMN id_venta;
DROP TABLE detalle_venta, venta, cliente;

ALTER TABLE movimiento_inventario
    ADD CONSTRAINT movimiento_inventario_tipo_check CHECK (tipo IN
        ('ENTRADA_COMPRA', 'SALIDA_DESPACHO', 'AJUSTE_ENTRADA', 'AJUSTE_SALIDA')),
    ADD CONSTRAINT movimiento_inventario_origen_check CHECK (
        (tipo = 'ENTRADA_COMPRA'  AND id_orden    IS NOT NULL AND id_despacho IS NULL) OR
        (tipo = 'SALIDA_DESPACHO' AND id_despacho IS NOT NULL AND id_obra IS NOT NULL AND id_orden IS NULL) OR
        (tipo = 'AJUSTE_ENTRADA'  AND motivo IS NOT NULL AND id_orden IS NULL AND id_despacho IS NULL) OR
        (tipo = 'AJUSTE_SALIDA'   AND motivo IS NOT NULL AND id_orden IS NULL AND id_despacho IS NULL AND id_obra IS NULL)
    );

-- Beneficiario
ALTER TABLE obra
    ADD COLUMN beneficiario_rut      VARCHAR(12),
    ADD COLUMN beneficiario_telefono VARCHAR(20);

-- Equipos prestados
CREATE TABLE prestamo_equipo (
    id_prestamo          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    equipo               VARCHAR(10)  NOT NULL CHECK (equipo IN ('Trompo', 'Placa', 'Bano')),
    id_obra              INT          NOT NULL REFERENCES obra,
    id_usuario           INT          NOT NULL REFERENCES usuario,
    fecha_prestamo       TIMESTAMP    NOT NULL DEFAULT now(),
    id_usuario_devuelve  INT          REFERENCES usuario,
    fecha_devolucion     TIMESTAMP,
    observaciones        VARCHAR(200),
    CHECK ((fecha_devolucion IS NULL) = (id_usuario_devuelve IS NULL)),
    CHECK (fecha_devolucion IS NULL OR fecha_devolucion >= fecha_prestamo)
);
GRANT SELECT, INSERT, UPDATE ON prestamo_equipo TO app_riobravo;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO app_riobravo;
ALTER TABLE prestamo_equipo ENABLE ROW LEVEL SECURITY;
CREATE POLICY app_riobravo_acceso ON prestamo_equipo TO app_riobravo USING (true) WITH CHECK (true);
DO $$
BEGIN
    IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'anon') THEN
        REVOKE ALL ON prestamo_equipo FROM anon, authenticated;
    END IF;
END $$;

-- Categoría
UPDATE categoria SET nombre = 'Electricidad', prefijo = 'ELE' WHERE prefijo = 'OTR';

COMMIT;
