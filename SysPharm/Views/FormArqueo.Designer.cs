namespace SysPharm.Views
{
  partial class FormArqueo
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArqueo));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblPag = new System.Windows.Forms.Label();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnPrev = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.listArqueo = new System.Windows.Forms.DataGridView();
      this.panel3 = new System.Windows.Forms.Panel();
      this.txtBuscar = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listArqueo)).BeginInit();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblPag);
      this.panel1.Controls.Add(this.btnNext);
      this.panel1.Controls.Add(this.btnPrev);
      this.panel1.Controls.Add(this.btnGuardar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 350);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 100);
      this.panel1.TabIndex = 0;
      // 
      // lblPag
      // 
      this.lblPag.AutoSize = true;
      this.lblPag.Cursor = System.Windows.Forms.Cursors.HSplit;
      this.lblPag.Location = new System.Drawing.Point(367, 14);
      this.lblPag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPag.Name = "lblPag";
      this.lblPag.Size = new System.Drawing.Size(64, 17);
      this.lblPag.TabIndex = 23;
      this.lblPag.Text = "Buscador";
      // 
      // btnNext
      // 
      this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNext.Location = new System.Drawing.Point(476, 11);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(25, 23);
      this.btnNext.TabIndex = 25;
      this.btnNext.Text = ">";
      this.btnNext.UseVisualStyleBackColor = true;
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
      // 
      // btnPrev
      // 
      this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnPrev.Location = new System.Drawing.Point(322, 11);
      this.btnPrev.Name = "btnPrev";
      this.btnPrev.Size = new System.Drawing.Size(25, 23);
      this.btnPrev.TabIndex = 24;
      this.btnPrev.Text = "<";
      this.btnPrev.UseVisualStyleBackColor = true;
      this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
      // 
      // btnGuardar
      // 
      this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGuardar.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
      this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnGuardar.Location = new System.Drawing.Point(360, 52);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 22;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.listArqueo);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(800, 350);
      this.panel2.TabIndex = 1;
      // 
      // listArqueo
      // 
      this.listArqueo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listArqueo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.listArqueo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.listArqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listArqueo.EnableHeadersVisualStyles = false;
      this.listArqueo.Location = new System.Drawing.Point(3, 57);
      this.listArqueo.Name = "listArqueo";
      this.listArqueo.Size = new System.Drawing.Size(785, 287);
      this.listArqueo.TabIndex = 23;
      this.listArqueo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDetalles_CellEndEdit);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.txtBuscar);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(800, 51);
      this.panel3.TabIndex = 2;
      // 
      // txtBuscar
      // 
      this.txtBuscar.Location = new System.Drawing.Point(92, 15);
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new System.Drawing.Size(405, 24);
      this.txtBuscar.TabIndex = 1;
      this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Buscador";
      // 
      // FormArqueo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FormArqueo";
      this.Text = "FormArqueo";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.listArqueo)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.DataGridView listArqueo;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.TextBox txtBuscar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblPag;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnPrev;
  }
}