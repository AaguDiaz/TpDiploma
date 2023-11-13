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
    public partial class ABMProveedores : Form
    {
        CnProveedor objetoCN = new CnProveedor();
        MoProveedor oPro= new MoProveedor();

        public ABMProveedores()
        {
            InitializeComponent();
        }

        private void LimpiarDataGridView()
        {
            dataGridView1.DataSource = null;
        }
        private void ABMProveedores_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void txtTelPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtCuilPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtNombrePro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePro.Text) || string.IsNullOrEmpty(txtDirePro.Text) || string.IsNullOrEmpty(txtCuilPro.Text) || string.IsNullOrEmpty(txtTelPro.Text))
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                LimpiarDataGridView();
                objetoCN.InsertarProv(txtNombrePro.Text,txtDirePro.Text,txtCuilPro.Text,txtTelPro.Text);
                MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDataGridView();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataGridView()
        {
            LimpiarDataGridView();
            dataGridView1.DataSource = objetoCN.MostrarProv();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarPedidos ped = new AgregarPedidos();
            ped.CargarProveedores();
            this.Close();
        }
    }
}
