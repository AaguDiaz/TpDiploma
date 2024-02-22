namespace Sistema_ACA.Forms.Admin
{
    partial class ABMProductos
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
            this.dgvProd = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblABM = new System.Windows.Forms.Label();
            this.cbCat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgrCat = new FontAwesome.Sharp.IconButton();
            this.btnBaja = new FontAwesome.Sharp.IconButton();
            this.btnMod = new FontAwesome.Sharp.IconButton();
            this.btnAgr = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProd
            // 
            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.AllowUserToDeleteRows = false;
            this.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd.Location = new System.Drawing.Point(10, 162);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.ReadOnly = true;
            this.dgvProd.Size = new System.Drawing.Size(620, 383);
            this.dgvProd.TabIndex = 19;
            this.dgvProd.SelectionChanged += new System.EventHandler(this.dgvProd_SelectionChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(296, 87);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(334, 63);
            this.txtDescripcion.TabIndex = 16;
            this.txtDescripcion.Text = "Descripcion:";
            this.txtDescripcion.Enter += new System.EventHandler(this.txtDescripcion_Enter);
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(10, 87);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 22);
            this.txtNombre.TabIndex = 15;
            this.txtNombre.Text = "Nombre:";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(612, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(29, 29);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblABM
            // 
            this.lblABM.AutoSize = true;
            this.lblABM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABM.Location = new System.Drawing.Point(6, 6);
            this.lblABM.Name = "lblABM";
            this.lblABM.Size = new System.Drawing.Size(95, 16);
            this.lblABM.TabIndex = 33;
            this.lblABM.Text = "ABMProductos";
            // 
            // cbCat
            // 
            this.cbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCat.FormattingEnabled = true;
            this.cbCat.Location = new System.Drawing.Point(104, 127);
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(186, 23);
            this.cbCat.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Categorias:";
            // 
            // btnAgrCat
            // 
            this.btnAgrCat.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgrCat.IconColor = System.Drawing.Color.Black;
            this.btnAgrCat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgrCat.IconSize = 30;
            this.btnAgrCat.Location = new System.Drawing.Point(216, 3);
            this.btnAgrCat.Name = "btnAgrCat";
            this.btnAgrCat.Size = new System.Drawing.Size(65, 57);
            this.btnAgrCat.TabIndex = 34;
            this.btnAgrCat.Tag = "Boton Categorias";
            this.btnAgrCat.Text = "Agregar categoria";
            this.btnAgrCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgrCat.UseVisualStyleBackColor = true;
            this.btnAgrCat.Visible = false;
            this.btnAgrCat.Click += new System.EventHandler(this.btnAgrCat_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBaja.IconColor = System.Drawing.Color.Black;
            this.btnBaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaja.IconSize = 40;
            this.btnBaja.Location = new System.Drawing.Point(145, 3);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(65, 57);
            this.btnBaja.TabIndex = 24;
            this.btnBaja.Tag = "Boton Eliminar";
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Visible = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnMod
            // 
            this.btnMod.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnMod.IconColor = System.Drawing.Color.Black;
            this.btnMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMod.IconSize = 40;
            this.btnMod.Location = new System.Drawing.Point(74, 3);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(65, 57);
            this.btnMod.TabIndex = 22;
            this.btnMod.Tag = "Boton Editar";
            this.btnMod.Text = "Modificar";
            this.btnMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Visible = false;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAgr
            // 
            this.btnAgr.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgr.IconColor = System.Drawing.Color.Black;
            this.btnAgr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgr.IconSize = 40;
            this.btnAgr.Location = new System.Drawing.Point(3, 3);
            this.btnAgr.Name = "btnAgr";
            this.btnAgr.Size = new System.Drawing.Size(65, 57);
            this.btnAgr.TabIndex = 21;
            this.btnAgr.Tag = "Boton Registrar";
            this.btnAgr.Text = "Agregar";
            this.btnAgr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgr.UseVisualStyleBackColor = true;
            this.btnAgr.Visible = false;
            this.btnAgr.Click += new System.EventHandler(this.btnAgr_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbCat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.dgvProd);
            this.panel1.Location = new System.Drawing.Point(-1, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 556);
            this.panel1.TabIndex = 37;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.flowLayoutPanel1.Controls.Add(this.btnAgr);
            this.flowLayoutPanel1.Controls.Add(this.btnMod);
            this.flowLayoutPanel1.Controls.Add(this.btnBaja);
            this.flowLayoutPanel1.Controls.Add(this.btnAgrCat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 14);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(620, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ABMProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 586);
            this.Controls.Add(this.lblABM);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABMProductos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMProductos";
            this.Load += new System.EventHandler(this.ABMProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBaja;
        private FontAwesome.Sharp.IconButton btnMod;
        private FontAwesome.Sharp.IconButton btnAgr;
        private System.Windows.Forms.DataGridView dgvProd;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblABM;
        private FontAwesome.Sharp.IconButton btnAgrCat;
        private System.Windows.Forms.ComboBox cbCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}