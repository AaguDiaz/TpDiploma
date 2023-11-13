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
using Controladora;

namespace Sistema_ACA.Forms
{
    public partial class Prestaciones : Form
    {
        public Prestaciones()
        {
            InitializeComponent();
        }

        private void Prestaciones_Load(object sender, EventArgs e)
        {

        }

        private void cbEcoOR_CheckedChanged(object sender, EventArgs e)
        {
            if(cbEcoOR.Checked == true)
            {
                nMonEcoOr.Enabled = true;
                nCuoEcoOr.Enabled = true;
            }
            else
            {
                nMonEcoOr.Enabled = false;
                nCuoEcoOr.Enabled = false;
            }
        }
        private void cbEcoSal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEcoSal.Checked == true)
            {
                nMonEcoSal.Enabled = true;
                nCuoEcoSal.Enabled = true;
            }
            else
            {
                nMonEcoSal.Enabled = false;
                nCuoEcoSal.Enabled = false;
            }
        }
        private void cbOdon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdon.Checked == true)
            {
                nMonOdo.Enabled = true;
                nCuoOdo.Enabled = true;
            }
            else
            {
                nMonOdo.Enabled = false;
                nCuoOdo.Enabled = false;
            }
        }
        private void cbOpt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOpt.Checked == true)
            {
                nMonOpt.Enabled = true;
                nCuoOpt.Enabled = true;
            }
            else
            {
                nMonOpt.Enabled = false;
                nCuoOpt.Enabled = false;
            }
        }
        private void cbFar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFar.Checked == true)
            {
                nMonFar.Enabled = true;
                nCuoFar.Enabled = true;
            }
            else
            {
                nMonFar.Enabled = false;
                nCuoFar.Enabled = false;
            }
        }
        private void cbSubCas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubCas.Checked == true)
            {
                nMonSubCas.Enabled = true;
            }
            else
            {
                nMonSubCas.Enabled = false;
            }
        }
        private void cbSubEsc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubEsc.Checked == true)
            {
                nMonSubEsc.Enabled = true;
            }
            else
            {
                nMonSubEsc.Enabled = false;
            }
        }
        private void cbSubNac_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubNac.Checked == true)
            {
                nMonSubNac.Enabled = true;
            }
            else
            {
                nMonSubNac.Enabled = false;
            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if(validar()== true)
            {
                enviarSolicitud();
                MessageBox.Show("Solicitud procesada con éxito.", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool validar()
        {
            if (!cbEcoOR.Checked && !cbEcoSal.Checked && !cbOdon.Checked && !cbOpt.Checked && !cbFar.Checked && !cbSubCas.Checked && !cbSubEsc.Checked && !cbSubNac.Checked )
            {
                MessageBox.Show("Seleccione al menos una prestación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Verificar valores válidos para Ayuda Económica
            if (cbEcoOR.Checked)
            {
                if (nMonEcoOr.Value <= 0 || nCuoEcoOr.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto o cuotas mayores a 0 para Ayuda Económica Ordinaria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (cbEcoSal.Checked)
            {
                if (nMonEcoSal.Value <= 0 || nCuoEcoSal.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto o cuotas mayores a 0 para Ayuda Económica Salud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (cbOdon.Checked)
            {
                if (nMonOdo.Value <= 0 || nCuoOdo.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto o cuotas mayores a 0 para Odontologia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (cbOpt.Checked)
            {
                if (nMonOpt.Value <= 0 || nCuoOpt.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto o cuotas mayores a 0 para Optica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (cbFar.Checked)
            {
                if (nMonFar.Value <= 0 || nCuoFar.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto o cuotas mayores a 0 para Farmacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if(cbSubCas.Checked)
            {
                if (nMonSubCas.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto mayor a 0 para Subsidio por Casamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if(cbSubEsc.Checked)
            {
                if (nMonSubEsc.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto mayor a 0 para Subsidio por Escolaridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if(cbSubNac.Checked)
            {
                if (nMonSubNac.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto mayor a 0 para Subsidio por Nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void enviarSolicitud()
        {
            List<IPrestacion> prestacionesSeleccionadas = new List<IPrestacion>();
            if (cbEcoOR.Checked)
            {
                AyudaEconomicaOrdinaria ayudaEconomicaOrdinaria = new AyudaEconomicaOrdinaria
                {
                    MontoSolicitado = Convert.ToInt32(nMonEcoOr.Value),
                    cuotas = Convert.ToInt32(nCuoEcoOr.Value)
                };
                prestacionesSeleccionadas.Add(ayudaEconomicaOrdinaria);
            }
            if (cbEcoSal.Checked)
            {
                AyudaEconomicaSalud ayudaEconomicaSalud = new AyudaEconomicaSalud
                {
                    MontoSolicitado = Convert.ToInt32(nMonEcoSal.Value),
                    cuotas = Convert.ToInt32(nCuoEcoSal.Value)
                };
                prestacionesSeleccionadas.Add(ayudaEconomicaSalud);
            }
            if (cbOdon.Checked)
            {
                Odontologia odontologia = new Odontologia
                {
                    MontoSolicitado = Convert.ToInt32(nMonOdo.Value),
                    cuotas = Convert.ToInt32(nCuoOdo.Value)
                };
                prestacionesSeleccionadas.Add(odontologia);
            }
            if (cbOpt.Checked)
            {
                Optica optica = new Optica
                {
                    MontoSolicitado = Convert.ToInt32(nMonOpt.Value),
                    cuotas = Convert.ToInt32(nCuoOpt.Value)
                };
                prestacionesSeleccionadas.Add(optica);
            }
            if (cbFar.Checked)
            {
                Farmacia farmacia = new Farmacia
                {
                    MontoSolicitado = Convert.ToInt32(nMonFar.Value),
                    cuotas = Convert.ToInt32(nCuoFar.Value)
                };
                prestacionesSeleccionadas.Add(farmacia);
            }
            if (cbSubCas.Checked)
            {
                SubsidioCasamiento subsidioCasamiento = new SubsidioCasamiento
                {
                    MontoSolicitado = Convert.ToInt32(nMonSubCas.Value)
                };
                prestacionesSeleccionadas.Add(subsidioCasamiento);
            }
            if (cbSubEsc.Checked)
            {
                SubsidioEscolar subsidioEscolar = new SubsidioEscolar
                {
                    MontoSolicitado = Convert.ToInt32(nMonSubEsc.Value)
                };
                prestacionesSeleccionadas.Add(subsidioEscolar);
            }
            if (cbSubNac.Checked)
            {
                SubsidioNacimiento subsidioNacimiento = new SubsidioNacimiento
                {
                    MontoSolicitado = Convert.ToInt32(nMonSubNac.Value)
                };
                prestacionesSeleccionadas.Add(subsidioNacimiento);
            }
            SolicitudController solicitudController = new SolicitudController();
            solicitudController.ProcesarSolicitud(prestacionesSeleccionadas);
        }

    }
}

