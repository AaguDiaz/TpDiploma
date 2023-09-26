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
    public partial class SolicitarPedido : Form
    {
        CnListaPedido oListaPed = new CnListaPedido();
        MoListaPedido moListaPedido = new MoListaPedido();
        CnListaProd cnListaProd = new CnListaProd();
        CnProducto cnProducto = new CnProducto();
        CnPedido cnPedido = new CnPedido();

        private List<MoPedidoLista> productosSeleccionados;
        int totalPedido;

        public SolicitarPedido()
        {
            InitializeComponent();
            productosSeleccionados = new List<MoPedidoLista>();
            totalPedido = 0;
        }

        private void SolicitarPedido_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        private void CargarLista()
        {
            List<MoListaPedido> listasPedidos = oListaPed.MostrarLista();
            cmbLista.Items.Clear();
            cmbLista.DataSource = oListaPed.MostrarLista();
            cmbLista.DisplayMember = "id_lista";
            cmbLista.ValueMember = "id_lista";
        }

        

        private void cmbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idLista = cmbLista.SelectedValue as string;

            // Obtener el nombre del proveedor y la fecha de vencimiento
            string nombreProveedor = oListaPed.ObtenerNombreProveedorPorIdLista(idLista);
            DateTime fechaVencimiento = oListaPed.ObtenerFechaVencimientoPorIdLista(idLista);

            // Obtener los productos por lista
            List<MoListaProd> ListaProd = cnListaProd.ObtenerProductosPorLista(idLista);
            List<MoProducto> prod = cnProducto.MostrarProductosPorLista(idLista);
            cmbProducto.DataSource = prod;
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.ValueMember = "id_producto";
            // Construir la cadena de texto con la información
            string informacion = $"Proveedor: {nombreProveedor}\nFecha de Vencimiento: {fechaVencimiento}\n\nProductos:\n";
            foreach (MoListaProd producto in ListaProd)
            {
                int idProducto = producto.id_productos;
                string nombre_producto = cnProducto.ObtenerNombreProductoPorId(idProducto);
                string descripcion = cnProducto.ObtenerDescripcionPorId(idProducto);
                int precio = producto.precio;
                informacion += $"{nombre_producto} - Descripción: {descripcion}, Precio: {precio}\n";
            }

           
            // Mostrar la información en el Label
            labelInformacion.Text = informacion;
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
            string nombreProducto = cmbProducto.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int precio = cnListaProd.ObtenerPrecioProducto(idProducto);
            int idLista = Convert.ToInt32(cmbLista.SelectedValue);

            int subtotal = precio * cantidad;
            totalPedido += subtotal;

            MoPedidoLista productoSeleccionado = new MoPedidoLista(idLista, idProducto, cantidad);
            productosSeleccionados.Add(productoSeleccionado);

            string detallePedido = $"{nombreProducto} (Cantidad: {cantidad}, Subtotal: {subtotal})";
            lblPedido.Text += detallePedido + Environment.NewLine;
            lblTot.Text = "Total: " + totalPedido;
        }

        private void bttnConfirmarPed_Click(object sender, EventArgs e)
        {
            int idLista = Convert.ToInt32(cmbLista.SelectedValue);
            int idPedido = cnPedido.CrearPedido(idLista,productosSeleccionados,totalPedido);

            if (idPedido > 0)
            {
                MessageBox.Show("Pedido confirmado correctamente. ID del pedido: " + idPedido.ToString());
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Error al confirmar el pedido. Inténtelo de nuevo.");
            }
        }

        private void LimpiarFormulario()
        {
            cmbLista.SelectedIndex = -1;
            cmbProducto.DataSource = null;
            txtCantidad.Clear();
            lblPedido.Text = string.Empty;
            productosSeleccionados.Clear();
            totalPedido = 0;
        }
    }
}
