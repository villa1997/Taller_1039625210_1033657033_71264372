using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaDeLogica
{
    public class ClientesLogica
    {
        public ClientesDatos ClientesDatos = new ClientesDatos();

        public DataTable ListarClientes()
        {
            return ClientesDatos.ListarClientes();
        }
    }
}
