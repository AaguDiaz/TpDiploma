using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN.Seguridad;
using Controladora;
using COMUN.Seguridad.Composite;

namespace Sistema_ACA.Forms.Admin
{
    public partial class Grupos : Form
    {
        public CargaDatosUsuarios CargaDatosUsuarios { get; set; }
        public ABMGrupos FormABMGrupos { get; set; }
        CnPermisos permisos = new CnPermisos();
        CnGrupos grupos = new CnGrupos();
        public Grupo grupoDelEditar { get; set; }

        public string modo;

        public Grupos()
        {
            InitializeComponent();
        }

        private void Grupos_Load(object sender, EventArgs e)
        {
            cbSecciones.SelectedIndex = 0;
            if(modo == "Editar")
            {
                txtNombre.Text = grupoDelEditar.nombre_grupo;
                txtDesc.Text = grupoDelEditar.descripcion_grupo;
                foreach(Permisos permiso in grupoDelEditar.permisos)
                {
                    TreeNode permisoNode = new TreeNode(permiso.nombre_permiso);
                    TreeNode formularioNode = new TreeNode(permiso.formulario.nombre_formulario);
                    permisoNode.Nodes.Add(formularioNode);
                    foreach(Modulos modulo in permiso.modulos)
                    {
                        TreeNode moduloNode = new TreeNode(modulo.nombre_modulo);
                        formularioNode.Nodes.Add(moduloNode);
                    }
                    tvGrupo.Nodes.Add(permisoNode);
                    tvGrupo.ExpandAll();
                }

                foreach (TreeNode node in tvGrupo.Nodes)
                {
                    // Recorrer todos los CheckBoxes del CheckedListBox
                    for (int i = 0; i < clbPermisos.Items.Count; i++)
                    {
                        // Si el nombre del nodo coincide con el nombre del CheckBox
                        if (node.Text == clbPermisos.Items[i].ToString())
                        {
                            // Marcar el CheckBox
                            clbPermisos.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void cbSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbPermisos.Items.Clear();
            foreach (string permiso in permisos.MostrarPermisosSegunSeccion(cbSecciones.SelectedIndex))
            {
                clbPermisos.Items.Add(permiso);
            }
            foreach (TreeNode node in tvGrupo.Nodes)
            {
                // Recorrer todos los CheckBoxes del CheckedListBox
                for (int i = 0; i < clbPermisos.Items.Count; i++)
                {
                    // Si el nombre del nodo coincide con el nombre del CheckBox
                    if (node.Text == clbPermisos.Items[i].ToString())
                    {
                        // Marcar el CheckBox
                        clbPermisos.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void clbPermisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string permisoSeleccionado = clbPermisos.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked) //(1) El CheckBox se marcó?
            {
                Permisos permiso = Permisos.PermisosPorFormulario.Find(p => p.nombre_permiso == permisoSeleccionado);
                if (permiso != null)// (2) Verdadero. Existe el permiso seleccionado en la lista de permisos del furmulario?
                {
                    TreeNode existingNode = tvGrupo.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == permiso.nombre_permiso); 
                    if (existingNode == null)// (3) Verdadero. Existe el nodo?
                    {
                        //(4) Verdadero. Crear un nodo para el permiso
                        TreeNode permisoNode = new TreeNode(permiso.nombre_permiso);
                        TreeNode formularioNode = new TreeNode(permiso.formulario.nombre_formulario);
                        permisoNode.Nodes.Add(formularioNode);
                        foreach (Modulos modulo in permiso.modulos)
                        {
                            TreeNode moduloNode = new TreeNode(modulo.nombre_modulo);
                            formularioNode.Nodes.Add(moduloNode);
                        }
                        tvGrupo.Nodes.Add(permisoNode);
                        tvGrupo.ExpandAll();
                    }
                }
            }
            else if (e.NewValue == CheckState.Unchecked)// (5) Negavito. El CheckBox se desmarcó?
            {
                foreach (TreeNode node in tvGrupo.Nodes)
                {
                    if (node.Text == permisoSeleccionado)//(6) Verdadero. Existe el nodo?
                    {
                        tvGrupo.Nodes.Remove(node);
                        break;
                    }
                }
            }
            tvGrupo.Refresh();//(7) Fin
        }

        private Composite Grupo()
        {
            string nombreGrupo = txtNombre.Text;
            string descripcionGrupo = txtDesc.Text;

            // Crear un nuevo grupo con el nombre y la descripción
            Composite grupo = new Composite(nombreGrupo, descripcionGrupo);

            // Recorrer cada nodo en el TreeView
            foreach (TreeNode nodo in tvGrupo.Nodes)
            {
                // Crear un nuevo permiso para cada nodo
                Leaf permiso = new Leaf(nodo.Text);

                // Agregar el permiso al grupo
                grupo.Agregar(permiso);
            }

            return grupo;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (txtDesc.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripcion para el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tvGrupo.Nodes.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un permiso para el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(modo == "Editar")
                {
                    if (grupos.EditarGrupo(Grupo(), grupoDelEditar.id_grupo) == true)
                    {
                        MessageBox.Show("Grupo editado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormABMGrupos.actualizarGrupos();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El nombre del grupo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(modo == "Agregar")
                {
                    if(grupos.AgregarGrupo(Grupo())==true)
                    {
                        MessageBox.Show("Grupo agregado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaDatosUsuarios.actualizarGrupos();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El nombre del grupo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la operacion?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 this.Close();
        }
    }
}
