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
using COMUN;
using COMUN.Seguridad;
using Controladora.Seguridad;

namespace Sistema_ACA
{
    public partial class PantallaPrincipal : Form
    {
        CnAuditoria cnAuditoria = new CnAuditoria();
        private Form formActivo = null;
        private InicioSesion forminicio;
        private int close = 0;
        private int cerrando = 0;

        public PantallaPrincipal(InicioSesion forminicio)
        {
            InitializeComponent();
            this.forminicio = forminicio;
        }
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            Cargarpermisos();
            
        }
        

        private void Cargarpermisos()
        {
            List<Permisos> permisosActivos = MetodosComunes.ObtenerPermisosActivos();
            int contador = 0;
            foreach(ToolStripMenuItem item in menuStrip1.Items)
            {
                int contadorAdmin = 0;
                if(item.HasDropDownItems)
                {
                    foreach(ToolStripMenuItem item2 in item.DropDownItems)
                    {
                        if(item2.HasDropDownItems)
                        {
                            foreach(ToolStripMenuItem item3 in item2.DropDownItems)
                            {
                                if(permisosActivos.Exists(x => x.formulario.nombre_formulario == item3.Tag.ToString()))
                                {
                                    item3.Visible = true;
                                }else
                                {
                                    contador++;
                                    item3.Visible = false;
                                }
                            }
                            if(contador == item2.DropDownItems.Count)
                            {
                                contadorAdmin++;
                                item2.Visible = false;
                            }
                            else
                            {

                                item2.Visible = true;
                            }
                        }
                        else
                        {
                            if(permisosActivos.Exists(x => x.formulario.nombre_formulario == item2.Tag.ToString()))
                            {
                                item2.Visible = true;
                            }else
                            {
                                contadorAdmin++;
                                item2.Visible = false;
                            }
                        }
                    }
                            if(contadorAdmin == item.DropDownItems.Count)
                            {
                                item.Visible = false;
                            }
                            else
                            {
                                item.Visible = true;
                            }
                }
                else
                {
                    if(permisosActivos.Exists(x => x.formulario.nombre_formulario == item.Tag.ToString()))
                    {
                        item.Visible = true;
                    }else
                    {
                        item.Visible = false;
                    }
                }
            }
            estadoDeCuentaToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = true;
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
                string registro = "Cierre de sesión";
                cnAuditoria.InsertarAuditoria(registro);
                MetodosComunes.CerrarSesion();
                this.Close();
                forminicio.Show();
            }
        }



        private void PantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close != 1)
            {
                cerrando++;
                if (cerrando == 1)
                {
                    string registro = "Cierre de sesión";
                    cnAuditoria.InsertarAuditoria(registro);
                }
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

        private void repotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new Reportes());
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new ABMGrupos());
        }

        private void pedidosPrestacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(new ABMPedidosYPrestaciones());
        }

        private void audiTMSI_Click(object sender, EventArgs e)
        {
            abrirForm(new Auditoria());
        }
    }
    }

