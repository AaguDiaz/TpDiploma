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
            this.estadoDeCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarListaDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarPrestacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abmTSMT = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosPrestacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestUsuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.audiTMSI = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadoDeCuentaToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.prestacionesToolStripMenuItem,
            this.repotesToolStripMenuItem,
            this.AdminToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1340, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // estadoDeCuentaToolStripMenuItem
            // 
            this.estadoDeCuentaToolStripMenuItem.Name = "estadoDeCuentaToolStripMenuItem";
            this.estadoDeCuentaToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.estadoDeCuentaToolStripMenuItem.Tag = "EstadoCuenta";
            this.estadoDeCuentaToolStripMenuItem.Text = "Estado de cuenta";
            this.estadoDeCuentaToolStripMenuItem.Click += new System.EventHandler(this.estadoDeCuentaToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPedidosToolStripMenuItem,
            this.agregarListaDePedidosToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Tag = "Pedidos";
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // solicitarPedidosToolStripMenuItem
            // 
            this.solicitarPedidosToolStripMenuItem.Name = "solicitarPedidosToolStripMenuItem";
            this.solicitarPedidosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.solicitarPedidosToolStripMenuItem.Tag = "SolicitarPedido";
            this.solicitarPedidosToolStripMenuItem.Text = "Solicitar pedidos";
            this.solicitarPedidosToolStripMenuItem.Click += new System.EventHandler(this.solicitarPedidosToolStripMenuItem_Click);
            // 
            // agregarListaDePedidosToolStripMenuItem
            // 
            this.agregarListaDePedidosToolStripMenuItem.Name = "agregarListaDePedidosToolStripMenuItem";
            this.agregarListaDePedidosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarListaDePedidosToolStripMenuItem.Tag = "AgregarPedidos";
            this.agregarListaDePedidosToolStripMenuItem.Text = "Lista de pedidos";
            this.agregarListaDePedidosToolStripMenuItem.Click += new System.EventHandler(this.agregarListaDePedidosToolStripMenuItem_Click);
            // 
            // prestacionesToolStripMenuItem
            // 
            this.prestacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarPrestacionToolStripMenuItem});
            this.prestacionesToolStripMenuItem.Name = "prestacionesToolStripMenuItem";
            this.prestacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.prestacionesToolStripMenuItem.Tag = "Prestaciones";
            this.prestacionesToolStripMenuItem.Text = "Prestaciones";
            // 
            // solicitarPrestacionToolStripMenuItem
            // 
            this.solicitarPrestacionToolStripMenuItem.Name = "solicitarPrestacionToolStripMenuItem";
            this.solicitarPrestacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.solicitarPrestacionToolStripMenuItem.Tag = "Prestaciones";
            this.solicitarPrestacionToolStripMenuItem.Text = "Solicitar prestacion";
            this.solicitarPrestacionToolStripMenuItem.Click += new System.EventHandler(this.solicitarPrestacionToolStripMenuItem_Click);
            // 
            // repotesToolStripMenuItem
            // 
            this.repotesToolStripMenuItem.Name = "repotesToolStripMenuItem";
            this.repotesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.repotesToolStripMenuItem.Tag = "Reportes";
            this.repotesToolStripMenuItem.Text = "Repotes";
            this.repotesToolStripMenuItem.Click += new System.EventHandler(this.repotesToolStripMenuItem_Click);
            // 
            // AdminToolStripMenuItem
            // 
            this.AdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmTSMT,
            this.gestUsuTSMI,
            this.audiTMSI});
            this.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem";
            this.AdminToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.AdminToolStripMenuItem.Tag = "Admin";
            this.AdminToolStripMenuItem.Text = "Administracion";
            // 
            // abmTSMT
            // 
            this.abmTSMT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.pedidosPrestacionesToolStripMenuItem,
            this.gruposToolStripMenuItem});
            this.abmTSMT.Name = "abmTSMT";
            this.abmTSMT.Size = new System.Drawing.Size(180, 22);
            this.abmTSMT.Tag = "ABMS";
            this.abmTSMT.Text = "ABMS";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.proveedoresToolStripMenuItem.Tag = "ABMProveedores";
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.productosToolStripMenuItem.Tag = "ABMProductos";
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // pedidosPrestacionesToolStripMenuItem
            // 
            this.pedidosPrestacionesToolStripMenuItem.Name = "pedidosPrestacionesToolStripMenuItem";
            this.pedidosPrestacionesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pedidosPrestacionesToolStripMenuItem.Tag = "ABMPedidosYPrestaciones";
            this.pedidosPrestacionesToolStripMenuItem.Text = "Pedidos/Prestaciones";
            this.pedidosPrestacionesToolStripMenuItem.Click += new System.EventHandler(this.pedidosPrestacionesToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gruposToolStripMenuItem.Tag = "ABMGrupos";
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // gestUsuTSMI
            // 
            this.gestUsuTSMI.Name = "gestUsuTSMI";
            this.gestUsuTSMI.Size = new System.Drawing.Size(180, 22);
            this.gestUsuTSMI.Tag = "ABMUsuarios";
            this.gestUsuTSMI.Text = "Gestion usuarios";
            this.gestUsuTSMI.Click += new System.EventHandler(this.gestionSociosToolStripMenuItem_Click);
            // 
            // audiTMSI
            // 
            this.audiTMSI.Name = "audiTMSI";
            this.audiTMSI.Size = new System.Drawing.Size(180, 22);
            this.audiTMSI.Tag = "Auditoria";
            this.audiTMSI.Text = "Auditoria";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.logoutToolStripMenuItem.Tag = "CerrarSesion";
            this.logoutToolStripMenuItem.Text = "Cerrar Sesion";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1340, 737);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A.C.A";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PantallaPrincipal_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem agregarListaDePedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoDeCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarPrestacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestUsuTSMI;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audiTMSI;
        private System.Windows.Forms.ToolStripMenuItem abmTSMT;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosPrestacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
    }
}

