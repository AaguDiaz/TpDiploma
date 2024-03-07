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
            this.btnNueGru = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.tvGrupos = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNombreg = new System.Windows.Forms.TextBox();
            this.txtApellidog = new System.Windows.Forms.TextBox();
            this.txtDNIg = new System.Windows.Forms.TextBox();
            this.dgvGrupoFamiliar = new System.Windows.Forms.DataGridView();
            this.cbParentesco = new System.Windows.Forms.ComboBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnAgrgarFamiliar = new System.Windows.Forms.Button();
            this.btnEliminarFamiliar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoFamiliar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(31, 14);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 14);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Text = "Nombre:";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.ForeColor = System.Drawing.Color.DimGray;
            this.txtApellido.Location = new System.Drawing.Point(279, 15);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(195, 13);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.Text = "Apellido:";
            this.txtApellido.Enter += new System.EventHandler(this.txtApellido_Enter);
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            this.txtApellido.Leave += new System.EventHandler(this.txtApellido_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(509, 51);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 14);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Text = "Email:";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContra.Font = new System.Drawing.Font("Arial", 9F);
            this.txtContra.ForeColor = System.Drawing.Color.DimGray;
            this.txtContra.Location = new System.Drawing.Point(752, 51);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(195, 14);
            this.txtContra.TabIndex = 8;
            this.txtContra.Text = "Contraseña:";
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.Location = new System.Drawing.Point(31, 53);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(195, 14);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.Text = "Direccion:";
            this.txtDireccion.Enter += new System.EventHandler(this.txtDireccion_Enter);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTelefono.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelefono.Location = new System.Drawing.Point(280, 51);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(194, 14);
            this.txtTelefono.TabIndex = 6;
            this.txtTelefono.Text = "Telefono:";
            this.txtTelefono.Enter += new System.EventHandler(this.txtTelefono_Enter);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Leave += new System.EventHandler(this.txtTelefono_Leave);
            // 
            // txtCvu
            // 
            this.txtCvu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCvu.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCvu.ForeColor = System.Drawing.Color.DimGray;
            this.txtCvu.Location = new System.Drawing.Point(752, 14);
            this.txtCvu.Name = "txtCvu";
            this.txtCvu.Size = new System.Drawing.Size(195, 14);
            this.txtCvu.TabIndex = 4;
            this.txtCvu.Text = "CVU:";
            this.txtCvu.Enter += new System.EventHandler(this.txtCVU_Enter);
            this.txtCvu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCvu_KeyPress);
            this.txtCvu.Leave += new System.EventHandler(this.txtCVU_Leave);
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDni.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDni.ForeColor = System.Drawing.Color.DimGray;
            this.txtDni.Location = new System.Drawing.Point(509, 14);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(195, 14);
            this.txtDni.TabIndex = 3;
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
            this.dgvPermisos.Location = new System.Drawing.Point(9, 7);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.Size = new System.Drawing.Size(584, 433);
            this.dgvPermisos.TabIndex = 11;
            this.dgvPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermisos_CellClick);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(9, 7);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.Size = new System.Drawing.Size(585, 433);
            this.dgvGrupos.TabIndex = 16;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
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
            this.btnAgrPer.BackColor = System.Drawing.Color.White;
            this.btnAgrPer.FlatAppearance.BorderSize = 0;
            this.btnAgrPer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgrPer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAgrPer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgrPer.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAgrPer.Location = new System.Drawing.Point(3, 3);
            this.btnAgrPer.Name = "btnAgrPer";
            this.btnAgrPer.Size = new System.Drawing.Size(95, 41);
            this.btnAgrPer.TabIndex = 12;
            this.btnAgrPer.Tag = "Boton Agregar Permisos";
            this.btnAgrPer.Text = "Agregar Permiso";
            this.btnAgrPer.UseVisualStyleBackColor = false;
            this.btnAgrPer.Visible = false;
            this.btnAgrPer.Click += new System.EventHandler(this.btnAgrPer_Click);
            // 
            // btnEliPer
            // 
            this.btnEliPer.BackColor = System.Drawing.Color.White;
            this.btnEliPer.FlatAppearance.BorderSize = 0;
            this.btnEliPer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEliPer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEliPer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliPer.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliPer.Location = new System.Drawing.Point(104, 3);
            this.btnEliPer.Name = "btnEliPer";
            this.btnEliPer.Size = new System.Drawing.Size(95, 41);
            this.btnEliPer.TabIndex = 13;
            this.btnEliPer.Tag = "Boton Eliminar Permisos";
            this.btnEliPer.Text = "Eliminar Permiso";
            this.btnEliPer.UseVisualStyleBackColor = false;
            this.btnEliPer.Visible = false;
            this.btnEliPer.Click += new System.EventHandler(this.btnEliPer_Click);
            // 
            // btnAgrGru
            // 
            this.btnAgrGru.BackColor = System.Drawing.Color.White;
            this.btnAgrGru.FlatAppearance.BorderSize = 0;
            this.btnAgrGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgrGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAgrGru.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgrGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAgrGru.Location = new System.Drawing.Point(3, 3);
            this.btnAgrGru.Name = "btnAgrGru";
            this.btnAgrGru.Size = new System.Drawing.Size(95, 41);
            this.btnAgrGru.TabIndex = 16;
            this.btnAgrGru.Tag = "Boton Agregar Grupo";
            this.btnAgrGru.Text = "Agregar  Grupo";
            this.btnAgrGru.UseVisualStyleBackColor = false;
            this.btnAgrGru.Visible = false;
            this.btnAgrGru.Click += new System.EventHandler(this.btnAgrGru_Click);
            // 
            // btnEliGru
            // 
            this.btnEliGru.BackColor = System.Drawing.Color.White;
            this.btnEliGru.FlatAppearance.BorderSize = 0;
            this.btnEliGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEliGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEliGru.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliGru.Location = new System.Drawing.Point(104, 3);
            this.btnEliGru.Name = "btnEliGru";
            this.btnEliGru.Size = new System.Drawing.Size(93, 41);
            this.btnEliGru.TabIndex = 17;
            this.btnEliGru.Tag = "Boton Eliminar Grupo";
            this.btnEliGru.Text = "Eliminar Grupo";
            this.btnEliGru.UseVisualStyleBackColor = false;
            this.btnEliGru.Visible = false;
            this.btnEliGru.Click += new System.EventHandler(this.btnEliPGru_Click);
            // 
            // btnNueGru
            // 
            this.btnNueGru.BackColor = System.Drawing.Color.White;
            this.btnNueGru.FlatAppearance.BorderSize = 0;
            this.btnNueGru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnNueGru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNueGru.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNueGru.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNueGru.Location = new System.Drawing.Point(203, 3);
            this.btnNueGru.Name = "btnNueGru";
            this.btnNueGru.Size = new System.Drawing.Size(93, 41);
            this.btnNueGru.TabIndex = 18;
            this.btnNueGru.Tag = "Boton Nuevo";
            this.btnNueGru.Text = "Nuevo Grupo";
            this.btnNueGru.UseVisualStyleBackColor = false;
            this.btnNueGru.Visible = false;
            this.btnNueGru.Click += new System.EventHandler(this.btnNueGru_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 519);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tvPermisos);
            this.tabPage1.Controls.Add(this.dgvPermisos);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Permisos";
            // 
            // tvPermisos
            // 
            this.tvPermisos.Indent = 14;
            this.tvPermisos.Location = new System.Drawing.Point(614, 7);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(343, 433);
            this.tvPermisos.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAgrPer);
            this.flowLayoutPanel1.Controls.Add(this.btnEliPer);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 443);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(215, 44);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtDescripcion);
            this.tabPage2.Controls.Add(this.tvGrupos);
            this.tabPage2.Controls.Add(this.dgvGrupos);
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(972, 493);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grupos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(610, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(169, 17);
            this.label12.TabIndex = 41;
            this.label12.Text = "Permisos que lo integran:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(610, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 40;
            this.label11.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(613, 27);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(343, 48);
            this.txtDescripcion.TabIndex = 40;
            // 
            // tvGrupos
            // 
            this.tvGrupos.Location = new System.Drawing.Point(613, 98);
            this.tvGrupos.Name = "tvGrupos";
            this.tvGrupos.Size = new System.Drawing.Size(343, 342);
            this.tvGrupos.TabIndex = 21;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAgrGru);
            this.flowLayoutPanel2.Controls.Add(this.btnEliGru);
            this.flowLayoutPanel2.Controls.Add(this.btnNueGru);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 443);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(378, 50);
            this.flowLayoutPanel2.TabIndex = 42;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmar.Location = new System.Drawing.Point(853, 610);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(122, 23);
            this.btnConfirmar.TabIndex = 31;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.brnConfirmar_Click);
            // 
            // bntCancelar
            // 
            this.bntCancelar.BackColor = System.Drawing.Color.Crimson;
            this.bntCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntCancelar.Location = new System.Drawing.Point(725, 610);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(122, 23);
            this.bntCancelar.TabIndex = 30;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = false;
            this.bntCancelar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "________________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "________________________________";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(749, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "________________________________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "________________________________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "________________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(749, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "________________________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(506, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "________________________________";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(972, 493);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Grupo Familiar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nombre:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Apellido:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "DNI:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Parentesco:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Fecha nacimiento:";
            // 
            // txtNombreg
            // 
            this.txtNombreg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreg.Location = new System.Drawing.Point(119, 20);
            this.txtNombreg.Name = "txtNombreg";
            this.txtNombreg.Size = new System.Drawing.Size(223, 13);
            this.txtNombreg.TabIndex = 5;
            this.txtNombreg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellidog
            // 
            this.txtApellidog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidog.Location = new System.Drawing.Point(119, 70);
            this.txtApellidog.Name = "txtApellidog";
            this.txtApellidog.Size = new System.Drawing.Size(223, 13);
            this.txtApellidog.TabIndex = 6;
            this.txtApellidog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtDNIg
            // 
            this.txtDNIg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNIg.Location = new System.Drawing.Point(119, 117);
            this.txtDNIg.Name = "txtDNIg";
            this.txtDNIg.Size = new System.Drawing.Size(223, 13);
            this.txtDNIg.TabIndex = 7;
            this.txtDNIg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // dgvGrupoFamiliar
            // 
            this.dgvGrupoFamiliar.AllowUserToAddRows = false;
            this.dgvGrupoFamiliar.AllowUserToDeleteRows = false;
            this.dgvGrupoFamiliar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupoFamiliar.Location = new System.Drawing.Point(389, 10);
            this.dgvGrupoFamiliar.Name = "dgvGrupoFamiliar";
            this.dgvGrupoFamiliar.ReadOnly = true;
            this.dgvGrupoFamiliar.Size = new System.Drawing.Size(529, 441);
            this.dgvGrupoFamiliar.TabIndex = 8;
            // 
            // cbParentesco
            // 
            this.cbParentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParentesco.FormattingEnabled = true;
            this.cbParentesco.Items.AddRange(new object[] {
            "Seleccionar",
            "Esposo/a",
            "Hijo/a"});
            this.cbParentesco.Location = new System.Drawing.Point(119, 217);
            this.cbParentesco.Name = "cbParentesco";
            this.cbParentesco.Size = new System.Drawing.Size(223, 21);
            this.cbParentesco.TabIndex = 9;
            this.cbParentesco.SelectedIndexChanged += new System.EventHandler(this.cbParentesco_SelectedIndexChanged);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(119, 164);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(223, 20);
            this.dtpFechaNacimiento.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(116, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(223, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "____________________________________";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(116, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(223, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "____________________________________";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(116, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(223, 13);
            this.label20.TabIndex = 42;
            this.label20.Text = "____________________________________";
            // 
            // btnAgrgarFamiliar
            // 
            this.btnAgrgarFamiliar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgrgarFamiliar.Location = new System.Drawing.Point(1, 288);
            this.btnAgrgarFamiliar.Name = "btnAgrgarFamiliar";
            this.btnAgrgarFamiliar.Size = new System.Drawing.Size(139, 29);
            this.btnAgrgarFamiliar.TabIndex = 43;
            this.btnAgrgarFamiliar.Text = "Agregar familiar";
            this.btnAgrgarFamiliar.UseVisualStyleBackColor = true;
            this.btnAgrgarFamiliar.Click += new System.EventHandler(this.btnAgrgarFamiliar_Click);
            // 
            // btnEliminarFamiliar
            // 
            this.btnEliminarFamiliar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarFamiliar.Location = new System.Drawing.Point(203, 288);
            this.btnEliminarFamiliar.Name = "btnEliminarFamiliar";
            this.btnEliminarFamiliar.Size = new System.Drawing.Size(139, 29);
            this.btnEliminarFamiliar.TabIndex = 44;
            this.btnEliminarFamiliar.Text = "Eliminar familiar";
            this.btnEliminarFamiliar.UseVisualStyleBackColor = true;
            this.btnEliminarFamiliar.Click += new System.EventHandler(this.btnEliminarFamiliar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEliminarFamiliar);
            this.panel1.Controls.Add(this.btnAgrgarFamiliar);
            this.panel1.Controls.Add(this.txtApellidog);
            this.panel1.Controls.Add(this.dtpFechaNacimiento);
            this.panel1.Controls.Add(this.cbParentesco);
            this.panel1.Controls.Add(this.dgvGrupoFamiliar);
            this.panel1.Controls.Add(this.txtNombreg);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtDNIg);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Location = new System.Drawing.Point(27, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 463);
            this.panel1.TabIndex = 45;
            // 
            // CargaDatosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 645);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCvu);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargaDatosUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CargaDatosUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoFamiliar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnNueGru;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.TreeView tvGrupos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvGrupoFamiliar;
        private System.Windows.Forms.TextBox txtDNIg;
        private System.Windows.Forms.TextBox txtApellidog;
        private System.Windows.Forms.TextBox txtNombreg;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.ComboBox cbParentesco;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnEliminarFamiliar;
        private System.Windows.Forms.Button btnAgrgarFamiliar;
        private System.Windows.Forms.Panel panel1;
    }
}