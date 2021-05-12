using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class InventarioDatos
    {
        // Instancia conexion base de datos
        public Conexion Conexion = new Conexion();

        // Metodo para listar el inventario, este realiza el llamado a la clase conexion y ejecuta el procedimiento almacenado
        public DataTable ListarInventario()
        {
            return Conexion.EjecutarStoredProcedureDeListado("SP_ListarInventario", new SqlParameter[0]);
        }

        // Metodo insertar inventario
        public string InsertarInventario(string codigo, string descripcion, string marca, int stock)
        {
            var parametros = new[]
            {
                new SqlParameter("@Codigo", codigo),
                new SqlParameter("@Marca", marca),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Stock", stock)
            };
            return Conexion.EjecutarStoredProcedure("SP_InsertarInventario", parametros);
        }

        // Metodo para actualizar inventario
        public string ActualizarInventario(string codigo, string marca, string descripcion, int stock)
        {
            var parametros = new[]
            {
                new SqlParameter("@Codigo", codigo),
                new SqlParameter("@Marca", marca),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Stock", stock)
            };
            return Conexion.EjecutarStoredProcedure("SP_ActualizarInventario", parametros);
        }

        // Metodo eliminar inventario
        public string EliminarInventario(string codigo)
        {
            var parametros = new[]
            {
                new SqlParameter("@Codigo", codigo)
            };

            return Conexion.EjecutarStoredProcedure("SP_EliminarInventario", parametros);
        }
    }
}
