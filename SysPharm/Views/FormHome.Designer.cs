namespace SysPharm.Views
{
  partial class FormHome
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
      this.pnlTitulo = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.btnMinWin = new System.Windows.Forms.PictureBox();
      this.btnMinimizar = new System.Windows.Forms.PictureBox();
      this.btnMaximizar = new System.Windows.Forms.PictureBox();
      this.btnCerrar = new System.Windows.Forms.PictureBox();
      this.pnlNav = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnMedicamentos = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnUsuarios = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pnlContenedor = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnInformes = new System.Windows.Forms.Button();
      this.panel4 = new System.Windows.Forms.Panel();
      this.btnEPS = new System.Windows.Forms.Button();
      this.pnlTitulo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMinWin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
      this.pnlNav.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlTitulo
      // 
      this.pnlTitulo.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.pnlTitulo.Controls.Add(this.label1);
      this.pnlTitulo.Controls.Add(this.pictureBox2);
      this.pnlTitulo.Controls.Add(this.btnMinWin);
      this.pnlTitulo.Controls.Add(this.btnMinimizar);
      this.pnlTitulo.Controls.Add(this.btnMaximizar);
      this.pnlTitulo.Controls.Add(this.btnCerrar);
      this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
      this.pnlTitulo.Name = "pnlTitulo";
      this.pnlTitulo.Size = new System.Drawing.Size(1050, 35);
      this.pnlTitulo.TabIndex = 1;
      this.pnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Cursor = System.Windows.Forms.Cursors.AppStarting;
      this.label1.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(32, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 21);
      this.label1.TabIndex = 5;
      this.label1.Text = "SysPharm";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // pictureBox2
      // 
      this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
      this.pictureBox2.Location = new System.Drawing.Point(4, 5);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(25, 25);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 4;
      this.pictureBox2.TabStop = false;
      // 
      // btnMinWin
      // 
      this.btnMinWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMinWin.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnMinWin.Image = ((System.Drawing.Image)(resources.GetObject("btnMinWin.Image")));
      this.btnMinWin.Location = new System.Drawing.Point(973, 5);
      this.btnMinWin.Name = "btnMinWin";
      this.btnMinWin.Size = new System.Drawing.Size(25, 25);
      this.btnMinWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.btnMinWin.TabIndex = 3;
      this.btnMinWin.TabStop = false;
      this.btnMinWin.Visible = false;
      this.btnMinWin.Click += new System.EventHandler(this.btnMinWin_Click);
      // 
      // btnMinimizar
      // 
      this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
      this.btnMinimizar.Location = new System.Drawing.Point(933, 5);
      this.btnMinimizar.Name = "btnMinimizar";
      this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
      this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.btnMinimizar.TabIndex = 2;
      this.btnMinimizar.TabStop = false;
      this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
      // 
      // btnMaximizar
      // 
      this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
      this.btnMaximizar.Location = new System.Drawing.Point(973, 5);
      this.btnMaximizar.Name = "btnMaximizar";
      this.btnMaximizar.Size = new System.Drawing.Size(25, 25);
      this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.btnMaximizar.TabIndex = 1;
      this.btnMaximizar.TabStop = false;
      this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
      // 
      // btnCerrar
      // 
      this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
      this.btnCerrar.Location = new System.Drawing.Point(1013, 5);
      this.btnCerrar.Name = "btnCerrar";
      this.btnCerrar.Size = new System.Drawing.Size(25, 25);
      this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.btnCerrar.TabIndex = 0;
      this.btnCerrar.TabStop = false;
      this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
      // 
      // pnlNav
      // 
      this.pnlNav.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.pnlNav.Controls.Add(this.panel4);
      this.pnlNav.Controls.Add(this.btnEPS);
      this.pnlNav.Controls.Add(this.panel3);
      this.pnlNav.Controls.Add(this.btnInformes);
      this.pnlNav.Controls.Add(this.panel2);
      this.pnlNav.Controls.Add(this.btnMedicamentos);
      this.pnlNav.Controls.Add(this.panel1);
      this.pnlNav.Controls.Add(this.btnUsuarios);
      this.pnlNav.Controls.Add(this.pictureBox1);
      this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlNav.Location = new System.Drawing.Point(0, 35);
      this.pnlNav.Name = "pnlNav";
      this.pnlNav.Size = new System.Drawing.Size(220, 615);
      this.pnlNav.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.panel2.Location = new System.Drawing.Point(0, 236);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(10, 35);
      this.panel2.TabIndex = 1;
      // 
      // btnMedicamentos
      // 
      this.btnMedicamentos.FlatAppearance.BorderSize = 0;
      this.btnMedicamentos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
      this.btnMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnMedicamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnMedicamentos.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicamentos.Image")));
      this.btnMedicamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnMedicamentos.Location = new System.Drawing.Point(4, 236);
      this.btnMedicamentos.Name = "btnMedicamentos";
      this.btnMedicamentos.Size = new System.Drawing.Size(213, 35);
      this.btnMedicamentos.TabIndex = 2;
      this.btnMedicamentos.Text = "Medicamentos";
      this.btnMedicamentos.UseVisualStyleBackColor = true;
      this.btnMedicamentos.Click += new System.EventHandler(this.button2_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.panel1.Location = new System.Drawing.Point(0, 195);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(10, 35);
      this.panel1.TabIndex = 0;
      // 
      // btnUsuarios
      // 
      this.btnUsuarios.FlatAppearance.BorderSize = 0;
      this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
      this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
      this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnUsuarios.Location = new System.Drawing.Point(4, 195);
      this.btnUsuarios.Name = "btnUsuarios";
      this.btnUsuarios.Size = new System.Drawing.Size(213, 35);
      this.btnUsuarios.TabIndex = 0;
      this.btnUsuarios.Text = "Usuarios";
      this.btnUsuarios.UseVisualStyleBackColor = true;
      this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(4, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(213, 115);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // pnlContenedor
      // 
      this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContenedor.Location = new System.Drawing.Point(220, 35);
      this.pnlContenedor.Name = "pnlContenedor";
      this.pnlContenedor.Size = new System.Drawing.Size(830, 615);
      this.pnlContenedor.TabIndex = 3;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.panel3.Location = new System.Drawing.Point(0, 277);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(10, 35);
      this.panel3.TabIndex = 3;
      // 
      // btnInformes
      // 
      this.btnInformes.FlatAppearance.BorderSize = 0;
      this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
      this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnInformes.Image = ((System.Drawing.Image)(resources.GetObject("btnInformes.Image")));
      this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnInformes.Location = new System.Drawing.Point(4, 277);
      this.btnInformes.Name = "btnInformes";
      this.btnInformes.Size = new System.Drawing.Size(213, 35);
      this.btnInformes.TabIndex = 4;
      this.btnInformes.Text = "Informes";
      this.btnInformes.UseVisualStyleBackColor = true;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.panel4.Location = new System.Drawing.Point(0, 318);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(10, 35);
      this.panel4.TabIndex = 5;
      // 
      // btnEPS
      // 
      this.btnEPS.FlatAppearance.BorderSize = 0;
      this.btnEPS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
      this.btnEPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEPS.Image = ((System.Drawing.Image)(resources.GetObject("btnEPS.Image")));
      this.btnEPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnEPS.Location = new System.Drawing.Point(4, 318);
      this.btnEPS.Name = "btnEPS";
      this.btnEPS.Size = new System.Drawing.Size(213, 35);
      this.btnEPS.TabIndex = 6;
      this.btnEPS.Text = "EPS";
      this.btnEPS.UseVisualStyleBackColor = true;
      this.btnEPS.Click += new System.EventHandler(this.btnEPS_Click);
      // 
      // FormHome
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(1050, 650);
      this.Controls.Add(this.pnlContenedor);
      this.Controls.Add(this.pnlNav);
      this.Controls.Add(this.pnlTitulo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormHome";
      this.Text = "SysPharm";
      this.pnlTitulo.ResumeLayout(false);
      this.pnlTitulo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMinWin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
      this.pnlNav.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlTitulo;
    private System.Windows.Forms.PictureBox btnCerrar;
    private System.Windows.Forms.Panel pnlNav;
    private System.Windows.Forms.Panel pnlContenedor;
    private System.Windows.Forms.PictureBox btnMinimizar;
    private System.Windows.Forms.PictureBox btnMaximizar;
    private System.Windows.Forms.PictureBox btnMinWin;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Button btnUsuarios;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnMedicamentos;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnInformes;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Button btnEPS;
  }
}