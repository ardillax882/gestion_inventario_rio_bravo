using System;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Mensajes estándar al usuario (RNF-07).</summary>
    public static class Mensajes
    {
        /// <summary>Validaciones: se muestra el mensaje tal cual. Errores inesperados: contexto + detalle técnico.</summary>
        public static void Error(string contexto, Exception ex)
        {
            if (ex is ValidacionException)
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(contexto + "\n\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
