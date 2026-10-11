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
                Advertencia(ex.Message);
            else
                MessageBox.Show(contexto + "\n\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Advertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static bool Confirmar(string pregunta) =>
            MessageBox.Show(pregunta, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
    }
}
