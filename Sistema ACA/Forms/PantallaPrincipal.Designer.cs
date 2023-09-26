namespace Sistema_ACA
{
    partial class PantallaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tusPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarListaDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoDeCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeSociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionSociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPrestacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidosToolStripMenuItem,
            this.prestacionesToolStripMenuItem,
            this.estadoDeCuentaToolStripMenuItem,
            this.gestionDeSociosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPedidosToolStripMenuItem,
            this.tusPedidosToolStripMenuItem,
            this.agregarListaDePedidosToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // solicitarPedidosToolStripMenuItem
            // 
            this.solicitarPedidosToolStripMenuItem.Name = "solicitarPedidosToolStripMenuItem";
            this.solicitarPedidosToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.solicitarPedidosToolStripMenuItem.Text = "Solicitar pedidos";
            this.solicitarPedidosToolStripMenuItem.Click += new System.EventHandler(this.solicitarPedidosToolStripMenuItem_Click);
            // 
            // tusPedidosToolStripMenuItem
            // 
            this.tusPedidosToolStripMenuItem.Name = "tusPedidosToolStripMenuItem";
            this.tusPedidosToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.tusPedidosToolStripMenuItem.Text = "Tus pedidos";
            this.tusPedidosToolStripMenuItem.Click += new System.EventHandler(this.tusPedidosToolStripMenuItem_Click);
            // 
            // agregarListaDePedidosToolStripMenuItem
            // 
            this.agregarListaDePedidosToolStripMenuItem.Name = "agregarListaDePedidosToolStripMenuItem";
            this.agregarListaDePedidosToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.agregarListaDePedidosToolStripMenuItem.Text = "Agregar lista de pedidos";
            this.agregarListaDePedidosToolStripMenuItem.Click += new System.EventHandler(this.agregarListaDePedidosToolStripMenuItem_Click);
            // 
            // prestacionesToolStripMenuItem
            // 
            this.prestacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPrestacionToolStripMenuItem});
            this.prestacionesToolStripMenuItem.Name = "prestacionesToolStripMenuItem";
            this.prestacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.prestacionesToolStripMenuItem.Text = "Prestaciones";
            // 
            // estadoDeCuentaToolStripMenuItem
            // 
            this.estadoDeCuentaToolStripMenuItem.Name = "estadoDeCuentaToolStripMenuItem";
            this.estadoDeCuentaToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.estadoDeCuentaToolStripMenuItem.Text = "Estado de cuenta";
            // 
            // gestionDeSociosToolStripMenuItem
            // 
            this.gestionDeSociosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionSociosToolStripMenuItem,
            this.informesToolStripMenuItem});
            this.gestionDeSociosToolStripMenuItem.Name = "gestionDeSociosToolStripMenuItem";
            this.gestionDeSociosToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.gestionDeSociosToolStripMenuItem.Text = "Administracion";
            this.gestionDeSociosToolStripMenuItem.Click += new System.EventHandler(this.gestionDeSociosToolStripMenuItem_Click);
            // 
            // gestionSociosToolStripMenuItem
            // 
            this.gestionSociosToolStripMenuItem.Name = "gestionSociosToolStripMenuItem";
            this.gestionSociosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestionSociosToolStripMenuItem.Text = "Gestion socios";
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // solicitarPrestacionToolStripMenuItem
            // 
            this.solicitarPrestacionToolStripMenuItem.Name = "solicitarPrestacionToolStripMenuItem";
            this.solicitarPrestacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.solicitarPrestacionToolStripMenuItem.Text = "Solicitar prestacion";
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A.C.A";
            this.Load += new System.EventHandler(this.PantallaPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tusPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarListaDePedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoDeCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeSociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarPrestacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionSociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
    }
}

