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
using COMUN.Cache;
using Modelo;

namespace Sistema_ACA.Forms
{
    public partial class CargaDatosUsuarios : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public string Modo { get; set; }
        public int id_usuario { get; set; }
        CnUsuario usuario = new CnUsuario();
        CnPermisosYGrupos cn = new CnPermisosYGrupos();
        DataGridViewCell celdaActual;
        int indiceColumna;
        bool Repetido;
        object valorCelda;
        object valorActual;

        public CargaDatosUsuarios()
        {
            InitializeComponent();
        }
        private void CargaDatosUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Carga de datos
        private void CargaDatosUsuarios_Load(object sender, EventArgs e)
        {

            if (Modo == "Editar")
            {
                CargarTXT();
                CargarDgvPer();
                CargarDgvGrup();
            }
            else if (Modo == "Agregar")
            {
                RestablecerTXT();
                CargarDgvPer();
                CargarDgvGrup();
            }
        }
        private void CargarDgvGrup()
        {

            dgvGrupos.Columns.Clear();
            dgvGrupos.Columns.Add("Actuales", "Actuales");
            dgvGrupos.Columns.Add("Todos", "Todos");

            List<string> gruposActuales = CacheEditarUsuario.gruposUsuario;
            DataTable dt2 = cn.MostrarGrupos();
            if (gruposActuales==null) {
                foreach (DataRow row in dt2.Rows)
                {
                    dgvGrupos.Rows.Add("",row["Grupos"]);
                }
            }
            else { 
                 // Determinar la cantidad de filas que necesitarás en total
                int totalfilasGrupos = Math.Max(gruposActuales.Count, dt2.Rows.Count);
               
                for (int i = 0; i < totalfilasGrupos; i++)
                {
                // Asegúrate de que haya suficientes columnas
                    if (dgvGrupos.Rows.Count <= i)
                    {
                        dgvGrupos.Rows.Add();
                    }
                    // Agregar permiso actual, si está disponible
                    if (i < gruposActuales.Count)
                    {
                        dgvGrupos.Rows[i].Cells["Actuales"].Value = gruposActuales[i];
                    }
                    // Agregar permiso de la DataTable, si está disponible
                    if (i < dt2.Rows.Count)
                    {
                        dgvGrupos.Rows[i].Cells["Todos"].Value = dt2.Rows[i]["Grupos"];
                    }
                }
            }
        }
        private void CargarDgvPer()
        {
            dgvPermisos.Columns.Clear();
            dgvPermisos.Columns.Add("Actuales", "Actuales");
            dgvPermisos.Columns.Add("Todos", "Todos");
            List<string> permisosActuales = CacheEditarUsuario.permisosUsuario;
            DataTable dt = cn.MostrarPermisos();
            if (permisosActuales == null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dgvPermisos.Rows.Add("",row["Permisos"]);
                }
            }
            else
            {
                int totalFilas = Math.Max(permisosActuales.Count, dt.Rows.Count);
                for (int i = 0; i < totalFilas; i++)
                {
                    // Asegúrate de que haya suficientes columnas
                    if (dgvPermisos.Rows.Count <= i)
                    {
                        dgvPermisos.Rows.Add();
                    }

                    // Agregar permiso actual, si está disponible
                    if (i < permisosActuales.Count)
                    {
                        dgvPermisos.Rows[i].Cells["Actuales"].Value = permisosActuales[i];
                    }

                    // Agregar permiso de la DataTable, si está disponible
                    if (i < dt.Rows.Count)
                    {
                        dgvPermisos.Rows[i].Cells["Todos"].Value = dt.Rows[i]["Permisos"];
                    }
                }
            }

        }
        private void CargarTXT()
        {
            usuario.CagarUsuario(id_usuario);
            txtNombre.Text = CacheEditarUsuario.nombre;
            txtNombre.ForeColor = Color.Black;
            txtApellido.Text = CacheEditarUsuario.apellido;
            txtApellido.ForeColor = Color.Black;
            txtEmail.Text = CacheEditarUsuario.mail;
            txtEmail.ForeColor = Color.Black;
            txtContra.Enabled = false;
            txtDni.Text = CacheEditarUsuario.dni.ToString();
            txtDni.ForeColor = Color.Black;
            txtCvu.Text = CacheEditarUsuario.cvu.ToString();
            txtCvu.ForeColor = Color.Black;
            txtTelefono.Text = CacheEditarUsuario.telefono.ToString();
            txtTelefono.ForeColor = Color.Black;
            txtDireccion.Text = CacheEditarUsuario.direccion;
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
        private void btnEliPer_Click(object sender,EventArgs e)
        {
            celdaActual = dgvPermisos.CurrentCell;

            if (celdaActual != null)
            {
                indiceColumna = celdaActual.ColumnIndex;

                if (indiceColumna == 0)
                {
                    valorCelda = dgvPermisos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value;

                    if (valorCelda != null && !string.IsNullOrEmpty(valorCelda.ToString()))
                    {
                        // Verificar si el valor existe en la lista de permisos
                        
                        foreach (DataGridViewRow fila in dgvPermisos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[0].Value;
                            if (valorActual==valorCelda)
                            {
                                // Eliminar el permiso de la lista
                                List<string> permisosEliminar = new List<string>();
                                permisosEliminar.Add(valorCelda.ToString());
                                CacheEditarUsuario.PermisosQuitar = permisosEliminar;

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
        private void btnEliPGru_Click(object sender, EventArgs e)
        {
            celdaActual = dgvGrupos.CurrentCell;

            if (celdaActual != null)
            {
                indiceColumna = celdaActual.ColumnIndex;

                if (indiceColumna == 0)
                {
                    valorCelda = dgvGrupos.Rows[celdaActual.RowIndex].Cells[indiceColumna].Value;

                    if (valorCelda != null && !string.IsNullOrEmpty(valorCelda.ToString()))
                    {
                        // Verificar si el valor existe en la tabla de grupos

                        foreach (DataGridViewRow fila in dgvGrupos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[0].Value;
                            if (valorActual == valorCelda)
                            {
                                // Eliminar el grupo de la lista
                                List<string> gruposEliminar = new List<string>();
                                gruposEliminar.Add(valorCelda.ToString());
                                CacheEditarUsuario.GruposQuitar = gruposEliminar;

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
        private void btnAgrPer_Click(object sender, EventArgs e)
        {
            celdaActual = dgvPermisos.CurrentCell;
            if (celdaActual != null) //verificar si se selecciono una celda
            {
                indiceColumna = celdaActual.ColumnIndex;
                if(indiceColumna==1)  // verifica si la celda seleccionada es la columna "Todos"
                {
                    //verifica que no sea nula la casilla
                    if (dgvPermisos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString() != null)
                    {
                        valorCelda = dgvPermisos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString();
                        Repetido = false;

                        foreach (DataGridViewRow fila in dgvPermisos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[0].Value;

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
                                valorActual = fila.Cells[0].Value;

                                if (valorActual == null || string.IsNullOrEmpty(valorActual.ToString()))
                                {
                                    // Agregar el valor deseado a la primera columna de la fila encontrada
                                    fila.Cells[0].Value = valorCelda;
                                    // Agregar el permiso al constructor PermisoAgregar
                                    List<string> permisosAgregar = new List<string>();
                                    permisosAgregar.Add(valorCelda.ToString());
                                    CacheEditarUsuario.PermisosAgregar = permisosAgregar;
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
        private void btnAgrGru_Click(object sender, EventArgs e)
        {
            celdaActual = dgvGrupos.CurrentCell;
            if (celdaActual != null) //verificar si se selecciono una celda
            {
                indiceColumna = celdaActual.ColumnIndex;
                if (indiceColumna == 1)  // verifica si la celda seleccionada es la columna "Todos"
                {
                    //verifica que no sea nula la casilla
                    if (dgvGrupos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString() != null)
                    {
                        valorCelda = dgvGrupos.Rows[celdaActual.RowIndex].Cells["Todos"].Value.ToString();
                        Repetido = false;

                        foreach (DataGridViewRow fila in dgvGrupos.Rows)
                        {
                            // Obtén el valor de la celda en la primera columna
                            valorActual = fila.Cells[0].Value;

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
                                valorActual = fila.Cells[0].Value;

                                if (valorActual == null || string.IsNullOrEmpty(valorActual.ToString()))
                                {
                                    // Agregar el valor deseado a la primera columna de la fila encontrada
                                    fila.Cells[0].Value = valorCelda;
                                    // Agregar el permiso al constructor PermisoAgregar
                                    List<string> gruposAgregar = new List<string>();
                                    gruposAgregar.Add(valorCelda.ToString());
                                    CacheEditarUsuario.GruposAgregar = gruposAgregar;
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
            }else if (fila.Cells[0].Value == null)
            {
                MessageBox.Show("Ingrese al menos un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (Modo == "Agregar")
            {

            }else if(Modo=="Editar")
            {
                if (usuario.EditarUsuario(id_usuario, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtDni.Text, txtCvu.Text, txtTelefono.Text, txtDireccion.Text) == true)
                {
                    MessageBox.Show("La edicion ha sido cargada exitosamanete.","Edicion exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    this.Close();
                }
            }
            

        }



        // validaciones
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

    }
}
