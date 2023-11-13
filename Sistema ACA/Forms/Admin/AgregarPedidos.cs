using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controladora;
using Modelo;


namespace Sistema_ACA
{
    public partial class AgregarPedidos : Form
    {
        CnListaPedido objList = new CnListaPedido();
        ProveedorController objP = new ProveedorController();
        CnProducto objProd = new CnProducto();
        CnListaProd objListProd = new CnListaProd();
        public AgregarPedidos()
        {
            InitializeComponent();
        }

        private void frmagregarp_Load(object sender, EventArgs e)
        {
           CargarProveedores();
           //ActualizarDataGridView();
           
        }
        private void cmbProveedor_DropDown(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        public void CargarProveedores()
        {
            //cmbProveedor.Items.Clear();
            cmbProveedor.DataSource = objP.ObtenerProveedores();
            cmbProveedor.DisplayMember = "nombre_proveedor";
            cmbProveedor.ValueMember = "id_proveedor";
        }
        private void CargarProducto()
        {
            cmbProducto.Items.Clear();
            cmbProducto.DataSource = objProd.ObtenerProducto();
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.ValueMember = "id_producto";
        }
        private void btnaddprov_Click(object sender, EventArgs e)
        {
            ABMProveedores agrpro = new ABMProveedores();
            agrpro.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbProveedor.Text) || string.IsNullOrEmpty(dtFechaV.Text))
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                 
                if (cmbProveedor.SelectedItem is proveedor proveedor) { 
                    objList.Insertarlista(Convert.ToInt32(proveedor.id_proveedor),Convert.ToDateTime(dtFechaV.Text));
                    AgregarNumeroLista();
                    gbAgrPed.Enabled = true;
                    cmbProveedor.Enabled = false;
                    dtFechaV.Enabled = false;
                    CargarProducto();
                    MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AgregarNumeroLista()
        {
            txtNumList.Clear();
            if (cmbProveedor.SelectedItem is proveedor proveedor)
            {
                txtNumList.Text = objList.MostrarId(proveedor.id_proveedor);
            }
        }

        private void bttnAgrProd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                if (cmbProducto.SelectedItem is MoProducto producto)
                {
                    string id_lista = txtNumList.Text;
                    objListProd.Insertarlista_Prod(id_lista, producto.id_producto, txtPrecio.Text);

                    LimpiarDataGridView();
                    
                    ActualizarTabla2(id_lista);
                    MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LimpiarDataGridView()
        {
            dataGridView1.DataSource = null;
        }
        private void ActualizarTabla2(string IdLista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objListProd.MostrarNuevaLista(IdLista);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttnConfirmar_Click(object sender, EventArgs e)
        {
            cmbProveedor.Enabled = true;
            dtFechaV.Enabled = true;
            txtNumList.Text = null;
            txtPrecio.Text = null;
            gbAgrPed.Enabled = false;
            MessageBox.Show("La lista se guardo con éxito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
