using COMUN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using Sistema_ACA.Forms.Admin.ListaPedidos;

namespace Sistema_ACA.Forms.Socio
{
    public partial class EstadoCuenta : Form
    {
        CnUsuario cnUsuario = new CnUsuario();
        CnPedido cnPedido = new CnPedido();
        int conteo = 1;
        int CurrentPage = 1;
        DateTime fechaActual = DateTime.Now;

        public EstadoCuenta()
        {
            InitializeComponent();
        }

        //Cargas
        private void EstadoCuenta_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            cbFiltrosPed.SelectedIndex = 0;
            
            DateTime fechaHaceUnAño = fechaActual.AddYears(-1);
            dtpDesde.Value = fechaHaceUnAño;
        }

        private void CargarDatosUsuario()
        {
            txtNombre.Text = COMUN.UserLoginCache.nombre;
            txtNombre.ReadOnly = true;
            txtApellido.Text = COMUN.UserLoginCache.apellido;
            txtApellido.ReadOnly = true;
            txtMail.Text = COMUN.UserLoginCache.mail;
            txtMail.ReadOnly = true;
            txtDni.Text = COMUN.UserLoginCache.dni.ToString();
            txtDni.ReadOnly = true;
            txtCvu.Text = COMUN.UserLoginCache.cvu.ToString();
            txtCvu.ReadOnly = true;
            txtDire.Text = COMUN.UserLoginCache.direccion;
            txtDire.ReadOnly = true;
            txtTel.Text = COMUN.UserLoginCache.telefono.ToString();
            txtTel.ReadOnly = true;
            txtContraInfo.Text = COMUN.MetodosComunes.DesEncriptarPassBD(COMUN.UserLoginCache.contra);
            txtContraInfo.ReadOnly = true;
           
        }

        private void ActualizarDGVPed()
        {
            if(cbFiltrosPed.SelectedIndex != 0 )
            {
                fechaActual = DateTime.Now;
                if(dtpHasta.Value <= fechaActual)
                {
                    bindingSource1.DataSource = cnPedido.MostrarPedidos(CurrentPage, cbFiltrosPed.Text, dtpDesde.Value, dtpHasta.Value);
                    bindingNavigator1.BindingSource = bindingSource1;
                    dgvPedido.DataSource = bindingSource1;
                    ConfiDgvPed();
                }
                else
                {
                    MessageBox.Show("La fecha hasta no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un filtro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ConfiDgvPed()
        {
            dgvPedido.Columns[0].Width = 100;
            dgvPedido.Columns[1].Width = 200;
            dgvPedido.Columns[2].Width = 300;
            dgvPedido.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        //Botones
        private void btnEditarInfo_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly =false;
            txtApellido.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtCvu.ReadOnly = false;
            txtDire.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtMail.Enabled = false;
            btnCancelar.Visible = true;
            btnConfirmar.Visible = true;
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            CambiarContra cambiarContra = new CambiarContra();
            cambiarContra.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnConfirmar.Visible = false;
                txtMail.Enabled = true;
                btnCancelar.Visible = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" && txtApellido.Text != "" && txtDni.Text != "" && txtDire.Text != "" && txtTel.Text != "" && txtCvu.Text != "")
            {
                if (MessageBox.Show("¿Está seguro que desea modificar sus datos?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cnUsuario.ModificarInfoEmpleado(txtNombre.Text,txtApellido.Text,txtDni.Text,txtCvu.Text,txtTel.Text,txtDire.Text);
                    CargarDatosUsuario();
                    btnCancelar.Visible = false;
                    txtMail.Enabled = true;
                    btnConfirmar.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if(dgvPedido.SelectedRows.Count > 0)
            {
                if (dgvPedido.CurrentRow != null)
                {
                    COMUN.Cache.CachePedido.Id =Convert.ToInt32(dgvPedido.CurrentRow.Cells[0].Value);
                    DetallesLista detalles = new DetallesLista(1);
                    detalles.ShowDialog();
                }
                else 
                {           
                    MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Navegacion
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvPedido.Rows.Count == 15)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage++;
                ActualizarDGVPed();
            }
        }

        private void bnMovePreviousItemPed_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage--;
                ActualizarDGVPed();
            }
        }
        private void bnMovePreviousItemPed_EnabledChanged(object sender, EventArgs e)
        {
            if(CurrentPage >= 1)
            {
                bnMovePreviousItemPed.Enabled = true;
            }
        }





        //validaciones
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloLetras(e);
        }


        private void cbFiltrosPed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltrosPed.SelectedIndex == 0)
            {
            }
            else
            {
                ActualizarDGVPed();
            }
            
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (cbFiltrosPed.SelectedIndex == 0)
            {
            }
            else
            {
                ActualizarDGVPed();
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (cbFiltrosPed.SelectedIndex == 0)
            {
            }
            else
            {
                ActualizarDGVPed();
            }
        }
    }
}
