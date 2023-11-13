namespace Sistema_ACA.Forms
{
    partial class CargaDatosUsuarios
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCvu = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgrPer = new System.Windows.Forms.Button();
            this.btnEliPer = new System.Windows.Forms.Button();
            this.btnAgrGru = new System.Windows.Forms.Button();
            this.btnEliGru = new System.Windows.Forms.Button();
            this.brnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNueGru = new System.Windows.Forms.Button();
            this.btnNuePer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(31, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 21);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Text = "Nombre:";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtApellido
            // 
            this.txtApellido.ForeColor = System.Drawing.Color.DimGray;
            this.txtApellido.Location = new System.Drawing.Point(31, 67);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(195, 20);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.Text = "Apellido:";
            this.txtApellido.Enter += new System.EventHandler(this.txtApellido_Enter);
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            this.txtApellido.Leave += new System.EventHandler(this.txtApellido_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(31, 105);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 21);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "Email:";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Arial", 9F);
            this.txtContra.ForeColor = System.Drawing.Color.DimGray;
            this.txtContra.Location = new System.Drawing.Point(31, 143);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(195, 21);
            this.txtContra.TabIndex = 3;
            this.txtContra.Text = "Contraseña:";
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.Location = new System.Drawing.Point(254, 143);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(195, 21);
            this.txtDireccion.TabIndex = 8;
            this.txtDireccion.Text = "Direccion:";
            this.txtDireccion.Enter += new System.EventHandler(this.txtDireccion_Enter);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTelefono.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelefono.Location = new System.Drawing.Point(254, 105);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(195, 21);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.Text = "Telefono:";
            this.txtTelefono.Enter += new System.EventHandler(this.txtTelefono_Enter);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Leave += new System.EventHandler(this.txtTelefono_Leave);
            // 
            // txtCvu
            // 
            this.txtCvu.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCvu.ForeColor = System.Drawing.Color.DimGray;
            this.txtCvu.Location = new System.Drawing.Point(254, 67);
            this.txtCvu.Name = "txtCvu";
            this.txtCvu.Size = new System.Drawing.Size(195, 21);
            this.txtCvu.TabIndex = 6;
            this.txtCvu.Text = "CVU:";
            this.txtCvu.Enter += new System.EventHandler(this.txtCVU_Enter);
            this.txtCvu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCvu_KeyPress);
            this.txtCvu.Leave += new System.EventHandler(this.txtCVU_Leave);
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDni.ForeColor = System.Drawing.Color.DimGray;
            this.txtDni.Location = new System.Drawing.Point(254, 27);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(195, 21);
            this.txtDni.TabIndex = 5;
            this.txtDni.Text = "DNI:";
            this.txtDni.Enter += new System.EventHandler(this.txtDNI_Enter);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            this.txtDni.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(31, 199);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.Size = new System.Drawing.Size(344, 181);
            this.dgvPermisos.TabIndex = 9;
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(31, 412);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.Size = new System.Drawing.Size(344, 181);
            this.dgvGrupos.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(28, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Permisos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(28, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Grupos:";
            // 
            // btnAgrPer
            // 
            this.btnAgrPer.FlatAppearance.BorderSize = 0;
            this.btnAgrPer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgrPer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAgrPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgrPer.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAgrPer.Location = new System.Drawing.Point(379, 199);
            this.btnAgrPer.Name = "btnAgrPer";
            this.btnAgrPer.Size = new System.Drawing.Size(95, 41);
            this.btnAgrPer.TabIndex = 13;
            this.btnAgrPer.Text = "Agregar Permiso";
            this.btnAgrPer.UseVisualStyleBackColor = true;
            this.btnAgrPer.Click += new System.EventHandler(this.btnAgrPer_Click);
            // 
            // btnEliPer
            // 
            this.btnEliPer.FlatAppearance.BorderSize = 0;
            this.btnEliPer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEliPer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEliPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliPer.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliPer.Location = new System.Drawing.Point(379, 246);
            this.btnEliPer.Name = "btnEliPer";
            this.btnEliPer.Size = new System.Drawing.Size(95, 41);
            this.btnEliPer.TabIndex = 14;
            this.btnEliPer.Text = "Eliminar Permiso";
            this.btnEliPer.UseVisualStyleBackColor = true;
            this.btnEliPer.Click += new System.EventHandler(this.btnEliPer_Click);
            // 
            // btnAgrGru
            // 
            this.btnAgrGru.FlatAppearance.BorderSize = 0;
            this.btnAgrGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgrGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAgrGru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgrGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAgrGru.Location = new System.Drawing.Point(381, 412);
            this.btnAgrGru.Name = "btnAgrGru";
            this.btnAgrGru.Size = new System.Drawing.Size(95, 41);
            this.btnAgrGru.TabIndex = 15;
            this.btnAgrGru.Text = "Agregar  Grupo";
            this.btnAgrGru.UseVisualStyleBackColor = true;
            this.btnAgrGru.Click += new System.EventHandler(this.btnAgrGru_Click);
            // 
            // btnEliGru
            // 
            this.btnEliGru.FlatAppearance.BorderSize = 0;
            this.btnEliGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEliGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEliGru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliGru.Location = new System.Drawing.Point(381, 459);
            this.btnEliGru.Name = "btnEliGru";
            this.btnEliGru.Size = new System.Drawing.Size(93, 41);
            this.btnEliGru.TabIndex = 16;
            this.btnEliGru.Text = "Eliminar Grupo";
            this.btnEliGru.UseVisualStyleBackColor = true;
            this.btnEliGru.Click += new System.EventHandler(this.btnEliPGru_Click);
            // 
            // brnConfirmar
            // 
            this.brnConfirmar.FlatAppearance.BorderSize = 0;
            this.brnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.brnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.brnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnConfirmar.Font = new System.Drawing.Font("Arial", 9F);
            this.brnConfirmar.Location = new System.Drawing.Point(383, 599);
            this.brnConfirmar.Name = "brnConfirmar";
            this.brnConfirmar.Size = new System.Drawing.Size(93, 34);
            this.brnConfirmar.TabIndex = 17;
            this.brnConfirmar.Text = "Confirmar";
            this.brnConfirmar.UseVisualStyleBackColor = true;
            this.brnConfirmar.Click += new System.EventHandler(this.brnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancelar.Location = new System.Drawing.Point(284, 599);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 34);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Crimson;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(463, 1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(22, 21);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNueGru
            // 
            this.btnNueGru.FlatAppearance.BorderSize = 0;
            this.btnNueGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnNueGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNueGru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNueGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNueGru.Location = new System.Drawing.Point(381, 506);
            this.btnNueGru.Name = "btnNueGru";
            this.btnNueGru.Size = new System.Drawing.Size(93, 41);
            this.btnNueGru.TabIndex = 20;
            this.btnNueGru.Text = "Nuevo Grupo";
            this.btnNueGru.UseVisualStyleBackColor = true;
            // 
            // btnNuePer
            // 
            this.btnNuePer.FlatAppearance.BorderSize = 0;
            this.btnNuePer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnNuePer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNuePer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuePer.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNuePer.Location = new System.Drawing.Point(381, 293);
            this.btnNuePer.Name = "btnNuePer";
            this.btnNuePer.Size = new System.Drawing.Size(93, 41);
            this.btnNuePer.TabIndex = 21;
            this.btnNuePer.Text = "Nuevo Permiso";
            this.btnNuePer.UseVisualStyleBackColor = true;
            // 
            // CargaDatosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 645);
            this.ControlBox = false;
            this.Controls.Add(this.btnNuePer);
            this.Controls.Add(this.btnNueGru);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.brnConfirmar);
            this.Controls.Add(this.btnEliGru);
            this.Controls.Add(this.btnAgrGru);
            this.Controls.Add(this.btnEliPer);
            this.Controls.Add(this.btnAgrPer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrupos);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCvu);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargaDatosUsuarios";
            this.Text = "CargaDatosUsuarios";
            this.Load += new System.EventHandler(this.CargaDatosUsuarios_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CargaDatosUsuarios_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCvu;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgrPer;
        private System.Windows.Forms.Button btnEliPer;
        private System.Windows.Forms.Button btnAgrGru;
        private System.Windows.Forms.Button btnEliGru;
        private System.Windows.Forms.Button brnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNueGru;
        private System.Windows.Forms.Button btnNuePer;
    }
}