namespace gestion_inventario_rio_bravo.Models
{
    /// <summary>Estados de obra (RF-13). Los nombres coinciden con obra.estado en la BD.</summary>
    public enum EstadoObra
    {
        En_planificacion,
        En_ejecucion,
        Finalizada
    }

    public class Obra
    {
        public int IdObra { get; set; }
        public string NombreObra { get; set; }
        public decimal? SuperficieM2 { get; set; }
        public string Direccion { get; set; }
        public string Beneficiario { get; set; }
        public string Maestro { get; set; }
        public decimal PresupuestoMateriales { get; set; }
        public EstadoObra Estado { get; set; } = EstadoObra.En_planificacion;

        /// <summary>Σ cantidad × precio de los despachos a la obra (RF-14).</summary>
        public decimal CostoDespachado { get; set; }

        public string EstadoTexto => TextoEstado(Estado);

        public static string TextoEstado(EstadoObra e) =>
            e == EstadoObra.En_planificacion ? "En planificación"
          : e == EstadoObra.En_ejecucion ? "En ejecución"
          : "Finalizada";

        public override string ToString() => NombreObra;
    }
}
