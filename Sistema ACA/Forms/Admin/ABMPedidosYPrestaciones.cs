using Controladora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_ACA.Forms.Admin.ListaPedidos;
using COMUN;

namespace Sistema_ACA.Forms.Admin
{
    public partial class ABMPedidosYPrestaciones : Form
    {
        CnPedido cnPedido = new CnPedido();

        int currentpage = 1;
        int conteo = 1;

        public ABMPedidosYPrestaciones()
        {
            InitializeComponent();
        }

        //Cargas
        private void ABMPedidosYPrestaciones_Load(object sender, EventArgs e)
        {
            cbFiltro.SelectedIndex = 0;
            MetodosComunes.CargarModulosFormularios("ABMPedidosYPrestaciones", flowLayoutPanel1);
            if (tabControl1.SelectedIndex == 0)
            {
                CargarDGVPedidos();
            }
        }

        private void CargarDGVPedidos()
        {
            if (cbFiltro.SelectedIndex == 1)
            {
                bindingSource1.DataSource = cnPedido.MostrarPedidosABM(currentpage, "Todas");
            }
            else if (cbFiltro.SelectedIndex == 2)
            {
                bindingSource1.DataSource = cnPedido.MostrarPedidosABM(currentpage, "Pendientes");
            }
            else if (cbFiltro.SelectedIndex == 3)
            {
                bindingSource1.DataSource = cnPedido.MostrarPedidosABM(currentpage, "Aceptadas");
            }
            else if (cbFiltro.SelectedIndex == 4)
            {
                bindingSource1.DataSource = cnPedido.MostrarPedidosABM(currentpage, "Rechazadas");
            }

            bindingNavigator1.BindingSource = bindingSource1;
            dgvPedidos.DataSource = bindingSource1;
            if (dgvPedidos.Rows.Count > 0)
            {
                dgvPedidos.Columns[0].Width = 250;
                dgvPedidos.Columns[1].Width = 250;
                dgvPedidos.Columns[2].Width = 100;
                dgvPedidos.Columns[3].Width = 150;
                dgvPedidos.Columns[4].Width = 150;
                dgvPedidos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                lblGestionar.Text = "GESTIONAR PEDIDOS";
                toolStripLabel2.Text = ":Pedidos";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                lblGestionar.Text = "GESTIONAR PRESTACIONES";
                toolStripLabel2.Text = ":Prestaciones";
            }
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CargarDGVPedidos();
            }
        }



        //Botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (dgvPedidos.Rows.Count > 0)
                {
                    if (dgvPedidos.SelectedRows.Count > 0)
                    {
                        int id_pedido = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells[2].Value);
                        string estado = "Aceptado";
                        if (MessageBox.Show("¿Está seguro que desea aceptar el pedido?", "Aceptar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cnPedido.CambiarEstadoPedido(id_pedido, estado);
                            cnPedido.MandarMailUsuario(id_pedido, dgvPedidos.SelectedRows[0].Cells[0].Value.ToString(), dgvPedidos.SelectedRows[0].Cells[1].Value.ToString(), estado);
                            CargarDGVPedidos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay pedidos para aceptar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (dgvPedidos.Rows.Count > 0)
                {
                    if (dgvPedidos.SelectedRows.Count > 0)
                    {
                        int id_pedido = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells[2].Value);
                        string estado = "Rechazado";
                        if (MessageBox.Show("¿Está seguro que desea rechazar el pedido?", "Rechazar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cnPedido.CambiarEstadoPedido(id_pedido, estado);
                            cnPedido.MandarMailUsuario(id_pedido, dgvPedidos.SelectedRows[0].Cells[0].Value.ToString(), dgvPedidos.SelectedRows[0].Cells[1].Value.ToString(), estado);
                            CargarDGVPedidos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay pedidos para rechazar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (dgvPedidos.SelectedRows.Count > 0)
                {
                    if (dgvPedidos.CurrentRow != null)
                    {
                        COMUN.Cache.CachePedido.Id = Convert.ToInt32(dgvPedidos.CurrentRow.Cells[2].Value);
                        DetallesLista detalles = new DetallesLista(1);
                        detalles.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Navegacion
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.Rows.Count == 15)
            {
                currentpage++;
                CargarDGVPedidos();
            }
        }

        private void bnMovePreviousItemPed_Click(object sender, EventArgs e)
        {
            if (currentpage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentpage--;
                CargarDGVPedidos();
            }
        }
        private void bnMovePreviousItemPed_EnabledChanged(object sender, EventArgs e)
        {
            if (currentpage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

    }
}
