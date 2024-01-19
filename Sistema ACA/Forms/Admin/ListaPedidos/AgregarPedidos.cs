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
using COMUN.Cache;
using Controladora;
using Sistema_ACA.Forms.Admin;
using Sistema_ACA.Forms.Admin.ListaPedidos;


namespace Sistema_ACA
{
    public partial class AgregarPedidos : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void AgregarPedidos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


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
        }

        public void ActualizarDataGridView()
        {
            bindingSource1.DataSource = new CnListaPedido().MostrarTodas(CurrentPage);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvLista.DataSource = bindingSource1;
            confiDGV();
        }

        private void confiDGV()
        {
            dgvLista.Columns[0].Width = 50;
            dgvLista.Columns[1].Width = 200;
            dgvLista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltro.SelectedIndex == 1)
            {
                bindingSource1.DataSource = new CnListaPedido().MostrarTodas(CurrentPage);
                confiDGV();
            }
            else if (cbFiltro.SelectedIndex == 2)
            {
                bindingSource1.DataSource = new CnListaPedido().MostrarActivas(CurrentPage);
                if (dgvLista.Rows.Count > 0 ) { 
                    confiDGV();
                }
            }
            else if (cbFiltro.SelectedIndex == 3)
            {
                bindingSource1.DataSource = new CnListaPedido().MostrarVencidas(CurrentPage);
                confiDGV();
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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


        //validaciones
        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.BackColor= Color.Red;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.White;

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
    }
}
