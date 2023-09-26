namespace Sistema_ACA
{
    partial class ABMProveedores
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
            this.txtNombrePro = new System.Windows.Forms.TextBox();
            this.txtDirePro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCuilPro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelPro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idproveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreproveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionproDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pruebaACADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pruebaACADataSet = new Sistema_ACA.pruebaACADataSet();
            this.proveedoresTableAdapter = new Sistema_ACA.pruebaACADataSetTableAdapters.proveedoresTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtNombrePro
            // 
            this.txtNombrePro.Location = new System.Drawing.Point(178, 40);
            this.txtNombrePro.Name = "txtNombrePro";
            this.txtNombrePro.Size = new System.Drawing.Size(140, 20);
            this.txtNombrePro.TabIndex = 1;
            this.txtNombrePro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePro_KeyPress);
            // 
            // txtDirePro
            // 
            this.txtDirePro.Location = new System.Drawing.Point(443, 40);
            this.txtDirePro.Name = "txtDirePro";
            this.txtDirePro.Size = new System.Drawing.Size(140, 20);
            this.txtDirePro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Direccion:";
            // 
            // txtCuilPro
            // 
            this.txtCuilPro.Location = new System.Drawing.Point(178, 79);
            this.txtCuilPro.Name = "txtCuilPro";
            this.txtCuilPro.Size = new System.Drawing.Size(140, 20);
            this.txtCuilPro.TabIndex = 5;
            this.txtCuilPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuilPro_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cuil:";
            // 
            // txtTelPro
            // 
            this.txtTelPro.Location = new System.Drawing.Point(443, 79);
            this.txtTelPro.Name = "txtTelPro";
            this.txtTelPro.Size = new System.Drawing.Size(140, 20);
            this.txtTelPro.TabIndex = 7;
            this.txtTelPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelPro_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefono:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 59);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idproveedorDataGridViewTextBoxColumn,
            this.nombreproveedorDataGridViewTextBoxColumn,
            this.direccionproDataGridViewTextBoxColumn,
            this.cuilDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.proveedoresBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(98, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(592, 258);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idproveedorDataGridViewTextBoxColumn
            // 
            this.idproveedorDataGridViewTextBoxColumn.DataPropertyName = "id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.HeaderText = "id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.Name = "idproveedorDataGridViewTextBoxColumn";
            this.idproveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreproveedorDataGridViewTextBoxColumn
            // 
            this.nombreproveedorDataGridViewTextBoxColumn.DataPropertyName = "nombre_proveedor";
            this.nombreproveedorDataGridViewTextBoxColumn.HeaderText = "nombre_proveedor";
            this.nombreproveedorDataGridViewTextBoxColumn.Name = "nombreproveedorDataGridViewTextBoxColumn";
            this.nombreproveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionproDataGridViewTextBoxColumn
            // 
            this.direccionproDataGridViewTextBoxColumn.DataPropertyName = "direccion_pro";
            this.direccionproDataGridViewTextBoxColumn.HeaderText = "direccion_pro";
            this.direccionproDataGridViewTextBoxColumn.Name = "direccionproDataGridViewTextBoxColumn";
            this.direccionproDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cuilDataGridViewTextBoxColumn
            // 
            this.cuilDataGridViewTextBoxColumn.DataPropertyName = "cuil";
            this.cuilDataGridViewTextBoxColumn.HeaderText = "cuil";
            this.cuilDataGridViewTextBoxColumn.Name = "cuilDataGridViewTextBoxColumn";
            this.cuilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "proveedores";
            this.proveedoresBindingSource.DataSource = this.pruebaACADataSetBindingSource;
            // 
            // pruebaACADataSetBindingSource
            // 
            this.pruebaACADataSetBindingSource.DataSource = this.pruebaACADataSet;
            this.pruebaACADataSetBindingSource.Position = 0;
            // 
            // pruebaACADataSet
            // 
            this.pruebaACADataSet.DataSetName = "pruebaACADataSet";
            this.pruebaACADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(733, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 27);
            this.button2.TabIndex = 10;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ABMProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTelPro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCuilPro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDirePro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombrePro);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABMProveedores";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMProveedores";
            this.Load += new System.EventHandler(this.ABMProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaACADataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombrePro;
        private System.Windows.Forms.TextBox txtDirePro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCuilPro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelPro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pruebaACADataSetBindingSource;
        private pruebaACADataSet pruebaACADataSet;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private pruebaACADataSetTableAdapters.proveedoresTableAdapter proveedoresTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreproveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionproDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
    }
}