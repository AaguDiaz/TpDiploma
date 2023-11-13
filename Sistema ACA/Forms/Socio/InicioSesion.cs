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
using Modelo;

namespace Sistema_ACA
{
    public partial class InicioSesion : Form
    {

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "MAIL")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.Black;
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "MAIL";
                txtMail.ForeColor = Color.DimGray;
            }
        }
        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }
        private void bttnInicio_Click(object sender, EventArgs e)
        {
            if (txtMail.Text != "MAIL")
            {
                if (txtContra.Text != "CONTRASEÑA")
                {
                    CnUsuario usuario = new CnUsuario();
                     var validLogin = usuario.Login(txtMail.Text,txtContra.Text);

                    if (validLogin == true)
                    {
                        // Si las credenciales son válidas, abrir la pantalla inicial pasando el ID de permiso
                        PantallaPrincipal pantallaInicialForm = new PantallaPrincipal();
                        pantallaInicialForm.Show();
                        pantallaInicialForm.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        // Mostrar un mensaje de error o realizar alguna otra acción en caso de inicio de sesión fallido
                        msgError("Credenciales inválidas. Inténtalo de nuevo.");
                        txtContra.Text="CONTRASEÑA";
                        txtMail.Focus();
                    }
                }
                else msgError("Por favor ingresa una contraseña.");
            }
            else
            {
                msgError("Por favor Ingresa un Mail.");
            }
        }

        private void msgError(string msg)
        {
            lblError.Text = "    " + msg;
            lblError.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtContra.Text="CONTRASEÑA";
            txtContra.UseSystemPasswordChar = false;
            txtMail.Text="MAIL";
            lblError.Visible = false;
            this.Show();
            txtMail.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new CambiarContra();
            form.ShowDialog();
        }
    }
    }

