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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using COMUN;
using System.Windows.Controls;

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
            Personalizado();
            btnSemana.Select();
            if(tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }

        }
        private void LoadDataPres()
        {
            var resfrescarinfo = new CnReportes().LoadDataPres(dtpDesde.Value, dtpHasta.Value);
            if (resfrescarinfo == true)
            {
                lblSoli.Text = CacheReportes.NumSoli.ToString();
                lblSoliPen.Text = CacheReportes.SoliPendientes.ToString();
                lblSoliAcep.Text = CacheReportes.SoliAceptadas.ToString();
                lblSoliRech.Text = CacheReportes.SoliRechazadas.ToString();

                lblPrestaciones.Text = CacheReportes.NumPrestaciones.ToString();
                lblDeu.Text = CacheReportes.NumDeudores.ToString();
                lblDeuTot.Text = CacheReportes.NumDeudaTot.ToString(); 


                chSolicitudes.DataSource = CacheReportes.Solicitudes;
                chSolicitudes.Series[0].XValueMember = "Fecha";
                chSolicitudes.Series[0].YValueMembers = "Total";
                chSolicitudes.DataBind();

                chPrestaciones.DataSource = CacheReportes.Prestaciones;
                chPrestaciones.Series[0].XValueMember = "Key";
                chPrestaciones.Series[0].YValueMembers = "Value";
                chPrestaciones.DataBind();

                chDeudores.DataSource = CacheReportes.Deudores;
                chDeudores.Series[0].XValueMember = "Key";
                chDeudores.Series[0].YValueMembers = "Value";
                chDeudores.DataBind();
            }
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
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }
            Personalizado();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }
            Personalizado();

        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }
            Personalizado();
        }

        private void btnAño_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-365);
            dtpHasta.Value = DateTime.Now;
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataPed();
            }
            else
            {
                LoadDataPres();
            }
            Personalizado();
        }

        private void btnPerso_Click(object sender, EventArgs e)
        {
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            btnOk.Visible = true;
        }

        private void PDFRepor()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = string.Format("Reporte ", DateTime.Now.ToString("ddMMyyyy"));

            string paginahtml_texto = Properties.Resources.Plantilla.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@CLIENTE", UserLoginCache.nombre + UserLoginCache.apellido);
            paginahtml_texto = paginahtml_texto.Replace("@DOCUMENTO", UserLoginCache.dni.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));



            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);

                    document.Open();
                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                    }


                    MemoryStream imagenChartPedidos = ConvertirChartAImagen(chPedidos);
                    iTextSharp.text.Image chartImage1 = iTextSharp.text.Image.GetInstance(imagenChartPedidos.ToArray());
                    chartImage1.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage1);

                    MemoryStream imagenChartProductos = ConvertirChartAImagen(chProductos);
                    iTextSharp.text.Image chartImage2 = iTextSharp.text.Image.GetInstance(imagenChartProductos.ToArray());
                    chartImage2.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage2);

                    document.NewPage();

                    MemoryStream imagenChartListas = ConvertirChartAImagen(chListas);
                    iTextSharp.text.Image chartImage3 = iTextSharp.text.Image.GetInstance(imagenChartListas.ToArray());
                    chartImage3.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage3);

                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Pedidos:"));
                    document.Add(new Paragraph("                        -Cantidad de pedidos: " + lblNumPed.Text));
                    document.Add(new Paragraph("                        -Pedidos pendientes: " + lblPedPend.Text));
                    document.Add(new Paragraph("                        -Pedidos aceptados: " + lblPedAcep.Text));
                    document.Add(new Paragraph("                        -Pedidos rechazados: " + lblPedRech.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Productos:"));
                    document.Add(new Paragraph("                          -Cantidad de productos: " + lblNumProd.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Listas:"));
                    document.Add(new Paragraph("                        -Cantidad de listas: " + lblNumListas.Text));
                    document.Add(new Paragraph("                        -Listas activas: " + lblLisAct.Text));
                    document.Add(new Paragraph("                        -Listas vencidas: " + lblListVen.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Proveedores:"));
                    document.Add(new Paragraph("                            -Cantidad de proveedores: " + lblNumProv.Text));
                    document.Add(new Paragraph("                            -Proveedores activos: " + lblProvAct.Text));
                    document.Add(new Paragraph("                            -Proveedores baja: " + lblProvBaja.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Empleados:"));
                    document.Add(new Paragraph("                        -Numeros de empleados: " + lblNumSocios.Text));
                    document.Add(new Paragraph("                        -Empleados activos: " + lblSocAct.Text));
                    document.Add(new Paragraph("                        -Empleados baja: " + lblSocBaj.Text));


                    document.Close();
                    stream.Close();
                    MessageBox.Show("Reporte guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       
        private void PDFPRES()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = string.Format("Reporte ", DateTime.Now.ToString("ddMMyyyy"));

            string paginahtml_texto = Properties.Resources.Plantilla.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@CLIENTE", UserLoginCache.nombre + UserLoginCache.apellido);
            paginahtml_texto = paginahtml_texto.Replace("@DOCUMENTO", UserLoginCache.dni.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            if(save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);

                    document.Open();
                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                    }

                    MemoryStream imagenChartSolicitudes = ConvertirChartAImagen(chSolicitudes);
                    iTextSharp.text.Image chartImage1 = iTextSharp.text.Image.GetInstance(imagenChartSolicitudes.ToArray());
                    chartImage1.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage1);

                    MemoryStream imagenChartPrestaciones = ConvertirChartAImagen(chPrestaciones);
                    iTextSharp.text.Image chartImage2 = iTextSharp.text.Image.GetInstance(imagenChartPrestaciones.ToArray());
                    chartImage2.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage2);

                    document.NewPage();

                    MemoryStream imagenChartDeudores = ConvertirChartAImagen(chDeudores);
                    iTextSharp.text.Image chartImage3 = iTextSharp.text.Image.GetInstance(imagenChartDeudores.ToArray());
                    chartImage3.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    document.Add(chartImage3);

                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Solicitudes:"));
                    document.Add(new Paragraph("                        -Cantidad de solicitudes: " + lblSoli.Text));
                    document.Add(new Paragraph("                        -Solicitudes pendientes: " + lblSoliPen.Text));
                    document.Add(new Paragraph("                        -Solicitudes aceptadas: " + lblSoliAcep.Text));
                    document.Add(new Paragraph("                        -Solicitudes rechazadas: " + lblSoliRech.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Prestaciones:"));
                    document.Add(new Paragraph("                          -Cantidad de prestaciones: " + lblPrestaciones.Text));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("                Deudores:"));
                    document.Add(new Paragraph("                        -Cantidad de deudores: " + lblDeu.Text));
                    document.Add(new Paragraph("                        -Deuda total: " + lblDeuTot.Text));
                    document.Close();
                    stream.Close();
                    MessageBox.Show("Reporte guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bttnPDF_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                PDFRepor();
            }
            else
            {
                PDFPRES();
            }

        }

        public MemoryStream ConvertirChartAImagen(Chart chart)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart.Width, chart.Height));

            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream;
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
