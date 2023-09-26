using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Sistema_ACA
{
    public partial class InicioSesion : Form
    {
        UsuarioService usuario = new UsuarioService();

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

        private void bttnInicio_Click(object sender, EventArgs e)
        {
            if (txtMail.Text != null)
            {
                if (txtContra.Text != null)
                {
                    string mail = txtMail.Text;
                    string contrasena = txtContra.Text;

                    int idPermiso = usuario.IniciarSesion(mail, contrasena);

                    if (idPermiso != -1)
                    {
                        // Si las credenciales son válidas, abrir la pantalla inicial pasando el ID de permiso
                        PantallaPrincipal pantallaInicialForm = new PantallaPrincipal(idPermiso);
                        pantallaInicialForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Mostrar un mensaje de error o realizar alguna otra acción en caso de inicio de sesión fallido
                        MessageBox.Show("Credenciales inválidas. Inténtalo de nuevo.");
                    }
                }
                else MessageBox.Show("Por favor ingresa una contraseña.");
            }
            else
            {
                MessageBox.Show("Por favor Ingresa un Usuario o Mail.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new CambiarContra();
            form.ShowDialog();
        }
    }
    }

