using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_ACA.Forms.Prestacion
{
    public partial class BuscadorPDF : Form
    {
        public AgregarPrestacion _AgregarPrestacion { get; set; }
        string filePath;
        public BuscadorPDF()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                webBrowser1.Navigate(filePath);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void BuscadorPDF_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Para solicitar un subsidio debera adjuntar un comprobante, en el caso de escolaridad un comprobante de alumno regular, en caso de nacimiento el acta de nacimiento y en el caso de casamiento el registro civil.", "Agregar PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(filePath != null)
            {
                _AgregarPrestacion.pdf = filePath;
                _AgregarPrestacion.enviarPrestacion();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
