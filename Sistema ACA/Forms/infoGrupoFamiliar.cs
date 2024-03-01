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
    public partial class infoGrupoFamiliar : Form
    {
        CnGrupoFamiliar cnGrupoF = new CnGrupoFamiliar();
        string filePath;
        public infoGrupoFamiliar()
        {
            InitializeComponent();
        }
        private void infoGrupoFamiliar_Load(object sender, EventArgs e)
        {
            cbParentezco.SelectedIndex = 0;
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                webBrowser1.IsWebBrowserContextMenuEnabled = false;
                webBrowser1.Navigate(filePath);
            }
        }
        private void bntCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtDni.Text == "" )
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(dtpNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(cbParentezco.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un parentezco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(cnGrupoF.MandarMail(txtNombre.Text, Convert.ToInt32(txtDni.Text), dtpNacimiento.Value, cbParentezco.Text, filePath))
                {
                    MessageBox.Show("Solicitud enviada con éxito", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al enviar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloLetras(e);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosComunes.KeyPressSoloNumeros(e);
        }
    }
}
