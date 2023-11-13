namespace Sistema_ACA
{
    partial class AgregarPedidos
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnaddprov = new System.Windows.Forms.Button();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaV = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.gbAgrPed = new System.Windows.Forms.GroupBox();
            this.bttnConfirmar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttnAgrProd = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.btnaddprod = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listapedidosproductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pruebaACADataSet = new Sistema_ACA.pruebaACADataSet();
            this.txtNumList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productosTableAdapter = new Sistema_ACA.pruebaACADataSetTableAdapters.productosTableAdapter();
            this.lista_pedidos_productosTableAdapter = new Sistema_ACA.pruebaACADataSetTableAdapters.lista_pedidos_productosTableAdapter();
            this.gbAgrPed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listapedidosproductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // btnaddprov
            // 
            this.btnaddprov.Location = new System.Drawing.Point(309, 62);
            this.btnaddprov.Name = "btnaddprov";
            this.btnaddprov.Size = new System.Drawing.Size(33, 23);
            this.btnaddprov.TabIndex = 2;
            this.btnaddprov.Text = "+";
            this.btnaddprov.UseVisualStyleBackColor = true;
            this.btnaddprov.Click += new System.EventHandler(this.btnaddprov_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(115, 62);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(187, 21);
            this.cmbProveedor.TabIndex = 3;
            this.cmbProveedor.DropDown += new System.EventHandler(this.cmbProveedor_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha vigencia:";
            // 
            // dtFechaV
            // 
            this.dtFechaV.Location = new System.Drawing.Point(115, 94);
            this.dtFechaV.MinDate = new System.DateTime(2023, 7, 7, 0, 0, 0, 0);
            this.dtFechaV.Name = "dtFechaV";
            this.dtFechaV.Size = new System.Drawing.Size(227, 20);
            this.dtFechaV.TabIndex = 5;
            this.dtFechaV.Value = new System.DateTime(2023, 7, 7, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Crear lista";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbAgrPed
            // 
            this.gbAgrPed.Controls.Add(this.bttnConfirmar);
            this.gbAgrPed.Controls.Add(this.dataGridView1);
            this.gbAgrPed.Controls.Add(this.bttnAgrProd);
            this.gbAgrPed.Controls.Add(this.txtPrecio);
            this.gbAgrPed.Controls.Add(this.label5);
            this.gbAgrPed.Controls.Add(this.cmbProducto);
            this.gbAgrPed.Controls.Add(this.btnaddprod);
            this.gbAgrPed.Controls.Add(this.label4);
            this.gbAgrPed.Enabled = false;
            this.gbAgrPed.Location = new System.Drawing.Point(387, 47);
            this.gbAgrPed.Name = "gbAgrPed";
            this.gbAgrPed.Size = new System.Drawing.Size(385, 402);
            this.gbAgrPed.TabIndex = 7;
            this.gbAgrPed.TabStop = false;
            this.gbAgrPed.Text = "Agregar productos";
            // 
            // bttnConfirmar
            // 
            this.bttnConfirmar.Location = new System.Drawing.Point(152, 354);
            this.bttnConfirmar.Name = "bttnConfirmar";
            this.bttnConfirmar.Size = new System.Drawing.Size(106, 23);
            this.bttnConfirmar.TabIndex = 14;
            this.bttnConfirmar.Text = "Confirmar Lista";
            this.bttnConfirmar.UseVisualStyleBackColor = true;
            this.bttnConfirmar.Click += new System.EventHandler(this.bttnConfirmar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(338, 254);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bttnAgrProd
            // 
            this.bttnAgrProd.Location = new System.Drawing.Point(239, 57);
            this.bttnAgrProd.Name = "bttnAgrProd";
            this.bttnAgrProd.Size = new System.Drawing.Size(106, 23);
            this.bttnAgrProd.TabIndex = 9;
            this.bttnAgrProd.Text = "Agregar producto";
            this.bttnAgrProd.UseVisualStyleBackColor = true;
            this.bttnAgrProd.Click += new System.EventHandler(this.bttnAgrProd_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(83, 59);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(150, 20);
            this.txtPrecio.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(83, 32);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(204, 21);
            this.cmbProducto.TabIndex = 11;
            // 
            // btnaddprod
            // 
            this.btnaddprod.Location = new System.Drawing.Point(312, 30);
            this.btnaddprod.Name = "btnaddprod";
            this.btnaddprod.Size = new System.Drawing.Size(33, 23);
            this.btnaddprod.TabIndex = 10;
            this.btnaddprod.Text = "+";
            this.btnaddprod.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Producto:";
            // 
            // listapedidosproductosBindingSource
            // 
            this.listapedidosproductosBindingSource.DataMember = "lista_pedidos_productos";
            this.listapedidosproductosBindingSource.DataSource = this.pruebaACADataSet;
            // 
            // pruebaACADataSet
            // 
            this.pruebaACADataSet.DataSetName = "pruebaACADataSet";
            this.pruebaACADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNumList
            // 
            this.txtNumList.Location = new System.Drawing.Point(115, 122);
            this.txtNumList.Name = "txtNumList";
            this.txtNumList.ReadOnly = true;
            this.txtNumList.Size = new System.Drawing.Size(187, 20);
            this.txtNumList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numero de lista:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "productos";
            this.bindingSource1.DataSource = this.pruebaACADataSet;
            // 
            // productosTableAdapter
            // 
            this.productosTableAdapter.ClearBeforeFill = true;
            // 
            // lista_pedidos_productosTableAdapter
            // 
            this.lista_pedidos_productosTableAdapter.ClearBeforeFill = true;
            // 
            // AgregarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumList);
            this.Controls.Add(this.gbAgrPed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtFechaV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.btnaddprov);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarPedidos";
            this.ShowIcon = false;
            this.Text = "Agregar lista de pedidos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmagregarp_Load);
            this.gbAgrPed.ResumeLayout(false);
            this.gbAgrPed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listapedidosproductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnaddprov;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbAgrPed;
        
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button btnaddprod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private System.Windows.Forms.Button bttnAgrProd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private pruebaACADataSet pruebaACADataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private pruebaACADataSetTableAdapters.productosTableAdapter productosTableAdapter;
        private System.Windows.Forms.BindingSource listapedidosproductosBindingSource;
        private pruebaACADataSetTableAdapters.lista_pedidos_productosTableAdapter lista_pedidos_productosTableAdapter;
        private System.Windows.Forms.Button bttnConfirmar;
    }
}