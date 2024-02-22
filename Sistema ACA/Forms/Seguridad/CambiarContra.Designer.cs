namespace Sistema_ACA
{
    partial class CambiarContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContra));
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtCOD = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEnviar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEnviar.Location = new System.Drawing.Point(513, 28);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(117, 27);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar codigo";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Enabled = false;
            this.btnVerificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnVerificar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnVerificar.Location = new System.Drawing.Point(513, 75);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(117, 27);
            this.btnVerificar.TabIndex = 5;
            this.btnVerificar.Text = "Verificar codigo";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnConfirmar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnConfirmar.Location = new System.Drawing.Point(513, 131);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(117, 53);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar contraseña";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Visible = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtMail.ForeColor = System.Drawing.Color.DimGray;
            this.txtMail.Location = new System.Drawing.Point(225, 30);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(273, 23);
            this.txtMail.TabIndex = 11;
            this.txtMail.Text = "MAIL";
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtCOD
            // 
            this.txtCOD.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtCOD.ForeColor = System.Drawing.Color.DimGray;
            this.txtCOD.Location = new System.Drawing.Point(225, 77);
            this.txtCOD.Name = "txtCOD";
            this.txtCOD.Size = new System.Drawing.Size(273, 23);
            this.txtCOD.TabIndex = 12;
            this.txtCOD.Text = "CÓDIGO";
            this.txtCOD.Enter += new System.EventHandler(this.txtCOD_Enter);
            this.txtCOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCOD_KeyPress);
            this.txtCOD.Leave += new System.EventHandler(this.txtCOD_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtContra.ForeColor = System.Drawing.Color.DimGray;
            this.txtContra.Location = new System.Drawing.Point(225, 131);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(273, 23);
            this.txtContra.TabIndex = 13;
            this.txtContra.Text = "CONTRASEÑA";
            this.txtContra.Visible = false;
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(226, 75);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 14;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmar.Location = new System.Drawing.Point(225, 162);
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Size = new System.Drawing.Size(273, 22);
            this.txtConfirmar.TabIndex = 15;
            this.txtConfirmar.Text = "CONFIRMAR CONTRASEÑA";
            this.txtConfirmar.Visible = false;
            this.txtConfirmar.Enter += new System.EventHandler(this.txtConfirmar_Enter);
            this.txtConfirmar.Leave += new System.EventHandler(this.txtConfirmar_Leave);
            // 
            // CambiarContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 214);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtCOD);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnEnviar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambiarContra";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.CambiarContra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtCOD;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtConfirmar;
    }
}