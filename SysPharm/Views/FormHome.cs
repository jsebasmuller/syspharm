using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SysPharm.Views
{
  public partial class FormHome : Form
  {
    public FormHome()
    {
      InitializeComponent();
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {

    }

    private void abrirForm(object formHijo)
    {
      if (this.pnlContenedor.Controls.Count > 0)
        this.pnlContenedor.Controls.RemoveAt(0);
      Form fh = formHijo as Form;
      fh.TopLevel = false;
      fh.Dock = DockStyle.Fill;
      this.pnlContenedor.Controls.Add(fh);
      this.pnlContenedor.Tag = fh;
      fh.Show();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnMaximizar_Click(object sender, EventArgs e)
    {
      this.Location = new Point(0, 0);
      this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
      btnMaximizar.Visible = false;
      btnMinWin.Visible = true;
    }

    private void btnMinWin_Click(object sender, EventArgs e)
    {
      this.Location = new Point(0, 0);
      this.Size = new Size(1050, 650);
      btnMaximizar.Visible = true;
      btnMinWin.Visible = false;
    }

    private void btnMinimizar_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]

    private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
    {
      ReleaseCapture();
      SendMessage(this.Handle, 0x112, 0xf012, 0);
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
      abrirForm(new FormUsuario());
    }

    private void btnEPS_Click(object sender, EventArgs e)
    {
      abrirForm(new FormEPS());
    }
  }
}
