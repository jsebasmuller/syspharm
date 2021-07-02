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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedido));
      this.tabPedidos = new System.Windows.Forms.TabControl();
      this.tabAddPedido = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label1 = new System.Windows.Forms.Label();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.cmbMedicamentos = new System.Windows.Forms.ComboBox();
      this.txtProveedor = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dtSolicitud = new System.Windows.Forms.DateTimePicker();
      this.dtIngreso = new System.Windows.Forms.DateTimePicker();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btnAddMedi = new System.Windows.Forms.Button();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.listPedidos = new System.Windows.Forms.DataGridView();
      this.label10 = new System.Windows.Forms.Label();
      this.txtBuscar = new System.Windows.Forms.TextBox();
      this.tabPedidos.SuspendLayout();
      this.tabAddPedido.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.listPedidos)).BeginInit();
      this.SuspendLayout();
      // 
      // tabPedidos
      // 
      this.tabPedidos.Controls.Add(this.tabAddPedido);
      this.tabPedidos.Controls.Add(this.tabPage2);
      this.tabPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabPedidos.Location = new System.Drawing.Point(0, 0);
      this.tabPedidos.Name = "tabPedidos";
      this.tabPedidos.SelectedIndex = 0;
      this.tabPedidos.Size = new System.Drawing.Size(800, 450);
      this.tabPedidos.TabIndex = 3;
      // 
      // tabAddPedido
      // 
      this.tabAddPedido.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
      this.tabAddPedido.Controls.Add(this.dataGridView1);
      this.tabAddPedido.Controls.Add(this.cmbMedicamentos);
      this.tabAddPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabAddPedido.Location = new System.Drawing.Point(4, 27);
      this.tabAddPedido.Name = "tabAddPedido";
      this.tabAddPedido.Padding = new System.Windows.Forms.Padding(3);
      this.tabAddPedido.Size = new System.Drawing.Size(792, 419);
      this.tabAddPedido.TabIndex = 0;
      this.tabAddPedido.Text = "Agregar Pedido";
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabPage2.Controls.Add(this.label10);
      this.tabPage2.Controls.Add(this.txtBuscar);
      this.tabPage2.Controls.Add(this.listPedidos);
      this.tabPage2.Location = new System.Drawing.Point(4, 27);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(792, 419);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Lista de Pedidos";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 18);
      this.label1.TabIndex = 5;
      this.label1.Text = "Proveedor";
      // 
      // dataGridView1
      // 
      this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(9, 158);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(776, 193);
      this.dataGridView1.TabIndex = 4;
      // 
      // cmbMedicamentos
      // 
      this.cmbMedicamentos.FormattingEnabled = true;
      this.cmbMedicamentos.Location = new System.Drawing.Point(172, 122);
      this.cmbMedicamentos.Name = "cmbMedicamentos";
      this.cmbMedicamentos.Size = new System.Drawing.Size(343, 26);
      this.cmbMedicamentos.TabIndex = 3;
      // 
      // txtProveedor
      // 
      this.txtProveedor.Location = new System.Drawing.Point(172, 24);
      this.txtProveedor.Name = "txtProveedor";
      this.txtProveedor.Size = new System.Drawing.Size(598, 24);
      this.txtProveedor.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(19, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(129, 18);
      this.label2.TabIndex = 7;
      this.label2.Text = "Fecha de Solicitud";
      // 
      // dtSolicitud
      // 
      this.dtSolicitud.Location = new System.Drawing.Point(172, 74);
      this.dtSolicitud.Name = "dtSolicitud";
      this.dtSolicitud.Size = new System.Drawing.Size(165, 24);
      this.dtSolicitud.TabIndex = 8;
      // 
      // dtIngreso
      // 
      this.dtIngreso.Location = new System.Drawing.Point(605, 74);
      this.dtIngreso.Name = "dtIngreso";
      this.dtIngreso.Size = new System.Drawing.Size(165, 24);
      this.dtIngreso.TabIndex = 10;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(452, 77);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(122, 18);
      this.label3.TabIndex = 9;
      this.label3.Text = "Fecha de Ingreso";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(19, 125);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(98, 18);
      this.label4.TabIndex = 11;
      this.label4.Text = "Medicamento";
      // 
      // btnAddMedi
      // 
      this.btnAddMedi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAddMedi.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMedi.Image")));
      this.btnAddMedi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnAddMedi.Location = new System.Drawing.Point(546, 116);
      this.btnAddMedi.Name = "btnAddMedi";
      this.btnAddMedi.Size = new System.Drawing.Size(102, 36);
      this.btnAddMedi.TabIndex = 13;
      this.btnAddMedi.Text = "Agregar";
      this.btnAddMedi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddMedi.UseVisualStyleBackColor = true;
      // 
      // btnLimpiar
      // 
      this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
      this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnLimpiar.Location = new System.Drawing.Point(681, 368);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
      this.btnLimpiar.TabIndex = 15;
      this.btnLimpiar.Text = "Limpiar";
      this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLimpiar.UseVisualStyleBackColor = true;
      this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
      this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnGuardar.Location = new System.Drawing.Point(573, 368);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 14;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // listPedidos
      // 
      this.listPedidos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.listPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listPedidos.Location = new System.Drawing.Point(6, 32);
      this.listPedidos.Name = "listPedidos";
      this.listPedidos.Size = new System.Drawing.Size(778, 386);
      this.listPedidos.TabIndex = 0;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(8, 5);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(72, 18);
      this.label10.TabIndex = 5;
      this.label10.Text = "Buscador";
      // 
      // txtBuscar
      // 
      this.txtBuscar.Location = new System.Drawing.Point(86, 2);
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new System.Drawing.Size(365, 24);
      this.txtBuscar.TabIndex = 4;
      // 
      // FormPedido
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabPedidos);
      this.Cursor = System.Windows.Forms.Cursors.Default;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPedido";
      this.Text = "FormPedido";
      this.tabPedidos.ResumeLayout(false);
      this.tabAddPedido.ResumeLayout(false);
      this.tabAddPedido.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.listPedidos)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabPedidos;
    private System.Windows.Forms.TabPage tabAddPedido;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.ComboBox cmbMedicamentos;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtProveedor;
    private System.Windows.Forms.DateTimePicker dtIngreso;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker dtSolicitud;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnAddMedi;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.DataGridView listPedidos;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtBuscar;
  }
}