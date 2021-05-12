using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class VentasDatos
    {
        public Conexion ConexionConBD = new Conexion();

        public DataTable ListarVentas()
        {
            return ConexionConBD.EjecutarStoredProcedureDeListado("SP_ListarVentas", new SqlParameter[0]);
        }

        public string InsertarVenta(string codigoCelular, int valorVenta, string vendedor, int cantidadVendida)
        {
            var parametros = new[]
            {
                new SqlParameter("@CodigoCelular", codigoCelular),
                new SqlParameter("@ValorVenta", valorVenta),
                new SqlParameter("@Vendededor", vendedor),
                new SqlParameter("@CantidadVenta", cantidadVendida)
            };
            return ConexionConBD.EjecutarStoredProcedure("SP_InsertarVenta", parametros);
        }

        public string ActualizarVenta(int ventaId,string codigoCelular, int valorVenta, string vendedor, int cantidadVendida)
        {
            var parametros = new[]
            {
                new SqlParameter("@VentaId", ventaId),
                new SqlParameter("@CodigoCelular", codigoCelular),
                new SqlParameter("@ValorVenta", valorVenta),
                new SqlParameter("@Vendededor", vendedor),
                new SqlParameter("@CantidadVenta", cantidadVendida)
            };
            return ConexionConBD.EjecutarStoredProcedure("SP_ActualizarVenta", parametros);
        }

        public string EliminarVenta(int ventaId)
        {
            var parametros = new[]
            {
                new SqlParameter("@VentaId", ventaId)
            };

            return ConexionConBD.EjecutarStoredProcedure("SP_EliminarVenta", parametros);
        }
    }
}
