using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ACA
{
    public partial class PantallaPrincipal : Form
    {
        private VerPedidos formver;
        private SolicitarPedido formped;
        private AgregarPedidos formagr;

        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        public PantallaPrincipal(int id_permiso)
        {
            InitializeComponent();
            if(id_permiso == 0)
            {
                agregarListaDePedidosToolStripMenuItem.Visible = true;
            }
            else
            {
                agregarListaDePedidosToolStripMenuItem.Visible = false;
            }
           
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

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
           //agregarListaDePedidosToolStripMenuItem.Visible = false;
        }

        private void gestionDeSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

         private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas salir de la aplicación?", "Precaución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    }

