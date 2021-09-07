namespace SysPharm.Views
{
  partial class FormPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPedidos = new System.Windows.Forms.TabControl();
            this.tabAddPedido = new System.Windows.Forms.TabPage();
            this.lblId = new System.Windows.Forms.Label();
            this.listDetalles = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAddMedi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtIngreso = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtSolicitud = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMedicamentos = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblPag = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.listPedidos = new System.Windows.Forms.DataGridView();
            this.errMedi = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPro = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFecS = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFecI = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDet = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNumFact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errNumFact = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnDownInfMon = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.tabPedidos.SuspendLayout();
            this.tabAddPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDetalles)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMedi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNumFact)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPedidos
            // 
            this.tabPedidos.Controls.Add(this.tabAddPedido);
            this.tabPedidos.Controls.Add(this.tabPage2);
            this.tabPedidos.Controls.Add(this.tabPage1);
            this.tabPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPedidos.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPedidos.Location = new System.Drawing.Point(0, 0);
            this.tabPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.tabPedidos.Name = "tabPedidos";
            this.tabPedidos.SelectedIndex = 0;
            this.tabPedidos.Size = new System.Drawing.Size(800, 450);
            this.tabPedidos.TabIndex = 3;
            // 
            // tabAddPedido
            // 
            this.tabAddPedido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabAddPedido.Controls.Add(this.label5);
            this.tabAddPedido.Controls.Add(this.txtNumFact);
            this.tabAddPedido.Controls.Add(this.lblId);
            this.tabAddPedido.Controls.Add(this.listDetalles);
            this.tabAddPedido.Controls.Add(this.btnLimpiar);
            this.tabAddPedido.Controls.Add(this.btnGuardar);
            this.tabAddPedido.Controls.Add(this.btnAddMedi);
            this.tabAddPedido.Controls.Add(this.label4);
            this.tabAddPedido.Controls.Add(this.dtIngreso);
            this.tabAddPedido.Controls.Add(this.label3);
            this.tabAddPedido.Controls.Add(this.dtSolicitud);
            this.tabAddPedido.Controls.Add(this.label2);
            this.tabAddPedido.Controls.Add(this.txtProveedor);
            this.tabAddPedido.Controls.Add(this.label1);
            this.tabAddPedido.Controls.Add(this.cmbMedicamentos);
            this.tabAddPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAddPedido.Location = new System.Drawing.Point(4, 26);
            this.tabAddPedido.Margin = new System.Windows.Forms.Padding(4);
            this.tabAddPedido.Name = "tabAddPedido";
            this.tabAddPedido.Padding = new System.Windows.Forms.Padding(4);
            this.tabAddPedido.Size = new System.Drawing.Size(792, 420);
            this.tabAddPedido.TabIndex = 0;
            this.tabAddPedido.Text = "Agregar Pedido";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(38, 13);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(44, 17);
            this.lblId.TabIndex = 22;
            this.lblId.Text = "label5";
            // 
            // listDetalles
            // 
            this.listDetalles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDetalles.EnableHeadersVisualStyles = false;
            this.listDetalles.Location = new System.Drawing.Point(41, 156);
            this.listDetalles.Name = "listDetalles";
            this.listDetalles.Size = new System.Drawing.Size(727, 204);
            this.listDetalles.TabIndex = 21;
            this.listDetalles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTable);
            this.listDetalles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDetalles_CellEndEdit);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.Location = new System.Drawing.Point(666, 366);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(552, 366);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 36);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAddMedi
            // 
            this.btnAddMedi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMedi.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMedi.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMedi.Image")));
            this.btnAddMedi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMedi.Location = new System.Drawing.Point(666, 114);
            this.btnAddMedi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMedi.Name = "btnAddMedi";
            this.btnAddMedi.Size = new System.Drawing.Size(102, 36);
            this.btnAddMedi.TabIndex = 13;
            this.btnAddMedi.Text = "Agregar";
            this.btnAddMedi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMedi.UseVisualStyleBackColor = true;
            this.btnAddMedi.Click += new System.EventHandler(this.btnAddMedi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Medicamento";
            // 
            // dtIngreso
            // 
            this.dtIngreso.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIngreso.Location = new System.Drawing.Point(548, 76);
            this.dtIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.dtIngreso.Name = "dtIngreso";
            this.dtIngreso.Size = new System.Drawing.Size(220, 24);
            this.dtIngreso.TabIndex = 10;
            this.dtIngreso.ValueChanged += new System.EventHandler(this.dtIngreso_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha de Ingreso";
            // 
            // dtSolicitud
            // 
            this.dtSolicitud.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSolicitud.Location = new System.Drawing.Point(180, 76);
            this.dtSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.dtSolicitud.Name = "dtSolicitud";
            this.dtSolicitud.Size = new System.Drawing.Size(220, 24);
            this.dtSolicitud.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha de Solicitud";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(180, 44);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(220, 24);
            this.txtProveedor.TabIndex = 6;
            this.txtProveedor.Leave += new System.EventHandler(this.validateProovedor);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proveedor";
            // 
            // cmbMedicamentos
            // 
            this.cmbMedicamentos.FormattingEnabled = true;
            this.cmbMedicamentos.Location = new System.Drawing.Point(180, 114);
            this.cmbMedicamentos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedicamentos.Name = "cmbMedicamentos";
            this.cmbMedicamentos.Size = new System.Drawing.Size(461, 26);
            this.cmbMedicamentos.TabIndex = 3;
            this.cmbMedicamentos.SelectedValueChanged += new System.EventHandler(this.validateMedicamento);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage2.Controls.Add(this.lblPag);
            this.tabPage2.Controls.Add(this.btnNext);
            this.tabPage2.Controls.Add(this.btnPrev);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtBuscar);
            this.tabPage2.Controls.Add(this.listPedidos);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(792, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista de Pedidos";
            // 
            // lblPag
            // 
            this.lblPag.AutoSize = true;
            this.lblPag.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.lblPag.Location = new System.Drawing.Point(365, 389);
            this.lblPag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPag.Name = "lblPag";
            this.lblPag.Size = new System.Drawing.Size(64, 17);
            this.lblPag.TabIndex = 11;
            this.lblPag.Text = "Buscador";
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(474, 386);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.Location = new System.Drawing.Point(320, 386);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(25, 23);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Buscador";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(115, 3);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(485, 24);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // listPedidos
            // 
            this.listPedidos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPedidos.EnableHeadersVisualStyles = false;
            this.listPedidos.Location = new System.Drawing.Point(8, 42);
            this.listPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.listPedidos.Name = "listPedidos";
            this.listPedidos.Size = new System.Drawing.Size(775, 337);
            this.listPedidos.TabIndex = 0;
            // 
            // errMedi
            // 
            this.errMedi.ContainerControl = this;
            // 
            // errPro
            // 
            this.errPro.ContainerControl = this;
            // 
            // errFecS
            // 
            this.errFecS.ContainerControl = this;
            // 
            // errFecI
            // 
            this.errFecI.ContainerControl = this;
            // 
            // errDet
            // 
            this.errDet.ContainerControl = this;
            // 
            // txtNumFact
            // 
            this.txtNumFact.Location = new System.Drawing.Point(548, 44);
            this.txtNumFact.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumFact.Name = "txtNumFact";
            this.txtNumFact.Size = new System.Drawing.Size(220, 24);
            this.txtNumFact.TabIndex = 23;
            this.txtNumFact.Leave += new System.EventHandler(this.validateNumFact);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(425, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Número Factura";
            // 
            // errNumFact
            // 
            this.errNumFact.ContainerControl = this;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 420);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Descargar Excel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnDownInfMon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 100);
            this.panel1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mes";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(163, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btnDownInfMon
            // 
            this.btnDownInfMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownInfMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownInfMon.Image = ((System.Drawing.Image)(resources.GetObject("btnDownInfMon.Image")));
            this.btnDownInfMon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownInfMon.Location = new System.Drawing.Point(610, 32);
            this.btnDownInfMon.Name = "btnDownInfMon";
            this.btnDownInfMon.Size = new System.Drawing.Size(106, 36);
            this.btnDownInfMon.TabIndex = 3;
            this.btnDownInfMon.Text = "Descargar";
            this.btnDownInfMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownInfMon.UseVisualStyleBackColor = true;
            this.btnDownInfMon.Click += new System.EventHandler(this.btnDownInfMon_Click);
            // 
            // saveFile
            // 
            this.saveFile.FileName = "InformePedidos.xlsx";
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabPedidos);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPedido";
            this.Text = "+";
            this.tabPedidos.ResumeLayout(false);
            this.tabAddPedido.ResumeLayout(false);
            this.tabAddPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDetalles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMedi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNumFact)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabPedidos;
    private System.Windows.Forms.TabPage tabAddPedido;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbMedicamentos;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtProveedor;
    private System.Windows.Forms.DateTimePicker dtIngreso;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker dtSolicitud;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnAddMedi;
    private System.Windows.Forms.DataGridView listPedidos;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtBuscar;
    private System.Windows.Forms.ErrorProvider errMedi;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.DataGridView listDetalles;
    private System.Windows.Forms.ErrorProvider errPro;
    private System.Windows.Forms.ErrorProvider errFecS;
    private System.Windows.Forms.ErrorProvider errFecI;
    private System.Windows.Forms.ErrorProvider errDet;
    private System.Windows.Forms.Label lblId;
    private System.Windows.Forms.Label lblPag;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumFact;
        private System.Windows.Forms.ErrorProvider errNumFact;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnDownInfMon;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}