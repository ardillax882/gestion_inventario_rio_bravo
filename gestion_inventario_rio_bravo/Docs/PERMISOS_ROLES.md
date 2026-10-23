# Roles y permisos del sistema — Río Bravo

> Documento para el cliente. Explica qué puede hacer cada persona en el sistema de inventario y qué no.
> Versión 1.1 · 2026-10-14 · Refleja el sistema tal como está programado hoy (`Services/Permisos.cs`), con las respuestas del cliente del 2026-10-14.

---

## 1. Los tres roles

Cada persona entra al sistema con su RUT o email y su contraseña. Según su **rol**, el sistema le muestra solo los menús y botones que le corresponden; lo que no le corresponde, simplemente no aparece.

| Rol | ¿Quién es? | En pocas palabras |
|---|---|---|
| **Gerente** | El gerente de Río Bravo | Puede hacer **todo**. Es el único que crea usuarios y obras. |
| **Jefe de Compras** | En la práctica, el contador | Se encarga del **catálogo de materiales y los precios** (y, cuando estén listos, de proveedores y compras). **No mueve stock** en bodega. |
| **Bodeguero** | El encargado de bodega | Registra lo que piden las obras, **lo autoriza o rechaza**, **entrega los materiales**, presta los equipos y registra lo que vuelve. No cambia precios. |

---

## 2. Tabla de permisos

✔ = puede · 👁 = solo puede mirar · ✖ = no puede

### Disponible hoy en el sistema

| Acción | Gerente | Jefe de Compras | Bodeguero |
|---|:-:|:-:|:-:|
| Ver la pantalla de Inicio (resumen de stock, obras y solicitudes) | ✔ | ✔ | ✔ |
| **Usuarios:** crear, editar, desactivar y restablecer contraseñas | ✔ | ✖ | ✖ |
| Cambiar **su propia** contraseña | ✔ | ✔ | ✔ |
| **Obras:** crear y editar (nombre, m², ubicación, maestro, presupuesto, estado) | ✔ | 👁 | 👁 |
| **Materiales:** crear y editar (código, nombre, unidad, categoría, stock mínimo, precio) | ✔ | ✔ | 👁 |
| Ver el stock y el historial de movimientos de cada material | ✔ | ✔ | ✔ |
| **Ajustar stock** (inventario inicial, conteo físico, merma) | ✔ | ✖ | ✔ |
| Registrar **devolución de material sobrante** de una obra | ✔ | ✖ | ✔ |
| **Solicitudes de obra:** crear y modificar mientras están pendientes | ✔ | ✖ | ✔ |
| **Aprobar o rechazar** una solicitud (también el material extra) | ✔ | ✖ | ✔ |
| **Despachar** materiales a una obra (entregas parciales) | ✔ | ✖ | ✔ |
| **Prestar equipos** (trompo, placa compactadora, baño químico) y registrar su vuelta | ✔ | ✖ | ✔ |
| Ver qué equipos están prestados y en qué obra | ✔ | ✔ | ✔ |
| Ver solicitudes e imprimir la planilla y los comprobantes | ✔ | ✔ | ✔ |

### Planificado (todavía no disponible)

| Acción | Gerente | Jefe de Compras | Bodeguero |
|---|:-:|:-:|:-:|
| Proveedores: crear y editar | ✔ | ✔ | 👁 |
| Crear órdenes de compra | ✔ | ✔ | ✖ |
| Recibir en bodega lo comprado, completo o en partes (suma stock) | ✔ | ✖ | ✔ |
| Reportes (stock, costo por obra, compras, equipos prestados) | ✔ | ✔ | ✔ |

Río Bravo **no vende** material a terceros, por eso el sistema no tiene ventas.

---

## 3. Lo que NO puede hacer cada rol

### Jefe de Compras
- ✖ No crea usuarios ni cambia contraseñas de otros.
- ✖ No crea ni modifica obras (solo las ve).
- ✖ No registra solicitudes de obra, no las aprueba, no despacha y no presta equipos.
- ✖ No ajusta el stock. **Ningún movimiento físico de bodega pasa por él**: así quien fija precios no es quien entrega el material.
- ✖ No recibe en bodega las compras (cuando exista ese módulo): las pide, pero las recibe el Bodeguero o el Gerente.

### Bodeguero
- ✖ No crea usuarios ni cambia contraseñas de otros.
- ✖ No crea ni modifica obras (solo las ve).
- ✖ No crea ni edita materiales, ni cambia **precios** o stock mínimo (solo los ve).
- ✖ No crea órdenes de compra (cuando exista ese módulo).

### Gerente
- Puede hacer todo, con dos límites de seguridad:
  - ✖ No puede cambiar su propio rol ni desactivarse a sí mismo.
  - ✖ El sistema no permite dejar la empresa sin al menos un Gerente activo.

---

## 4. Reglas que aplican a todos (nadie puede saltárselas)

Estas reglas las impone el sistema y la base de datos, sin importar el rol:

1. **El stock nunca queda negativo.** No se puede entregar ni ajustar a la baja más de lo que hay en bodega.
2. **Solo se entrega lo aprobado.** Una solicitud se despacha únicamente si está aprobada y la obra está "En ejecución".
3. **No se entrega más de lo pedido.** Cada entrega se descuenta del saldo pendiente de la solicitud.
4. **Una solicitud aprobada ya no se modifica.** Si la obra necesita material extra, se registra una solicitud nueva ("Pedir material extra"), que se vuelve a aprobar.
5. **El historial no se borra.** Cada entrada y salida de stock queda registrada con fecha, hora y usuario, y no se puede editar ni eliminar; los errores se corrigen con un ajuste que también queda registrado, con su motivo.
6. **Nadie escribe el stock a mano.** El stock cambia solo con movimientos (ajustes, despachos, devoluciones y, más adelante, compras).
7. **Todo queda a nombre de quien lo hizo:** quién registró, quién aprobó y quién entregó cada solicitud; quién prestó y quién recibió de vuelta cada equipo.
8. **Precios con IVA, en pesos chilenos.**

---

## 5. Ejemplo: el recorrido de una solicitud

1. La obra pide materiales → el **Bodeguero** (o el Gerente) registra la solicitud en el sistema. Estado: *Pendiente*.
2. El **encargado de bodega** (o el Gerente) la revisa y la **aprueba** (o la rechaza indicando el motivo).
3. El **Bodeguero** entrega los materiales, en una o varias entregas. Cada entrega descuenta stock y se imprime su comprobante, que firma el **maestro jefe de cuadrilla**.
4. Cuando se entregó todo, la solicitud queda *Despachada total*. La planilla impresa muestra todas las entregas con sus fechas.
5. Si la obra necesita más, se pide **material extra** (solicitud nueva, se aprueba de nuevo). Si sobra material, se registra la **devolución** y se descuenta del costo de la obra.

El **Jefe de Compras** no participa en este recorrido, pero puede verlo en todo momento, y mantiene al día el catálogo y los precios con los que se valoriza lo entregado a cada obra.

---

## 6. Preguntas para confirmar con el cliente

| # | Pregunta | Cómo está hoy (provisorio) |
|---|---|---|
| 1 | ¿El Bodeguero debería poder crear materiales nuevos cuando llega algo que no está en el catálogo? | No puede (lo hace el Jefe de Compras o el Gerente) |
| 2 | ¿El Jefe de Compras debería poder registrar o aprobar solicitudes de obra? | No puede |
| 3 | ¿Está bien que el Bodeguero pueda ajustar stock (merma, conteo) sin aprobación del Gerente? | Puede, con motivo obligatorio y registro de quién lo hizo |

Ya respondidas (2026-10-14): aprueba el **encargado de bodega**; **no hay ventas** a terceros.

Cualquier cambio en esta tabla es simple de aplicar: los permisos están centralizados en un solo lugar del sistema.
