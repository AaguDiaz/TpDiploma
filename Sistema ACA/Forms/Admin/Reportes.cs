using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using COMUN.Cache;

namespace Sistema_ACA.Forms.Admin
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();

            //Por defecto en ultimos 7 dias
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            btnSemana.Select();
            LoadDataPed();

        }

        private void LoadDataPed()
        {
            var resfrescarinfo = new CnReportes().LoadDataPed(dtpDesde.Value, dtpHasta.Value);
            if (resfrescarinfo== true)
            {
                lblNumListas.Text = CacheReportes.NumListaPedidos.ToString();
                lblLisAct.Text = CacheReportes.ListasActivas.ToString();
                lblListVen.Text = CacheReportes.ListasVencidas.ToString();

                lblNumPed.Text = CacheReportes.NumPedidos.ToString();
                lblPedPend.Text = CacheReportes.PedidosPendientes.ToString();
                lblPedAcep.Text = CacheReportes.PedidosAceptadas.ToString();
                lblPedRech.Text = CacheReportes.PedidosRechazadas.ToString();

                lblNumProd.Text = CacheReportes.NumProductos.ToString();

                lblNumProv.Text = CacheReportes.NumProveedores.ToString();
                lblProvAct.Text = CacheReportes.ProveedoresActivos.ToString();
                lblProvBaja.Text = CacheReportes.ProveedoresBaja.ToString();

                lblNumSocios.Text = CacheReportes.NumEmpleados.ToString();
                lblSocAct.Text = CacheReportes.EmpleadosActivos.ToString();
                lblSocBaj.Text = CacheReportes.EmpleadosBaja.ToString();

                chPedidos.DataSource = CacheReportes.PedidosLista;
                chPedidos.Series[0].XValueMember = "Fecha";
                chPedidos.Series[0].YValueMembers = "Total";
                chPedidos.DataBind();

                chProductos.DataSource =  CacheReportes.TopProductos;
                chProductos.Series[0].XValueMember = "Key";
                chProductos.Series[0].YValueMembers = "Value";
                chProductos.DataBind();

                chListas.DataSource = CacheReportes.TopListas;
                chListas.Series[0].XValueMember = "Key";
                chListas.Series[0].YValueMembers = "Value";
                chListas.DataBind();

            }
        }

        private void Personalizado()
        {
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            btnOk.Visible = false;
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadDataPed();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Now;
            LoadDataPed();
            Personalizado();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            LoadDataPed();
            Personalizado();

        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
            LoadDataPed();
            Personalizado();
        }

        private void btnAño_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-365);
            dtpHasta.Value = DateTime.Now;
            LoadDataPed();
            Personalizado();
        }

        private void btnPerso_Click(object sender, EventArgs e)
        {
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            btnOk.Visible = true;
        }
    }
}
