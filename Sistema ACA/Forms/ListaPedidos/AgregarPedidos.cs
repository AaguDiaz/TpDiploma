using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN;
using COMUN.Cache;
using Controladora;
using Sistema_ACA.Forms.Admin;
using Sistema_ACA.Forms.Admin.ListaPedidos;


namespace Sistema_ACA
{
    public partial class AgregarPedidos : Form
    {
        public static DataTable dtLista;
        int CurrentPage = 1;
        int conteo = 1;

        public AgregarPedidos()
        {
            InitializeComponent();
        }

        private void frmagregarp_Load(object sender, EventArgs e)
        {
            cbFiltro.SelectedIndex = 0;
            ActualizarDataGridView();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
            DateTime fechaHaceUnAño = DateTime.Now.AddYears(-1);
            dtpDesde.Value = fechaHaceUnAño;
        }

        public void ActualizarDataGridView()
        {
            if (cbFiltro.SelectedIndex == 1)
            {
                lblDesde.Visible = true;
                lblHasta.Visible = true;
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
                bindingSource1.DataSource = new CnListaPedido().MostrarTodas(CurrentPage, dtpDesde.Value, dtpHasta.Value);
            }
            else if (cbFiltro.SelectedIndex == 2)
            {
                lblDesde.Visible = false;
                lblHasta.Visible = false;
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
                bindingSource1.DataSource = new CnListaPedido().MostrarActivas(CurrentPage);

            }
            else if (cbFiltro.SelectedIndex == 3)
            {
                lblDesde.Visible = true;
                lblHasta.Visible = true;
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
                bindingSource1.DataSource = new CnListaPedido().MostrarVencidas(CurrentPage, dtpDesde.Value, dtpHasta.Value);
            }
            bindingNavigator1.BindingSource = bindingSource1;
            dgvLista.DataSource = bindingSource1;
            dtLista = (DataTable)bindingSource1.DataSource;
            if (dtLista != null)
            {
                confiDGV();
            } 
        }

        private void confiDGV()
        {
            dgvLista.Columns[0].Width = 50;
            dgvLista.Columns[1].Width = 200;
            dgvLista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
           ActualizarDataGridView();
        }


        private void btnNueva_Click(object sender, EventArgs e)
        {
            NuevaLista nuevaLista = new NuevaLista();
            nuevaLista.AgrPedForm = this;
            nuevaLista.ShowDialog();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);
                    CacheLista.Id = id;
                    DetallesLista detallesLista = new DetallesLista(2);
                    detallesLista.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay listas para mostrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Movilizacion de la tabla
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count == 15)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage++;
                ActualizarDataGridView();
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage--;
                ActualizarDataGridView();
            }
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            if (CurrentPage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }
    }
}
