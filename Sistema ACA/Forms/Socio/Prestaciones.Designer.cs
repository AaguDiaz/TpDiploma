namespace Sistema_ACA.Forms
{
    partial class Prestaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEcoOR = new System.Windows.Forms.CheckBox();
            this.cbEcoSal = new System.Windows.Forms.CheckBox();
            this.cbOdon = new System.Windows.Forms.CheckBox();
            this.cbOpt = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSubNac = new System.Windows.Forms.CheckBox();
            this.cbSubCas = new System.Windows.Forms.CheckBox();
            this.cbFar = new System.Windows.Forms.CheckBox();
            this.cbSubEsc = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.btnEditarLimite = new System.Windows.Forms.Button();
            this.nMonEcoOr = new System.Windows.Forms.NumericUpDown();
            this.nCuoEcoOr = new System.Windows.Forms.NumericUpDown();
            this.nMonEcoSal = new System.Windows.Forms.NumericUpDown();
            this.nMonOdo = new System.Windows.Forms.NumericUpDown();
            this.nMonOpt = new System.Windows.Forms.NumericUpDown();
            this.nMonFar = new System.Windows.Forms.NumericUpDown();
            this.nMonSubCas = new System.Windows.Forms.NumericUpDown();
            this.nMonSubEsc = new System.Windows.Forms.NumericUpDown();
            this.nCuoEcoSal = new System.Windows.Forms.NumericUpDown();
            this.nCuoOdo = new System.Windows.Forms.NumericUpDown();
            this.nCuoOpt = new System.Windows.Forms.NumericUpDown();
            this.nMonSubNac = new System.Windows.Forms.NumericUpDown();
            this.nCuoFar = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nMonEcoOr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoEcoOr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonEcoSal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonOdo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonOpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonFar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubCas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubEsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoEcoSal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoOdo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoOpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubNac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoFar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitar Prestaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Limite total de prestaciones para socios: $130.000";
            // 
            // cbEcoOR
            // 
            this.cbEcoOR.AutoSize = true;
            this.cbEcoOR.Location = new System.Drawing.Point(37, 144);
            this.cbEcoOR.Name = "cbEcoOR";
            this.cbEcoOR.Size = new System.Drawing.Size(165, 17);
            this.cbEcoOR.TabIndex = 2;
            this.cbEcoOR.Text = "Ayudas Economicas ordinaria";
            this.cbEcoOR.UseVisualStyleBackColor = true;
            this.cbEcoOR.CheckedChanged += new System.EventHandler(this.cbEcoOR_CheckedChanged);
            // 
            // cbEcoSal
            // 
            this.cbEcoSal.AutoSize = true;
            this.cbEcoSal.Location = new System.Drawing.Point(37, 168);
            this.cbEcoSal.Name = "cbEcoSal";
            this.cbEcoSal.Size = new System.Drawing.Size(152, 17);
            this.cbEcoSal.TabIndex = 3;
            this.cbEcoSal.Text = "Ayudas Economicas Salud";
            this.cbEcoSal.UseVisualStyleBackColor = true;
            this.cbEcoSal.CheckedChanged += new System.EventHandler(this.cbEcoSal_CheckedChanged);
            // 
            // cbOdon
            // 
            this.cbOdon.AutoSize = true;
            this.cbOdon.Location = new System.Drawing.Point(37, 194);
            this.cbOdon.Name = "cbOdon";
            this.cbOdon.Size = new System.Drawing.Size(85, 17);
            this.cbOdon.TabIndex = 4;
            this.cbOdon.Text = "Odontología";
            this.cbOdon.UseVisualStyleBackColor = true;
            this.cbOdon.CheckedChanged += new System.EventHandler(this.cbOdon_CheckedChanged);
            // 
            // cbOpt
            // 
            this.cbOpt.AutoSize = true;
            this.cbOpt.Location = new System.Drawing.Point(37, 220);
            this.cbOpt.Name = "cbOpt";
            this.cbOpt.Size = new System.Drawing.Size(57, 17);
            this.cbOpt.TabIndex = 5;
            this.cbOpt.Text = "Óptica";
            this.cbOpt.UseVisualStyleBackColor = true;
            this.cbOpt.CheckedChanged += new System.EventHandler(this.cbOpt_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prestaciones";
            // 
            // cbSubNac
            // 
            this.cbSubNac.AutoSize = true;
            this.cbSubNac.Location = new System.Drawing.Point(37, 320);
            this.cbSubNac.Name = "cbSubNac";
            this.cbSubNac.Size = new System.Drawing.Size(196, 17);
            this.cbSubNac.TabIndex = 10;
            this.cbSubNac.Text = "Subsidio por nacimiento o adopcíon";
            this.cbSubNac.UseVisualStyleBackColor = true;
            this.cbSubNac.CheckedChanged += new System.EventHandler(this.cbSubNac_CheckedChanged);
            // 
            // cbSubCas
            // 
            this.cbSubCas.AutoSize = true;
            this.cbSubCas.Location = new System.Drawing.Point(37, 271);
            this.cbSubCas.Name = "cbSubCas";
            this.cbSubCas.Size = new System.Drawing.Size(141, 17);
            this.cbSubCas.TabIndex = 8;
            this.cbSubCas.Text = "Subsidio por casamiento";
            this.cbSubCas.UseVisualStyleBackColor = true;
            this.cbSubCas.CheckedChanged += new System.EventHandler(this.cbSubCas_CheckedChanged);
            // 
            // cbFar
            // 
            this.cbFar.AutoSize = true;
            this.cbFar.Location = new System.Drawing.Point(37, 246);
            this.cbFar.Name = "cbFar";
            this.cbFar.Size = new System.Drawing.Size(69, 17);
            this.cbFar.TabIndex = 7;
            this.cbFar.Text = "Farmacia";
            this.cbFar.UseVisualStyleBackColor = true;
            this.cbFar.CheckedChanged += new System.EventHandler(this.cbFar_CheckedChanged);
            // 
            // cbSubEsc
            // 
            this.cbSubEsc.AutoSize = true;
            this.cbSubEsc.Location = new System.Drawing.Point(37, 294);
            this.cbSubEsc.Name = "cbSubEsc";
            this.cbSubEsc.Size = new System.Drawing.Size(141, 17);
            this.cbSubEsc.TabIndex = 11;
            this.cbSubEsc.Text = "Subsidio por escolaridad";
            this.cbSubEsc.UseVisualStyleBackColor = true;
            this.cbSubEsc.CheckedChanged += new System.EventHandler(this.cbSubEsc_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(258, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Limite Actual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(378, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cant. Cuotas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(503, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tu monto a solicitar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "$120.000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "$100.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "18";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "$100.000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(280, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "$100.000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(280, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "$75.000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(280, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "$7.000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(280, 298);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "$3.200";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(280, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "$7.000";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(418, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "18";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(418, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "18";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(418, 221);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(424, 247);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "6";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(669, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 20);
            this.label20.TabIndex = 49;
            this.label20.Text = "Cuotas";
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(334, 357);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(103, 36);
            this.btnSolicitar.TabIndex = 50;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.UseVisualStyleBackColor = true;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // btnEditarLimite
            // 
            this.btnEditarLimite.Location = new System.Drawing.Point(262, 83);
            this.btnEditarLimite.Name = "btnEditarLimite";
            this.btnEditarLimite.Size = new System.Drawing.Size(90, 23);
            this.btnEditarLimite.TabIndex = 58;
            this.btnEditarLimite.Text = "Editar limite";
            this.btnEditarLimite.UseVisualStyleBackColor = true;
            this.btnEditarLimite.Visible = false;
            // 
            // nMonEcoOr
            // 
            this.nMonEcoOr.Enabled = false;
            this.nMonEcoOr.Location = new System.Drawing.Point(517, 141);
            this.nMonEcoOr.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonEcoOr.Name = "nMonEcoOr";
            this.nMonEcoOr.Size = new System.Drawing.Size(120, 20);
            this.nMonEcoOr.TabIndex = 59;
            // 
            // nCuoEcoOr
            // 
            this.nCuoEcoOr.Enabled = false;
            this.nCuoEcoOr.Location = new System.Drawing.Point(683, 141);
            this.nCuoEcoOr.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nCuoEcoOr.Name = "nCuoEcoOr";
            this.nCuoEcoOr.Size = new System.Drawing.Size(34, 20);
            this.nCuoEcoOr.TabIndex = 60;
            // 
            // nMonEcoSal
            // 
            this.nMonEcoSal.Enabled = false;
            this.nMonEcoSal.Location = new System.Drawing.Point(517, 167);
            this.nMonEcoSal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonEcoSal.Name = "nMonEcoSal";
            this.nMonEcoSal.Size = new System.Drawing.Size(120, 20);
            this.nMonEcoSal.TabIndex = 61;
            // 
            // nMonOdo
            // 
            this.nMonOdo.Enabled = false;
            this.nMonOdo.Location = new System.Drawing.Point(517, 193);
            this.nMonOdo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonOdo.Name = "nMonOdo";
            this.nMonOdo.Size = new System.Drawing.Size(120, 20);
            this.nMonOdo.TabIndex = 62;
            // 
            // nMonOpt
            // 
            this.nMonOpt.Enabled = false;
            this.nMonOpt.Location = new System.Drawing.Point(517, 219);
            this.nMonOpt.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonOpt.Name = "nMonOpt";
            this.nMonOpt.Size = new System.Drawing.Size(120, 20);
            this.nMonOpt.TabIndex = 63;
            // 
            // nMonFar
            // 
            this.nMonFar.Enabled = false;
            this.nMonFar.Location = new System.Drawing.Point(517, 245);
            this.nMonFar.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonFar.Name = "nMonFar";
            this.nMonFar.Size = new System.Drawing.Size(120, 20);
            this.nMonFar.TabIndex = 64;
            // 
            // nMonSubCas
            // 
            this.nMonSubCas.Enabled = false;
            this.nMonSubCas.Location = new System.Drawing.Point(517, 270);
            this.nMonSubCas.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonSubCas.Name = "nMonSubCas";
            this.nMonSubCas.Size = new System.Drawing.Size(120, 20);
            this.nMonSubCas.TabIndex = 65;
            // 
            // nMonSubEsc
            // 
            this.nMonSubEsc.Enabled = false;
            this.nMonSubEsc.Location = new System.Drawing.Point(517, 296);
            this.nMonSubEsc.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonSubEsc.Name = "nMonSubEsc";
            this.nMonSubEsc.Size = new System.Drawing.Size(120, 20);
            this.nMonSubEsc.TabIndex = 66;
            // 
            // nCuoEcoSal
            // 
            this.nCuoEcoSal.Enabled = false;
            this.nCuoEcoSal.Location = new System.Drawing.Point(683, 167);
            this.nCuoEcoSal.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nCuoEcoSal.Name = "nCuoEcoSal";
            this.nCuoEcoSal.Size = new System.Drawing.Size(34, 20);
            this.nCuoEcoSal.TabIndex = 67;
            // 
            // nCuoOdo
            // 
            this.nCuoOdo.Enabled = false;
            this.nCuoOdo.Location = new System.Drawing.Point(683, 193);
            this.nCuoOdo.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nCuoOdo.Name = "nCuoOdo";
            this.nCuoOdo.Size = new System.Drawing.Size(34, 20);
            this.nCuoOdo.TabIndex = 68;
            // 
            // nCuoOpt
            // 
            this.nCuoOpt.Enabled = false;
            this.nCuoOpt.Location = new System.Drawing.Point(683, 219);
            this.nCuoOpt.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nCuoOpt.Name = "nCuoOpt";
            this.nCuoOpt.Size = new System.Drawing.Size(34, 20);
            this.nCuoOpt.TabIndex = 69;
            // 
            // nMonSubNac
            // 
            this.nMonSubNac.Enabled = false;
            this.nMonSubNac.Location = new System.Drawing.Point(517, 322);
            this.nMonSubNac.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nMonSubNac.Name = "nMonSubNac";
            this.nMonSubNac.Size = new System.Drawing.Size(120, 20);
            this.nMonSubNac.TabIndex = 70;
            // 
            // nCuoFar
            // 
            this.nCuoFar.Enabled = false;
            this.nCuoFar.Location = new System.Drawing.Point(683, 245);
            this.nCuoFar.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nCuoFar.Name = "nCuoFar";
            this.nCuoFar.Size = new System.Drawing.Size(34, 20);
            this.nCuoFar.TabIndex = 71;
            // 
            // Prestaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 445);
            this.ControlBox = false;
            this.Controls.Add(this.nCuoFar);
            this.Controls.Add(this.nMonSubNac);
            this.Controls.Add(this.nCuoOpt);
            this.Controls.Add(this.nCuoOdo);
            this.Controls.Add(this.nCuoEcoSal);
            this.Controls.Add(this.nMonSubEsc);
            this.Controls.Add(this.nMonSubCas);
            this.Controls.Add(this.nMonFar);
            this.Controls.Add(this.nMonOpt);
            this.Controls.Add(this.nMonOdo);
            this.Controls.Add(this.nMonEcoSal);
            this.Controls.Add(this.nCuoEcoOr);
            this.Controls.Add(this.nMonEcoOr);
            this.Controls.Add(this.btnEditarLimite);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSubEsc);
            this.Controls.Add(this.cbSubNac);
            this.Controls.Add(this.cbSubCas);
            this.Controls.Add(this.cbFar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOpt);
            this.Controls.Add(this.cbOdon);
            this.Controls.Add(this.cbEcoSal);
            this.Controls.Add(this.cbEcoOR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prestaciones";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Prestaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Prestaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nMonEcoOr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoEcoOr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonEcoSal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonOdo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonOpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonFar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubCas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubEsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoEcoSal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoOdo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoOpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMonSubNac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCuoFar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbEcoOR;
        private System.Windows.Forms.CheckBox cbEcoSal;
        private System.Windows.Forms.CheckBox cbOdon;
        private System.Windows.Forms.CheckBox cbOpt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSubNac;
        private System.Windows.Forms.CheckBox cbSubCas;
        private System.Windows.Forms.CheckBox cbFar;
        private System.Windows.Forms.CheckBox cbSubEsc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.Button btnEditarLimite;
        private System.Windows.Forms.NumericUpDown nMonEcoOr;
        private System.Windows.Forms.NumericUpDown nCuoEcoOr;
        private System.Windows.Forms.NumericUpDown nMonEcoSal;
        private System.Windows.Forms.NumericUpDown nMonOdo;
        private System.Windows.Forms.NumericUpDown nMonOpt;
        private System.Windows.Forms.NumericUpDown nMonFar;
        private System.Windows.Forms.NumericUpDown nMonSubCas;
        private System.Windows.Forms.NumericUpDown nMonSubEsc;
        private System.Windows.Forms.NumericUpDown nCuoEcoSal;
        private System.Windows.Forms.NumericUpDown nCuoOdo;
        private System.Windows.Forms.NumericUpDown nCuoOpt;
        private System.Windows.Forms.NumericUpDown nMonSubNac;
        private System.Windows.Forms.NumericUpDown nCuoFar;
    }
}