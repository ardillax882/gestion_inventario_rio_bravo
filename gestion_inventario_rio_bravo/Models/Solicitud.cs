using System;
using System.Collections.Generic;

namespace gestion_inventario_rio_bravo.Models
{
    /// <summary>Estados de solicitud (RF-16). Los nombres coinciden con solicitud.estado en la BD.</summary>
    public enum EstadoSolicitud
    {
        Pendiente,
        Aprobada,
        Rechazada,
        Despachada_parcial,
        Despachada_total
    }

    /// <summary>Folios con prefijo por tipo de documento (RN-11). El número es el id.</summary>
    public static class Folio
    {
        public static string Solicitud(int id) => "SOL-" + id.ToString("D6");
        public static string Despacho(int id) => "DES-" + id.ToString("D6");
    }

    /// <summary>La planilla "Salida de materiales" de una obra (§8.2).</summary>
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int IdObra { get; set; }
        public string ObraNombre { get; set; }
        public decimal? ObraSuperficie { get; set; }
        public string ObraDireccion { get; set; }
        public string ObraBeneficiario { get; set; }
        public string ObraMaestro { get; set; }
        public EstadoObra ObraEstado { get; set; }
        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
        public string AprobadorNombre { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public string MotivoRechazo { get; set; }
        public bool EquipoTrompo { get; set; }
        public bool EquipoPlaca { get; set; }
        public bool EquipoBano { get; set; }
        public string Observaciones { get; set; }

        public List<DetalleSolicitud> Lineas { get; set; } = new List<DetalleSolicitud>();

        /// <summary>Saldo total pendiente (para el listado).</summary>
        public decimal SaldoTotal { get; set; }

        public string Folio => IdSolicitud == 0 ? "(nueva)" : Models.Folio.Solicitud(IdSolicitud);
        public string EstadoTexto => TextoEstado(Estado);
        public bool EsNueva => IdSolicitud == 0;
        public bool Editable => Estado == EstadoSolicitud.Pendiente;
        public bool Despachable => Estado == EstadoSolicitud.Aprobada || Estado == EstadoSolicitud.Despachada_parcial;

        public static string TextoEstado(EstadoSolicitud e) => e.ToString().Replace('_', ' ');
    }

    public class DetalleSolicitud
    {
        public int IdDetalleSolicitud { get; set; }
        public int IdMaterial { get; set; }
        public string Codigo { get; set; }
        public string Material { get; set; }
        public string Unidad { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int CategoriaOrden { get; set; }
        public decimal CantidadSolicitada { get; set; }
        public decimal CantidadDespachada { get; set; }
        public decimal StockActual { get; set; }

        public decimal Saldo => CantidadSolicitada - CantidadDespachada;
    }

    /// <summary>Una entrega (columna "Fecha" de la planilla).</summary>
    public class Despacho
    {
        public int IdDespacho { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime FechaHora { get; set; }
        public string UsuarioNombre { get; set; }
        public string RecibidoPor { get; set; }
        public string Observaciones { get; set; }

        /// <summary>Cantidad entregada por id_detalle_solicitud.</summary>
        public Dictionary<int, decimal> Cantidades { get; set; } = new Dictionary<int, decimal>();

        public string Folio => Models.Folio.Despacho(IdDespacho);
    }
}
