using Controladora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN;

namespace Sistema_ACA.Forms
{
    public partial class ABMUsuarios:Form
    {
        int resultado;
        CargaDatosUsuarios Formcarga= new CargaDatosUsuarios();
        public ABMUsuarios()
        {
            InitializeComponent();
            
        }
        CnUsuario usuario = new CnUsuario();
        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = usuario.MostrarUsuarios();
            lblError.Visible= false;
            lbluno.Visible = false;
        }
        private void error(string mensaje)
        {
            lbluno.Visible = true;
            lblError.Text = " "+mensaje;
            lblError.Visible = true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formcarga.Modo = "Agregar";
            Formcarga.ShowDialog();
            lblError.Visible = false;
            lbluno.Visible = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                Formcarga.id_usuario = id;
                usuario.permisosUsuario(id);
                usuario.grupoUsuario(id);
                Formcarga.Modo = "Editar";
                Formcarga.ShowDialog();
                lblError.Visible = false;
                lbluno.Visible = false;
            }
            else {
                error("Seleccione un usuario"); }
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if(dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                if(usuario.AltaUsuario(id)== true)
                {
                    MessageBox.Show("El usuario ha sido dado de alta.","Alta exitosa", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = usuario.MostrarUsuarios();
                    lblError.Visible = false;
                    lbluno.Visible = false;
                }
                else { MessageBox.Show("El usuario ya esta en alta.", "Alta fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else {error("Seleccione un usuario");}
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                if (usuario.BajaUsuario(id) == true)
                {
                    MessageBox.Show("El usuario ha sido dado de baja.", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = usuario.MostrarUsuarios();
                    lblError.Visible = false;
                    lbluno.Visible = false;
                }
                else { MessageBox.Show("El usuario ya esta en baja.", "Baja fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else { error("Seleccione un usuario"); }
        }
    }
}
