using COMUN;
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

namespace Sistema_ACA.Forms
{
    public partial class ABMUsuarios:Form
    {
        CargaDatosUsuarios Formcarga = new CargaDatosUsuarios();
        CnUsuario usuario = new CnUsuario();
        int busqueda = 0;
        int currentPage = 1;
        int conteo = 1;

        public ABMUsuarios()
        {
            InitializeComponent();
        }
        
        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            MetodosComunes.CargarModulosFormularios(this.Name, flowLayoutPanel1);
            cmbBusqueda.SelectedIndex = 0;
        }

        private void ActualizarDataGridView()
        {
            bindingSource1.DataSource = usuario.MostrarUsuarios(currentPage);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvUsuarios.DataSource = bindingSource1;
            confiDGV();
        }

        private void confiDGV()
        {
            dgvUsuarios.Columns[0].Width = 50;
            dgvUsuarios.Columns[1].Width = 150;
            dgvUsuarios.Columns[2].Width = 150;
            dgvUsuarios.Columns[3].Width = 200;
            dgvUsuarios.Columns[4].Width = 150;
            dgvUsuarios.Columns[5].Width = 150;
            dgvUsuarios.Columns[6].Width = 150;
            dgvUsuarios.Columns[7].Width = 150;
            dgvUsuarios.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        //botones principales
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formcarga.Modo = "Agregar";
            Formcarga.fomABMUsuario = this;
            Formcarga.ShowDialog();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                Formcarga.id_usuario = id;
                Formcarga.Modo = "Editar";
                Formcarga.ShowDialog();
            }
            else {
                MessageBox.Show("Seleccione un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if(dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                if(usuario.AltaUsuario(id)== true)
                {
                    MessageBox.Show("El usuario ha sido dado de alta.","Alta exitosa", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = usuario.MostrarUsuarios(currentPage);
                }
                else { MessageBox.Show("El usuario ya esta en alta.", "Alta fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else {MessageBox.Show("Seleccione un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value.ToString());
                if (usuario.BajaUsuario(id) == true)
                {
                    MessageBox.Show("El usuario ha sido dado de baja.", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = usuario.MostrarUsuarios(currentPage);
                }
                else { MessageBox.Show("El usuario ya esta en baja.", "Baja fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else { MessageBox.Show("Seleccione un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        //filtros
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBusqueda.Text != "")
            {
                bindingSource1.DataSource = usuario.MostrarUsuariosFiltrados(cmbBusqueda.SelectedItem.ToString(), txtBusqueda.Text, currentPage);
            }
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBusqueda.SelectedIndex == 0)
            {
                txtBusqueda.Visible = false;
                btnBuscar.Visible = false;
                btnBorrar.Visible = false;
                busqueda = 0;
                bindingSource1.DataSource = usuario.MostrarUsuarios(currentPage);
            }else if (cmbBusqueda.SelectedIndex ==3)
            {
                txtBusqueda.Visible = true;
                btnBuscar.Visible = true;
                btnBorrar.Visible = true;
                txtBusqueda.Text = "";
                busqueda = 3;
                txtBusqueda.Focus();
            }
            else
            {
                busqueda = 0;
                txtBusqueda.Visible = true;
                btnBuscar.Visible = true;
                btnBorrar.Visible = true;
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(busqueda == 3) { MetodosComunes.KeyPressSoloNumeros(e); }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            cmbBusqueda.SelectedIndex = 0;
            txtBusqueda.Text = "";  
            bindingSource1.DataSource = usuario.MostrarUsuarios(currentPage);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if(currentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage--;
                ActualizarDataGridView();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 15)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage++;
                ActualizarDataGridView();
            }
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            if (currentPage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }
    }
}
