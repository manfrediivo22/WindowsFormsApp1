using Entidades;
using System;
using System.Data;
using System.Data.OleDb;


namespace CapaDatos
{
    class AdminisProductos : DatosConexion
    {
        public int abmProductos(string accion, Producto objProducto)
        {
            int resultado = -1;// control que se realiza la operacion con exito
            string orden = string.Empty;//para guardar consulta
            if (accion == "Alta")//para agregar un producto nuevo
                orden = "insert into Producto values (" + objProducto.p_codigo +
                ",'" + objProducto.p_descripcion + "');";
            if (accion == "Modificar")//para modificar un exstente
                orden = "update Producto set Descrip='" + objProducto.p_descripcion + 
                    "'where CodProf = "+ objProducto.p_stock + "; ";
            // falta la orden de borrar

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar de Profesionales",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;

        }

        public DataSet listadoProductos(string cual)//para 1 o los datos segun el codigo
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Profesionales where CodProf = " + int.Parse(cual) + ";";
            else
                orden = "select * from Profesionales;";
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar profesionales", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
}