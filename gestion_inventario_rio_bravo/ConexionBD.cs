using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace gestion_inventario_rio_bravo
{
    public class ConexionBD
    {
        private static string cadenaConexion = "Server=db.zjquxoxepevlymvnhfcw.supabase.co;Port=5432;Database=postgres;User Id=postgres;Password=q0Op4ZIQCeDEDdkY;";

        public static NpgsqlConnection ObtenerConexion()
        {
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar a la base de datos: " + ex.Message);
            }
        }
    }
}