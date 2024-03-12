namespace Sistema_ACA.Forms.Admin
{
    partial class Backup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnGenerar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.bttnBuscar = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 114);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "BACKUP BASE DE DATOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Generar Backup:";
            // 
            // bttnGenerar
            // 
            this.bttnGenerar.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.bttnGenerar.IconColor = System.Drawing.Color.Black;
            this.bttnGenerar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bttnGenerar.IconSize = 30;
            this.bttnGenerar.Location = new System.Drawing.Point(194, 54);
            this.bttnGenerar.Name = "bttnGenerar";
            this.bttnGenerar.Size = new System.Drawing.Size(138, 36);
            this.bttnGenerar.TabIndex = 2;
            this.bttnGenerar.Text = "Backup";
            this.bttnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttnGenerar.UseVisualStyleBackColor = true;
            this.bttnGenerar.Click += new System.EventHandler(this.bttnGenerar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ruta:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Controls.Add(this.bttnBuscar);
            this.panel2.Controls.Add(this.txtRuta);
            this.panel2.Controls.Add(this.bttnGenerar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 329);
            this.panel2.TabIndex = 1;
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(110, 164);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(470, 20);
            this.txtRuta.TabIndex = 4;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.bttnBuscar.IconColor = System.Drawing.Color.Black;
            this.bttnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bttnBuscar.IconSize = 27;
            this.bttnBuscar.Location = new System.Drawing.Point(586, 163);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(38, 23);
            this.bttnBuscar.TabIndex = 5;
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(630, 161);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(138, 28);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.Text = "Restaurar Base de datos";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton bttnGenerar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton bttnBuscar;
        private System.Windows.Forms.TextBox txtRuta;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}