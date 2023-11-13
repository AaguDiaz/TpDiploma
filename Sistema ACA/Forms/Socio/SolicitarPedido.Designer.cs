namespace Sistema_ACA
{
    partial class SolicitarPedido
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
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.bttnConfirmarPed = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista:";
            // 
            // cmbLista
            // 
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(85, 48);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(222, 21);
            this.cmbLista.TabIndex = 1;
            this.cmbLista.SelectedIndexChanged += new System.EventHandler(this.cmbLista_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTot);
            this.groupBox1.Controls.Add(this.lblPedido);
            this.groupBox1.Controls.Add(this.bttnConfirmarPed);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbProducto);
            this.groupBox1.Controls.Add(this.btnAgregarProd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(365, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 416);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Productos";
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Location = new System.Drawing.Point(276, 110);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(34, 13);
            this.lblTot.TabIndex = 10;
            this.lblTot.Text = "Total:";
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Location = new System.Drawing.Point(12, 110);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(44, 13);
            this.lblPedido.TabIndex = 6;
            this.lblPedido.Text = "Tu lista:";
            // 
            // bttnConfirmarPed
            // 
            this.bttnConfirmarPed.Location = new System.Drawing.Point(225, 63);
            this.bttnConfirmarPed.Name = "bttnConfirmarPed";
            this.bttnConfirmarPed.Size = new System.Drawing.Size(125, 21);
            this.bttnConfirmarPed.TabIndex = 9;
            this.bttnConfirmarPed.Text = "Confirmar Pedido";
            this.bttnConfirmarPed.UseVisualStyleBackColor = true;
            this.bttnConfirmarPed.Click += new System.EventHandler(this.bttnConfirmarPed_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(279, 35);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(71, 20);
            this.txtCantidad.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(77, 34);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(138, 21);
            this.cmbProducto.TabIndex = 6;
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Location = new System.Drawing.Point(77, 63);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(125, 21);
            this.btnAgregarProd.TabIndex = 4;
            this.btnAgregarProd.Text = "Agregar producto";
            this.btnAgregarProd.UseVisualStyleBackColor = true;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Productos:";
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(47, 104);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(116, 13);
            this.labelInformacion.TabIndex = 5;
            this.labelInformacion.Text = "Nombre del Proveedor:";
            // 
            // SolicitarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 461);
            this.ControlBox = false;
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbLista);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolicitarPedido";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SolicitarPedido_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregarProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button bttnConfirmarPed;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblPedido;
    }
}