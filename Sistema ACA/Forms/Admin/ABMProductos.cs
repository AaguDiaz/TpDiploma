using COMUN;
using Controladora;
using Sistema_ACA.Forms.Admin.ListaPedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Sistema_ACA.Forms.Admin
{
    public partial class ABMProductos : Form
    {
        CnProducto cnProducto = new CnProducto();
        public ABMProductos()
        {
            InitializeComponent();
        }

        private void ABMProductos_Load(object sender, EventArgs e)
        {
            dgvProd.DataSource = cnProducto.MostrarProductosABM();
            cargarCategorias();
            cargarDGV();
            dgvProd.ClearSelection();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
        }

        public void cargarCategorias()
        {
            cbCat.DataSource = cnProducto.MostrarCategorias();
            cbCat.DisplayMember = "nombre";
            cbCat.ValueMember = "id_categoria";
        }

        public void confiVentana()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            btnSalir.Visible = false;
            lblABM.Visible = false;
            panel1.Size = new Size(641, 586);
            panel1.Location = new Point(0, 0);
        }
        public void cargarDGV()
        {
            dgvProd.DataSource = null;
            dgvProd.Rows.Clear();
            dgvProd.DataSource = cnProducto.MostrarProductosABM();
            dgvProd.Columns[0].Width = 50;
            dgvProd.Columns[1].Width = 200;
            dgvProd.Columns[1].Width = 200;
            dgvProd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Botones
        private void btnAgrCat_Click(object sender, EventArgs e)
        {
            CargarCat cargarCat = new CargarCat();
            cargarCat.AMBProdForm = this;
            cargarCat.ShowDialog();
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "Nombre:" && txtDescripcion.Text != "Descripcion:" && cbCat.SelectedIndex != 0)
            {
                cnProducto.AgregarProducto(txtNombre.Text, txtDescripcion.Text, cbCat.Text);
                cargarDGV();
                txtNombre.Text = "Nombre:";
                txtNombre.ForeColor = System.Drawing.Color.DimGray;
                txtDescripcion.Text = "Descripcion:";
                txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
                cbCat.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if(dgvProd.SelectedRows.Count > 0)
            {
                if(txtNombre.Text != "Nombre:" && txtDescripcion.Text != "Descripcion:" && cbCat.Text != "Seleccionar")
                {
                    cnProducto.ModificarProducto(Convert.ToInt32(dgvProd.CurrentRow.Cells[0].Value), txtNombre.Text, txtDescripcion.Text, cbCat.Text);
                    cargarDGV();
                    txtNombre.Text = "Nombre:";
                    txtNombre.ForeColor = System.Drawing.Color.DimGray;
                    txtDescripcion.Text = "Descripcion:";
                    txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
                    cbCat.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if(dgvProd.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Estas seguro que deseas eliminar el producto?", "Precaución",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (cnProducto.EliminarProducto(Convert.ToInt32(dgvProd.CurrentRow.Cells[0].Value)) == 0)
                    {
                        MessageBox.Show("Producto eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDGV();
                    }else
                    {
                        MessageBox.Show("No se pudo eliminar el producto, debido a que ya es utilizado en una lista de pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProd_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProd.SelectedRows.Count > 0)
            {
                txtNombre.Text = dgvProd.CurrentRow.Cells[1].Value.ToString();
                txtNombre.ForeColor = System.Drawing.Color.Black;
                txtDescripcion.Text = dgvProd.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.ForeColor = System.Drawing.Color.Black;
                cbCat.Text = dgvProd.CurrentRow.Cells[3].Value.ToString();

            }
        }

        //Validaciones
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre:")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre:";
                txtNombre.ForeColor = System.Drawing.Color.DimGray;
            }
        }
        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if(txtDescripcion.Text == "Descripcion:")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion:";
                txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            }
        }

    }
}
