namespace gestion_inventario_rio_bravo.Models
{
    /// <summary>Sección del formulario estandarizado (§8.3). Se ordenan por Orden.</summary>
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Prefijo { get; set; }
        public int Orden { get; set; }

        public override string ToString() => Nombre;
    }

    public class Material
    {
        /// <summary>Unidades permitidas (§8.4); coinciden con el CHECK de material.unidad_medida.</summary>
        public static readonly string[] Unidades =
            { "un", "kg", "m", "m2", "rollo", "caja", "saco", "barra", "plancha", "litro", "galón", "tarro", "tineta", "juego", "kit" };

        public int IdMaterial { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; } = "un";
        public int? IdCategoria { get; set; }
        public string CategoriaNombre { get; set; }
        public decimal StockActual { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Activo { get; set; } = true;

        /// <summary>Alerta RF-07; solo aplica si se definió un stock mínimo.</summary>
        public bool BajoMinimo => StockMinimo > 0 && StockActual <= StockMinimo;
        public string CodigoNombre => Codigo + " - " + Nombre;

        public override string ToString() => CodigoNombre;
    }

    /// <summary>Tipos de movimiento de un ajuste manual (RF-24).</summary>
    public enum TipoAjuste
    {
        AJUSTE_ENTRADA,
        AJUSTE_SALIDA
    }

    /// <summary>Una fila del kardex (RF-25).</summary>
    public class Movimiento
    {
        public System.DateTime FechaHora { get; set; }
        public string Tipo { get; set; }
        public decimal Entrada { get; set; }
        public decimal Salida { get; set; }
        public decimal Saldo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Usuario { get; set; }
        public string Documento { get; set; }
        public string Detalle { get; set; }

        public string TipoTexto =>
            Tipo == "ENTRADA_COMPRA" ? "Compra"
          : Tipo == "SALIDA_DESPACHO" ? "Despacho a obra"
          : Tipo == "SALIDA_VENTA" ? "Venta"
          : Tipo == "AJUSTE_ENTRADA" ? "Ajuste (entrada)"
          : "Ajuste (salida)";
    }
}
