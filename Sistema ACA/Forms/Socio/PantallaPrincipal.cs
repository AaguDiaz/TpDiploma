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
using Sistema_ACA.Forms;
using Sistema_ACA.Forms.Admin;
using Sistema_ACA.Forms.Socio;

namespace Sistema_ACA
{
    public partial class PantallaPrincipal : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void PantallaPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }


        private Form formActivo = null;
        private InicioSesion forminicio;
        private int close = 0;

        public PantallaPrincipal(InicioSesion forminicio)
        {
            InitializeComponent();
            this.forminicio = forminicio;
        }
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
        }
        
        
        private void abrirForm(Form formHijo)
        {
            // Si hay un formulario abierto, lo cerramos
            if (formActivo != null)
            {
                formActivo.Close();
            }
            // Abrimos el formulario hijo
            formActivo = formHijo;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.MdiParent = this;
            // Ponemos al frente el formulario hijo
            formHijo.BringToFront();

            // Abrimos el formulario
            formHijo.Show();
        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cerrar la sesión?", "Precaución",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                close = 1;
                this.Close();
                forminicio.Show();
            }
        }


        private void PantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close != 1)
            {
              Application.Exit();
            }
                
        }


        private void solicitarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new SolicitarPedido());
        }
        
        private void agregarListaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           abrirForm(new AgregarPedidos());
        }

        private void gestionDeSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new ABMUsuarios());
        }

        private void solicitarPrestacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new Prestaciones());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new ABMProveedores());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           abrirForm(new ABMProductos());
        }

        private void estadoDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new EstadoCuenta());
        }
    }
    }

