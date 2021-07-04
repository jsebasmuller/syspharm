namespace SysPharm.Views
{
  partial class FormEPS
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEPS));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.tabEps = new System.Windows.Forms.TabControl();
      this.tabAddEps = new System.Windows.Forms.TabPage();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.btnMod = new System.Windows.Forms.Button();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.txtNomEps = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label10 = new System.Windows.Forms.Label();
      this.txtBuscar = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.listEPS = new System.Windows.Forms.DataGridView();
      this.errNomEps = new System.Windows.Forms.ErrorProvider(this.components);
      this.tabEps.SuspendLayout();
      this.tabAddEps.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listEPS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNomEps)).BeginInit();
      this.SuspendLayout();
      // 
      // tabEps
      // 
      this.tabEps.Controls.Add(this.tabAddEps);
      this.tabEps.Controls.Add(this.tabPage2);
      this.tabEps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabEps.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabEps.Location = new System.Drawing.Point(0, 0);
      this.tabEps.Name = "tabEps";
      this.tabEps.SelectedIndex = 0;
      this.tabEps.Size = new System.Drawing.Size(800, 450);
      this.tabEps.TabIndex = 0;
      // 
      // tabAddEps
      // 
      this.tabAddEps.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabAddEps.Controls.Add(this.btnCancel);
      this.tabAddEps.Controls.Add(this.btnDel);
      this.tabAddEps.Controls.Add(this.btnMod);
      this.tabAddEps.Controls.Add(this.btnLimpiar);
      this.tabAddEps.Controls.Add(this.btnGuardar);
      this.tabAddEps.Controls.Add(this.txtNomEps);
      this.tabAddEps.Controls.Add(this.label1);
      this.tabAddEps.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabAddEps.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tabAddEps.Location = new System.Drawing.Point(4, 26);
      this.tabAddEps.Name = "tabAddEps";
      this.tabAddEps.Padding = new System.Windows.Forms.Padding(3);
      this.tabAddEps.Size = new System.Drawing.Size(792, 420);
      this.tabAddEps.TabIndex = 0;
      this.tabAddEps.Text = "Agregar EPS";
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
      // txtNomEps
      // 
      this.txtNomEps.Location = new System.Drawing.Point(284, 113);
      this.txtNomEps.Name = "txtNomEps";
      this.txtNomEps.Size = new System.Drawing.Size(370, 24);
      this.txtNomEps.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(111, 116);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(122, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Nombre de la EPS";
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabPage2.Controls.Add(this.label10);
      this.tabPage2.Controls.Add(this.txtBuscar);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.listEPS);
      this.tabPage2.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabPage2.Location = new System.Drawing.Point(4, 26);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(792, 420);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Lista de EPS";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(4, 25);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(64, 17);
      this.label10.TabIndex = 5;
      this.label10.Text = "Buscador";
      // 
      // txtBuscar
      // 
      this.txtBuscar.Location = new System.Drawing.Point(82, 24);
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new System.Drawing.Size(365, 24);
      this.txtBuscar.TabIndex = 4;
      this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.SkyBlue;
      this.label7.Dock = System.Windows.Forms.DockStyle.Top;
      this.label7.Location = new System.Drawing.Point(3, 3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(637, 17);
      this.label7.TabIndex = 3;
      this.label7.Text = "Sí desea modificar o eliminar una EPS, debes dar doble clic sobre la EPS a la que" +
    " deseas hacer la acción";
      // 
      // listEPS
      // 
      this.listEPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listEPS.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.listEPS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.listEPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listEPS.EnableHeadersVisualStyles = false;
      this.listEPS.GridColor = System.Drawing.SystemColors.ControlLightLight;
      this.listEPS.Location = new System.Drawing.Point(3, 54);
      this.listEPS.Name = "listEPS";
      this.listEPS.Size = new System.Drawing.Size(786, 363);
      this.listEPS.TabIndex = 2;
      this.listEPS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doubleClickTablePaciente);
      // 
      // errNomEps
      // 
      this.errNomEps.ContainerControl = this;
      // 
      // FormEPS
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabEps);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormEPS";
      this.Text = "FormEPS";
      this.tabEps.ResumeLayout(false);
      this.tabAddEps.ResumeLayout(false);
      this.tabAddEps.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listEPS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errNomEps)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabEps;
    private System.Windows.Forms.TabPage tabAddEps;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtNomEps;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.Button btnMod;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.ErrorProvider errNomEps;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DataGridView listEPS;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtBuscar;
  }
}