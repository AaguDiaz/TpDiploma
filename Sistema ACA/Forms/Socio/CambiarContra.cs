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
using COMUN;
using System.Net.Mail;

namespace Sistema_ACA
{
    public partial class CambiarContra : Form
    {
        public CambiarContra()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CambiarContra_Load(object sender, EventArgs e)
        {

        }
        private void txtCOD_Enter(object sender, EventArgs e)
        {
            if (txtCOD.Text == "CÓDIGO")
            {
                txtCOD.Text = "";
                txtCOD.ForeColor = Color.Black;
            }
        }

        private void txtCOD_Leave(object sender, EventArgs e)
        {
            if (txtCOD.Text == "")
            {
                txtCOD.Text = "CÓDIGO";
                txtCOD.ForeColor = Color.DimGray;
            }
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
        private void txtConfirmar_Enter(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "CONFIRMAR CONTRASEÑA")
            {
                txtConfirmar.Text = "";
                txtConfirmar.ForeColor = Color.Black;
                txtConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmar_Leave(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "CONFIRMAR CONTRASEÑA";
                txtConfirmar.ForeColor = Color.DimGray;
                txtConfirmar.UseSystemPasswordChar = false;
            }
        }
        Random random = new Random();
        
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtMail.Text != "MAIL")
            {
                int codigorecuperacion = random.Next(1000, 99999);
                MailCache.cod = codigorecuperacion;
                var user = new CnUsuario();
                if(user.enviarCodigo(txtMail.Text, codigorecuperacion)== "Mail no registrado")
                {
                   MessageBox.Show("Mail no registrado");
                    return;
                }
                  btnVerificar.Enabled = true;
                  msgError("Revisa tu correro electronico para el codigo.");
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if(txtCOD.Text != "CODIGO")
            {

                if(int.Parse(txtCOD.Text) == MailCache.cod)
                {
                    btnConfirmar.Visible = true;
                    btnConfirmar.Enabled = true;
                    txtContra.Visible = true;
                    txtConfirmar.Visible = true;
                    btnEnviar.Enabled = false;
                    btnVerificar.Enabled= false;
                    txtCOD.Enabled = false;
                    txtMail.Enabled = false;
                    MessageBox.Show("Ingrese su nueva contraseña");
                }
                else
                {
                    MessageBox.Show("Código erroneo.");
                }
            }
        }
        private void msgError(string msg)
        {
            lblError.Text = "    " + msg;
            lblError.Visible = true;
        }

        private void txtCOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtContra.Text!="CONTRASEÑA"||txtContra.Text!="")
            {
                if(txtContra.Text == txtConfirmar.Text)
                {
                    var user = new CnUsuario();
                    user.cambiarContra(txtMail.Text, txtContra.Text);
                    MessageBox.Show("Contraseña cambiada con exito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una contraseña.");
            }
        }
    }
}
