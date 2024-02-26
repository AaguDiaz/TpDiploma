using COMUN;
using COMUN.Cache;
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
    public partial class BuscarProductos : Form
    {
        public NuevaLista nuevaListaForm { get; set; }
        CnProducto cnProducto = new CnProducto();
        CnCaches Caches = new CnCaches();
        int CurrentPage = 1;
        int conteo = 1;

        public BuscarProductos()
        {
            InitializeComponent();
        }
        private void BuscarProductos_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
        }

        public void cargarCategorias()
        {
            cbCat.DataSource = cnProducto.MostrarCategorias();
            cbCat.DisplayMember = "nombre";
            cbCat.ValueMember = "id_categoria";
        }

        public void cargarDGV(int valor)
        {
            dgvProd.DataSource = null;
            dgvProd.Rows.Clear();
            
            if (valor == 1)
            {
                bindingSource1.DataSource = cnProducto.MostrarProductos(CurrentPage);
                bindingNavigator1.BindingSource = bindingSource1;
                dgvProd.DataSource = bindingSource1;
            }
            else if (valor != 1)
            {
                bindingSource1.DataSource = cnProducto.MostrarProductosFil(CurrentPage, valor);
                bindingNavigator1.BindingSource = bindingSource1;
                dgvProd.DataSource = bindingSource1;
            }
            dgvProd.Columns[0].Width = 300;
            dgvProd.Columns[1].Width = 200;
            dgvProd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = 0;
            if(cbCat.SelectedIndex > 0)
            {
                valor = Convert.ToInt32(cbCat.SelectedValue);
                cargarDGV(valor);

            }
            else
            {
                valor = 1;
                cargarDGV(valor);
            }
        }


        //Botones
        private void btnAgrProd_Click(object sender, EventArgs e)
        {
            ABMProductos abm = new ABMProductos();
            abm.confiVentana();
            abm.ShowDialog();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación?, Se perdera el progreso", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvProd.CurrentCell != null)
            {
                if (txtPrecio.Text != "0" && txtPrecio.Text != "")
                {
                    if (MessageBox.Show("¿Desea agregar el producto a la lista?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string nombreProducto = dgvProd.CurrentRow.Cells[0].Value.ToString();
                        string descripcionProducto = dgvProd.CurrentRow.Cells[1].Value.ToString();
                        string categoriaProducto = dgvProd.CurrentRow.Cells[2].Value.ToString();
                        int precioProducto = Convert.ToInt32(txtPrecio.Text);

                        if (nuevaListaForm.GetDataGridView() == null || nuevaListaForm.GetDataGridView().Rows.Count == 0)
                        {
                            Caches.Productos().Rows.Add(nombreProducto, descripcionProducto, categoriaProducto, precioProducto);

                            // Actualizar el DGV de los productos agregados
                            nuevaListaForm.ActualizarDataGridView(Caches.Productos());
                            this.Close();
                        }
                        else { 
                            int verificador = 0;
                            foreach (DataGridViewRow row in nuevaListaForm.GetDataGridView().Rows)
                            {
                                if (row.Cells[0].Value.ToString() == nombreProducto)
                                {
                                    MessageBox.Show("El producto ya se encuentra en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            if (verificador == 0)
                            {
                                // Cargar cache de la tabla productos
                                Caches.Productos().Rows.Add(nombreProducto, descripcionProducto, categoriaProducto, precioProducto);

                                // Actualizar el DGV de los productos agregados
                                nuevaListaForm.ActualizarDataGridView(Caches.Productos());

                                this.Close();
                            }
                        } 
                    }
                } else
                    {
                        MessageBox.Show("Debe ingresar un precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //validaciones
        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "0";
                txtPrecio.ForeColor = Color.DimGray;
            }
        }
        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "0")
            {
                txtPrecio.Text = "";
                txtPrecio.ForeColor = Color.Black;
            }
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvProd.Rows.Count == 12)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage++;
                int valor = 0;
                valor = cbCat.SelectedIndex + 1;
                cargarDGV(valor);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage--;
                int valor = 0;
                valor = cbCat.SelectedIndex + 1;
                cargarDGV(valor);
            }
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            if (CurrentPage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
