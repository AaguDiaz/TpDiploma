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
using COMUN.Cache;

namespace Sistema_ACA.Forms.Admin.ListaPedidos
{
    public partial class DetallesLista : Form
    {
        CnListaProd cnListaProd = new CnListaProd();
        CnPedidoLista cnPedidoLista = new CnPedidoLista();
        SolicitudController cnSolicitud = new SolicitudController();
        int CurrentPage = 1;
        int conteo = 1;
        int entradaa = 0;

        public DetallesLista()
        {
            InitializeComponent();
        }
        public DetallesLista(int entrada)
        {
            InitializeComponent();

            if (entrada == 1)
            {
                lblInfoProv.Text = "";
                lbl_2.Text = "";
                lblInfoFech.Text = "";
                lbl_.Text = "";
                entradaa = entrada;
                pnlUp.Visible = true;
                pnlDown.Visible = true;
                btnPDF.Visible = false;
                ConfiDgvPed();
            }
            else if(entrada == 2)
            {
                lblInfoProv.Text = "Proveedor:";
                lbl_2.Text = "______________________";
                lblInfoFech.Text = "Fecha vencimiento:";
                lbl_.Text = "______________________";
                entradaa = entrada;
                lblProv.Text = cnListaProd.MostrarProvDetalleLPP(Convert.ToInt32(CacheLista.Id));
                lblFecha.Text = cnListaProd.MostrarFechaDetalleLPP(Convert.ToInt32(CacheLista.Id));
                pnlUp.Visible = false;
                pnlDown.Visible = false;
                btnPDF.Visible = false;
                confiDGV();
            }else if(entrada == 3)
            {
                lblInfoProv.Text = "";
                lbl_2.Text = "";
                lblInfoFech.Text = "";
                lbl_.Text = "";
                entradaa = entrada;
                pnlUp.Visible = true;
                pnlDown.Visible = true;
                btnPDF.Visible = true;
                ConfiDgvSoli();
            }

        }


        private void DetallesLista_Load(object sender, EventArgs e)
        {
        }

        public void ConfiDgvSoli()
        {
            bindingSource1.DataSource = cnSolicitud.MostrarSolicitudXID(Convert.ToInt32(CacheSolicitud.id_solicitud), CurrentPage);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvLista.DataSource = bindingSource1;
            dgvLista.Columns[0].Width = 200;
            dgvLista.Columns[1].Width = 200;
            dgvLista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        public void ConfiDgvPed()
        {
            bindingSource1.DataSource = cnPedidoLista.MostrarPedidoLista(Convert.ToInt32(CachePedido.Id), CurrentPage);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvLista.DataSource = bindingSource1;
            dgvLista.Columns[0].Width = 200;
            dgvLista.Columns[1].Width = 200;
            dgvLista.Columns[2].Width = 100;
            dgvLista.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        public void confiDGV()
        {
            bindingSource1.DataSource = cnListaProd.MostrarDetalleLista(Convert.ToInt32(CacheLista.Id),CurrentPage);
            bindingNavigator1.BindingSource = bindingSource1;
            dgvLista.DataSource = bindingSource1;
            dgvLista.Columns[0].Width = 200;
            dgvLista.Columns[1].Width = 200;
            dgvLista.Columns[2].Width = 100;
            dgvLista.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if(dgvLista.Rows.Count == 12)
            {
                conteo++;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage++;
                if (entradaa==2)
                {
                    confiDGV(); 
                }else if(entradaa == 1)
                {
                    ConfiDgvPed();
                }else if(entradaa == 3)
                {
                    ConfiDgvSoli();
                }
            }

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                conteo--;
                tsPag.Text = "Paginas: " + conteo.ToString();
                CurrentPage--;
                if (entradaa == 2)
                {
                    confiDGV();
                }else if(entradaa == 1)
                {
                    ConfiDgvPed();
                }else if(entradaa == 3)
                {
                    ConfiDgvSoli();
                }
            }
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            if (CurrentPage >= 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (entradaa == 3)
            {
                if(dgvLista.SelectedRows.Count > 0)
                {
                    if (dgvLista.CurrentRow.Cells[1].Value.ToString() == "Subsidio Casamiento"|| dgvLista.CurrentRow.Cells[1].Value.ToString() == "Subsidio Escolaridad"||dgvLista.CurrentRow.Cells[1].Value.ToString() == "Subsidio Nacimiento")
                    {
                        byte[] file = cnSolicitud.MostrarArchivo(Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString()));
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Solicitud.pdf";
                        System.IO.File.WriteAllBytes(path, file);
                        System.Diagnostics.Process.Start(path);
                    }else
                    {
                        MessageBox.Show("Esta prestacion no tiene un comprobante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una prestacion", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }
    }
}
