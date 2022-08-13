using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WindowsFormsApp1
{
    public partial class FormProducto : Form
    {
        Producto ProdExistente;
        bool nuevo = true;
        Producto nuevoprod;
        int fila;
        public FormProducto()
        
        {
            InitializeComponent();
            dataGridView2.Columns.Add("0", "Código");
            dataGridView2.Columns.Add("1", "Descripción");
            dataGridView2.Columns.Add("2", "Stock");
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[1].Width = 300;
            dataGridView2.Columns[2].Width = 60;

            txb_Codigo.Focus();
        }

        void limpiar()
        {
            txb_Codigo.Clear();
            txb_Descrip.Clear();
            txb_Stock.Clear();
        }
        
        void LlevarProdAldgv(Producto Prod, int lugar)
        {
            dataGridView2[0, lugar].Value = Prod.p_codigo.ToString();
            dataGridView2[1, lugar].Value = Prod.p_descripcion;
            dataGridView2[2, lugar].Value = Prod.p_stock.ToString();
        }

        

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            //Producto nuevoprod;
            //peticion utilizamos el constructor con contorno
            nuevoprod = new Producto(int.Parse(txb_Codigo.Text), txb_Descrip.Text);
            int codigo = nuevoprod.p_codigo;
            String desc = nuevoprod.p_descripcion;
            int stock = int.Parse(txb_Stock.Text);

            dataGridView2.Rows.Add(codigo, desc, stock);
            limpiar();
            txb_Codigo.Focus();
            nuevo = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdExistente = new Producto(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), dataGridView2.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value));
            lbl_CodigoMov.Text = ProdExistente.p_codigo.ToString();
            lbl_DescripcionMov.Text = ProdExistente.p_descripcion;
            lbl_stock.Text = "Hay " + ProdExistente.p_stock.ToString() + " unidades";
            textBox4.Clear();
            fila = e.RowIndex;
            //MessageBox.Show("fila " + fila);
            nuevo = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nuevo == true)
            {
                if (radioButton1.Checked == true)
                {
                    nuevoprod.Ingreso(int.Parse(textBox4.Text));
                }
                if (radioButton2.Checked == true)
                {
                    nuevoprod.Salida(int.Parse(textBox4.Text));
                }
                LlevarProdAldgv(nuevoprod, fila);
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    ProdExistente.Ingreso(int.Parse(textBox4.Text));
                }
                if (radioButton2.Checked == true)
                {
                    ProdExistente.Salida(int.Parse(textBox4.Text));
                }
                LlevarProdAldgv(ProdExistente, fila);
            }
            nuevo = false;
        }
    }
}