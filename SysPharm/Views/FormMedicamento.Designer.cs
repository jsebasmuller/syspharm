namespace SysPharm.Views
{
  partial class FormMedicamento
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMedicamento));
      this.tabListUsers = new System.Windows.Forms.TabPage();
      this.label11 = new System.Windows.Forms.Label();
      this.txtBuscar = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.listMedicamentos = new System.Windows.Forms.DataGridView();
      this.tabBulkLoad = new System.Windows.Forms.TabPage();
      this.btnDown = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.tabAddMed = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtVlrV = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnMod = new System.Windows.Forms.Button();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.txtNom = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtVlrC = new System.Windows.Forms.TextBox();
      this.tabMedicamentos = new System.Windows.Forms.TabControl();
      this.errNom = new System.Windows.Forms.ErrorProvider(this.components);
      this.errVlrC = new System.Windows.Forms.ErrorProvider(this.components);
      this.openFile = new System.Windows.Forms.OpenFileDialog();
      this.saveFile = new System.Windows.Forms.SaveFileDialog();
      this.errVlrV = new System.Windows.Forms.ErrorProvider(this.components);
      this.tabListUsers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listMedicamentos)).BeginInit();
      this.tabBulkLoad.SuspendLayout();
      this.tabAddMed.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabMedicamentos.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errNom)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errVlrC)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errVlrV)).BeginInit();
      this.SuspendLayout();
      // 
      // tabListUsers
      // 
      this.tabListUsers.Controls.Add(this.label11);
      this.tabListUsers.Controls.Add(this.txtBuscar);
      this.tabListUsers.Controls.Add(this.label7);
      this.tabListUsers.Controls.Add(this.listMedicamentos);
      this.tabListUsers.Location = new System.Drawing.Point(4, 26);
      this.tabListUsers.Margin = new System.Windows.Forms.Padding(4);
      this.tabListUsers.Name = "tabListUsers";
      this.tabListUsers.Padding = new System.Windows.Forms.Padding(4);
      this.tabListUsers.Size = new System.Drawing.Size(792, 420);
      this.tabListUsers.TabIndex = 2;
      this.tabListUsers.Text = "Lista de Medicamentos";
      this.tabListUsers.UseVisualStyleBackColor = true;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(5, 33);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(64, 17);
      this.label11.TabIndex = 7;
      this.label11.Text = "Buscador";
      // 
      // txtBuscar
      // 
      this.txtBuscar.Location = new System.Drawing.Point(109, 31);
      this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new System.Drawing.Size(485, 24);
      this.txtBuscar.TabIndex = 6;
      this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.SkyBlue;
      this.label7.Dock = System.Windows.Forms.DockStyle.Top;
      this.label7.Location = new System.Drawing.Point(4, 4);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(740, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "Sí desea modificar o eliminar un medicamento, debes dar doble clic sobre el medic" +
    "amento al que deseas hacer la acción";
      // 
      // listMedicamentos
      // 
      this.listMedicamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listMedicamentos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.listMedicamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.listMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listMedicamentos.EnableHeadersVisualStyles = false;
      this.listMedicamentos.GridColor = System.Drawing.SystemColors.ControlLightLight;
      this.listMedicamentos.Location = new System.Drawing.Point(4, 71);
      this.listMedicamentos.Margin = new System.Windows.Forms.Padding(4);
      this.listMedicamentos.Name = "listMedicamentos";
      this.listMedicamentos.Size = new System.Drawing.Size(1048, 474);
      this.listMedicamentos.TabIndex = 0;
      this.listMedicamentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTables);
      // 
      // tabBulkLoad
      // 
      this.tabBulkLoad.Controls.Add(this.btnDown);
      this.tabBulkLoad.Controls.Add(this.btnLoad);
      this.tabBulkLoad.Location = new System.Drawing.Point(4, 26);
      this.tabBulkLoad.Margin = new System.Windows.Forms.Padding(4);
      this.tabBulkLoad.Name = "tabBulkLoad";
      this.tabBulkLoad.Padding = new System.Windows.Forms.Padding(4);
      this.tabBulkLoad.Size = new System.Drawing.Size(792, 420);
      this.tabBulkLoad.TabIndex = 1;
      this.tabBulkLoad.Text = "Cargue Masivo";
      this.tabBulkLoad.UseVisualStyleBackColor = true;
      // 
      // btnDown
      // 
      this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
      this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDown.Location = new System.Drawing.Point(240, 217);
      this.btnDown.Margin = new System.Windows.Forms.Padding(4);
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(221, 47);
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
      this.btnLoad.Location = new System.Drawing.Point(604, 217);
      this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(221, 47);
      this.btnLoad.TabIndex = 1;
      this.btnLoad.Text = "Cargar Datos";
      this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // tabAddMed
      // 
      this.tabAddMed.Controls.Add(this.groupBox1);
      this.tabAddMed.Location = new System.Drawing.Point(4, 26);
      this.tabAddMed.Margin = new System.Windows.Forms.Padding(4);
      this.tabAddMed.Name = "tabAddMed";
      this.tabAddMed.Padding = new System.Windows.Forms.Padding(4);
      this.tabAddMed.Size = new System.Drawing.Size(792, 420);
      this.tabAddMed.TabIndex = 0;
      this.tabAddMed.Text = "Añadir Medicamento";
      this.tabAddMed.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtVlrV);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.btnCancel);
      this.groupBox1.Controls.Add(this.btnDel);
      this.groupBox1.Controls.Add(this.btnMod);
      this.groupBox1.Controls.Add(this.btnLimpiar);
      this.groupBox1.Controls.Add(this.btnGuardar);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txtNom);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtVlrC);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(4, 4);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(784, 412);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Medicamento";
      // 
      // txtVlrV
      // 
      this.txtVlrV.Location = new System.Drawing.Point(595, 158);
      this.txtVlrV.Margin = new System.Windows.Forms.Padding(4);
      this.txtVlrV.Name = "txtVlrV";
      this.txtVlrV.Size = new System.Drawing.Size(156, 24);
      this.txtVlrV.TabIndex = 18;
      this.txtVlrV.Leave += new System.EventHandler(this.ValidarVlrV);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(457, 161);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(101, 17);
      this.label9.TabIndex = 17;
      this.label9.Text = "Valor de Venta";
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnCancel.Location = new System.Drawing.Point(606, 268);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
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
      this.btnDel.Location = new System.Drawing.Point(355, 268);
      this.btnDel.Margin = new System.Windows.Forms.Padding(4);
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
      this.btnMod.Location = new System.Drawing.Point(82, 268);
      this.btnMod.Margin = new System.Windows.Forms.Padding(4);
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
      this.btnLimpiar.Location = new System.Drawing.Point(462, 268);
      this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
      this.btnLimpiar.TabIndex = 13;
      this.btnLimpiar.Text = "Limpiar";
      this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLimpiar.UseVisualStyleBackColor = true;
      // 
      // btnGuardar
      // 
      this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
      this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnGuardar.Location = new System.Drawing.Point(226, 268);
      this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 12;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(32, 96);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(171, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "Nombre del Medicamento";
      // 
      // txtNom
      // 
      this.txtNom.Location = new System.Drawing.Point(244, 93);
      this.txtNom.Margin = new System.Windows.Forms.Padding(4);
      this.txtNom.Name = "txtNom";
      this.txtNom.Size = new System.Drawing.Size(507, 24);
      this.txtNom.TabIndex = 5;
      this.txtNom.Leave += new System.EventHandler(this.ValidarNombre);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(91, 162);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(115, 17);
      this.label4.TabIndex = 6;
      this.label4.Text = "Valor de Compra";
      // 
      // txtVlrC
      // 
      this.txtVlrC.Location = new System.Drawing.Point(244, 158);
      this.txtVlrC.Margin = new System.Windows.Forms.Padding(4);
      this.txtVlrC.Name = "txtVlrC";
      this.txtVlrC.Size = new System.Drawing.Size(156, 24);
      this.txtVlrC.TabIndex = 7;
      this.txtVlrC.Leave += new System.EventHandler(this.ValidarVlrC);
      // 
      // tabMedicamentos
      // 
      this.tabMedicamentos.Controls.Add(this.tabAddMed);
      this.tabMedicamentos.Controls.Add(this.tabBulkLoad);
      this.tabMedicamentos.Controls.Add(this.tabListUsers);
      this.tabMedicamentos.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabMedicamentos.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabMedicamentos.Location = new System.Drawing.Point(0, 0);
      this.tabMedicamentos.Margin = new System.Windows.Forms.Padding(4);
      this.tabMedicamentos.Name = "tabMedicamentos";
      this.tabMedicamentos.SelectedIndex = 0;
      this.tabMedicamentos.Size = new System.Drawing.Size(800, 450);
      this.tabMedicamentos.TabIndex = 1;
      // 
      // errNom
      // 
      this.errNom.ContainerControl = this;
      // 
      // errVlrC
      // 
      this.errVlrC.ContainerControl = this;
      // 
      // openFile
      // 
      this.openFile.FileName = "openFileDialog1";
      this.openFile.Filter = "Archivos Excel|*.xls;*.xlsx;*.xlsm";
      // 
      // saveFile
      // 
      this.saveFile.FileName = "TemplateMedicamentos.xlsx";
      this.saveFile.Filter = "Archivos Excel|*.xlsx;*.xls;*.xlsm";
      // 
      // errVlrV
      // 
      this.errVlrV.ContainerControl = this;
      // 
      // FormMedicamento
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabMedicamentos);
      this.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FormMedicamento";
      this.Text = "FormMedicamento";
      this.tabListUsers.ResumeLayout(false);
      this.tabListUsers.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listMedicamentos)).EndInit();
      this.tabBulkLoad.ResumeLayout(false);
      this.tabAddMed.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabMedicamentos.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errNom)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errVlrC)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errVlrV)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage tabListUsers;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DataGridView listMedicamentos;
    private System.Windows.Forms.TabPage tabBulkLoad;
    private System.Windows.Forms.Button btnDown;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.TabPage tabAddMed;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnMod;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtNom;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtVlrC;
    private System.Windows.Forms.TabControl tabMedicamentos;
    private System.Windows.Forms.ErrorProvider errNom;
    private System.Windows.Forms.ErrorProvider errVlrC;
    private System.Windows.Forms.OpenFileDialog openFile;
    private System.Windows.Forms.SaveFileDialog saveFile;
    private System.Windows.Forms.ErrorProvider errVlrV;
    private System.Windows.Forms.TextBox txtVlrV;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtBuscar;
  }
}