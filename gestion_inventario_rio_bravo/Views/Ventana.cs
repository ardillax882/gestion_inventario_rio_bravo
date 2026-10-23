using System;
using System.Windows.Forms;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Base de todas las ventanas: aplica el tamaño de letra elegido por el usuario (<see cref="Letra"/>).</summary>
    public class Ventana : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            // Antes de base.OnLoad, para que Windows centre la ventana ya con su tamaño final.
            if (!DesignMode) Letra.Aplicar(this);
            base.OnLoad(e);
        }
    }
}
