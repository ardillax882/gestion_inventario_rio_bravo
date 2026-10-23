using System;
using System.Linq;
using System.Windows.Forms;
using gestion_inventario_rio_bravo.Models;
using gestion_inventario_rio_bravo.Services;

namespace gestion_inventario_rio_bravo.Views
{
    /// <summary>Crear o editar un usuario. Con primerGerente = true se usa al instalar, cuando la BD no tiene usuarios.</summary>
    public partial class FormUsuarioEditar : Ventana
    {
        private readonly Usuario usuario;
        private readonly bool esNuevo;

        public FormUsuarioEditar(Usuario existente = null, bool primerGerente = false)
        {
            InitializeComponent();
            esNuevo = existente == null;
            usuario = existente ?? new Usuario { Rol = primerGerente ? Rol.Gerente : Rol.Bodeguero };

            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Valor";
            cmbRol.DataSource = Enum.GetValues(typeof(Rol)).Cast<Rol>()
                .Select(r => new { Valor = r, Texto = Usuario.TextoRol(r) }).ToList();

            txtRut.Text = usuario.Rut;
            txtNombre.Text = usuario.Nombre;
            txtEmail.Text = usuario.Email;
            chkActivo.Checked = usuario.Activo;

            // La contraseña solo se pide al crear; después se usa "Restablecer contraseña".
            lblPassword.Visible = txtPassword.Visible = lblConfirmar.Visible = txtConfirmar.Visible = esNuevo;

            if (primerGerente)
            {
                Text = "Crear primer usuario (Gerente)";
                lblInfo.Text = "No hay usuarios registrados. Cree el Gerente, que podrá crear al resto de usuarios.";
                cmbRol.Enabled = chkActivo.Enabled = false;
            }
            else
            {
                Text = esNuevo ? "Nuevo usuario" : "Editar usuario";
                lblInfo.Text = "";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbRol.SelectedValue = usuario.Rol; // requiere el enlace de datos ya creado
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var datos = new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Rut = txtRut.Text,
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Rol = (Rol)cmbRol.SelectedValue,
                Activo = chkActivo.Checked
            };

            try
            {
                if (esNuevo)
                    UsuarioService.Crear(datos, txtPassword.Text, txtConfirmar.Text);
                else
                    UsuarioService.Actualizar(datos);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No se pudo guardar el usuario.", ex);
            }
        }
    }
}
