namespace SysPharm.Views
{
  partial class FormContraseña
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContraseña));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.btnGuardar = new System.Windows.Forms.Button();
      this.passAct = new System.Windows.Forms.TextBox();
      this.passReN = new System.Windows.Forms.TextBox();
      this.passNue = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.errPassAct = new System.Windows.Forms.ErrorProvider(this.components);
      this.errPassNue = new System.Windows.Forms.ErrorProvider(this.components);
      this.errPassNueR = new System.Windows.Forms.ErrorProvider(this.components);
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errPassAct)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errPassNue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errPassNueR)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnLimpiar);
      this.panel1.Controls.Add(this.btnGuardar);
      this.panel1.Controls.Add(this.passAct);
      this.panel1.Controls.Add(this.passReN);
      this.panel1.Controls.Add(this.passNue);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 450);
      this.panel1.TabIndex = 0;
      // 
      // btnLimpiar
      // 
      this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
      this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnLimpiar.Location = new System.Drawing.Point(443, 338);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(102, 36);
      this.btnLimpiar.TabIndex = 15;
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
      this.btnGuardar.Location = new System.Drawing.Point(266, 338);
      this.btnGuardar.Name = "btnGuardar";
      this.btnGuardar.Size = new System.Drawing.Size(102, 36);
      this.btnGuardar.TabIndex = 14;
      this.btnGuardar.Text = "Guardar";
      this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnGuardar.UseVisualStyleBackColor = true;
      this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
      // 
      // passAct
      // 
      this.passAct.Location = new System.Drawing.Point(160, 155);
      this.passAct.Name = "passAct";
      this.passAct.PasswordChar = '*';
      this.passAct.Size = new System.Drawing.Size(195, 24);
      this.passAct.TabIndex = 5;
      this.passAct.Leave += new System.EventHandler(this.ValidarPassAct);
      // 
      // passReN
      // 
      this.passReN.Location = new System.Drawing.Point(591, 213);
      this.passReN.Name = "passReN";
      this.passReN.PasswordChar = '*';
      this.passReN.Size = new System.Drawing.Size(195, 24);
      this.passReN.TabIndex = 4;
      this.passReN.Leave += new System.EventHandler(this.ValidarPassNueR);
      // 
      // passNue
      // 
      this.passNue.Location = new System.Drawing.Point(160, 213);
      this.passNue.Name = "passNue";
      this.passNue.PasswordChar = '*';
      this.passNue.Size = new System.Drawing.Size(195, 24);
      this.passNue.TabIndex = 3;
      this.passNue.Leave += new System.EventHandler(this.ValidarPassNue);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(390, 216);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(183, 17);
      this.label3.TabIndex = 2;
      this.label3.Text = "Confirme Nueva Contraseña";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 216);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(122, 17);
      this.label2.TabIndex = 1;
      this.label2.Text = "Nueva Contraseña";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(17, 158);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(122, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Contraseña Actual";
      // 
      // errPassAct
      // 
      this.errPassAct.ContainerControl = this;
      // 
      // errPassNue
      // 
      this.errPassNue.ContainerControl = this;
      // 
      // errPassNueR
      // 
      this.errPassNueR.ContainerControl = this;
      // 
      // FormContraseña
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormContraseña";
      this.Text = "FormContraseña";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errPassAct)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errPassNue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errPassNueR)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox passAct;
    private System.Windows.Forms.TextBox passReN;
    private System.Windows.Forms.TextBox passNue;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.ErrorProvider errPassAct;
    private System.Windows.Forms.ErrorProvider errPassNue;
    private System.Windows.Forms.ErrorProvider errPassNueR;
  }
}