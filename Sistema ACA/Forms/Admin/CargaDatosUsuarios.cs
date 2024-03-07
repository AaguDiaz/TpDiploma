using COMUN;
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
using Controladora;
using Sistema_ACA.Forms.Admin;
using COMUN.Seguridad;

namespace Sistema_ACA.Forms
{
    public partial class CargaDatosUsuarios : Form
    {
        public ABMUsuarios fomABMUsuario { get; set; } 
        public string Modo { get; set; }
        public int id_usuario { get; set; }

        
        CnUsuario usuario = new CnUsuario();
        CnGrupos cnGrupo = new CnGrupos();
        CnPermisos cnPermiso = new CnPermisos();
        CnCaches caches = new CnCaches();
        CnGrupoFamiliar cnGrupoFamiliar = new CnGrupoFamiliar();
        DataGridViewCell celdaActual;
        DataTable dt = new DataTable();
        int indiceColumna;
        bool Repetido;
        object valorCelda;
        object valorActual;

        public CargaDatosUsuarios()
        {
            InitializeComponent();
        }

        //Carga de datos
        private void CargaDatosUsuarios_Load(object sender, EventArgs e)
        {

            if (Modo == "Editar")
            {
                CargarTXT();
                CargarDgvFamiliares();
                cbParentesco.SelectedIndex = 0;
                panel1.Visible = true;
            }
            else if (Modo == "Agregar")
            {
                id_usuario = 0;
                RestablecerTXT();
                panel1.Visible = false;
            }
            CargarDgvPer();
            MetodosComunes.CargarModulosFormularios("CargaDatosUsuarios", flowLayoutPanel1);
            CargarDgvGrup();
            MetodosComunes.CargarModulosFormularios("CargaDatosUsuarios", flowLayoutPanel2);
        }

        public void actualizarGrupos()
        {
            CargarDgvGrup();
        }

        public void CargarDgvFamiliares()
        {
            dgvGrupoFamiliar.Columns.Clear();
            dgvGrupoFamiliar.Columns.Add("ID", "ID");
            dgvGrupoFamiliar.Columns.Add("Nombre", "Nombre");
            dgvGrupoFamiliar.Columns.Add("Apellido", "Apellido");
            dgvGrupoFamiliar.Columns.Add("DNI", "DNI");
            dgvGrupoFamiliar.Columns.Add("Fecha de nacimiento", "Fecha de nacimiento");
            dgvGrupoFamiliar.Columns.Add("Parentesco", "Parentesco");
            dgvGrupoFamiliar.Columns[0].Width = 50;
            dgvGrupoFamiliar.Columns[1].Width = 75;
            dgvGrupoFamiliar.Columns[2].Width = 75;
            dgvGrupoFamiliar.Columns[3].Width = 100;
            dgvGrupoFamiliar.Columns[4].Width = 120;
            dgvGrupoFamiliar.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrupoFamiliar.ClearSelection();
            dt.Clear();
            dt = cnGrupoFamiliar.MostrarFamiliares(id_usuario);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dgvGrupoFamiliar.Rows.Add(row["ID_GRUPO"], row["Nombre"], row["Apellido"], row["DNI"] ,row["Fecha_nacimiento"], row["parentesco"]);
                }
            }
        }
        public void CargarDgvGrup()
        {

            dgvGrupos.Columns.Clear();
            dgvGrupos.Columns.Add("Todos", "Todos");
            dgvGrupos.Columns.Add("Actuales", "Actuales");
            dgvGrupos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrupos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            List<Grupo> GruposActuales = usuario.grupoUsuario(id_usuario);
            dt.Clear();
            dt = cnGrupo.MostrarGrupos();
            if (GruposActuales==null) {
                foreach (DataRow row in dt.Rows)
                {
                    dgvGrupos.Rows.Add(row["Grupos"],"");
                }
            }
            else { 
                 // Determinar la cantidad de filas que necesitarás en total
                int totalfilasGrupos = Math.Max(GruposActuales.Count, dt.Rows.Count);
               
                for (int i = 0; i < totalfilasGrupos; i++)
                {
                // Asegúrate de que haya suficientes columnas
                    if (dgvGrupos.Rows.Count <= i)
                    {
                        dgvGrupos.Rows.Add();
                    }
                    // Agregar permiso actual, si está disponible
                    if (i < GruposActuales.Count)
                    {
                        dgvGrupos.Rows[i].Cells["Actuales"].Value = GruposActuales[i].nombre_grupo;
                    }
                    // Agregar permiso de la DataTable, si está disponible
                    if (i < dt.Rows.Count)
                    {
                        dgvGrupos.Rows[i].Cells["Todos"].Value = dt.Rows[i]["Grupos"];
                    }
                }
            }

            dgvGrupos.ClearSelection();
        }
        private void CargarDgvPer()
        {
            dgvPermisos.DataSource = null;
            dgvPermisos.Columns.Clear();
            dgvPermisos.Columns.Add("Todos", "Todos");
            dgvPermisos.Columns.Add("Actuales", "Actuales");
            dgvPermisos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPermisos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            List<Permisos> PermisosActuales = usuario.permisosUsuario(id_usuario);
            dt.Clear();
            dt = cnPermiso.MostrarPermisos();
            if (PermisosActuales == null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dgvPermisos.Rows.Add(row["Permisos"],"");
                }
            }
            else
            {
                int totalFilas = Math.Max(PermisosActuales.Count, dt.Rows.Count);
                for (int i = 0; i < totalFilas; i++)
                {
                    // Asegúrate de que haya suficientes columnas
                    if (dgvPermisos.Rows.Count <= i)
                    {
                        dgvPermisos.Rows.Add();
                    }

                    // Agregar permiso actual, si está disponible
                    if (i < PermisosActuales.Count)
                    {
                        dgvPermisos.Rows[i].Cells["Actuales"].Value = PermisosActuales[i].nombre_permiso;
                    }

                    // Agregar permiso de la DataTable, si está disponible
                    if (i < dt.Rows.Count)
                    {
                        dgvPermisos.Rows[i].Cells["Todos"].Value = dt.Rows[i]["Permisos"];
                    }
                }
            }
            dgvPermisos.ClearSelection();
        }
        private void CargarTXT()
        {
            usuario.CagarUsuario(id_usuario);
            txtNombre.Text = caches.CacheNombre();
            txtNombre.ForeColor = Color.Black;
            txtApellido.Text = caches.CacheApellido();
            txtApellido.ForeColor = Color.Black;
            txtEmail.Text = caches.CacheMail();
            txtEmail.ForeColor = Color.Black;
            txtContra.Enabled = false;
            txtDni.Text = caches.CacheDni();
            txtDni.ForeColor = Color.Black;
            txtCvu.Text = caches.CacheCVU();
            txtCvu.ForeColor = Color.Black;
            txtTelefono.Text = caches.CacheTelefono();
            txtTelefono.ForeColor = Color.Black;
            txtDireccion.Text = caches.CacheDireccion();
            txtDireccion.ForeColor = Color.Black;
        }
        private void RestablecerTXT()
        {
            txtNombre.Text = "Nombre:";
            txtNombre.ForeColor = Color.DimGray;
            txtApellido.Text = "Apellido:";
            txtApellido.ForeColor = Color.DimGray;
            txtEmail.Text = "Email:";
            txtEmail.ForeColor = Color.DimGray;
            txtContra.Text = "Contraseña:";
            txtContra.ForeColor = Color.DimGray;
            txtContra.UseSystemPasswordChar = false;
            txtContra.Enabled = false;
            txtDni.Text = "DNI:";
            txtDni.ForeColor = Color.DimGray;
            txtCvu.Text = "CVU:";
            txtCvu.ForeColor = Color.DimGray;
            txtTelefono.Text = "Telefono:";
            txtTelefono.ForeColor = Color.DimGray;
            txtDireccion.Text = "Direccion:";
            txtDireccion.ForeColor = Color.DimGray;
            
        }



        //Botones
        private void btnAgrPer_Click(object sender, EventArgs e)
        {
            celdaActual = dgvPermisos.CurrentCell;
            if (celdaActual != null) //verificar si se selecciono una celda
            {
                indiceColumna = celdaActual.ColumnIndex;
                if(indiceColumna == 0)  // verifica si la celda seleccionada es la columna "Todos"
                {
                    //verifica que no sea nula la casilla
                    if (dgvPermisos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString() != null)
                    {
                        valorCelda = dgvPermisos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString();
                        Repetido = false;

                        foreach (DataGridViewRow fila in dgvPermisos.Rows)
                        {
                            // Obtén el valor de la celda de la columna "Actuales"
                            valorActual = fila.Cells[1].Value;

                            if (valorActual != null && valorActual.ToString() == valorCelda.ToString()) 
                            {
                                Repetido = true;
                                MessageBox.Show("El usuario ya tiene permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        if(!Repetido)
                        {
                            foreach (DataGridViewRow fila in dgvPermisos.Rows)
                            {
                                valorActual = fila.Cells[1].Value;

                                if (valorActual == null || string.IsNullOrEmpty(valorActual.ToString()))
                                {
                                    // Agregar el valor deseado a la primera columna de la fila encontrada
                                    fila.Cells[1].Value = valorCelda;
                                    dgvPermisos.Refresh();
                                    MessageBox.Show("Se agrego correctamente el permiso", "Permiso agregado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El permiso que selecciono esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso de la columna 'Todos' para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un permiso de la columna 'Todos' para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void btnEliPer_Click(object sender,EventArgs e)
        {
            celdaActual = dgvPermisos.CurrentCell;

            if (celdaActual != null)
            {
                indiceColumna = celdaActual.ColumnIndex;

                if (indiceColumna == 1)
                {
                    valorCelda = dgvPermisos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value;

                    if (valorCelda != null && !string.IsNullOrEmpty(valorCelda.ToString()))
                    {
                        // Verificar si el valor existe en la lista de permisos
                        
                        foreach (DataGridViewRow fila in dgvPermisos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[1].Value;
                            if (valorActual==valorCelda)
                            {
                                // Eliminar el permiso de la celda
                                dgvPermisos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value = null;
                                MessageBox.Show("Se eliminó correctamente el permiso", "Permiso eliminado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un permiso de la columna 'Actuales' existente para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso de la columna 'Actuales' para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgrGru_Click(object sender, EventArgs e)
        {
            celdaActual = dgvGrupos.CurrentCell;
            if (celdaActual != null) //verificar si se selecciono una celda
            {
                indiceColumna = celdaActual.ColumnIndex;
                if (indiceColumna == 0)  // verifica si la celda seleccionada es la columna "Todos"
                {
                    //verifica que no sea nula la casilla
                    if (dgvGrupos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString() != null)
                    {
                        valorCelda = dgvGrupos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString();
                        Repetido = false;

                        foreach (DataGridViewRow fila in dgvGrupos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[1].Value;

                            if (valorActual != null && valorActual.ToString() == valorCelda.ToString())
                            {
                                Repetido = true;
                                MessageBox.Show("El usuario ya tiene este grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        if (!Repetido)
                        {
                            foreach (DataGridViewRow fila in dgvGrupos.Rows)
                            {
                                valorActual = fila.Cells[1].Value;

                                if (valorActual == null || string.IsNullOrEmpty(valorActual.ToString()))
                                {
                                    // Agregar el valor deseado a la primera columna de la fila encontrada
                                    fila.Cells[1].Value = valorCelda;
                                    dgvGrupos.Refresh();
                                    MessageBox.Show("Se agrego correctamente el grupo", "Grupo agregado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El grupo que selecciono esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un grupo de la columna 'Todos' para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un grupo de la columna 'Todos' para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliPGru_Click(object sender, EventArgs e)
        {
            celdaActual = dgvGrupos.CurrentCell;

            if (celdaActual != null)
            {
                indiceColumna = celdaActual.ColumnIndex;

                if (indiceColumna == 1)
                {
                    valorCelda = dgvGrupos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value;

                    if (valorCelda != null && !string.IsNullOrEmpty(valorCelda.ToString()))
                    {
                        // Verificar si el valor existe en la tabla de grupos

                        foreach (DataGridViewRow fila in dgvGrupos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[1].Value;
                            if (valorActual == valorCelda)
                            {
                                // Eliminar el grupo de la celda
                                dgvGrupos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value = null;
                                MessageBox.Show("Se eliminó correctamente el grupo", "Grupo eliminado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un grupo de la columna 'Actuales' existente para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un grupo de la columna 'Actuales' para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un grupo para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNueGru_Click(object sender, EventArgs e)
        {
            Grupos FormGrupos = new Grupos();
            FormGrupos.CargaDatosUsuarios = this;
            FormGrupos.ShowDialog();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro que deseas salir? se perdera todo progreso", "Precausion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
                this.Close();
            }
        }
        private void brnConfirmar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvGrupos.Rows[0];
            if (txtNombre.Text=="Nombre:"||txtNombre.Text==null)
            {
                MessageBox.Show("Ingrese un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtApellido.Text=="Apellido:"||txtApellido.Text==null)
            {
                MessageBox.Show("Ingrese un apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtEmail.Text=="Email:"||txtEmail.Text==null)
            {
                MessageBox.Show("Ingrese un email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtDni.Text=="DNI:"||txtDni.Text==null)
            {
                MessageBox.Show("Ingrese un DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtCvu.Text=="CVU:"||txtCvu.Text==null)
            {
                MessageBox.Show("Ingrese un CVU", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtTelefono.Text=="Telefono:"||txtTelefono.Text==null)
            {
                MessageBox.Show("Ingrese un telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtDireccion.Text=="Direccion:"||txtDireccion.Text==null)
            {
                MessageBox.Show("Ingrese una direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (fila.Cells[1].Value == null)
            {
                MessageBox.Show("Ingrese al menos un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (Modo == "Agregar")
            {
                List<string> permisos = new List<string>();
                List<string> grupos = new List<string>();

                foreach (DataGridViewRow row in dgvPermisos.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        permisos.Add(row.Cells[1].Value.ToString());
                    }
                }
                foreach (DataGridViewRow row in dgvGrupos.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        grupos.Add(row.Cells[1].Value.ToString());
                    }
                }

                if (usuario.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtDni.Text, txtCvu.Text, txtTelefono.Text, txtDireccion.Text, permisos, grupos) == true)
                {
                    
                    MessageBox.Show("El usuario ha sido cargado exitosamanete.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }else if(Modo=="Editar")
            {
                List<string> permisos = new List<string>();
                List<string> grupos = new List<string>();

                foreach (DataGridViewRow row in dgvPermisos.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        permisos.Add(row.Cells[1].Value.ToString());
                    }
                }
                foreach (DataGridViewRow row in dgvGrupos.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        grupos.Add(row.Cells[1].Value.ToString());
                    }
                }

                if (usuario.EditarUsuario(id_usuario, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtDni.Text, txtCvu.Text, txtTelefono.Text, txtDireccion.Text, permisos, grupos) == true)
                {
                    MessageBox.Show("La edicion ha sido cargada exitosamanete.","Edicion exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    this.Close();
                }
            }
            

        }
        private void dgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // limpiar el treeview
            tvPermisos.Nodes.Clear();
            if(dgvPermisos.CurrentCell.Value!=null)
            {
                string permisoSeleccionado = dgvPermisos.CurrentCell.Value.ToString();
                Permisos permiso = cnPermiso.MostrarPermisosSegunNombre(permisoSeleccionado);
                if (permiso != null)
                {
                    TreeNode existingNode = tvPermisos.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == permiso.nombre_permiso);
                    if (existingNode == null)
                    {
                        TreeNode permisoNode = new TreeNode(permiso.nombre_permiso);
                        TreeNode formularioNode = new TreeNode(permiso.formulario.nombre_formulario);
                        permisoNode.Nodes.Add(formularioNode);
                        foreach (Modulos modulo in permiso.modulos)
                        {
                            TreeNode moduloNode = new TreeNode(modulo.nombre_modulo);
                            formularioNode.Nodes.Add(moduloNode);
                        }
                        tvPermisos.Nodes.Add(permisoNode);
                        tvPermisos.ExpandAll();
                    }
                }
            }
        }
        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tvGrupos.Nodes.Clear();
            if (dgvGrupos.CurrentCell.Value != null)
            {
                string grupoSeleccionado = dgvGrupos.CurrentCell.Value.ToString();
                Grupo grupo = cnGrupo.MostrarGrupoSegunNombre(grupoSeleccionado);
                if (grupo != null)
                {
                    TreeNode existingNode = tvGrupos.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == grupo.nombre_grupo);
                    txtDescripcion.Text = grupo.descripcion_grupo;
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


        // validaciones
        #region validaciones
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre:")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre:";
                txtNombre.ForeColor = Color.DimGray;
            }
        }
        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido:")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
            }
        }
        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Text = "Apellido:";
                txtApellido.ForeColor = Color.DimGray;
            }
        }
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email:")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email:";
                txtEmail.ForeColor = Color.DimGray;
            }
        }
        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña:")
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
                txtContra.Text = "Contraseña:";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }
        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDni.Text == "DNI:")
            {
                txtDni.Text = "";
                txtDni.ForeColor = Color.Black;
            }
        }
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                txtDni.Text = "DNI:";
                txtDni.ForeColor = Color.DimGray;
            }
        }
        private void txtCVU_Enter(object sender, EventArgs e)
        {
            if (txtCvu.Text == "CVU:")
            {
                txtCvu.Text = "";
                txtCvu.ForeColor = Color.Black;
            }
        }
        private void txtCVU_Leave(object sender, EventArgs e)
        {
            if (txtCvu.Text == "")
            {
                txtCvu.Text = "CVU:";
                txtCvu.ForeColor = Color.DimGray;
            }
        }
        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Direccion:")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.Black;
            }
        }
        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Direccion:";
                txtDireccion.ForeColor = Color.DimGray;
            }
        }
        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Telefono:")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.Black;
            }
        }
        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Telefono:";
                txtTelefono.ForeColor = Color.DimGray;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloLetras(e);
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloLetras(e);
        }
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }
        private void txtCvu_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }
        #endregion

        private void cbParentesco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgrgarFamiliar_Click(object sender, EventArgs e)
        {
            if(txtNombreg.Text==""||txtApellidog.Text==""||txtDNIg.Text==""||cbParentesco.Text=="Seleccionar")
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(dtpFechaNacimiento.Value>DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cnGrupoFamiliar.agregarFamiliar(id_usuario, txtNombreg.Text, txtApellidog.Text, Convert.ToInt32(txtDNIg.Text), dtpFechaNacimiento.Value, cbParentesco.Text);
                MessageBox.Show("Se agrego el familiar correctamente", "Familiar agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDgvFamiliares();
            }
        }

        private void btnEliminarFamiliar_Click(object sender, EventArgs e)
        {
            if(dgvGrupoFamiliar.CurrentRow!=null)
            {
                int dni = Convert.ToInt32(dgvGrupoFamiliar.CurrentRow.Cells[3].Value);
                cnGrupoFamiliar.EliminarFamiliar(id_usuario, dni);
                CargarDgvFamiliares();
                MessageBox.Show("Se elimino el familiar correctamente", "Familiar eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un familiar para dar de baja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
