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
using Controladora.Seguridad;

namespace Sistema_ACA
{
    public partial class InicioSesion : Form
    {

        CnAuditoria auditoria = new CnAuditoria();
        public InicioSesion()
        {
            InitializeComponent();
        }


        private void InicioSesion_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
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
        private void msgError(string msg)
        {
            lblError.Text = "    " + msg;
            lblError.Visible = true;
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
                        if (usuario.EstadoUsuario(txtMail.Text)==true){
                            // Si las credenciales son válidas y el usuario esta activo, abrir la pantalla inicial pasando el ID de permiso
                            PantallaPrincipal pantallaInicialForm = new PantallaPrincipal(this);
                            pantallaInicialForm.Show();
                            pantallaInicialForm.FormClosed += Logout;
                            string registro = "Inicio de Sesión";
                            auditoria.InsertarAuditoria(registro);
                            this.Hide();

                        }else
                        {
                            msgError("Usuario Inactivo. Contacte al administrador.");
                            txtContra.Text="";
                            txtMail.Focus();
                        }
                    }
                    else
                    {
                        // Mostrar un mensaje de error o realizar alguna otra acción en caso de inicio de sesión fallido
                        msgError("Credenciales inválidas. Inténtalo de nuevo.");
                        txtContra.Text="";
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new CambiarContra();
            form.ShowDialog();
        }


        //validaciones
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

        private void InicioSesion_Activated(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
    }

