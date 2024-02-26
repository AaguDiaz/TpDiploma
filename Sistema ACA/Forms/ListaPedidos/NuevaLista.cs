using COMUN;
using Controladora;
using Sistema_ACA.Forms.Admin.ListaPedidos;
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

namespace Sistema_ACA.Forms.Admin
{
    public partial class NuevaLista : Form
    {
        
        public AgregarPedidos AgrPedForm { get; set; }
        CnListaPedido cnLista = new CnListaPedido();
        int close = 1;

        public NuevaLista()
        {
            InitializeComponent();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
        }
        private void NuevaLista_Load(object sender, EventArgs e)
        {
            CargarProveedor();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
        }

        public void CargarProveedor()
        {
            CnProveedor cnP = new CnProveedor();
            cbProveedores.DataSource = cnP.MostrarProveedor();
            cbProveedores.DisplayMember = "nombre_proveedor";
        }

        public void ActualizarDataGridView(DataTable nuevoDataSource)
        {
            dgvProd.DataSource = nuevoDataSource;
            cargarDGV();
        }

        public void cargarDGV()
        {
            dgvProd.Columns[0].Width = 200;
            dgvProd.Columns[1].Width = 200;
            dgvProd.Columns[2].Width = 100;
            dgvProd.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public DataGridView GetDataGridView()
        {
            return dgvProd;
        }


        //Botones

        private void btnAgProveedor_Click(object sender, EventArgs e)
        {
            ABMProveedores abmP = new ABMProveedores();
            abmP.ModificacionForm();
            abmP.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BuscarProductos buscar = new BuscarProductos();
            buscar.nuevaListaForm = this;
            buscar.ShowDialog();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProd.SelectedRows.Count > 0)
            {
                dgvProd.Rows.RemoveAt(dgvProd.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación?, Se perdera el progreso", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                close = 0;
                this.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cbProveedores.Text != "")
            {
                if (dgvProd.Rows.Count > 0)
                {
                    if(dtpFechaVen.Value > DateTime.Now)
                    {
                        if (MessageBox.Show("¿Desea agregar el producto a la lista?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string nombreProveedor = cbProveedores.Text;
                            string descripcion = DateTime.Now.ToString("MMMM yy");
                            DateTime fechaVencimiento = dtpFechaVen.Value;
                            string proveedor= nombreProveedor + " " + descripcion;
                            // Cargar los datos a la base de datos
                            foreach(DataRow row in AgregarPedidos.dtLista.Rows)
                            {
                              if (string.Equals(row[1].ToString(), proveedor, StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Ya existe una lista con el proveedor " + nombreProveedor + " en el mes " + descripcion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }  
                            }
                            int id_lista = cnLista.CargarLista(nombreProveedor, descripcion ,fechaVencimiento);
                            if (id_lista !=0 )
                            {
                                foreach (DataGridViewRow row in dgvProd.Rows)
                                {

                                    string nombreProducto = row.Cells[0].Value.ToString();
                                    string descripcionProducto = row.Cells[1].Value.ToString();
                                    int precioProducto = Convert.ToInt32(row.Cells[3].Value);

                                    // Cargar los productos a la lista
                                    if(cnLista.CargarListaPxP(id_lista, nombreProducto, descripcionProducto, precioProducto) == 0)
                                    {
                                        MessageBox.Show("No se ha podido cargar el producto " + nombreProducto + " a la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                MessageBox.Show("La lista se ha cargado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("La lista no se ha cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            // Actualizar el DGV de los productos agregados
                            AgrPedForm.ActualizarDataGridView();
                            close = 0;
                            this.Close();
                        }
                    }
                    else
                    {
                      MessageBox.Show("La fecha de vencimiento no puede ser menor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("No hay productos cargados en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevaLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                if (MessageBox.Show("¿Está seguro que desea salir?, si no has confirmado la nueva lista se perdera el cargado", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
