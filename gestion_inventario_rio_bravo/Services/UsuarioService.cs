using System.Collections.Generic;
using System.Net.Mail;
using gestion_inventario_rio_bravo.Data;
using gestion_inventario_rio_bravo.Models;
using Npgsql;

namespace gestion_inventario_rio_bravo.Services
{
    public static class UsuarioService
    {
        public const int LargoMinimoPassword = 8;

        public static bool ExisteAlguno() => UsuarioRepository.ExisteAlguno();

        public static List<Usuario> Listar()
        {
            ExigirGerente();
            return UsuarioRepository.Listar();
        }

        /// <summary>Crea un usuario. Si aún no existe ninguno, solo se permite crear el primer Gerente (sin sesión).</summary>
        public static void Crear(Usuario u, string password, string confirmacion)
        {
            bool primerUsuario = !UsuarioRepository.ExisteAlguno();
            if (primerUsuario)
            {
                if (u.Rol != Rol.Gerente || !u.Activo)
                    throw new ValidacionException("El primer usuario debe ser un Gerente activo.");
            }
            else ExigirGerente();

            Validar(u);
            ValidarPassword(password, confirmacion);
            Guardar(() => u.IdUsuario = UsuarioRepository.Crear(u, PasswordHasher.Hash(password)));
        }

        public static void Actualizar(Usuario u)
        {
            ExigirGerente();
            Validar(u);
            if (u.IdUsuario == Sesion.Actual.IdUsuario && (u.Rol != Sesion.Actual.Rol || !u.Activo))
                throw new ValidacionException("No puede cambiar su propio rol ni desactivarse.");
            if ((u.Rol != Rol.Gerente || !u.Activo) && UsuarioRepository.ContarOtrosGerentesActivos(u.IdUsuario) == 0)
                throw new ValidacionException("Debe quedar al menos un Gerente activo en el sistema.");
            Guardar(() => UsuarioRepository.Actualizar(u));
        }

        /// <summary>El Gerente restablece la contraseña de cualquier usuario; cada usuario puede cambiar la suya.</summary>
        public static void CambiarPassword(int idUsuario, string password, string confirmacion)
        {
            if (Sesion.Actual == null || (Sesion.Actual.IdUsuario != idUsuario && !Permisos.GestionarUsuarios))
                throw new ValidacionException("No tiene permiso para cambiar esta contraseña.");
            ValidarPassword(password, confirmacion);
            UsuarioRepository.CambiarPassword(idUsuario, PasswordHasher.Hash(password));
        }

        private static void Validar(Usuario u)
        {
            u.Nombre = (u.Nombre ?? "").Trim();
            u.Email = (u.Email ?? "").Trim().ToLowerInvariant();

            if (!Rut.EsValido(u.Rut))
                throw new ValidacionException("El RUT no es válido. Ejemplo: 12.345.678-5");
            u.Rut = Rut.Normalizar(u.Rut);

            if (u.Nombre.Length == 0 || u.Nombre.Length > 100)
                throw new ValidacionException("Ingrese el nombre (máximo 100 caracteres).");
            if (u.Email.Length > 100 || !EsEmail(u.Email))
                throw new ValidacionException("Ingrese un email válido.");
        }

        private static void ValidarPassword(string password, string confirmacion)
        {
            if ((password ?? "").Length < LargoMinimoPassword)
                throw new ValidacionException($"La contraseña debe tener al menos {LargoMinimoPassword} caracteres.");
            if (password != confirmacion)
                throw new ValidacionException("Las contraseñas no coinciden.");
        }

        private static bool EsEmail(string email)
        {
            try { return new MailAddress(email).Address == email; }
            catch (System.FormatException) { return false; }
        }

        private static void ExigirGerente()
        {
            if (!Permisos.GestionarUsuarios)
                throw new ValidacionException("Solo el Gerente puede gestionar usuarios.");
        }

        /// <summary>Traduce RUT/email duplicado (restricción UNIQUE) a un mensaje para el usuario.</summary>
        private static void Guardar(System.Action accion)
        {
            try { accion(); }
            catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                throw new ValidacionException(ex.ConstraintName == "usuario_rut_key"
                    ? "Ya existe un usuario con ese RUT."
                    : "Ya existe un usuario con ese email.");
            }
        }
    }
}
