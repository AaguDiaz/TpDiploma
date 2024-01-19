namespace Sistema_ACA.Forms.Admin
{
    partial class NuevaLista
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.botones = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProveedores = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaVen = new System.Windows.Forms.DateTimePicker();
            this.btnAgProveedor = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProd
            // 
            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.AllowUserToDeleteRows = false;
            this.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd.Location = new System.Drawing.Point(13, 56);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.ReadOnly = true;
            this.dgvProd.Size = new System.Drawing.Size(671, 293);
            this.dgvProd.TabIndex = 24;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(425, 395);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 27);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(562, 395);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(122, 27);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // botones
            // 
            this.botones.BackColor = System.Drawing.SystemColors.Menu;
            this.botones.Enabled = false;
            this.botones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botones.Location = new System.Drawing.Point(0, 0);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(696, 434);
            this.botones.TabIndex = 25;
            this.botones.Text = " ";
            this.botones.UseVisualStyleBackColor = false;
            this.botones.Click += new System.EventHandler(this.botones_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Proveedores:";
            // 
            // cbProveedores
            // 
            this.cbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedores.FormattingEnabled = true;
            this.cbProveedores.Location = new System.Drawing.Point(84, 21);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(197, 21);
            this.cbProveedores.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(341, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Fecha Vencimiento:";
            // 
            // dtpFechaVen
            // 
            this.dtpFechaVen.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVen.Location = new System.Drawing.Point(451, 21);
            this.dtpFechaVen.Name = "dtpFechaVen";
            this.dtpFechaVen.Size = new System.Drawing.Size(232, 22);
            this.dtpFechaVen.TabIndex = 36;
            // 
            // btnAgProveedor
            // 
            this.btnAgProveedor.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgProveedor.IconColor = System.Drawing.Color.Black;
            this.btnAgProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgProveedor.IconSize = 25;
            this.btnAgProveedor.Location = new System.Drawing.Point(287, 17);
            this.btnAgProveedor.Name = "btnAgProveedor";
            this.btnAgProveedor.Size = new System.Drawing.Size(26, 28);
            this.btnAgProveedor.TabIndex = 25;
            this.btnAgProveedor.UseVisualStyleBackColor = true;
            this.btnAgProveedor.Click += new System.EventHandler(this.btnAgProveedor_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.Location = new System.Drawing.Point(104, 356);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 69);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Productos";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.Location = new System.Drawing.Point(13, 356);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 69);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Productos";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // NuevaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 434);
            this.Controls.Add(this.btnAgProveedor);
            this.Controls.Add(this.dtpFechaVen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbProveedores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvProd);
            this.Controls.Add(this.botones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaLista";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva lista de pedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NuevaLista_FormClosing);
            this.Load += new System.EventHandler(this.NuevaLista_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NuevaLista_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProd;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button botones;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProveedores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaVen;
        private FontAwesome.Sharp.IconButton btnAgProveedor;
    }
}