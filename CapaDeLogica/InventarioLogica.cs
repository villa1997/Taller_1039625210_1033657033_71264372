using CapaDeDatos;
using System.Data;

namespace CapaDeLogica
{
    public class InventarioLogica
    {
        public InventarioDatos Inventario = new InventarioDatos();


        public DataTable ListarInventario()
        {
            return Inventario.ListarInventario();
        }
        public string InsertarInventario(string codigo, string descripcion, string marca, int stock)
        {
            return Inventario.InsertarInventario(codigo, descripcion, marca, stock);
        }

        public string ActualizarInventario(string codigo, string marca, string descripcion, int stock)
        {
            return Inventario.ActualizarInventario(codigo, marca, descripcion, stock);
        }

        public string EliminarInventario(string codigo)
        {
            return Inventario.EliminarInventario(codigo);
        }

    }
}