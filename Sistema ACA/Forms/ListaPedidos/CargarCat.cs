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

namespace Sistema_ACA.Forms.Admin.ListaPedidos
{
    public partial class CargarCat : Form
    {
        CnProducto cnProducto = new CnProducto();
        public ABMProductos AMBProdForm { get; set; }

        public CargarCat()
        {
            InitializeComponent();
        }

        private void CargarCat_Load(object sender, EventArgs e)
        {
            txtId.Text = cnProducto.ObtenerIdCat().ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la carga de la categoria?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                cnProducto.AgregarCategoria(txtNombre.Text);
                MessageBox.Show("Categoria agregada correctamente", "Categoria agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AMBProdForm.cargarCategorias();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
