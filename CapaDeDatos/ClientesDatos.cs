using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ClientesDatos
    {
        public int ClienteId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public Conexion Conexion = new Conexion();

        public DataTable ListarClientes()
        {
            return Conexion.EjecutarStoredProcedureDeListado("SP_ListarClientes", new SqlParameter[0]);
        }

    }
}
