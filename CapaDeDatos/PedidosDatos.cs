using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class PedidosDatos
    {
        // Instancia conexion base de datos
        public Conexion Conexion = new Conexion();

        // Metodo para listar los pedidos, este realiza el llamado a la clase conexion y ejecuta el procedimiento almacenado
        public DataTable ListarPedido()
        {
            return Conexion.EjecutarStoredProcedureDeListado("SP_ListarPedido", new SqlParameter[0]);
        }

        // Metodo insertar inventario
        public string InsertarPedido(string asesor, string descripcion, int cantidad, string nombreCelular)
        {
            var parametros = new[]
            {
                new SqlParameter("@Asesor", asesor),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Marca", nombreCelular)
            };
            return Conexion.EjecutarStoredProcedure("SP_InsertarPedido", parametros);
        }

        // Metodo para actualizar pedidos
        public string ActualizarPedido(string asesor, string descripcion, int cantidad, string nombreCelular, int idPedido)
        {
            var parametros = new[]
            {
                new SqlParameter("@Asesor", asesor),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Marca", nombreCelular),
                new SqlParameter("@IdPedido", idPedido)
            };
            return Conexion.EjecutarStoredProcedure("SP_ActualizarPedido", parametros);
        }

        // Metodo eliminar pedido
        public string EliminarPedido(int idPedido)
        {
            var parametros = new[]
            {
                new SqlParameter("@IdPedido", idPedido)
            };

            return Conexion.EjecutarStoredProcedure("SP_EliminarPedido", parametros);
        }
    }
}
