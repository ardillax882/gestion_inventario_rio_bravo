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
        /// <summary>Titular del subsidio habitacional.</summary>
        public string Beneficiario { get; set; }
        public string BeneficiarioRut { get; set; }
        public string BeneficiarioTelefono { get; set; }
        public string Maestro { get; set; }
        public decimal PresupuestoMateriales { get; set; }
        public EstadoObra Estado { get; set; } = EstadoObra.En_planificacion;

        /// <summary>Σ cantidad × precio de los despachos a la obra, menos las devoluciones (RF-14).</summary>
        public decimal CostoDespachado { get; set; }

        public string EstadoTexto => TextoEstado(Estado);

        public static string TextoEstado(EstadoObra e) =>
            e == EstadoObra.En_planificacion ? "En planificación"
          : e == EstadoObra.En_ejecucion ? "En ejecución"
          : "Finalizada";

        public override string ToString() => NombreObra;
    }

    /// <summary>Equipos que se prestan a las obras y deben volver a bodega. Los nombres coinciden con prestamo_equipo.equipo.</summary>
    public enum Equipo
    {
        Trompo,
        Placa,
        Bano
    }

    public class PrestamoEquipo
    {
        public int IdPrestamo { get; set; }
        public Equipo Equipo { get; set; }
        public int IdObra { get; set; }
        public string ObraNombre { get; set; }
        public System.DateTime FechaPrestamo { get; set; }
        public string UsuarioNombre { get; set; }
        public System.DateTime? FechaDevolucion { get; set; }
        /// <summary>Quien registró la devolución en bodega.</summary>
        public string RecibidoPor { get; set; }
        public string Observaciones { get; set; }

        public bool Devuelto => FechaDevolucion.HasValue;
        public string EquipoTexto => TextoEquipo(Equipo);

        public static string TextoEquipo(Equipo e) =>
            e == Equipo.Trompo ? "Trompo (betonera)"
          : e == Equipo.Placa ? "Placa compactadora"
          : "Baño químico";
    }
}
