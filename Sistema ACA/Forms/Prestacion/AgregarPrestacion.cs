using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN.Cache;
using COMUN.Interfaces.Strategy;
using Controladora;
using COMUN.Interfaces;

namespace Sistema_ACA.Forms.Prestacion
{
    public partial class AgregarPrestacion : Form
    {
        public Prestaciones prestacion { get; set;} 
        CnPrestacion _CnPrestacion = new CnPrestacion();
        public string pdf { get; set; }

        public AgregarPrestacion()
        {
            InitializeComponent();
        }


        private void AgregarPrestacion_Load(object sender, EventArgs e)
        {
            CargarDGV();
        }

        public void CargarDGV()
        {
            _CnPrestacion.CargarPrestaciones();
            dgvPres.Columns.Add("Nombre Prestacion", "Nombre Prestacion");
            dgvPres.Columns.Add("Limite", "Limite");
            dgvPres.Columns.Add("Cuotas", "Cuotas");
            dgvPres.Rows.Add("Ayuda Economica Ordinaria", AyudaEconomicaOrdinaria.limite, AyudaEconomicaOrdinaria.cuotas);
            dgvPres.Rows.Add("Ayuda Economica Salud", AyudaEconomicaSalud.limite, AyudaEconomicaSalud.cuotas);
            dgvPres.Rows.Add("Odontologia", Odontologia.limite, Odontologia.cuotas);
            dgvPres.Rows.Add("Optica", Optica.limite, Optica.cuotas);
            dgvPres.Rows.Add("Farmacia", Farmacia.limite, Farmacia.cuotas);
            dgvPres.Rows.Add("Subsidio Escolaridad", SubsidioEscolar.limite, SubsidioEscolar.cuotas);
            dgvPres.Rows.Add("Subsidio Casamiento", SubsidioCasamiento.limite, SubsidioCasamiento.cuotas);
            dgvPres.Rows.Add("Subsidio Nacimiento", SubsidioNacimiento.limite, SubsidioNacimiento.cuotas);
            dgvPres.Columns[0].Width= 400;
            dgvPres.Columns[1].Width = 200;
            dgvPres.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvPres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nupCuotas.Maximum = Convert.ToInt32(dgvPres.CurrentRow.Cells[2].Value);
            nudMonto.Maximum = Convert.ToInt32(dgvPres.CurrentRow.Cells[1].Value);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(dgvPres.CurrentRow != null)
            {
                if(nudMonto.Value > 0 && nupCuotas.Value > 0)
                {
                    if (dgvPres.CurrentRow.Cells[0].Value.ToString() == "Subsidio Escolaridad" || dgvPres.CurrentRow.Cells[0].Value.ToString() == "Subsidio Casamiento" || dgvPres.CurrentRow.Cells[0].Value.ToString() == "Subsidio Nacimiento")
                    {
                        BuscadorPDF buscadorPDF = new BuscadorPDF();
                        buscadorPDF._AgregarPrestacion = this;
                        buscadorPDF.ShowDialog();
                    }
                    else
                    {
                        enviarPrestacion();
                    }
                   
                }
                else
                {
                    MessageBox.Show("El monto y las cuotas deben ser mayores a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una prestacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void enviarPrestacion()
        {
            prestacion.CargarDGV(dgvPres.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(nudMonto.Value), Convert.ToInt32(nupCuotas.Value), pdf);
            MessageBox.Show("Prestacion agregada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
