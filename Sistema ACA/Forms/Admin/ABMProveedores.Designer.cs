namespace Sistema_ACA
{
    partial class ABMProveedores
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
            this.components = new System.ComponentModel.Container();
            this.txtNombrePro = new System.Windows.Forms.TextBox();
            this.txtDirePro = new System.Windows.Forms.TextBox();
            this.txtCuilPro = new System.Windows.Forms.TextBox();
            this.txtTelPro = new System.Windows.Forms.TextBox();
            this.dgvProv = new System.Windows.Forms.DataGridView();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pruebaACADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pruebaACADataSet = new Sistema_ACA.pruebaACADataSet();
            this.proveedoresTableAdapter = new Sistema_ACA.pruebaACADataSetTableAdapters.proveedoresTableAdapter();
            this.btnAgr = new FontAwesome.Sharp.IconButton();
            this.btnMod = new FontAwesome.Sharp.IconButton();
            this.btnAlta = new FontAwesome.Sharp.IconButton();
            this.btnBaja = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblABM = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombrePro
            // 
            this.txtNombrePro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePro.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombrePro.Location = new System.Drawing.Point(9, 51);
            this.txtNombrePro.Name = "txtNombrePro";
            this.txtNombrePro.Size = new System.Drawing.Size(140, 22);
            this.txtNombrePro.TabIndex = 1;
            this.txtNombrePro.Text = "Nombre:";
            this.txtNombrePro.Enter += new System.EventHandler(this.txtNombrePro_Enter);
            this.txtNombrePro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePro_KeyPress);
            this.txtNombrePro.Leave += new System.EventHandler(this.txtNombrePro_Leave);
            // 
            // txtDirePro
            // 
            this.txtDirePro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirePro.ForeColor = System.Drawing.Color.DimGray;
            this.txtDirePro.Location = new System.Drawing.Point(155, 51);
            this.txtDirePro.Name = "txtDirePro";
            this.txtDirePro.Size = new System.Drawing.Size(155, 22);
            this.txtDirePro.TabIndex = 3;
            this.txtDirePro.Text = "Direccion:";
            this.txtDirePro.Enter += new System.EventHandler(this.txtDirePro_Enter);
            this.txtDirePro.Leave += new System.EventHandler(this.txtDirePro_Leave);
            // 
            // txtCuilPro
            // 
            this.txtCuilPro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuilPro.ForeColor = System.Drawing.Color.DimGray;
            this.txtCuilPro.Location = new System.Drawing.Point(9, 86);
            this.txtCuilPro.Name = "txtCuilPro";
            this.txtCuilPro.Size = new System.Drawing.Size(140, 22);
            this.txtCuilPro.TabIndex = 5;
            this.txtCuilPro.Text = "Cuil:";
            this.txtCuilPro.Enter += new System.EventHandler(this.txtCuilPro_Enter);
            this.txtCuilPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuilPro_KeyPress);
            this.txtCuilPro.Leave += new System.EventHandler(this.txtCuilPro_Leave);
            // 
            // txtTelPro
            // 
            this.txtTelPro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelPro.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelPro.Location = new System.Drawing.Point(155, 86);
            this.txtTelPro.Name = "txtTelPro";
            this.txtTelPro.Size = new System.Drawing.Size(155, 22);
            this.txtTelPro.TabIndex = 7;
            this.txtTelPro.Text = "Telefono:";
            this.txtTelPro.Enter += new System.EventHandler(this.txtTelPro_Enter);
            this.txtTelPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelPro_KeyPress);
            this.txtTelPro.Leave += new System.EventHandler(this.txtTelPro_Leave);
            // 
            // dgvProv
            // 
            this.dgvProv.AllowUserToAddRows = false;
            this.dgvProv.AllowUserToDeleteRows = false;
            this.dgvProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProv.Location = new System.Drawing.Point(9, 125);
            this.dgvProv.Name = "dgvProv";
            this.dgvProv.ReadOnly = true;
            this.dgvProv.Size = new System.Drawing.Size(592, 258);
            this.dgvProv.TabIndex = 9;
            this.dgvProv.SelectionChanged += new System.EventHandler(this.dgvProv_SelectionChanged);
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "proveedores";
            this.proveedoresBindingSource.DataSource = this.pruebaACADataSetBindingSource;
            // 
            // pruebaACADataSetBindingSource
            // 
            this.pruebaACADataSetBindingSource.DataSource = this.pruebaACADataSet;
            this.pruebaACADataSetBindingSource.Position = 0;
            // 
            // pruebaACADataSet
            // 
            this.pruebaACADataSet.DataSetName = "pruebaACADataSet";
            this.pruebaACADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // btnAgr
            // 
            this.btnAgr.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAgr.IconColor = System.Drawing.Color.Black;
            this.btnAgr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgr.IconSize = 40;
            this.btnAgr.Location = new System.Drawing.Point(3, 3);
            this.btnAgr.Name = "btnAgr";
            this.btnAgr.Size = new System.Drawing.Size(65, 57);
            this.btnAgr.TabIndex = 11;
            this.btnAgr.Tag = "Boton Registrar";
            this.btnAgr.Text = "Agregar";
            this.btnAgr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgr.UseVisualStyleBackColor = true;
            this.btnAgr.Visible = false;
            this.btnAgr.Click += new System.EventHandler(this.btnAgr_Click);
            // 
            // btnMod
            // 
            this.btnMod.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnMod.IconColor = System.Drawing.Color.Black;
            this.btnMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMod.IconSize = 40;
            this.btnMod.Location = new System.Drawing.Point(74, 3);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(65, 57);
            this.btnMod.TabIndex = 12;
            this.btnMod.Tag = "Boton Editar";
            this.btnMod.Text = "Modificar";
            this.btnMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Visible = false;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btnAlta.IconColor = System.Drawing.Color.Black;
            this.btnAlta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAlta.IconSize = 40;
            this.btnAlta.Location = new System.Drawing.Point(145, 3);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(65, 57);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Tag = "Boton Alta";
            this.btnAlta.Text = "Alta";
            this.btnAlta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Visible = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btnBaja.IconColor = System.Drawing.Color.Black;
            this.btnBaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaja.IconSize = 40;
            this.btnBaja.Location = new System.Drawing.Point(216, 3);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(65, 57);
            this.btnBaja.TabIndex = 14;
            this.btnBaja.Tag = "Boton Baja";
            this.btnBaja.Text = "Baja";
            this.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Visible = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(584, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(29, 29);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // lblABM
            // 
            this.lblABM.AutoSize = true;
            this.lblABM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABM.Location = new System.Drawing.Point(6, 6);
            this.lblABM.Name = "lblABM";
            this.lblABM.Size = new System.Drawing.Size(107, 16);
            this.lblABM.TabIndex = 32;
            this.lblABM.Text = "ABMProveedores";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(-4, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 367);
            this.panel1.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btnAgr);
            this.flowLayoutPanel1.Controls.Add(this.btnMod);
            this.flowLayoutPanel1.Controls.Add(this.btnAlta);
            this.flowLayoutPanel1.Controls.Add(this.btnBaja);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(316, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 68);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ABMProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 397);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblABM);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvProv);
            this.Controls.Add(this.txtTelPro);
            this.Controls.Add(this.txtCuilPro);
            this.Controls.Add(this.txtDirePro);
            this.Controls.Add(this.txtNombrePro);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABMProveedores";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Proveedores";
            this.Load += new System.EventHandler(this.ABMProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombrePro;
        private System.Windows.Forms.TextBox txtDirePro;
        private System.Windows.Forms.TextBox txtCuilPro;
        private System.Windows.Forms.TextBox txtTelPro;
        private System.Windows.Forms.DataGridView dgvProv;
        private System.Windows.Forms.BindingSource pruebaACADataSetBindingSource;
        private pruebaACADataSet pruebaACADataSet;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private pruebaACADataSetTableAdapters.proveedoresTableAdapter proveedoresTableAdapter;
        private FontAwesome.Sharp.IconButton btnAgr;
        private FontAwesome.Sharp.IconButton btnMod;
        private FontAwesome.Sharp.IconButton btnAlta;
        private FontAwesome.Sharp.IconButton btnBaja;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblABM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}