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

namespace Sistema_ACA
{
    public partial class PantallaPrincipal : Form
    {
        private VerPedidos formver;
        private SolicitarPedido formped;
        private AgregarPedidos formagr;
        private ABMUsuarios formusu;
        private Prestaciones formpre;


        public PantallaPrincipal()
        {
            InitializeComponent();
        }
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
        }
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void PantallaPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        private void solicitarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(formped == null)
            {
                formped = new SolicitarPedido();
                formped.MdiParent = this;
                formped.FormClosed += new FormClosedEventHandler(cerrarforms);
                formped.Show();
                formped.BringToFront();
            }
            else
            {
                formped.Activate();
            }
        }
        void cerrarforms(object sender, FormClosedEventArgs e)
        {
            formped = null;
            formagr = null;
            formver = null;
            formusu = null;
        }
        private void tusPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (formver == null)
            {
                formver = new VerPedidos();
                formver.MdiParent = this;
                formver.FormClosed += new FormClosedEventHandler(cerrarforms);
                formver.Show();
                formver.BringToFront();
            }
            else
            {
                formver.Activate();
            }
        }
        private void agregarListaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formagr == null)
            {
                formagr = new AgregarPedidos();
                formagr.MdiParent = this;
                formagr.FormClosed += new FormClosedEventHandler(cerrarforms);
                formagr.Show();
                formagr.BringToFront();
            }
            else
            {
                formagr.Activate();
            }
        }

        private void gestionDeSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro que deseas salir de la aplicación?", "Precaución",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void gestionSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formusu== null)
            {
                formusu = new ABMUsuarios();
                formusu.MdiParent = this;
                formusu.FormClosed += new FormClosedEventHandler(cerrarforms);
                formusu.Show();
                formusu.BringToFront();
            }
            else
            {
                formusu.Activate();
            }
        }

        private void solicitarPrestacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formpre == null)
            {
                formpre = new Prestaciones();
                formpre.MdiParent = this;
                formpre.FormClosed += new FormClosedEventHandler(cerrarforms);
                formpre.Show();
                formpre.BringToFront();
            }
            else
            {
                formpre.Activate();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cerrar la sesión?", "Precaución",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
    }

