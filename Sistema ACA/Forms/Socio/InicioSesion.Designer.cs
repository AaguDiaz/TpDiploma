namespace Sistema_ACA
{
    partial class InicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesion));
            this.bttnInicio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnInicio
            // 
            this.bttnInicio.BackColor = System.Drawing.SystemColors.Control;
            this.bttnInicio.FlatAppearance.BorderSize = 0;
            this.bttnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.bttnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.bttnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnInicio.Font = new System.Drawing.Font("Arial", 10F);
            this.bttnInicio.ForeColor = System.Drawing.Color.Black;
            this.bttnInicio.Location = new System.Drawing.Point(278, 156);
            this.bttnInicio.Name = "bttnInicio";
            this.bttnInicio.Size = new System.Drawing.Size(273, 36);
            this.bttnInicio.TabIndex = 3;
            this.bttnInicio.Text = "Iniciar sesion";
            this.bttnInicio.UseVisualStyleBackColor = false;
            this.bttnInicio.Click += new System.EventHandler(this.bttnInicio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio Sesión";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.Color.DimGray;
            this.txtMail.Location = new System.Drawing.Point(278, 74);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(273, 21);
            this.txtMail.TabIndex = 1;
            this.txtMail.Text = "MAIL";
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.Color.DimGray;
            this.txtContra.Location = new System.Drawing.Point(278, 114);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(273, 20);
            this.txtContra.TabIndex = 2;
            this.txtContra.Text = "CONTRASEÑA";
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(584, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 20);
            this.button3.TabIndex = 4;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.linkLabel1.Location = new System.Drawing.Point(344, 195);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(134, 14);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Olvidaste tu contraseña?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(275, 137);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 239);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioSesion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesion";
            this.Load += new System.EventHandler(this.InicioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bttnInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblError;
    }
}