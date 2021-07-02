namespace SysPharm.Views
{
  partial class FormUsuario
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
      this.tabUser = new System.Windows.Forms.TabControl();
      this.tabAddUser = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cmbEps = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnMod = new System.Windows.Forms.Button();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.cmbTDoc = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtTel = new System.Windows.Forms.TextBox();
      this.txtDoc = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbTUsu = new System.Windows.Forms.ComboBox();
      this.txtNombres = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDireccion = new System.Windows.Forms.TextBox();
      this.tabBulkLoad = new System.Windows.Forms.TabPage();
      this.btnDown = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.tabListUsers = new System.Windows.Forms.TabPage();
      this.label10 = new System.Windows.Forms.Label();
      this.txtBuscarPac = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.listUsuarios = new System.Windows.Forms.DataGridView();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.label11 = new System.Windows.Forms.Label();
      this.txtBuscarMed = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.listMedicos = new System.Windows.Forms.DataGridView();
      this.errTDoc = new System.Windows.Forms.ErrorProvider(this.components);
      this.errDoc = new System.Windows.Forms.ErrorProvider(this.components);
      this.errNames = new System.Windows.Forms.ErrorProvider(this.components);
      this.errDir = new System.Windows.Forms.ErrorProvider(this.components);
      this.errTUsu = new System.Windows.Forms.ErrorProvider(this.components);
      this.errTel = new System.Windows.Forms.ErrorProvider(this.components);
      this.openFile = new System.Windows.Forms.OpenFileDialog();
      this.saveFile = new System.Windows.Forms.SaveFileDialog();
      this.errEps = new System.Windows.Forms.ErrorProvider(this.components);
      this.tabUser.SuspendLayout();
      this.tabAddUser.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabBulkLoad.SuspendLayout();
      this.tabListUsers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listUsuarios)).BeginInit();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listMedicos)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTDoc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errDoc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNames)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errDir)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTUsu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errEps)).BeginInit();
      this.SuspendLayout();
      // 
      // tabUser
      // 
      this.tabUser.Controls.Add(this.tabAddUser);
      this.tabUser.Controls.Add(this.tabBulkLoad);
      this.tabUser.Controls.Add(this.tabListUsers);
      this.tabUser.Controls.Add(this.tabPage1);
      this.tabUser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabUser.Location = new System.Drawing.Point(0, 0);
      this.tabUser.Name = "tabUser";
      this.tabUser.SelectedIndex = 0;
      this.tabUser.Size = new System.Drawing.Size(800, 450);
      this.tabUser.TabIndex = 0;
      // 
      // tabAddUser
      // 
      this.tabAddUser.Controls.Add(this.groupBox1);
      this.tabAddUser.Location = new System.Drawing.Point(4, 27);
      this.tabAddUser.Name = "tabAddUser";
      this.tabAddUser.Padding = new System.Windows.Forms.Padding(3);
      this.tabAddUser.Size = new System.Drawing.Size(792, 419);
      this.tabAddUser.TabIndex = 0;
      this.tabAddUser.Text = "Agregar Usuario";
      this.tabAddUser.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.cmbEps);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.btnCancel);
      this.groupBox1.Controls.Add(this.btnDel);
      this.groupBox1.Controls.Add(this.btnMod);
      this.groupBox1.Controls.Add(this.btnLimpiar);
      this.groupBox1.Controls.Add(this.btnGuardar);
      this.groupBox1.Controls.Add(this.cmbTDoc);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.txtTel);
      this.groupBox1.Controls.Add(this.txtDoc);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.cmbTUsu);
      this.groupBox1.Controls.Add(this.txtNombres);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtDireccion);
      this.groupBox1.Location = new System.Drawing.Point(8, 6);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(776, 410);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Datos del Usuario";
      // 
      // cmbEps
      // 
      this.cmbEps.FormattingEnabled = true;
      this.cmbEps.Location = new System.Drawing.Point(540, 163);
      this.cmbEps.Name = "cmbEps";
      this.cmbEps.Size = new System.Drawing.Size(200, 26);
      this.cmbEps.TabIndex = 18;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(432, 166);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(38, 18);
      this.label9.TabIndex = 17;
      this.label9.Text = "EPS";
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnCancel.Location = new System.Drawing.Point(543, 306);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(102, 36);
      this.btnCancel.TabIndex = 16;
      this.btnCancel.Text = "Cancelar";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Visible = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnDel
      // 
      this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
      this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDel.Location = new System.Drawing.Point(355, 306);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(102, 36);
      this.btnDel.TabIndex = 15;
      this.btnDel.Text = "Eliminar";
      this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Visible = false;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // btnMod
      // 
      this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnMod.Image = ((System.Drawing.Image)(resources.GetObject("btnMod.Image")));
      this.btnMod.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnMod.Location = new System.Drawing.Point(150, 306);
      this.btnMod.Name = "btnMod";
      this.btnMod.Size = new System.Drawing.Size(102, 36);
      this.btnMod.TabIndex = 14;
      this.btnMod.Text = "Modificar";
      this.btnMod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnMod.UseVisualStyleBackColor = true;
      this.btnMod.Visible = false;
      this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
      // 
      // btnLimpiar
      // 
      this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
      this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnLimpiar.Location = new System.Drawing.Point(435, 306);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
      this.btnLimpiar.TabIndex = 13;
      this.btnLimpiar.Text = "Limpiar";
      this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLimpiar.UseVisualStyleBackColor = true;
      this.btnLimpiar.Click += new System.EventHandler(this.LimpiarDatos);
      // 
      // btnGuardar
      // 
      this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
      this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnGuardar.Location = new System.Drawing.Point(258, 306);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 12;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // cmbTDoc
      // 
      this.cmbTDoc.FormattingEnabled = true;
      this.cmbTDoc.Location = new System.Drawing.Point(197, 49);
      this.cmbTDoc.Name = "cmbTDoc";
      this.cmbTDoc.Size = new System.Drawing.Size(200, 26);
      this.cmbTDoc.TabIndex = 1;
      this.cmbTDoc.SelectedValueChanged += new System.EventHandler(this.ValidarTipoDocumento);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(34, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(139, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Tipo de Documento";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(432, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "Documento";
      // 
      // txtTel
      // 
      this.txtTel.Location = new System.Drawing.Point(540, 220);
      this.txtTel.Name = "txtTel";
      this.txtTel.Size = new System.Drawing.Size(200, 24);
      this.txtTel.TabIndex = 11;
      this.txtTel.Leave += new System.EventHandler(this.ValidarTelefono);
      // 
      // txtDoc
      // 
      this.txtDoc.Location = new System.Drawing.Point(540, 51);
      this.txtDoc.Name = "txtDoc";
      this.txtDoc.Size = new System.Drawing.Size(200, 24);
      this.txtDoc.TabIndex = 3;
      this.txtDoc.Leave += new System.EventHandler(this.ValidarDocumento);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(432, 221);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(66, 18);
      this.label5.TabIndex = 10;
      this.label5.Text = "Teléfono";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(34, 111);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(144, 18);
      this.label3.TabIndex = 4;
      this.label3.Text = "Nombres y Apellidos";
      // 
      // cmbTUsu
      // 
      this.cmbTUsu.FormattingEnabled = true;
      this.cmbTUsu.Location = new System.Drawing.Point(197, 218);
      this.cmbTUsu.Name = "cmbTUsu";
      this.cmbTUsu.Size = new System.Drawing.Size(200, 26);
      this.cmbTUsu.TabIndex = 9;
      this.cmbTUsu.SelectedValueChanged += new System.EventHandler(this.ValidarTipoUsuario);
      // 
      // txtNombres
      // 
      this.txtNombres.Location = new System.Drawing.Point(197, 108);
      this.txtNombres.Name = "txtNombres";
      this.txtNombres.Size = new System.Drawing.Size(543, 24);
      this.txtNombres.TabIndex = 5;
      this.txtNombres.Leave += new System.EventHandler(this.ValidarNombres);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(34, 221);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(113, 18);
      this.label6.TabIndex = 8;
      this.label6.Text = "Tipo de Usuario";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(34, 166);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(71, 18);
      this.label4.TabIndex = 6;
      this.label4.Text = "Dirección";
      // 
      // txtDireccion
      // 
      this.txtDireccion.Location = new System.Drawing.Point(197, 163);
      this.txtDireccion.Name = "txtDireccion";
      this.txtDireccion.Size = new System.Drawing.Size(200, 24);
      this.txtDireccion.TabIndex = 7;
      this.txtDireccion.Leave += new System.EventHandler(this.ValidarDireccion);
      // 
      // tabBulkLoad
      // 
      this.tabBulkLoad.Controls.Add(this.btnDown);
      this.tabBulkLoad.Controls.Add(this.btnLoad);
      this.tabBulkLoad.Location = new System.Drawing.Point(4, 27);
      this.tabBulkLoad.Name = "tabBulkLoad";
      this.tabBulkLoad.Padding = new System.Windows.Forms.Padding(3);
      this.tabBulkLoad.Size = new System.Drawing.Size(792, 419);
      this.tabBulkLoad.TabIndex = 1;
      this.tabBulkLoad.Text = "Cargue Masivo";
      this.tabBulkLoad.UseVisualStyleBackColor = true;
      // 
      // btnDown
      // 
      this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
      this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDown.Location = new System.Drawing.Point(180, 166);
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(166, 36);
      this.btnDown.TabIndex = 2;
      this.btnDown.Text = "Descargar Plantilla";
      this.btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDown.UseVisualStyleBackColor = true;
      this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
      this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnLoad.Location = new System.Drawing.Point(453, 166);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(166, 36);
      this.btnLoad.TabIndex = 1;
      this.btnLoad.Text = "Cargar Datos";
      this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // tabListUsers
      // 
      this.tabListUsers.Controls.Add(this.label10);
      this.tabListUsers.Controls.Add(this.txtBuscarPac);
      this.tabListUsers.Controls.Add(this.label7);
      this.tabListUsers.Controls.Add(this.listUsuarios);
      this.tabListUsers.Location = new System.Drawing.Point(4, 27);
      this.tabListUsers.Name = "tabListUsers";
      this.tabListUsers.Padding = new System.Windows.Forms.Padding(3);
      this.tabListUsers.Size = new System.Drawing.Size(792, 419);
      this.tabListUsers.TabIndex = 2;
      this.tabListUsers.Text = "Lista de Pacientes";
      this.tabListUsers.UseVisualStyleBackColor = true;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(4, 25);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(72, 18);
      this.label10.TabIndex = 3;
      this.label10.Text = "Buscador";
      // 
      // txtBuscarPac
      // 
      this.txtBuscarPac.Location = new System.Drawing.Point(82, 24);
      this.txtBuscarPac.Name = "txtBuscarPac";
      this.txtBuscarPac.Size = new System.Drawing.Size(365, 24);
      this.txtBuscarPac.TabIndex = 2;
      this.txtBuscarPac.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.SkyBlue;
      this.label7.Dock = System.Windows.Forms.DockStyle.Top;
      this.label7.Location = new System.Drawing.Point(3, 3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(719, 18);
      this.label7.TabIndex = 1;
      this.label7.Text = "Sí desea modificar o eliminar un usuario, debes dar doble clic sobre el usuario a" +
    "l que deseas hacer la acción";
      // 
      // listUsuarios
      // 
      this.listUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.listUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listUsuarios.GridColor = System.Drawing.SystemColors.ControlLightLight;
      this.listUsuarios.Location = new System.Drawing.Point(3, 54);
      this.listUsuarios.Name = "listUsuarios";
      this.listUsuarios.Size = new System.Drawing.Size(786, 362);
      this.listUsuarios.TabIndex = 0;
      this.listUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTablePaciente);
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabPage1.Controls.Add(this.label11);
      this.tabPage1.Controls.Add(this.txtBuscarMed);
      this.tabPage1.Controls.Add(this.label8);
      this.tabPage1.Controls.Add(this.listMedicos);
      this.tabPage1.Location = new System.Drawing.Point(4, 27);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(792, 419);
      this.tabPage1.TabIndex = 3;
      this.tabPage1.Text = "Lista de Medicos";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(4, 25);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(72, 18);
      this.label11.TabIndex = 5;
      this.label11.Text = "Buscador";
      // 
      // txtBuscarMed
      // 
      this.txtBuscarMed.Location = new System.Drawing.Point(82, 24);
      this.txtBuscarMed.Name = "txtBuscarMed";
      this.txtBuscarMed.Size = new System.Drawing.Size(365, 24);
      this.txtBuscarMed.TabIndex = 4;
      this.txtBuscarMed.TextChanged += new System.EventHandler(this.txtBuscarMed_TextChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.BackColor = System.Drawing.Color.SkyBlue;
      this.label8.Dock = System.Windows.Forms.DockStyle.Top;
      this.label8.Location = new System.Drawing.Point(3, 3);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(719, 18);
      this.label8.TabIndex = 2;
      this.label8.Text = "Sí desea modificar o eliminar un usuario, debes dar doble clic sobre el usuario a" +
    "l que deseas hacer la acción";
      // 
      // listMedicos
      // 
      this.listMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listMedicos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.listMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listMedicos.GridColor = System.Drawing.SystemColors.ControlLightLight;
      this.listMedicos.Location = new System.Drawing.Point(3, 54);
      this.listMedicos.Name = "listMedicos";
      this.listMedicos.Size = new System.Drawing.Size(786, 362);
      this.listMedicos.TabIndex = 1;
      this.listMedicos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTableMedico);
      // 
      // errTDoc
      // 
      this.errTDoc.ContainerControl = this;
      // 
      // errDoc
      // 
      this.errDoc.ContainerControl = this;
      // 
      // errNames
      // 
      this.errNames.ContainerControl = this;
      // 
      // errDir
      // 
      this.errDir.ContainerControl = this;
      // 
      // errTUsu
      // 
      this.errTUsu.ContainerControl = this;
      // 
      // errTel
      // 
      this.errTel.ContainerControl = this;
      // 
      // openFile
      // 
      this.openFile.FileName = "openFileDialog1";
      this.openFile.Filter = "Archivos Excel|*.xls;*.xlsx;*.xlsm";
      // 
      // saveFile
      // 
      this.saveFile.FileName = "TemplateUsuarios.xlsx";
      this.saveFile.Filter = "Archivos Excel|*.xlsx;*.xls;*.xlsm";
      // 
      // errEps
      // 
      this.errEps.ContainerControl = this;
      // 
      // FormUsuario
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabUser);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormUsuario";
      this.Text = "Usuario";
      this.tabUser.ResumeLayout(false);
      this.tabAddUser.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabBulkLoad.ResumeLayout(false);
      this.tabListUsers.ResumeLayout(false);
      this.tabListUsers.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listUsuarios)).EndInit();
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listMedicos)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTDoc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errDoc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNames)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errDir)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTUsu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errTel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errEps)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.TabControl tabUser;
    private System.Windows.Forms.TabPage tabAddUser;
    private System.Windows.Forms.TabPage tabListUsers;
    private System.Windows.Forms.DataGridView listUsuarios;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtTel;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cmbTUsu;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtDireccion;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtNombres;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDoc;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbTDoc;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView listMedicos;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ErrorProvider errTDoc;
    private System.Windows.Forms.ErrorProvider errDoc;
    private System.Windows.Forms.ErrorProvider errNames;
    private System.Windows.Forms.ErrorProvider errDir;
    private System.Windows.Forms.ErrorProvider errTUsu;
    private System.Windows.Forms.ErrorProvider errTel;
    private System.Windows.Forms.Button btnMod;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.OpenFileDialog openFile;
    private System.Windows.Forms.SaveFileDialog saveFile;
    private System.Windows.Forms.TabPage tabBulkLoad;
    private System.Windows.Forms.Button btnDown;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cmbEps;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ErrorProvider errEps;
    private System.Windows.Forms.TextBox txtBuscarPac;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtBuscarMed;
  }
}