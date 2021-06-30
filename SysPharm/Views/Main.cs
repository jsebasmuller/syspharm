using SysPharm.Controllers;
using SysPharm.Models;
using SysPharm.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm
{
  public partial class Form1 : Form
  {
    UsuarioController userControl = new UsuarioController(new Context());
    public Form1()
    {
      InitializeComponent();
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btnIngreso_Click(object sender, EventArgs e)
    {
      var texto = textBox1.Text;
      bool login = userControl.Login(texto);
      if (login)
      {
        var form = new FormHome();
        form.Show();
        this.Hide();
      }
      else
      {
        const string message = "La clave es incorrecta";
        const string caption = "Advertencia!";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
        textBox1.Text = "";
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
