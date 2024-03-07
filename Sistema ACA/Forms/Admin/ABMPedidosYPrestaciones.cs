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
using COMUN.Cache;

namespace Sistema_ACA.Forms.Admin
{
    public partial class ABMPedidosYPrestaciones : Form
    {
        CnPedido cnPedido = new CnPedido();
        SolicitudController cnSolicitud = new SolicitudController();
        CnDeudas cnDeudas = new CnDeudas();
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
            }else if (tabControl1.SelectedIndex == 1)
            {
                CargarDGVPrestaciones();
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
        private void CargarDGVPrestaciones()
        {
            if (cbFiltro.SelectedIndex == 1)
            {
                bindingSource1.DataSource = cnSolicitud.MostrarPrestacionesFiltro(currentpage, "Todas");
            }
            else if (cbFiltro.SelectedIndex == 2)
            {
                bindingSource1.DataSource = cnSolicitud.MostrarPrestacionesFiltro(currentpage, "Pendientes");
            }
            else if (cbFiltro.SelectedIndex == 3)
            {
                bindingSource1.DataSource = cnSolicitud.MostrarPrestacionesFiltro(currentpage, "Aceptadas");
            }
            else if (cbFiltro.SelectedIndex == 4)
            {
                bindingSource1.DataSource = cnSolicitud.MostrarPrestacionesFiltro(currentpage, "Rechazadas");
            }

            bindingNavigator1.BindingSource = bindingSource1;
            dgvPres.DataSource = bindingSource1;
            if (dgvPres.Rows.Count > 0)
            {
                dgvPres.Columns[0].Width = 250;
                dgvPres.Columns[1].Width = 250;
                dgvPres.Columns[2].Width = 100;
                dgvPres.Columns[3].Width = 150;
                dgvPres.Columns[4].Width = 150;
                dgvPres.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                currentpage = 1;
                lblGestionar.Text = "GESTIONAR PEDIDOS";
                toolStripLabel2.Text = ":Pedidos";
                CargarDGVPedidos();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                currentpage = 1;
                lblGestionar.Text = "GESTIONAR PRESTACIONES";
                toolStripLabel2.Text = ":Prestaciones";
                CargarDGVPrestaciones();
            }
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CargarDGVPedidos();
            }else if (tabControl1.SelectedIndex == 1)
            {
                CargarDGVPrestaciones();
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
            }else if (tabControl1.SelectedIndex == 1)
            {
                if (dgvPres.Rows.Count > 0)
                {
                    if (dgvPres.SelectedRows.Count > 0)
                    {
                        int id_solicitud = Convert.ToInt32(dgvPres.SelectedRows[0].Cells[2].Value.ToString());
                        string estado = "Aceptado";
                        if (MessageBox.Show("¿Está seguro que desea aceptar la prestación?", "Aceptar prestación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (dgvPres.SelectedRows[0].Cells[4].Value.ToString() == "Pendiente")
                            {
                                if (cnDeudas.VerificarDeuda(id_solicitud, Convert.ToInt32(dgvPres.SelectedRows[0].Cells[3].Value.ToString()), dgvPres.SelectedRows[0].Cells[0].Value.ToString()) ==true)
                                {
                                    cnSolicitud.cambiarEstado(id_solicitud, 2);
                                    cnSolicitud.MandarMailUsuario(id_solicitud, dgvPres.SelectedRows[0].Cells[0].Value.ToString(), dgvPres.SelectedRows[0].Cells[1].Value.ToString(), estado);
                                    CargarDGVPrestaciones();
                                }else
                                {
                                    MessageBox.Show("El monto de la prestación supera el limite de deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }else
                            {
                                MessageBox.Show("La solicitudes de prestaciónes ya fue aceptada o esta actualmente rechazada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay prestaciones para aceptar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }else if (tabControl1.SelectedIndex == 1)
            {
                if (dgvPres.Rows.Count > 0)
                {
                    if (dgvPres.SelectedRows.Count > 0)
                    {
                        int id_solicitud = Convert.ToInt32(dgvPres.SelectedRows[0].Cells[2].Value);
                        string estado = "Rechazado";
                        if (MessageBox.Show("¿Está seguro que desea rechazar la prestación?", "Rechazar prestación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (dgvPres.SelectedRows[0].Cells[4].Value.ToString() == "Pendiente")
                            {
                                cnSolicitud.cambiarEstado(id_solicitud, 3);
                                cnSolicitud.MandarMailUsuario(id_solicitud, dgvPres.SelectedRows[0].Cells[0].Value.ToString(), dgvPres.SelectedRows[0].Cells[1].Value.ToString(), estado);
                                CargarDGVPrestaciones();
                            }
                            else
                            {
                                MessageBox.Show("La solicitudes de prestaciónes ya fue rechazada o esta actualmente aceptada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay prestaciones para rechazar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }else if (tabControl1.SelectedIndex == 1)
            {
                if (dgvPres.SelectedRows.Count > 0)
                {
                    if (dgvPres.CurrentRow != null)
                    {
                        CacheSolicitud.id_solicitud = Convert.ToInt32(dgvPres.CurrentRow.Cells[2].Value);
                        DetallesLista detalles = new DetallesLista(3);
                        detalles.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una prestación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
