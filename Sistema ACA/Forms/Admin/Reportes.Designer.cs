namespace Sistema_ACA.Forms.Admin
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chPedidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chListas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOk = new FontAwesome.Sharp.IconButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPerso = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumProv = new System.Windows.Forms.Label();
            this.lblNumProd = new System.Windows.Forms.Label();
            this.lblNumListas = new System.Windows.Forms.Label();
            this.lblNumPed = new System.Windows.Forms.Label();
            this.lblNumSocios = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAño = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnSemana = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPedAcep = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPedPend = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPedRech = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSocBaj = new System.Windows.Forms.Label();
            this.lblSocActivo = new System.Windows.Forms.Label();
            this.lblSocAct = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblListVen = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblLisAct = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.lblProvBaja = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblProvAct = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chListas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chProductos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // chPedidos
            // 
            chartArea1.Name = "ChartArea1";
            this.chPedidos.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chPedidos.Legends.Add(legend1);
            this.chPedidos.Location = new System.Drawing.Point(6, 6);
            this.chPedidos.Name = "chPedidos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chPedidos.Series.Add(series1);
            this.chPedidos.Size = new System.Drawing.Size(1070, 292);
            this.chPedidos.TabIndex = 0;
            this.chPedidos.Text = "1330; 700";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Pedidos";
            this.chPedidos.Titles.Add(title1);
            // 
            // chListas
            // 
            chartArea2.Name = "ChartArea1";
            this.chListas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chListas.Legends.Add(legend2);
            this.chListas.Location = new System.Drawing.Point(545, 303);
            this.chListas.Name = "chListas";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.chListas.Series.Add(series2);
            this.chListas.Size = new System.Drawing.Size(531, 334);
            this.chListas.TabIndex = 1;
            this.chListas.Text = "chart2";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Listas de pedido mas usadas";
            this.chListas.Titles.Add(title2);
            // 
            // chProductos
            // 
            chartArea3.Name = "ChartArea1";
            this.chProductos.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chProductos.Legends.Add(legend3);
            this.chProductos.Location = new System.Drawing.Point(3, 303);
            this.chProductos.Name = "chProductos";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            this.chProductos.Series.Add(series3);
            this.chProductos.Size = new System.Drawing.Size(531, 334);
            this.chProductos.TabIndex = 2;
            this.chProductos.Text = "chart3";
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Productos mas pedidos";
            this.chProductos.Titles.Add(title3);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnOk.IconColor = System.Drawing.Color.Black;
            this.btnOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOk.IconSize = 30;
            this.btnOk.Location = new System.Drawing.Point(697, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(36, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd MMMM, yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(440, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(207, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd MMMM, yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(134, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(207, 20);
            this.dtpDesde.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(376, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(49, 17);
            this.label.TabIndex = 6;
            this.label.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde:";
            // 
            // btnPerso
            // 
            this.btnPerso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPerso.Location = new System.Drawing.Point(739, 10);
            this.btnPerso.Name = "btnPerso";
            this.btnPerso.Size = new System.Drawing.Size(111, 27);
            this.btnPerso.TabIndex = 8;
            this.btnPerso.Text = "Personalizado";
            this.btnPerso.UseVisualStyleBackColor = true;
            this.btnPerso.Click += new System.EventHandler(this.btnPerso_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1337, 663);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.chPedidos);
            this.tabPage1.Controls.Add(this.chProductos);
            this.tabPage1.Controls.Add(this.chListas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1329, 637);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pedidos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblNumProd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1088, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 620);
            this.panel1.TabIndex = 3;
            // 
            // lblNumProv
            // 
            this.lblNumProv.AutoSize = true;
            this.lblNumProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProv.Location = new System.Drawing.Point(175, 31);
            this.lblNumProv.Name = "lblNumProv";
            this.lblNumProv.Size = new System.Drawing.Size(40, 17);
            this.lblNumProv.TabIndex = 27;
            this.lblNumProv.Text = "1000";
            // 
            // lblNumProd
            // 
            this.lblNumProd.AutoSize = true;
            this.lblNumProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProd.Location = new System.Drawing.Point(178, 457);
            this.lblNumProd.Name = "lblNumProd";
            this.lblNumProd.Size = new System.Drawing.Size(40, 17);
            this.lblNumProd.TabIndex = 26;
            this.lblNumProd.Text = "1000";
            // 
            // lblNumListas
            // 
            this.lblNumListas.AutoSize = true;
            this.lblNumListas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumListas.Location = new System.Drawing.Point(175, 31);
            this.lblNumListas.Name = "lblNumListas";
            this.lblNumListas.Size = new System.Drawing.Size(40, 17);
            this.lblNumListas.TabIndex = 25;
            this.lblNumListas.Text = "1000";
            // 
            // lblNumPed
            // 
            this.lblNumPed.AutoSize = true;
            this.lblNumPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPed.Location = new System.Drawing.Point(175, 27);
            this.lblNumPed.Name = "lblNumPed";
            this.lblNumPed.Size = new System.Drawing.Size(40, 17);
            this.lblNumPed.TabIndex = 24;
            this.lblNumPed.Text = "1000";
            // 
            // lblNumSocios
            // 
            this.lblNumSocios.AutoSize = true;
            this.lblNumSocios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumSocios.Location = new System.Drawing.Point(175, 30);
            this.lblNumSocios.Name = "lblNumSocios";
            this.lblNumSocios.Size = new System.Drawing.Size(40, 17);
            this.lblNumSocios.TabIndex = 23;
            this.lblNumSocios.Text = "1000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Numero de proveedores:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 457);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Numero de productos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Numero de Listas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Numero de Socios:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Numero de pedidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Totales:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1329, 637);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prestaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAño
            // 
            this.btnAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAño.Location = new System.Drawing.Point(856, 10);
            this.btnAño.Name = "btnAño";
            this.btnAño.Size = new System.Drawing.Size(111, 27);
            this.btnAño.TabIndex = 10;
            this.btnAño.Text = "Ultimo año";
            this.btnAño.UseVisualStyleBackColor = true;
            this.btnAño.Click += new System.EventHandler(this.btnAño_Click);
            // 
            // btnMes
            // 
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMes.Location = new System.Drawing.Point(973, 10);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(111, 27);
            this.btnMes.TabIndex = 11;
            this.btnMes.Text = "Ultimo mes";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btnSemana
            // 
            this.btnSemana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSemana.Location = new System.Drawing.Point(1090, 10);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(111, 27);
            this.btnSemana.TabIndex = 12;
            this.btnSemana.Text = "Ultima semana";
            this.btnSemana.UseVisualStyleBackColor = true;
            this.btnSemana.Click += new System.EventHandler(this.btnSemana_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHoy.Location = new System.Drawing.Point(1207, 10);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(111, 27);
            this.btnHoy.TabIndex = 13;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Pedidos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblPedRech);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblPedPend);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblPedAcep);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblNumPed);
            this.panel2.Location = new System.Drawing.Point(3, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 111);
            this.panel2.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Aceptados:";
            // 
            // lblPedAcep
            // 
            this.lblPedAcep.AutoSize = true;
            this.lblPedAcep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedAcep.Location = new System.Drawing.Point(175, 67);
            this.lblPedAcep.Name = "lblPedAcep";
            this.lblPedAcep.Size = new System.Drawing.Size(40, 17);
            this.lblPedAcep.TabIndex = 30;
            this.lblPedAcep.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "Pendientes:";
            // 
            // lblPedPend
            // 
            this.lblPedPend.AutoSize = true;
            this.lblPedPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedPend.Location = new System.Drawing.Point(175, 47);
            this.lblPedPend.Name = "lblPedPend";
            this.lblPedPend.Size = new System.Drawing.Size(40, 17);
            this.lblPedPend.TabIndex = 32;
            this.lblPedPend.Text = "1000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Rechazados:";
            // 
            // lblPedRech
            // 
            this.lblPedRech.AutoSize = true;
            this.lblPedRech.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedRech.Location = new System.Drawing.Point(175, 88);
            this.lblPedRech.Name = "lblPedRech";
            this.lblPedRech.Size = new System.Drawing.Size(40, 17);
            this.lblPedRech.TabIndex = 34;
            this.lblPedRech.Text = "1000";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.lblSocBaj);
            this.panel3.Controls.Add(this.lblSocActivo);
            this.panel3.Controls.Add(this.lblNumSocios);
            this.panel3.Controls.Add(this.lblSocAct);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(222, 111);
            this.panel3.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 17);
            this.label15.TabIndex = 33;
            this.label15.Text = "Dados de baja:";
            // 
            // lblSocBaj
            // 
            this.lblSocBaj.AutoSize = true;
            this.lblSocBaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocBaj.Location = new System.Drawing.Point(175, 80);
            this.lblSocBaj.Name = "lblSocBaj";
            this.lblSocBaj.Size = new System.Drawing.Size(40, 17);
            this.lblSocBaj.TabIndex = 34;
            this.lblSocBaj.Text = "1000";
            // 
            // lblSocActivo
            // 
            this.lblSocActivo.AutoSize = true;
            this.lblSocActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocActivo.Location = new System.Drawing.Point(3, 55);
            this.lblSocActivo.Name = "lblSocActivo";
            this.lblSocActivo.Size = new System.Drawing.Size(57, 17);
            this.lblSocActivo.TabIndex = 29;
            this.lblSocActivo.Text = "Activos:";
            // 
            // lblSocAct
            // 
            this.lblSocAct.AutoSize = true;
            this.lblSocAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocAct.Location = new System.Drawing.Point(175, 55);
            this.lblSocAct.Name = "lblSocAct";
            this.lblSocAct.Size = new System.Drawing.Size(40, 17);
            this.lblSocAct.TabIndex = 30;
            this.lblSocAct.Text = "1000";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(2, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 20);
            this.label22.TabIndex = 28;
            this.label22.Text = "Socios";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.lblListVen);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.lblNumListas);
            this.panel4.Controls.Add(this.lblLisAct);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(3, 297);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 111);
            this.panel4.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "Vencidas:";
            // 
            // lblListVen
            // 
            this.lblListVen.AutoSize = true;
            this.lblListVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListVen.Location = new System.Drawing.Point(175, 81);
            this.lblListVen.Name = "lblListVen";
            this.lblListVen.Size = new System.Drawing.Size(40, 17);
            this.lblListVen.TabIndex = 34;
            this.lblListVen.Text = "1000";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 17);
            this.label24.TabIndex = 29;
            this.label24.Text = "Activas:";
            // 
            // lblLisAct
            // 
            this.lblLisAct.AutoSize = true;
            this.lblLisAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLisAct.Location = new System.Drawing.Point(175, 56);
            this.lblLisAct.Name = "lblLisAct";
            this.lblLisAct.Size = new System.Drawing.Size(40, 17);
            this.lblLisAct.TabIndex = 30;
            this.lblLisAct.Text = "1000";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(2, 3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(133, 20);
            this.label27.TabIndex = 28;
            this.label27.Text = "Listas de pedidos";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.lblProvBaja);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.lblProvAct);
            this.panel5.Controls.Add(this.lblNumProv);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label30);
            this.panel5.Location = new System.Drawing.Point(3, 506);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(222, 111);
            this.panel5.TabIndex = 37;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(3, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 17);
            this.label21.TabIndex = 33;
            this.label21.Text = "Dados de baja:";
            // 
            // lblProvBaja
            // 
            this.lblProvBaja.AutoSize = true;
            this.lblProvBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvBaja.Location = new System.Drawing.Point(175, 81);
            this.lblProvBaja.Name = "lblProvBaja";
            this.lblProvBaja.Size = new System.Drawing.Size(40, 17);
            this.lblProvBaja.TabIndex = 34;
            this.lblProvBaja.Text = "1000";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(3, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 17);
            this.label26.TabIndex = 29;
            this.label26.Text = "Activos:";
            // 
            // lblProvAct
            // 
            this.lblProvAct.AutoSize = true;
            this.lblProvAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvAct.Location = new System.Drawing.Point(175, 56);
            this.lblProvAct.Name = "lblProvAct";
            this.lblProvAct.Size = new System.Drawing.Size(40, 17);
            this.lblProvAct.TabIndex = 30;
            this.lblProvAct.Text = "1000";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(2, 3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(102, 20);
            this.label30.TabIndex = 28;
            this.label30.Text = "Proveedores:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 426);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 20);
            this.label28.TabIndex = 35;
            this.label28.Text = "Productos:";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 700);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.btnSemana);
            this.Controls.Add(this.btnMes);
            this.Controls.Add(this.btnAño);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnPerso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.chPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chListas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chProductos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chPedidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chListas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chProductos;
        private FontAwesome.Sharp.IconButton btnOk;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPerso;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAño;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btnSemana;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumProv;
        private System.Windows.Forms.Label lblNumProd;
        private System.Windows.Forms.Label lblNumListas;
        private System.Windows.Forms.Label lblNumPed;
        private System.Windows.Forms.Label lblNumSocios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSocBaj;
        private System.Windows.Forms.Label lblSocActivo;
        private System.Windows.Forms.Label lblSocAct;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblPedRech;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPedPend;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPedAcep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblProvBaja;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblProvAct;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblListVen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblLisAct;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
    }
}