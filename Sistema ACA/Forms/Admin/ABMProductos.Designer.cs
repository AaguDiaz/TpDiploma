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
            this.btnMarco = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblABM = new System.Windows.Forms.Label();
            this.cbCat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgrCat = new FontAwesome.Sharp.IconButton();
            this.btnBaja = new FontAwesome.Sharp.IconButton();
            this.btnMod = new FontAwesome.Sharp.IconButton();
            this.btnAgr = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProd
            // 
            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.AllowUserToDeleteRows = false;
            this.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd.Location = new System.Drawing.Point(9, 113);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.ReadOnly = true;
            this.dgvProd.Size = new System.Drawing.Size(620, 325);
            this.dgvProd.TabIndex = 19;
            this.dgvProd.SelectionChanged += new System.EventHandler(this.dgvProd_SelectionChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(167, 43);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(238, 22);
            this.txtDescripcion.TabIndex = 16;
            this.txtDescripcion.Text = "Descripcion:";
            this.txtDescripcion.Enter += new System.EventHandler(this.txtDescripcion_Enter);
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(9, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(152, 22);
            this.txtNombre.TabIndex = 15;
            this.txtNombre.Text = "Nombre:";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // btnMarco
            // 
            this.btnMarco.BackColor = System.Drawing.SystemColors.Control;
            this.btnMarco.Enabled = false;
            this.btnMarco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMarco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarco.Location = new System.Drawing.Point(0, 29);
            this.btnMarco.Name = "btnMarco";
            this.btnMarco.Size = new System.Drawing.Size(641, 421);
            this.btnMarco.TabIndex = 20;
            this.btnMarco.UseVisualStyleBackColor = false;
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
            this.cbCat.Location = new System.Drawing.Point(85, 75);
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(186, 23);
            this.cbCat.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 79);
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
            this.btnAgrCat.IconSize = 20;
            this.btnAgrCat.Location = new System.Drawing.Point(277, 75);
            this.btnAgrCat.Name = "btnAgrCat";
            this.btnAgrCat.Size = new System.Drawing.Size(128, 25);
            this.btnAgrCat.TabIndex = 34;
            this.btnAgrCat.Text = "Agregar categoria";
            this.btnAgrCat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgrCat.UseVisualStyleBackColor = true;
            this.btnAgrCat.Click += new System.EventHandler(this.btnAgrCat_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBaja.IconColor = System.Drawing.Color.Black;
            this.btnBaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaja.IconSize = 40;
            this.btnBaja.Location = new System.Drawing.Point(564, 43);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(65, 57);
            this.btnBaja.TabIndex = 24;
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnMod
            // 
            this.btnMod.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnMod.IconColor = System.Drawing.Color.Black;
            this.btnMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMod.IconSize = 40;
            this.btnMod.Location = new System.Drawing.Point(493, 43);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(65, 57);
            this.btnMod.TabIndex = 22;
            this.btnMod.Text = "Modificar";
            this.btnMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAgr
            // 
            this.btnAgr.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgr.IconColor = System.Drawing.Color.Black;
            this.btnAgr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgr.IconSize = 40;
            this.btnAgr.Location = new System.Drawing.Point(422, 43);
            this.btnAgr.Name = "btnAgr";
            this.btnAgr.Size = new System.Drawing.Size(65, 57);
            this.btnAgr.TabIndex = 21;
            this.btnAgr.Text = "Agregar";
            this.btnAgr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgr.UseVisualStyleBackColor = true;
            this.btnAgr.Click += new System.EventHandler(this.btnAgr_Click);
            // 
            // ABMProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCat);
            this.Controls.Add(this.btnAgrCat);
            this.Controls.Add(this.lblABM);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAgr);
            this.Controls.Add(this.dgvProd);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnMarco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABMProductos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMProductos";
            this.Load += new System.EventHandler(this.ABMProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
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
        private System.Windows.Forms.Button btnMarco;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblABM;
        private FontAwesome.Sharp.IconButton btnAgrCat;
        private System.Windows.Forms.ComboBox cbCat;
        private System.Windows.Forms.Label label1;
    }
}