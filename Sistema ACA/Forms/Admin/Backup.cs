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
    public partial class Backup : Form
    {
        CnBackup backup = new CnBackup();
        public Backup()
        {
            InitializeComponent();
        }

        private void bttnGenerar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(backup.GenerarBackup());
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup";
            openFileDialog.Filter = "Archivos de backup (*.bak)|*.bak";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtRuta.Text != "")
            {
                MessageBox.Show(backup.RestaurarBackup(txtRuta.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo de backup");
            }
        }
    }
}
