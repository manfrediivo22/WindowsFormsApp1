using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocios
{
    public class NegProductos
    {
       AdminisProductos DatosobjProducto = new AdminisProductos();

        public int adminisProductos(string accion, Producto objProducto)
        {
            return DatosobjProducto.aminisProductos(accion, objProducto);
        }

        public DataSet listadoProductos(string cual)
        {
            return DatosobjProducto.listadoProductos(cual);

        }
    }
}
