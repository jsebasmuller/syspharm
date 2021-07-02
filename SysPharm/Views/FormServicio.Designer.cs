namespace SysPharm.Views
{
  partial class FormServicio
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServicio));
      this.tabEps = new System.Windows.Forms.TabControl();
      this.tabAddSer = new System.Windows.Forms.TabPage();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnMod = new System.Windows.Forms.Button();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.txtNomSer = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label7 = new System.Windows.Forms.Label();
      this.listSer = new System.Windows.Forms.DataGridView();
      this.errNom = new System.Windows.Forms.ErrorProvider(this.components);
      this.label11 = new System.Windows.Forms.Label();
      this.txtBuscar = new System.Windows.Forms.TextBox();
      this.tabEps.SuspendLayout();
      this.tabAddSer.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listSer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNom)).BeginInit();
      this.SuspendLayout();
      // 
      // tabEps
      // 
      this.tabEps.Controls.Add(this.tabAddSer);
      this.tabEps.Controls.Add(this.tabPage2);
      this.tabEps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabEps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabEps.Location = new System.Drawing.Point(0, 0);
      this.tabEps.Name = "tabEps";
      this.tabEps.SelectedIndex = 0;
      this.tabEps.Size = new System.Drawing.Size(800, 450);
      this.tabEps.TabIndex = 1;
      // 
      // tabAddSer
      // 
      this.tabAddSer.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabAddSer.Controls.Add(this.btnCancel);
      this.tabAddSer.Controls.Add(this.btnDel);
      this.tabAddSer.Controls.Add(this.btnMod);
      this.tabAddSer.Controls.Add(this.btnLimpiar);
      this.tabAddSer.Controls.Add(this.btnGuardar);
      this.tabAddSer.Controls.Add(this.txtNomSer);
      this.tabAddSer.Controls.Add(this.label1);
      this.tabAddSer.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tabAddSer.Location = new System.Drawing.Point(4, 27);
      this.tabAddSer.Name = "tabAddSer";
      this.tabAddSer.Padding = new System.Windows.Forms.Padding(3);
      this.tabAddSer.Size = new System.Drawing.Size(792, 419);
      this.tabAddSer.TabIndex = 0;
      this.tabAddSer.Text = "Agregar Servicio";
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnCancel.Location = new System.Drawing.Point(546, 253);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(102, 36);
      this.btnCancel.TabIndex = 21;
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
      this.btnDel.Location = new System.Drawing.Point(358, 253);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(102, 36);
      this.btnDel.TabIndex = 20;
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
      this.btnMod.Location = new System.Drawing.Point(153, 253);
      this.btnMod.Name = "btnMod";
      this.btnMod.Size = new System.Drawing.Size(102, 36);
      this.btnMod.TabIndex = 19;
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
      this.btnLimpiar.Location = new System.Drawing.Point(438, 253);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
      this.btnLimpiar.TabIndex = 18;
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
      this.btnGuardar.Location = new System.Drawing.Point(261, 253);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 17;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // txtNomSer
      // 
      this.txtNomSer.Location = new System.Drawing.Point(284, 113);
      this.txtNomSer.Name = "txtNomSer";
      this.txtNomSer.Size = new System.Drawing.Size(370, 24);
      this.txtNomSer.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(111, 116);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(142, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Nombre del Servicio";
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabPage2.Controls.Add(this.label11);
      this.tabPage2.Controls.Add(this.txtBuscar);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.listSer);
      this.tabPage2.Location = new System.Drawing.Point(4, 27);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(792, 419);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Lista de Servicios";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.SkyBlue;
      this.label7.Dock = System.Windows.Forms.DockStyle.Top;
      this.label7.Location = new System.Drawing.Point(3, 3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(727, 18);
      this.label7.TabIndex = 3;
      this.label7.Text = "Sí desea modificar o eliminar un Servicio, debes dar doble clic sobre el Servicio" +
    " al que deseas hacer la acción";
      // 
      // listSer
      // 
      this.listSer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listSer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      this.listSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listSer.GridColor = System.Drawing.SystemColors.ControlLightLight;
      this.listSer.Location = new System.Drawing.Point(3, 54);
      this.listSer.Name = "listSer";
      this.listSer.Size = new System.Drawing.Size(786, 362);
      this.listSer.TabIndex = 2;
      this.listSer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTablePaciente);
      // 
      // errNom
      // 
      this.errNom.ContainerControl = this;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(4, 25);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(72, 18);
      this.label11.TabIndex = 7;
      this.label11.Text = "Buscador";
      // 
      // txtBuscar
      // 
      this.txtBuscar.Location = new System.Drawing.Point(82, 24);
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new System.Drawing.Size(365, 24);
      this.txtBuscar.TabIndex = 6;
      this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
      // 
      // FormServicio
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabEps);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormServicio";
      this.Text = "FormServicio";
      this.tabEps.ResumeLayout(false);
      this.tabAddSer.ResumeLayout(false);
      this.tabAddSer.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listSer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNom)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabEps;
    private System.Windows.Forms.TabPage tabAddSer;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnMod;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.TextBox txtNomSer;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DataGridView listSer;
    private System.Windows.Forms.ErrorProvider errNom;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtBuscar;
  }
}