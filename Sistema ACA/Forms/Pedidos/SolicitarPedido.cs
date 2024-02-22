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
using Sistema_ACA.Forms.Socio;
using COMUN;

namespace Sistema_ACA
{
    public partial class SolicitarPedido : Form
    {

        public SolicitarPedido()
        {
            InitializeComponent();
            
        }

        CnPedido pedido = new CnPedido();
        CnPedidoLista pedlist = new CnPedidoLista();
        int total = 0;
        private void SolicitarPedido_Load(object sender, EventArgs e)
        {
          congiDGV();
          MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
        }
        
        public void congiDGV()
        {
            dgvProd.Columns.Add("Producto", "Producto");
            dgvProd.Columns[0].Width = 200;
            dgvProd.Columns.Add("Descripcion", "Descripcion");
            dgvProd.Columns[1].Width = 200;
            dgvProd.Columns.Add("Categoria", "Categoria");
            dgvProd.Columns[2].Width = 200;
            dgvProd.Columns.Add("Cantidad", "Cantidad");    
            dgvProd.Columns[3].Width = 100;
            dgvProd.Columns.Add("PrecioInd", "Precio individual");
            dgvProd.Columns[4].Width = 150;
            dgvProd.Columns.Add("PrecioTot", "Precio total");
            dgvProd.Columns[5].Width = 150;
            dgvProd.Columns.Add("Proveedor", "Proveedor");
            dgvProd.Columns[6].Width = 200;
            dgvProd.Columns.Add("IDLista", "ID Lista");
            dgvProd.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        
        public void ActualizarDGV(DataTable nuevoDataSource)
        {
            dgvProd.Rows.Add(nuevoDataSource.Rows[0][0].ToString(), nuevoDataSource.Rows[0][1].ToString(), nuevoDataSource.Rows[0][2].ToString(), nuevoDataSource.Rows[0][3].ToString(), nuevoDataSource.Rows[0][4].ToString(), nuevoDataSource.Rows[0][5].ToString(), nuevoDataSource.Rows[0][6].ToString(), nuevoDataSource.Rows[0][7].ToString());
            total = 0;
            foreach (DataGridViewRow row in dgvProd.Rows)
            {
                total += Convert.ToInt32(row.Cells[5].Value);
            }
            lblTot.Text = total.ToString();
        }

        public DataGridView GetDataGridView()
        {
            return dgvProd;
        }

        //botones
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AgregarProductos agregar = new AgregarProductos();
            agregar.SolPedForm = this;
            agregar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProd.Rows.Count > 0)
            {
                if(dgvProd.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el producto de la lista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvProd.Rows.Remove(dgvProd.CurrentRow);
                        total = 0;
                        foreach (DataGridViewRow row in dgvProd.Rows)
                        {
                            
                            total += Convert.ToInt32(row.Cells[5].Value);
                        }
                        lblTot.Text = total.ToString();
                    }
                }else
                {
                    MessageBox.Show("Seleccione un producto de la lista para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dgvProd.Rows.Count > 0)
            {
                if(MessageBox.Show("¿Está seguro que desea limpiar toda la lista?","Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvProd.Rows.Clear();
                    total = 0;
                    lblTot.Text = total.ToString();
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para limpiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar el pedido?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(dgvProd.Rows != null)
            {
                //cargar pedido y obtener el id del nuevo pedido
                if(MessageBox.Show("¿Está seguro que desea confirmar el pedido?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id_pedido = pedido.CargarPedido(lblTot.Text);
                    if(id_pedido != 0)
                    {
                        foreach (DataGridViewRow row in dgvProd.Rows)
                        {
                            pedlist.CargarPedidoLista(id_pedido, row.Cells[7].Value.ToString(), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[5].Value.ToString());
                        }
                        pedido.MandarMailAdmins();
                        MessageBox.Show("Pedido confirmado con éxito", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
            }else
            {
                MessageBox.Show("Debe ingresar minimo un producto para confirmar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
