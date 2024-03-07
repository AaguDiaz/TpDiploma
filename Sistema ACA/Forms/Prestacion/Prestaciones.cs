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
using Sistema_ACA.Forms.Prestacion;

namespace Sistema_ACA.Forms
{
    public partial class Prestaciones : Form
    {
        SolicitudController solicitudController = new SolicitudController();
        CnDeudas CnDeudas = new CnDeudas();
        CnPrestacion CnPrestacion = new CnPrestacion();
        public Prestaciones()
        {
            InitializeComponent();
        }
        private void Prestaciones_Load(object sender, EventArgs e)
        {
            dgvPres.Columns.Add("Nombre Prestacion", "Nombre Prestacion");
            dgvPres.Columns.Add("Monto", "Monto");
            dgvPres.Columns.Add("Cuotas", "Cuotas");
            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.HeaderText = "PDF";
            linkColumn.Name = "pdfLink";
            dgvPres.Columns.Add(linkColumn);
            dgvPres.Columns[0].Width = 400;
            dgvPres.Columns[1].Width = 200;
            dgvPres.Columns[2].Width = 100;
            dgvPres.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AgregarPrestacion agregarPrestacion = new AgregarPrestacion();
            agregarPrestacion.prestacion = this;
            agregarPrestacion.ShowDialog();
        }

        public void CargarDGV(string nombre, int monto, int cuotas, string pdf)
        {
            dgvPres.Rows.Add(nombre, monto, cuotas,pdf);
            lblTotal.Text = "0";
            foreach (DataGridViewRow row in dgvPres.Rows)
            {
                lblTotal.Text = (Convert.ToInt32(lblTotal.Text) + Convert.ToInt32(row.Cells[1].Value)).ToString();
            }
        }

        private void dgvPres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPres.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                string filePath = (string)dgvPres.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvPres.SelectedRows.Count > 0)
            {
                dgvPres.Rows.RemoveAt(dgvPres.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dgvPres.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro que desea limpiar la tabla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dgvPres.Rows.Clear();
                    lblTotal.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("No hay datos para limpiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(dgvPres.Rows.Count > 0)
            {
                List<IPrestacion> prestaciones = new List<IPrestacion>();
                foreach (DataGridViewRow row in dgvPres.Rows)
                {
                    
                }
                if (enviarSolicitud()==true)
                {
                    MessageBox.Show("Solicitud procesada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El monto total supera el limite de la deuda por empleado, verifique su deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para procesar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool enviarSolicitud()
        {
            List<IPrestacion> prestacionesSeleccionadas = new List<IPrestacion>();
            foreach(DataGridViewRow row in dgvPres.Rows)
            {
            if (row.Cells[0].Value.ToString()== "Ayuda Economica Ordinaria")
            {
                AyudaEconomicaOrdinaria ayudaEconomicaOrdinaria = new AyudaEconomicaOrdinaria
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value)
                };
                prestacionesSeleccionadas.Add(ayudaEconomicaOrdinaria);
            }else if (row.Cells[0].Value.ToString() == "Ayuda Economica Salud")
            {
                AyudaEconomicaSalud ayudaEconomicaSalud = new AyudaEconomicaSalud
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value)
                };
                prestacionesSeleccionadas.Add(ayudaEconomicaSalud);
            }else if (row.Cells[0].Value.ToString() == "Farmacia")
            {
                Farmacia farmacia = new Farmacia
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value)
                };
                prestacionesSeleccionadas.Add(farmacia);
            }else if (row.Cells[0].Value.ToString() == "Optica")
            {
                Optica optica = new Optica
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value)
                };
                prestacionesSeleccionadas.Add(optica);
            }else if (row.Cells[0].Value.ToString() == "Odontologia")
            {
                Odontologia odontologia = new Odontologia
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value)
                };
                prestacionesSeleccionadas.Add(odontologia);
            }else if (row.Cells[0].Value.ToString() == "Subsidio Escolaridad")
            {
                SubsidioEscolar subsidioEscolar = new SubsidioEscolar
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value),
                    pdf = row.Cells[3].Value.ToString()
                };
                prestacionesSeleccionadas.Add(subsidioEscolar);
            }else if (row.Cells[0].Value.ToString() == "Subsidio Casamiento")
            {
                SubsidioCasamiento subsidioCasamiento = new SubsidioCasamiento
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value),
                    pdf = row.Cells[3].Value.ToString()
                };
                prestacionesSeleccionadas.Add(subsidioCasamiento);
            }else if (row.Cells[0].Value.ToString() == "Subsidio Nacimiento")
            {
                SubsidioNacimiento subsidioNacimiento = new SubsidioNacimiento
                {
                    MontoSolicitado = Convert.ToInt32(row.Cells[1].Value),
                    cuotasSolicitado = Convert.ToInt32(row.Cells[2].Value),
                    pdf = row.Cells[3].Value.ToString()
                };
                prestacionesSeleccionadas.Add(subsidioNacimiento);
            }
            }
            if (solicitudController.ProcesarSolicitud(prestacionesSeleccionadas) == false)
            {
                return false;
            }
            return true;
        }
    }
}

