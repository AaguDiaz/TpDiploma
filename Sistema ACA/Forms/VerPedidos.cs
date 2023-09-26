using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using Modelo;

namespace Sistema_ACA
{
    public partial class VerPedidos : Form
    {
        CnPedido ped = new CnPedido();
        public VerPedidos()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                int idUsuario = 1;
                bttnAceptar.Visible=false;
                bttnRechazar.Visible = false;
             
                
                // Mostrar los pedidos en un DataGridView
                MostrarPedidosEnDataGridView();
            }
            else
            {
                // Limpiar el DataGridView u ocultarlo si no se seleccionó el RadioButton
                LimpiarDataGridView();
            }
        }
        private void MostrarPedidosEnDataGridView()
        {
            dataGridView1.DataSource = ped.ListarPedido();
            dataGridView1.Columns["id_pedido"].HeaderText = "Num Pedido";
            dataGridView1.Columns["mail"].HeaderText = "Mail";
            dataGridView1.Columns["total"].HeaderText = "Total";
            dataGridView1.Columns["Estado"].HeaderText = "Estado";
        }
        private void LimpiarDataGridView()
        {
            dataGridView1.DataSource = null;
        }

        private void rbttnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbttnAdmin.Checked)
            {
                
                int idUsuario = 0;
                bttnAceptar.Visible = true;
                bttnRechazar.Visible= true;
               

                // Mostrar los pedidos en un DataGridView
                MostrarPedidosPorEstadoEnDataGridView();
            }
            else
            {
                // Limpiar el DataGridView u ocultarlo si no se seleccionó el RadioButton
                LimpiarDataGridView();
            }
            
        }
        private void MostrarPedidosPorEstadoEnDataGridView()
            {
                dataGridView1.DataSource = ped.ListarPedidoPorEstado();
                dataGridView1.Columns["id_pedido"].HeaderText = "Num Pedido";
                dataGridView1.Columns["mail"].HeaderText = "Mail";
                dataGridView1.Columns["total"].HeaderText = "Total";
                dataGridView1.Columns["Estado"].HeaderText = "Estado";
            }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            int idPedido = ObtenerIdPedidoSeleccionado();

            ped.ActualizarEstado(idPedido, 2);
            MostrarPedidosPorEstadoEnDataGridView();
        }

        private int ObtenerIdPedidoSeleccionado()
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                return Convert.ToInt32(filaSeleccionada.Cells["id_pedido"].Value);
            }
            else
            {
                return 0;
            }
        }

        private void bttnRechazar_Click(object sender, EventArgs e)
        {
            int idPedido = ObtenerIdPedidoSeleccionado();

            ped.ActualizarEstado(idPedido, 3);
            MostrarPedidosPorEstadoEnDataGridView();
        }
    }
}
