using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controladora;
using COMUN;

namespace Sistema_ACA
{
    public partial class ABMProveedores : Form
    {
        CnProveedor cnProv = new CnProveedor();

        public ABMProveedores()
        {
            InitializeComponent();
        }

        private void ABMProveedores_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        public void ModificacionForm()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            btnSalir.Visible = false;
            lblABM.Visible = false;
            btnMarco.Size = new Size(613, 397);
            btnMarco.Location = new Point(0, 0);
        }
        private void ActualizarDataGridView()
        {
            LimpiarDataGridView();
            dgvProv.DataSource = cnProv.MostrarProv();
            confiDGV();
        }

        private void LimpiarDataGridView()
        {
            dgvProv.DataSource = null;
        }

        public void confiDGV()
        {
            dgvProv.Columns[0].Width = 50;
            dgvProv.Columns[1].Width = 100;
            dgvProv.Columns[2].Width = 100;
            dgvProv.Columns[3].Width = 100;
            dgvProv.Columns[4].Width = 100;
            dgvProv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            if(txtNombrePro.Text == null || txtNombrePro.Text == "Nombre" || txtDirePro.Text == null || txtDirePro.Text == "Direccion" || txtCuilPro.Text == null || txtCuilPro.Text == "Cuil" || txtTelPro.Text == null || txtTelPro.Text == "Telefono")
            {
                MessageBox.Show("Porfavor ingrese valores en todas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cnProv.VerificarProv(txtNombrePro.Text, txtDirePro.Text, txtCuilPro.Text, txtTelPro.Text) > 0)
                {
                    MessageBox.Show("El proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        LimpiarDataGridView();
                        cnProv.InsertarProv(txtNombrePro.Text, txtDirePro.Text, txtCuilPro.Text, txtTelPro.Text);
                        MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarDataGridView();
                        txtNombrePro.Text = "Nombre:";
                        txtNombrePro.ForeColor = Color.DimGray;
                        txtDirePro.Text = "Direccion:";
                        txtDirePro.ForeColor = Color.DimGray;
                        txtCuilPro.Text = "Cuil:";
                        txtCuilPro.ForeColor = Color.DimGray;
                        txtTelPro.Text = "Telefono:";
                        txtTelPro.ForeColor = Color.DimGray;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if(dgvProv.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvProv.CurrentRow.Cells[0].Value);
                    cnProv.ModificarProv(id, txtNombrePro.Text, txtDirePro.Text, txtCuilPro.Text, txtTelPro.Text);
                    MessageBox.Show("Los datos se han modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDataGridView(); 
                    ActualizarDataGridView();
                    txtNombrePro.Text = "Nombre:";
                    txtNombrePro.ForeColor = Color.DimGray;
                    txtDirePro.Text = "Direccion:";
                    txtDirePro.ForeColor = Color.DimGray;
                    txtCuilPro.Text = "Cuil:";
                    txtCuilPro.ForeColor = Color.DimGray;
                    txtTelPro.Text = "Telefono:";
                    txtTelPro.ForeColor = Color.DimGray;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if(dgvProv.SelectedRows.Count > 0)
            {
                if (dgvProv.CurrentRow.Cells[5].Value.ToString() == "Activo")
                {
                    MessageBox.Show("El proveedor ya se encuentra activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        int id = Convert.ToInt32(dgvProv.CurrentRow.Cells[0].Value);
                        cnProv.DarAltaProv(id);
                        MessageBox.Show("El proveedor se ha dado de alta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarDataGridView();
                        ActualizarDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al dar de alta el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvProv.SelectedRows.Count > 0)
            {
                if (dgvProv.CurrentRow.Cells[5].Value.ToString() == "Inactivo")
                {
                    MessageBox.Show("El proveedor ya se encuentra inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        if (dgvProv.CurrentRow != null)
                        {
                            int id = Convert.ToInt32(dgvProv.CurrentRow.Cells[0].Value);
                            cnProv.DarBajaProv(id);
                            MessageBox.Show("El proveedor se ha dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarDataGridView(); 
                            ActualizarDataGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al dar de baja el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validaciones
        private void txtNombrePro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }
        private void txtTelPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void txtCuilPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.Handled = true;
        }
        private void txtNombrePro_Enter(object sender, EventArgs e)
        {
            if (txtNombrePro.Text == "Nombre:")
            {
                txtNombrePro.Text = "";
                txtNombrePro.ForeColor = Color.Black;
            }
        }
        private void txtNombrePro_Leave(object sender, EventArgs e)
        {
            if (txtNombrePro.Text == "")
            {
                txtNombrePro.Text = "Nombre:";
                txtNombrePro.ForeColor = Color.DimGray;
            }
        }
        private void txtDirePro_Enter(object sender, EventArgs e)
        {
            if (txtDirePro.Text == "Direccion:")
            {
                txtDirePro.Text = "";
                txtDirePro.ForeColor = Color.Black;
            }
        }
        private void txtDirePro_Leave(object sender, EventArgs e)
        {
            if (txtDirePro.Text == "")
            {
                txtDirePro.Text = "Direccion:";
                txtDirePro.ForeColor = Color.DimGray;
            }
        }
        private void txtCuilPro_Enter(object sender, EventArgs e)
        {
            if (txtCuilPro.Text == "Cuil:")
            {
                txtCuilPro.Text = "";
                txtCuilPro.ForeColor = Color.Black;
            }
        }
        private void txtCuilPro_Leave(object sender, EventArgs e)
        {
            if (txtCuilPro.Text == "")
            {
                txtCuilPro.Text = "Cuil:";
                txtCuilPro.ForeColor = Color.DimGray;
            }
        }
        private void txtTelPro_Enter(object sender, EventArgs e)
        {
            if (txtTelPro.Text == "Telefono:")
            {
                txtTelPro.Text = "";
                txtTelPro.ForeColor = Color.Black;
            }
        }
        private void txtTelPro_Leave(object sender, EventArgs e)
        {
            if (txtTelPro.Text == "")
            {
                txtTelPro.Text = "Telefono:";
                txtTelPro.ForeColor = Color.DimGray;
            }
        }
        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.Red;
        }
        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.White;
        }

        private void dgvProv_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProv.SelectedRows.Count > 0)
            {
                txtNombrePro.Text = dgvProv.CurrentRow.Cells[1].Value.ToString();
                txtNombrePro.ForeColor = Color.Black;
                txtDirePro.Text = dgvProv.CurrentRow.Cells[2].Value.ToString();
                txtDirePro.ForeColor = Color.Black;
                txtCuilPro.Text = dgvProv.CurrentRow.Cells[3].Value.ToString();
                txtCuilPro.ForeColor = Color.Black;
                txtTelPro.Text = dgvProv.CurrentRow.Cells[4].Value.ToString();
                txtTelPro.ForeColor = Color.Black;
            }
        }

    }
}
