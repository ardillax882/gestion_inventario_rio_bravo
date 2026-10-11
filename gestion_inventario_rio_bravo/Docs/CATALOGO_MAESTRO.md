# Catálogo maestro de materiales — PROPUESTA PARA REVISIÓN

> **Estado:** borrador generado a partir de las 9 planillas de `Docs/` (2026-10-11). **No está cargado en la base de datos.**
> Se carga solo cuando el responsable lo apruebe (REQUERIMIENTOS.md §8.4).

- 270 nombres distintos en las planillas (290 si se distinguen mayúsculas, tildes y espacios) → **231 materiales** después de unir duplicados y variantes con errores de tipeo.
- **40 materiales marcados [REVISAR]**: la unidad o el significado no se puede deducir de las planillas. Necesitan tu respuesta.
- **Código:** prefijo de la categoría + correlativo (`RAD-001`). Se asigna en orden alfabético dentro de cada categoría.
- **Categoría:** la sección donde más aparece el material. Si aparece en otras, se indica en Observaciones; en la planilla se puede usar en cualquier sección (RN-10).
- **Unidad:** una de las permitidas: `un, kg, m, m2, rollo, caja, saco, barra, plancha, litro, galón, tarro, tineta, juego, kit`.
- **Aparece en:** planillas donde figura (nombre del archivo; "Trankura" es la casa Trancura). "Milahue (borrador)" es la hoja extra "Hoja1" de esa planilla.

## Cómo revisarlo

1. Corrige directamente en este archivo: nombre, unidad o categoría. Para mover un material de categoría, corta la fila y pégala en la otra tabla (el código se recalcula al cargar).
2. Responde los **[REVISAR]**: reemplaza la observación por la respuesta o borra la marca si está bien.
3. Si dos filas son el mismo material, deja una y anota en Observaciones "unir con …". Si falta un material, agrega una fila sin código.
4. Avisa cuando esté listo: se genera el script de carga (`Database/catalogo_inicial.sql`) desde este archivo.

## Resumen por categoría

| Categoría | Prefijo | Materiales | [REVISAR] |
|---|---|--:|--:|
| Radier | RAD | 11 | 4 |
| Maderas | MAD | 8 | 0 |
| Techumbre | TEC | 13 | 3 |
| Revestimiento exterior | REX | 21 | 4 |
| Revestimiento interior | RIN | 16 | 1 |
| Cerámicas | CER | 12 | 5 |
| Puertas | PUE | 22 | 5 |
| Ventanas | VEN | 12 | 0 |
| Molduras | MOL | 7 | 1 |
| Pinturas | PIN | 10 | 3 |
| Sala de baño | BAN | 29 | 1 |
| Canales | CAN | 14 | 2 |
| Gasfitería | GAS | 14 | 1 |
| Red de gas | RGA | 18 | 3 |
| Terminaciones | TER | 18 | 5 |
| Otros | OTR | 6 | 2 |
| **Total** | | **231** | **40** |

## RAD · Radier

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| RAD-001 | Alambre negro | kg | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Alambre negro |  |
| RAD-002 | Cadena 8 mm | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cadenas 8 mm | Cadena de fierro armada. |
| RAD-003 | Cemento | saco | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cemento |  |
| RAD-004 | Disco de corte | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Discos de corte | También en Techumbre. |
| RAD-005 | Fierro 6 mm | barra | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Fierro 6 mm | También se pide en Terminaciones. |
| RAD-006 | Fierro 8 mm | barra | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Fierro 8 mm |  |
| RAD-007 | Planta de alcantarillado | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | planta de alcantaril · planta de alcantarillado | ¿Qué es exactamente? [REVISAR] |
| RAD-008 | Polietileno | rollo | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Polietileno (rollo) | Una planilla indica "25 Mts": ¿rollo de 25 m? [REVISAR] |
| RAD-009 | Sika (aditivo) | litro | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Sika (litros) | Se pide en litros (60). ¿Qué producto Sika exacto? [REVISAR] |
| RAD-010 | Tapa 1x4 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tapa 1x4 | Tabla para moldaje. |
| RAD-011 | Tornillo 2" | caja | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornilllos 2" | Original "Tornilllos" (con error). Cantidad 3: ¿cajas o unidades? [REVISAR] |

## MAD · Maderas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| MAD-001 | Clavo 2,5" | kg | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Clavos 2,5" |  |
| MAD-002 | Clavo 4" | kg | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Clavo de 4" | También en Radier. |
| MAD-003 | Fieltro 10/40 | rollo | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Fieltro 10/40 | También en Revestimiento exterior. |
| MAD-004 | Grampa | kg | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Grampas Kg |  |
| MAD-005 | Pino 1x4 3,2 m | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pino 1x4 3,2 mt |  |
| MAD-006 | Pino 2x2 | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pino 2x2 | También en Radier. |
| MAD-007 | Pino 2x3 | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pino 2x3 |  |
| MAD-008 | Pino 2x4 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pino 2x4 |  |

## TEC · Techumbre

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| TEC-001 | Alambre galvanizado | kg | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Alambre galvanizado |  |
| TEC-002 | Caballete | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Caballete · Caballete 0,50x3,00 | Una planilla indica medida 0,50 x 3,00 m. |
| TEC-003 | Canal corta fuego | un | 2: Bodega CF, Castaño | Canal corta fuego · Canal Corta Fuego | En la planilla dice "hacer": se fabrica a medida. [REVISAR] |
| TEC-004 | Canal limahoya | un | 1: Roble CF | Canal Limahoya | En la planilla dice "hacerla": se fabrica a medida. [REVISAR] |
| TEC-005 | Corchete | caja | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Corchetes · Corchetes caja | Se pide en cajas ("2 cajas"). También en Revestimiento exterior e interior. |
| TEC-006 | Fieltro 15/40 | rollo | 8: Bodega CF, Castaño, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Fieltro 15/40 |  |
| TEC-007 | Lata en L | un | 7: Castaño, Larqui, Libuy, Libuy 2, Roble, Roble CF, Trankura | Lata    L | Original "Lata    L". [REVISAR] |
| TEC-008 | Limahoya | un | 6: Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF | Limahoya |  |
| TEC-009 | Membrana | rollo | 1: Larqui | Membrana |  |
| TEC-010 | Silicona hojalatera | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Silicona hojalatera |  |
| TEC-011 | Tornillo techo | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornillos techo · Tornillos techo 2 1/2" | Una planilla indica 2 1/2". También en Terminaciones. |
| TEC-012 | Zinc tipo teja 3,00 m | plancha | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Zinc 3.00 · Zinc tipo teja 3,00 |  |
| TEC-013 | Zinc tipo teja 3,66 m | plancha | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Zinc tipo teja 3.66 |  |

## REX · Revestimiento exterior

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| REX-001 | Alféizar | un | 7: Castaño, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Alfizer · alfizer | Original "alfizer". |
| REX-002 | Cortagotera ventana | un | 1: Larqui | Corta gotera Ventanas |  |
| REX-003 | Esquinero siding | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Esquineros |  |
| REX-004 | Inicio siding | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Inicios | Original "Inicios". ¿Perfil de inicio para siding? [REVISAR] |
| REX-005 | Perfil Metalcon | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Metalcom | Original "Metalcom". ¿Qué perfil/medida? [REVISAR] |
| REX-006 | Permanit 4 mm | plancha | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Permanit 4mm · Planchas Permanit 4mm | También en Terminaciones. |
| REX-007 | Perno de anclaje | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pernos de Anclaje · pernos de anclaje · Pernos de anclaje |  |
| REX-008 | Pintura anticorrosiva | galón | 1: Larqui | Pintura anticorrosiva | Unidad supuesta. [REVISAR] |
| REX-009 | Placa OSB | plancha | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Placa osb · Placas Osb | También en Revestimiento interior. |
| REX-010 | Poste metálico 100x100 mm | un | 4: Castaño, Larqui, Roble, Roble CF | Poste 100mm · Poste 100x100 · Poste de 100 x 100mm |  |
| REX-011 | Poste metálico 75x75 mm | un | 7: Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Poste · Poste 75 · Poste 75mm · Poste de 75 x 75mm · Poste de 75mm · Poste Metalico 2=100 2=75 | Incluye "Poste" sin medida y "Poste Metalico 2=100 2=75" (2 de cada medida). [REVISAR] |
| REX-012 | Siding | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Siding |  |
| REX-013 | Silicona pintable | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Silicona pintable |  |
| REX-014 | Smart Panel | plancha | 4: Bodega CF, Castaño, Roble CF, Trankura | Smart panel · Smart Panel |  |
| REX-015 | Tapacán 1x8 | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tacacan 1x8 | Original "Tacacan". |
| REX-016 | Taparregla 1x4 | un | 1: Bodega CF | Taparegla 1x4 |  |
| REX-017 | Taparregla 1x5 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Taparegla 1x5 |  |
| REX-018 | Taparregla 1x6 | un | 5: Castaño, Milahue, Roble, Roble CF, Trankura | Taparegla 1x6 |  |
| REX-019 | Taparregla 1x7 | un | 3: Larqui, Libuy, Libuy 2 | Taparegla 1x7 |  |
| REX-020 | Tornillo siding | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornillo Siding |  |
| REX-021 | Viga cepillada 2x6 | un | 1: Trankura | Viga cepillada 2x6 |  |

## RIN · Revestimiento interior

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| RIN-001 | Aislapol | plancha | 1: Castaño | Aislapol |  |
| RIN-002 | Clavo verde | kg | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Clavo verde | Se pide "1 kg". |
| RIN-003 | Huincha americana | rollo | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Huincha americana |  |
| RIN-004 | Lana de vidrio | rollo | 2: Libuy 2, Milahue | Lana de vidrio · Lana de vidrio rollo |  |
| RIN-005 | Lana mineral | rollo | 6: Castaño, Larqui, Libuy, Roble, Roble CF, Trankura | Lana Mineral |  |
| RIN-006 | Lija | un | 6: Castaño, Larqui, Libuy, Libuy 2, Milahue, Trankura | Lija · Lijas · lijas | Sin grano indicado. [REVISAR] |
| RIN-007 | Pasta muro | tineta | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pasta muro tineta |  |
| RIN-008 | Permanit 6 mm | plancha | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Permanit 6 mm |  |
| RIN-009 | Tornillo 1 5/8" | un | 1: Bodega CF | tornillos 1 5/8 |  |
| RIN-010 | Tornillo volcanita | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornillos volcanita |  |
| RIN-011 | Tornillo volcanita cielo | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornillo volcanita cielo |  |
| RIN-012 | Tornillo volcanita hilo fino | un | 1: Bodega CF | tornillos hilo fino |  |
| RIN-013 | Traje desechable | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Traje desechable |  |
| RIN-014 | Volcanita | plancha | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Volcanita |  |
| RIN-015 | Volcanita RH | plancha | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Volcanita RH |  |
| RIN-016 | Yeso | saco | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Yeso | Se pide "1 saco". |

## CER · Cerámicas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| CER-001 | Adhesivo cerámico | saco | 1: Bodega CF | adesivo ceramico | Original "adesivo". |
| CER-002 | Bekron AC | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Beckron ac | Original "Beckron ac". ¿Formato? [REVISAR] |
| CER-003 | Bekron polvo | saco | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Beckron polvo | Original "Beckron". Cantidad 25: ¿sacos o kg? [REVISAR] |
| CER-004 | Cerámica muro | caja | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Ceramica muro | ¿Cajas o m²? [REVISAR] |
| CER-005 | Cerámica piso | caja | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | cajas ceramica · Ceramica piso | Cantidad 32 en casa de 68 m²: ¿cajas o m²? Incluye "cajas ceramica" de Bodega CF. [REVISAR] |
| CER-006 | Cerámica piso baño | caja | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Ceramica piso baño | ¿Cajas o m²? [REVISAR] |
| CER-007 | Espaciador cerámica 3 mm | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Espaciadores 3mm |  |
| CER-008 | Espaciador cerámica 4 mm | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Espaciadores 4mm |  |
| CER-009 | Fragüe blanco | kg | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Frague blanco |  |
| CER-010 | Fragüe café | kg | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Frague Café · Frague café |  |
| CER-011 | Fragüe gris | kg | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Frague gris |  |
| CER-012 | Moldura ventana baño | m | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Moldura ventana baño | Se pide 1,5. |

## PUE · Puertas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| PUE-001 | Bisagra 3,5x3,5" | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Bisagras de 3,5 x 3,5 · juego bisagras 3,5x 3,5 | Una planilla la pide por juego. [REVISAR] |
| PUE-002 | Bisagra 3x3" | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Bisagra 3x3 · Bisagras 3x3 | También en Terminaciones. |
| PUE-003 | Cerradura baño | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cerradura baño |  |
| PUE-004 | Cerradura dormitorio | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cerradura dormitorio |  |
| PUE-005 | Cerradura escape con manilla | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cerradura esc. manilla | Original "Cerradura esc. manilla": ¿"esc." = escape? [REVISAR] |
| PUE-006 | Cerradura parche | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Cerradura Parche |  |
| PUE-007 | Chapa puerta acceso | un | 1: Bodega CF | Chapa Acceso |  |
| PUE-008 | Llavero con nombre | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Llavero con nombre |  |
| PUE-009 | Marco puerta 4,5" | un | 5: Castaño, Larqui, Libuy, Milahue, Trankura | Marcos puertas 4,5" |  |
| PUE-010 | Marco puerta 5" | un | 4: Bodega CF, Libuy 2, Roble, Roble CF | marco puerta · Marcos puertas 5" | Incluye "marco puerta" sin medida. [REVISAR] |
| PUE-011 | Marco puerta 6" | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Marcos puertas 6" |  |
| PUE-012 | Perillón | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Perillon |  |
| PUE-013 | Puerta acceso 85 cm | un | 4: Bodega CF, Larqui, Milahue, Trankura | puerta acceso 85 · Puerta acceso 85 |  |
| PUE-014 | Puerta acceso 90 cm | un | 5: Castaño, Libuy, Libuy 2, Roble, Roble CF | Puerta acceso · Puerta acceso 90 | Incluye "Puerta acceso" sin medida. [REVISAR] |
| PUE-015 | Puerta escape 80 cm | un | 4: Castaño, Larqui, Milahue, Trankura | Puerta escape · Puerta escape 80 | Incluye "Puerta escape" sin medida. [REVISAR] |
| PUE-016 | Puerta escape 85 cm | un | 2: Roble, Roble CF | Puerta escape 85 |  |
| PUE-017 | Puerta escape 90 cm | un | 2: Libuy, Libuy 2 | Puerta escape 90 |  |
| PUE-018 | Puerta terciado 70 cm | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Puerta terciado 70cm |  |
| PUE-019 | Puerta terciado 90 cm | un | 2: Libuy, Libuy 2 | Puerta terciado 90cm |  |
| PUE-020 | Tope puerta goma | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tope Goma · Topes de puerta · Topes de puerta goma |  |
| PUE-021 | Tope puerta largo | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tope puerta largo |  |
| PUE-022 | Tornillo 3" | caja | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornillos 3" | Se pide "1 caja". |

## VEN · Ventanas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| VEN-001 | Ventana 40x170 cm | un | 4: Larqui, Milahue, Roble, Roble CF | Ventana 40x170 |  |
| VEN-002 | Ventana 40x180 cm | un | 2: Libuy, Libuy 2 | Ventana 40x180 |  |
| VEN-003 | Ventana 60x60 cm | un | 4: Larqui, Milahue, Roble, Roble CF | Ventana 60x60 |  |
| VEN-004 | Ventana 80x80 cm | un | 2: Libuy, Libuy 2 | Ventana 80x80 |  |
| VEN-005 | Ventana 100x100 cm | un | 1: Larqui | Ventana 100x100 |  |
| VEN-006 | Ventana 120x100 cm | un | 4: Libuy, Libuy 2, Roble, Roble CF | Ventana 120x100 |  |
| VEN-007 | Ventana 130x130 cm | un | 3: Larqui, Roble, Roble CF | Ventana 130x130 |  |
| VEN-008 | Ventana 130x170 cm | un | 2: Roble, Roble CF | Ventana 130x170 |  |
| VEN-009 | Ventana 140x130 cm | un | 1: Libuy 2 | Ventana 140x130 |  |
| VEN-010 | Ventana 140x140 cm | un | 2: Libuy, Libuy 2 | Ventana 140x140 |  |
| VEN-011 | Ventana 160x130 cm | un | 1: Larqui | Ventana 160x130 |  |
| VEN-012 | Ventana 160x170 cm | un | 2: Libuy, Libuy 2 | Ventana 160x170 |  |

## MOL · Molduras

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| MOL-001 | Adhesivo de montaje | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Adhesivo Montaje |  |
| MOL-002 | Barniz marino natural | galón | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Barniz marino natural | Unidad supuesta. [REVISAR] |
| MOL-003 | Espuma de poliuretano | tarro | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Espuma de Poliuretano · Espuma Poliuretano · Espuma poliuretano | Se pide "1 grande". |
| MOL-004 | Guardapolvo | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | guardapolvos · Guardapolvos |  |
| MOL-005 | Junquillo | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | junquillos · Junquillos |  |
| MOL-006 | Media caña Plumavit | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Media caña Plumavit |  |
| MOL-007 | Punta 2" | kg | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Puntas 2" (kg) |  |

## PIN · Pinturas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| PIN-001 | Brocha 2" | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Brocha 2" · Brochas 2" |  |
| PIN-002 | Brocha 4" | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Brochas 4" |  |
| PIN-003 | Diluyente | litro | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Diluyente | También en Molduras. Unidad supuesta. [REVISAR] |
| PIN-004 | Óleo | tarro | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Oleo  (galon) · Oleo  (Tarro) | Una planilla lo pide en galón. [REVISAR] |
| PIN-005 | Pintura blanca | galón | 1: Bodega CF | pintura blanca galon |  |
| PIN-006 | Pintura cielo y aleros | tineta | 6: Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF | Pintura Aleros y cielo (tineta) · Pintura cielo y alero (tineta) · Pintura Cielo y alero (tineta) · Pintura cielo y aleros (tineta) · Pintura cielos y aleros (tineta) |  |
| PIN-007 | Pintura exterior | tineta | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pintura Exterior · Pintura exterior (tineta) |  |
| PIN-008 | Pintura interior | tineta | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pintura Interior (tineta) |  |
| PIN-009 | Rodillo 18 cm pelo largo | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Rodillo · Rodillos  18 cm p largo |  |
| PIN-010 | Waterproof Princesa | galón | 4: Larqui, Libuy 2, Roble, Roble CF | Waterprooff princesa | Original "Waterprooff". Unidad supuesta. [REVISAR] |

## BAN · Sala de baño

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| BAN-001 | Atril metálico lavadero | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Atril Lavadero · Atril lavadero · Atril Lavaropas · Atril metalico Lavadero |  |
| BAN-002 | Base metálica lavaplatos | un | 2: Libuy, Libuy 2 | base metalica lavaplatos |  |
| BAN-003 | Desagüe lavamanos | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Desague lavamanos |  |
| BAN-004 | Desagüe lavaplatos | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Desague lavaplato |  |
| BAN-005 | Estanque WC | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Estanque |  |
| BAN-006 | Estanque WC discapacitado | un | 2: Libuy, Libuy 2 | Estanque discapacitado |  |
| BAN-007 | Flexible HI-HI | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Flexibles hi-hi |  |
| BAN-008 | Kit instalación WC | kit | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Kit istalacion wc | Original "istalacion". |
| BAN-009 | Lavadero | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Lava ropas | Original "Lava ropas". [REVISAR] |
| BAN-010 | Lavamanos | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Lavamanos |  |
| BAN-011 | Lavamanos discapacitado | un | 2: Libuy, Libuy 2 | Lavamanos discapacitado |  |
| BAN-012 | Lavaplatos | un | 7: Castaño, Larqui, Libuy 2, Milahue, Roble, Roble CF, Trankura | Lavaplato |  |
| BAN-013 | Lavaplatos secador izquierdo | un | 1: Libuy | Lavaplato sec izquierdo |  |
| BAN-014 | Llave combinación | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Llave combinacion |  |
| BAN-015 | Llave combinación discapacitado | un | 2: Libuy, Libuy 2 | Llave combinacion discapacitado |  |
| BAN-016 | Llave lavamanos discapacitado | un | 2: Libuy, Libuy 2 | Llave lavamanos discapacitado · Llave lavamanos Discapacitado |  |
| BAN-017 | Monoblock lavamanos | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Monoblock lavamanos |  |
| BAN-018 | Monoblock tina-ducha | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Monoblock tina-ducha |  |
| BAN-019 | Mueble lavaplatos | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Mueble lavaplato |  |
| BAN-020 | Pasamanos abatible | un | 2: Libuy, Libuy 2 | Pasamano abatible | Para baño de discapacitado. |
| BAN-021 | Pasamanos fijo | un | 1: Libuy 2 | Pasamanos fijo | Para baño de discapacitado. |
| BAN-022 | Pedestal lavamanos | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Pedestal |  |
| BAN-023 | Sifón lavamanos | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Sifon lavatorio |  |
| BAN-024 | Sifón lavamanos especial | un | 1: Libuy | Sifon lavatorio especial |  |
| BAN-025 | Sifón lavaplatos | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Sifon lavaplato |  |
| BAN-026 | Silicona baño y cocina | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Silicona baño y cocina |  |
| BAN-027 | Tapa WC | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tapa WC · tapa wc |  |
| BAN-028 | WC | un | 6: Castaño, Larqui, Milahue, Roble, Roble CF, Trankura | Wc |  |
| BAN-029 | WC discapacitado | un | 2: Libuy, Libuy 2 | Wc discapacitado · WC discapacitado |  |

## CAN · Canales

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| CAN-001 | Abrazadera bajada | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Abrazadera bajada · abrazaderas · Abrazaderas |  |
| CAN-002 | Boquilla canal | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | boquillas |  |
| CAN-003 | Canal PVC Vinilit | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | canales | Original "canales" dentro de la sección Canales. |
| CAN-004 | Celosía | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | celocia baño · Celosias | Incluye "celocia baño". |
| CAN-005 | Celosía puerta | un | 6: Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF | Celosia de puerta |  |
| CAN-006 | Codo bajada | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | codos · Codos bajada · curvas | Incluye "codos" y "curvas". |
| CAN-007 | Esquinero canal | un | 7: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF | esquineros |  |
| CAN-008 | Gancho canal | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | ganchos |  |
| CAN-009 | Sistema Vinilit tradicional | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | vinilit normal · Vinilit tradicional | ¿Es la línea/modelo de canal o un producto aparte? [REVISAR] |
| CAN-010 | Tapa canal | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | tapas |  |
| CAN-011 | Tornillo 1" | caja | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tornilos 1" | Original "Tornilos". ¿Caja o unidades? [REVISAR] |
| CAN-012 | Tubo bajada | un | 9: Bodega CF, Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | tubos |  |
| CAN-013 | Unión canal | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | union |  |
| CAN-014 | Ventilación pasiva | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Extractor pasivo · Ventilacion pasiva | Incluye "Extractor pasivo". |

## GAS · Gasfitería

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| GAS-001 | Cañería cobre tipo M | barra | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Cobre tipo M | ¿Barra de 6 m o metros? [REVISAR] |
| GAS-002 | Codo cobre SO-SO | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Codo So-So | También en Red de gas. |
| GAS-003 | Codo HE | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Codo HE | También en Red de gas. |
| GAS-004 | Codo HI | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Codo HI |  |
| GAS-005 | Gas butano (cartucho) | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Gas Butano |  |
| GAS-006 | Lija grano 100 | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Lija de 100gr | Original "Lija de 100gr". |
| GAS-007 | Llave de bola | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Llave de bola |  |
| GAS-008 | Llave de paso campana | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Llave de paso campana |  |
| GAS-009 | Llave de paso corriente | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Llave de paso corriente |  |
| GAS-010 | Pasta de soldar | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Pasta de soldar |  |
| GAS-011 | Silicona alta temperatura | un | 1: Castaño | Silicona alta teperatura | Original "teperatura". |
| GAS-012 | Soldadura de estaño | rollo | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Rollo de estaño |  |
| GAS-013 | Tee cobre SO-SO | un | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Tee So-So | También en Red de gas. |
| GAS-014 | Teflón blanco | rollo | 6: Larqui, Libuy 2, Milahue, Milahue (borrador), Roble, Roble CF | Teflon Blanco |  |

## RGA · Red de gas

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| RGA-001 | Abrazadera cañería | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Abrazadera |  |
| RGA-002 | Calefón | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Calefont | Original "Calefont". |
| RGA-003 | Cañería cobre tipo L | barra | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Cobre tipo L | ¿Barra de 6 m o metros? [REVISAR] |
| RGA-004 | Cola con tuerca | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Cola con tuerca |  |
| RGA-005 | Flexible de gas | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Flexible |  |
| RGA-006 | Fundente | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Fundente |  |
| RGA-007 | Kit de calefón | kit | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Kit de calefont |  |
| RGA-008 | Llave de paso gas | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Llave de paso de gas |  |
| RGA-009 | Red de gas (instalación completa) | un | 3: Castaño, Libuy, Trankura | Red de gas | En Libuy, Trancura y Castaño aparece una línea "Red de gas" con cantidad 1. ¿Es un ítem o un servicio? [REVISAR] |
| RGA-010 | Regulador de gas | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Regulador |  |
| RGA-011 | Soldadura de plata | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Soldadura de plata | ¿Varilla? [REVISAR] |
| RGA-012 | Tapa HE | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Tapa HE |  |
| RGA-013 | Tapa HI | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Tapa HI |  |
| RGA-014 | Tarugo 6 mm | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Tarugo 6mm |  |
| RGA-015 | Tee HI | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Tee HI |  |
| RGA-016 | Teflón de gas | rollo | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Teflon de gas |  |
| RGA-017 | Terminal HE | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Terminal HE |  |
| RGA-018 | Terminal HI | un | 5: Larqui, Libuy 2, Milahue, Roble, Roble CF | Terminal HI |  |

## TER · Terminaciones

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| TER-001 | Anillo 10 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Anillo 10 | [REVISAR] |
| TER-002 | Dren | m | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Dren (mt) |  |
| TER-003 | Estanque de agua | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Estanque | En Terminaciones "Estanque" no es del WC: ¿estanque de agua? [REVISAR] |
| TER-004 | Fosa séptica | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Fosa |  |
| TER-005 | Kit pozo | kit | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Kit pozo | Cantidad "variable": se define al despachar. |
| TER-006 | Marco cuadrado | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Marco cuadrado |  |
| TER-007 | Módulo cámara 60x30 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Modulo 60x30 | ¿Módulo de cámara de inspección? [REVISAR] |
| TER-008 | Módulo cámara 60x60 | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Modulo 60x60 | ¿Módulo de cámara de inspección? [REVISAR] |
| TER-009 | Pino 2x2 blanco | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | 2x2 blanco | Original "2x2 blanco". [REVISAR] |
| TER-010 | Portacandado | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Portacandado |  |
| TER-011 | Tapa cuadrada | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tapa cuadrada |  |
| TER-012 | Tapa redonda | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tapas redonda |  |
| TER-013 | Tee PVC 110 a 75 mm | un | 1: Larqui | Tee 110 a 75 |  |
| TER-014 | Tee PVC 75 a 50 mm | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Tee 75 a 50 |  |
| TER-015 | Tubo PVC 110 mm | un | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pvc 110 |  |
| TER-016 | Tubo PVC 20 mm | m | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Pvc 20 | Cantidad "variable": se define al despachar. |
| TER-017 | Zinc 2,5 m | plancha | 8: Castaño, Larqui, Libuy, Libuy 2, Milahue, Roble, Roble CF, Trankura | Zinc 2,5 mt |  |
| TER-018 | Zinc en V | un | 4: Larqui, Milahue, Roble, Roble CF | Zinc en V |  |

## OTR · Otros

| Código | Nombre | Unidad | Aparece en | Nombres originales | Observaciones |
|---|---|---|---|---|---|
| OTR-001 | Gasfitería (ítem general) | un | 2: Castaño, Trankura | Gasfitería | Línea "Gasfitería" con cantidad 1 en la sección sin título (Libuy la tiene sin cantidad). ¿Qué incluye? [REVISAR] |
| OTR-002 | Gorro extractor | un | 3: Castaño, Larqui, Milahue | Gorro extractor · Gorro Extractor | Venía en secciones sin título. |
| OTR-003 | Pasamanos exterior | un | 2: Libuy, Libuy 2 | Pasamanos exterior | Venía en secciones sin título. |
| OTR-004 | Pasamanos interior | un | 1: Libuy | Pasamanos interiores | Venía en secciones sin título. |
| OTR-005 | Tubería eléctrica | un | 6: Castaño, Larqui, Libuy, Libuy 2, Milahue, Trankura | Tuberia eléctrica | Venía en secciones sin título. ¿Unidad (rollo, m)? [REVISAR] |
| OTR-006 | Tubo extractor | un | 3: Castaño, Larqui, Milahue | tubo extractor · Tubos extractores | Venía en secciones sin título. |

## Notas de la estandarización

- Se corrigieron tipeos ("Tornilllos", "Waterprooff", "istalacion", "adesivo", "teperatura", "Tacacan", "alfizer", "Metalcom", "Beckron", "Calefont") y se quitó la unidad del nombre ("Sika (litros)", "Polietileno (rollo)", "Puntas 2\" (kg)", "Pasta muro tineta").
- Los nombres en plural pasaron a singular y las medidas se escriben igual en todo el catálogo (`3,2 m`, `75x75 mm`, `4"`).
- "Esquineros" y "Estanque" se separaron según la sección: el esquinero de siding no es el de canal, y el estanque de Terminaciones no es el del WC.
- Las ventanas pasaron a ser un material por medida (`Ventana 130x130 cm`). Se supuso que las medidas están en centímetros. [REVISAR]
- La sección **sin título** de Libuy, Trancura y Castaño está justo antes de Revestimiento interno y trae Gasfitería, Tubería eléctrica y extractores: parecen **instalaciones embutidas antes de revestir**. Se dejaron en "Otros"; ¿conviene una categoría "Instalaciones"? [REVISAR]
- Cantidades no numéricas ("variable", "hacer", "1 grande") no forman parte del catálogo; se ingresan en cada solicitud.
- Precio unitario y stock mínimo quedan en 0. Se completan después desde la pantalla Materiales o con la primera compra.
