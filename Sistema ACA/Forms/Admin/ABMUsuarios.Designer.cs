namespace Sistema_ACA.Forms
{
    partial class ABMUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltros = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lbluno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 121);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 322);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(302, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestionar usuarios";
            // 
            // cmbFiltros
            // 
            this.cmbFiltros.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltros.FormattingEnabled = true;
            this.cmbFiltros.Location = new System.Drawing.Point(314, 86);
            this.cmbFiltros.Name = "cmbFiltros";
            this.cmbFiltros.Size = new System.Drawing.Size(190, 21);
            this.cmbFiltros.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(264, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtros:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAgregar.Location = new System.Drawing.Point(12, 75);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 40);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Registrar usuario";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.FlatAppearance.BorderSize = 0;
            this.btnAlta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAlta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.Location = new System.Drawing.Point(526, 75);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(120, 40);
            this.btnAlta.TabIndex = 5;
            this.btnAlta.Text = "Dar de Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.FlatAppearance.BorderSize = 0;
            this.btnBaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnBaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaja.Location = new System.Drawing.Point(652, 75);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(120, 40);
            this.btnBaja.TabIndex = 6;
            this.btnBaja.Text = "Dar de Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEditar.Location = new System.Drawing.Point(138, 75);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 40);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar usuario";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Arial", 9F);
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(45, 42);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(14, 15);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "X";
            // 
            // lbluno
            // 
            this.lbluno.AutoSize = true;
            this.lbluno.Font = new System.Drawing.Font("Arial", 12F);
            this.lbluno.ForeColor = System.Drawing.Color.Red;
            this.lbluno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbluno.Location = new System.Drawing.Point(36, 39);
            this.lbluno.Name = "lbluno";
            this.lbluno.Size = new System.Drawing.Size(13, 18);
            this.lbluno.TabIndex = 10;
            this.lbluno.Text = "!";
            // 
            // ABMUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 447);
            this.ControlBox = false;
            this.Controls.Add(this.lbluno);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFiltros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABMUsuarios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ABMUsuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ABMUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lbluno;
    }
}