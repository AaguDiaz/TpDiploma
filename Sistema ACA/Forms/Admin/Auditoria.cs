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
using Controladora.Seguridad;
using COMUN.Cache;


namespace Sistema_ACA.Forms.Admin
{
    public partial class Auditoria : Form
    {
        CnAuditoria auditoria = new CnAuditoria();
        
        int CurrentPage = 1;
        int PagesCount = 1;
        DateTime desde = DateTime.Now.AddDays(-7);
        DateTime hasta = DateTime.Now;


        public Auditoria()
        {
            InitializeComponent();
        }
        private void Auditoria_Load(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 0)
            {
                CargarInicio(desde, hasta);
            }
        }


        private void CargarInicio(DateTime desde, DateTime hasta)
        {
            bindingSource1.DataSource = auditoria.CargarInicio(CurrentPage, desde, hasta);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvInicio.DataSource = bindingSource1;
            if(dgvInicio.Rows.Count > 0)
            {
                dgvInicio.Columns[0].Width = 100;
                dgvInicio.Columns[1].Width = 200;
                dgvInicio.Columns[2].Width = 200;
                dgvInicio.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            auditoria.LoadInicio(desde, hasta);
            chart1.DataSource = CacheReportes.TopInicio;
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            chart1.DataBind();
        }

        private void CargarTrazabilidad(DateTime desde, DateTime hasta)
        {
            bindingSource1.DataSource = auditoria.CargarTrazabilidad(CurrentPage, desde, hasta);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvTraza.DataSource = bindingSource1;
            if (dgvTraza.Rows.Count > 0)
            {
                dgvTraza.Columns[0].Width = 50;
                dgvTraza.Columns[1].Width = 100;
                dgvTraza.Columns[2].Width = 100;
                dgvTraza.Columns[3].Width = 100;
                dgvTraza.Columns[4].Width = 100;
                dgvTraza.Columns[5].Width = 200;
                dgvTraza.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            auditoria.LoadTrazabilidad(desde, hasta);
            chart2.DataSource = CacheReportes.TopTrazabilidad;
            chart2.Series[0].XValueMember = "Key";
            chart2.Series[0].YValueMembers = "Value";
            chart2.DataBind();
        }


        private void btnAño_Click(object sender, EventArgs e)
        {
            desde = DateTime.Now.AddDays(-365);
            hasta = DateTime.Now;
            if(tabControl1.SelectedIndex == 0)
            {
                CargarInicio(desde, hasta);
            }else
            {
                CargarTrazabilidad(desde, hasta);
            }
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            desde = DateTime.Now.AddDays(-30);
            hasta = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                CargarInicio(desde, hasta);
            }else
            {
                CargarTrazabilidad(desde, hasta);
            }
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            desde = DateTime.Now.AddDays(-7);
            hasta = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                CargarInicio(desde, hasta);
            }
            else
            {
                CargarTrazabilidad(desde, hasta);
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            desde = DateTime.Now;
            hasta = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                CargarInicio(desde, hasta);
            }
            else
            {
                CargarTrazabilidad(desde, hasta);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

            if (CurrentPage > 1)
            {
                PagesCount--;
                tsPag.Text = "Paginas: " + PagesCount.ToString();
                CurrentPage--;
                if (tabControl1.SelectedIndex == 0)
                {
                    CargarInicio(desde, hasta);
                }
                else
                {
                    CargarTrazabilidad(desde, hasta);
                }
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

            if (dgvInicio.Rows.Count == 18)
            {
                CurrentPage++;
                PagesCount++;
                tsPag.Text = "Paginas: " + PagesCount.ToString();
                CargarInicio(desde, hasta);
            }
            if (dgvTraza.Rows.Count == 18)
            {
                CurrentPage--;
                PagesCount--;
                tsPag.Text = "Paginas: " + PagesCount.ToString();
                CargarTrazabilidad(desde, hasta);
            }
            
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {

            if (CurrentPage > 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CurrentPage = 1;
                PagesCount = 1;
                CargarInicio(desde, hasta);
                lblBus.Visible = false;
                txtBus.Visible = false;
                iconButton1.Visible = false;
            }
            else
            {
                CurrentPage = 1;
                PagesCount = 1;
                CargarTrazabilidad(desde, hasta);
                lblBus.Visible = true;
                txtBus.Visible = true;
                iconButton1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(txtBus.Text != "")
            {
                bindingSource1.DataSource = auditoria.BuscarTrazabilidad(CurrentPage,desde, hasta,Convert.ToInt32(txtBus.Text));
                bindingNavigator1.BindingSource = bindingSource1;
                dgvTraza.DataSource = bindingSource1;
                if (dgvTraza.Rows.Count > 0)
                {
                    dgvTraza.Columns[0].Width = 50;
                    dgvTraza.Columns[1].Width = 100;
                    dgvTraza.Columns[2].Width = 100;
                    dgvTraza.Columns[3].Width = 100;
                    dgvTraza.Columns[4].Width = 100;
                    dgvTraza.Columns[5].Width = 200;
                    dgvTraza.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            else
            {
                CargarTrazabilidad(desde, hasta);
            }
        }
    }
}
