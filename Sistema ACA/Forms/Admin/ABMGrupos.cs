using COMUN;
using COMUN.Seguridad;
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

namespace Sistema_ACA.Forms.Admin
{
    public partial class ABMGrupos : Form
    {
        CnGrupos cnGrupo = new CnGrupos();
        int currentPage = 1;
        int conteo = 1;

        public ABMGrupos()
        {
            InitializeComponent();
        }

        private void ABMGrupos_Load(object sender, EventArgs e)
        {
            cbFiltro.SelectedIndex = 0;
            CargarGrupos(1);
            dgvGrupos.ClearSelection();
            MetodosComunes.CargarModulosFormularios("ABMGrupos", flpControles);
        }


        public void actualizarGrupos()
        {
            CargarGrupos(1);
        }

        private void CargarGrupos(int filtro)
        {
            if (filtro == 1)
            {
                bindingSource1.DataSource = cnGrupo.MostrarGruposFiltro(1, currentPage);
            }
            else if (filtro == 2)
            {
                bindingSource1.DataSource = cnGrupo.MostrarGruposFiltro(2, currentPage);
            }
            else if (filtro == 3)
            {
                bindingSource1.DataSource = cnGrupo.MostrarGruposFiltro(3, currentPage);
            }
            else if (filtro == 0)
            {
                bindingSource1.DataSource = cnGrupo.MostrarGruposFiltro(1, currentPage);
            }
            bindingNavigator1.BindingSource = bindingSource1;
            dgvGrupos.DataSource = bindingSource1;
            dgvGrupos.Columns[0].Width = 100;
            dgvGrupos.Columns[1].Width = 200;
            dgvGrupos.Columns[2].Width = 500;
            dgvGrupos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }
        private void CargarTreeView()
        {
            tvGrupos.Nodes.Clear();
            if (dgvGrupos.CurrentCell.Value != null)
            {
                string grupoSeleccionado = dgvGrupos.CurrentRow.Cells[1].Value.ToString();
                Grupo grupo = cnGrupo.MostrarGrupoSegunNombre(grupoSeleccionado);
                if (grupo != null)
                {
                    TreeNode existingNode = tvGrupos.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == grupo.nombre_grupo);
                    
                    if (existingNode == null)
                    {
                        TreeNode grupoNode = new TreeNode(grupo.nombre_grupo);
                        foreach (Permisos permiso in grupo.permisos)
                        {
                            TreeNode permisoNode = new TreeNode(permiso.nombre_permiso);
                            TreeNode formularioNode = new TreeNode(permiso.formulario.nombre_formulario);
                            permisoNode.Nodes.Add(formularioNode);
                            foreach (Modulos modulo in permiso.modulos)
                            {
                                TreeNode moduloNode = new TreeNode(modulo.nombre_modulo);
                                formularioNode.Nodes.Add(moduloNode);
                            }
                            grupoNode.Nodes.Add(permisoNode);
                        }
                        tvGrupos.Nodes.Add(grupoNode);
                        tvGrupos.ExpandAll();
                    }
                }
            }
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarTreeView();
        }
        private void dgvGrupos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CargarTreeView();
        }
        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            CargarTreeView();
        }

        //botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            Grupos form = new Grupos();
            form.modo = "Agregar";
            form.ShowDialog();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentCell.Value != null)
            {
                string grupoSeleccionado = dgvGrupos.CurrentRow.Cells[1].Value.ToString();
                Grupo grupo = cnGrupo.MostrarGrupoSegunNombre(grupoSeleccionado);
                if (grupo != null)
                {
                    Grupos form = new Grupos();
                    form.FormABMGrupos= this;
                    form.modo = "Editar";
                    form.grupoDelEditar = grupo;
                    form.ShowDialog();
                }
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if(dgvGrupos.CurrentCell.Value != null)
            {
                string grupoSeleccionado = dgvGrupos.CurrentRow.Cells[1].Value.ToString();
                string estado = dgvGrupos.CurrentRow.Cells[3].Value.ToString();
                if (grupoSeleccionado != null)
                {
                    if (estado == "Baja")
                    {
                        if (cnGrupo.CambiarEstadoGrupo(grupoSeleccionado, 4))
                        {
                            MessageBox.Show("Grupo dado de alta correctamente", "Alta de grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarGrupos(cbFiltro.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Error al dar de alta el grupo", "Alta de grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El grupo seleccionado no se encuentra dado de baja", "Alta de grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }   
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentCell.Value != null)
            {
                string grupoSeleccionado = dgvGrupos.CurrentRow.Cells[1].Value.ToString();
                string estado = dgvGrupos.CurrentRow.Cells[3].Value.ToString();
                if (grupoSeleccionado != null)
                {
                    if (estado == "Alta")
                    {
                        if (cnGrupo.CambiarEstadoGrupo(grupoSeleccionado, 5))
                        {
                            MessageBox.Show("Grupo dado de baja correctamente", "Baja de grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarGrupos(cbFiltro.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Error al dar de baja el grupo", "Baja de grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El grupo seleccionado no se encuentra dado de alta", "Baja de grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        //Navegacion y filtro
        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFiltro.SelectedIndex == 1)
            {
                CargarGrupos(1);
            }
            else if (cbFiltro.SelectedIndex == 2)
            {
                CargarGrupos(2);
            }
            else if(cbFiltro.SelectedIndex == 3)
            {
                CargarGrupos(3);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage--;
                CargarGrupos(cbFiltro.SelectedIndex);
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.Rows.Count == 15)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                currentPage++;
                CargarGrupos(cbFiltro.SelectedIndex);
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
