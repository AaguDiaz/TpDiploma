using COMUN;
using Controladora;
using Sistema_ACA.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ACA.Forms.Socio
{
    public partial class AgregarProductos : Form
    {
        public SolicitarPedido SolPedForm { get; set; }
        public AgregarProductos()
        {
            InitializeComponent();
        }
        CnListaPedido cnLista = new CnListaPedido();
        CnListaProd cnListaProd = new CnListaProd();
        DataTable dt = new DataTable();



        int currentPage = 1;
        int conteo = 0;

        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            cargarCB();
            ActualizarDGV();
            dt.Columns.Add("Producto");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("PrecioInd");
            dt.Columns.Add("PrecioTot");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("IDLista");
        }

        public void cargarCB()
        {
            cbLista.DataSource = null;

            DataTable dt = new DataTable();

            dt =  cnLista.MostrarActivas(currentPage);

            if(dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string Lista = row["Proveedor"].ToString();
                    cbLista.Items.Add(Lista);
                    cbLista.ValueMember = row["IDLista"].ToString();
                }
                cbLista.SelectedIndex = 0;
            }
        }

        public void ActualizarDGV()
        {

            dgvLista.Columns.Clear();
            dgvLista.Rows.Clear();

            if (cbLista.SelectedIndex != 0)
            {
                bindingSource1.DataSource = cnListaProd.MostrarDetalleLista(Convert.ToInt32(cbLista.ValueMember), currentPage);
                bindingNavigator1.BindingSource = bindingSource1;
                dgvLista.DataSource = bindingSource1;
                dgvLista.Columns[0].Width = 300;
                dgvLista.Columns[1].Width = 300;
                dgvLista.Columns[2].Width = 200;
                dgvLista.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                dgvLista.DataSource = null;
            }

        }

        private void cbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDGV();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count == 12)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage++;
                ActualizarDGV();
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage--;
                ActualizarDGV();
            }
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            if (currentPage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }





        //Validaciones
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea cancelar? el producto no se cargará","Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(dgvLista.Rows.Count > 0)
            {
                if (txtCantidad.Text != "")
                {
                    if (Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        if (MessageBox.Show("¿Está seguro que desea agregar el producto a la lista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string nombreProducto = dgvLista.CurrentRow.Cells[0].Value.ToString();
                            string descripcionProducto = dgvLista.CurrentRow.Cells[1].Value.ToString();
                            string categoriaProducto = dgvLista.CurrentRow.Cells[2].Value.ToString();
                            int cantidadProducto = Convert.ToInt32(txtCantidad.Text);
                            int precioProducto = Convert.ToInt32( dgvLista.CurrentRow.Cells[3].Value);
                            int precioTotal = cantidadProducto * precioProducto;
                            string proveedor = cbLista.Text;
                            int idLista = Convert.ToInt32(cbLista.ValueMember);
                            
                            if (SolPedForm.GetDataGridView() == null || SolPedForm.GetDataGridView().Rows.Count == 0)
                            {
                                // Actualizar el DGV de los productos agregados
                                dt.Rows.Add(nombreProducto, descripcionProducto, categoriaProducto, cantidadProducto, precioProducto, precioTotal, proveedor, idLista);
                                SolPedForm.ActualizarDGV(dt);
                                this.Close();
                            }
                            else
                            {
                                int verificador = 0 ;
                                foreach (DataGridViewRow row in SolPedForm.GetDataGridView().Rows)
                                {
                                    if (row.Cells[0].Value.ToString() == nombreProducto)
                                    {
                                        // Actualizar el DGV de los productos agregados
                                        verificador++;
                                        MessageBox.Show("El producto ya se encuentra en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                if(verificador == 0)
                                {
                                    dt.Rows.Add(nombreProducto, descripcionProducto, categoriaProducto, cantidadProducto, precioProducto, precioTotal, proveedor, idLista);
                                    SolPedForm.ActualizarDGV(dt);
                                    this.Close();
                                }        
                                
                            }
                                
                            
                        }
                    }else
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
