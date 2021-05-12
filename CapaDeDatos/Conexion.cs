using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class Conexion
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        
        // Metodo abrir la conexion
        public void AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed) conexion.Open();
        }

        // Metodo para cerrar la cedena de conexion
        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open) conexion.Close();
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado  
        /// </summary>
        /// <param name="nombreDeSP">Nombre procedimiento almacenado</param>
        /// <param name="parametrosDeSP">Arreglo de parametros del tipo SqlParameter</param>
        public void EjecutarStoredProcedureSinRetorno(string nombreDeSP, SqlParameter[] parametrosDeSP)
        {
            var command = new SqlCommand(nombreDeSP, conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parametrosDeSP);

            AbrirConexion();
            command.ExecuteReader();
            CerrarConexion();            
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado  
        /// </summary>
        /// <param name="nombreDeSP">Nombre procedimiento almacenado</param>
        /// <param name="parametrosDeSP">Arreglo de parametros del tipo SqlParameter</param>
        /// <returns>Retorna un string con el mensaje recpetivo de acuerdo al sp ejecutado</returns>
        public string EjecutarStoredProcedure(string nombreDeSP, SqlParameter[] parametrosDeSP)
        {
            var resultado = string.Empty;
            var command = new SqlCommand(nombreDeSP, conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parametrosDeSP);

            AbrirConexion();
            var a = command.ExecuteReader();
            while (a.Read())
            {
                resultado = a[0].ToString();
            }
            CerrarConexion();
            return resultado;
        }
        /// <summary>
        /// Ejecutar procedimiento que retorna un booleano
        /// </summary>
        /// <param name="nombreDeSP"></param>
        /// <param name="parametrosDeSP"></param>
        /// <returns>Retorna un valor booleano segun sea la respuesta de la base de datos</returns>
        public bool EjecutarStoredProcedureBool(string nombreDeSP, SqlParameter[] parametrosDeSP)
        {
            var resultado = false;
            var command = new SqlCommand(nombreDeSP, conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parametrosDeSP);

            AbrirConexion();
            var a = command.ExecuteReader();
            while (a.Read())
            {
                resultado = bool.Parse(a[0].ToString());
            }
            CerrarConexion();
            return resultado;
        }

        /// <summary>
        /// Ejecutar un procedimiento almacenado que retorna un listado
        /// </summary>
        /// <param name="nombreDeSP">Nombre procedimiento almacenado</param>
        /// <param name="parametrosDeSP">Arreglo de parametros del tipo SqlParameter</param>
        /// <returns>Retorna un listado de elementos de una tabla sql de acuerdo al sp ejecutado</returns>
        public DataTable EjecutarStoredProcedureDeListado(string nombreDeSP, SqlParameter[] parametrosDeSP)
        {
            DataTable resultado = new DataTable();
            var command = new SqlCommand(nombreDeSP, conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(parametrosDeSP);
            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(resultado);
            return resultado;
        }
    }
}
