namespace SysPharm.Views
{
  partial class FormInforme
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInforme));
      this.saveRepMon = new System.Windows.Forms.SaveFileDialog();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnDownInfMon = new System.Windows.Forms.Button();
      this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.tabInformes = new System.Windows.Forms.TabControl();
      this.tabPage1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabInformes.SuspendLayout();
      this.SuspendLayout();
      // 
      // saveRepMon
      // 
      this.saveRepMon.FileName = "InformeMensual.xlsx";
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tabPage1.Controls.Add(this.panel1);
      this.tabPage1.Location = new System.Drawing.Point(4, 26);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(792, 420);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Informe Mensual";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.dateTimePicker1);
      this.panel1.Controls.Add(this.btnDownInfMon);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(786, 100);
      this.panel1.TabIndex = 17;
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
      // dateTimePicker1
      // 
      this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new System.Drawing.Point(163, 36);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
      this.dateTimePicker1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Mes a Reportar";
      // 
      // tabInformes
      // 
      this.tabInformes.Controls.Add(this.tabPage1);
      this.tabInformes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabInformes.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabInformes.Location = new System.Drawing.Point(0, 0);
      this.tabInformes.Name = "tabInformes";
      this.tabInformes.SelectedIndex = 0;
      this.tabInformes.Size = new System.Drawing.Size(800, 450);
      this.tabInformes.TabIndex = 0;
      // 
      // FormInforme
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabInformes);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormInforme";
      this.Text = "FormInforme";
      this.tabPage1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tabInformes.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.SaveFileDialog saveRepMon;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.Button btnDownInfMon;
    private System.Windows.Forms.TabControl tabInformes;
  }
}