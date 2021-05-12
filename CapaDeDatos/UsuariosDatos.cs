using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class UsuariosDatos
    {
        public Conexion ConexionConBD = new Conexion();

        public DataTable ListarUsuario()
        {
            return ConexionConBD.EjecutarStoredProcedureDeListado("SP_ListarUsuarios", new SqlParameter[0]);
        }

        public string InsertarUsuario(string identificacion, string nombres, string apellidos, string usuario, string contrasena)
        {
            var parametros = new[]
            {
                new SqlParameter("@Identificacion", identificacion),
                new SqlParameter("@Nombres", nombres),
                new SqlParameter("@Apellidos", apellidos),
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Contrasena", contrasena)
            };
            return ConexionConBD.EjecutarStoredProcedure("SP_InsertarUsuario", parametros);
        }

        public string ActualizarUsuario(string identificacion, string nombres, string apellidos, string usuario, string contrasena)
        {
            var parametros = new[]
            {
                new SqlParameter("@Identificacion", identificacion),
                new SqlParameter("@Nombres", nombres),
                new SqlParameter("@Apellidos", apellidos),
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Contrasena", contrasena)
            };
            return ConexionConBD.EjecutarStoredProcedure("SP_ActualizarUsuario", parametros);
        }

        public string EliminarUsuario(string identificacion)
        {
            var parametros = new[]
            {
                new SqlParameter("@Identificacion", identificacion)
            };

            return ConexionConBD.EjecutarStoredProcedure("SP_EliminarUsuario", parametros);
        }
    }
}
