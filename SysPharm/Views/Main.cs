using SysPharm.Controllers;
using SysPharm.Models;
using SysPharm.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        GuardarDatos();
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

    private void GuardarDatos()
    {
      MedicamentoController medControl = new MedicamentoController(new Context());
      DateTime hoy = DateTime.Now;
      DateTime ultimoDiaMes = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1).AddDays(-1);
      if (ultimoDiaMes.ToString("dddd", new CultureInfo("es-ES")).Equals("sábado"))
      {
        if (hoy.Year.Equals(ultimoDiaMes.AddDays(-1).Year) && hoy.Month.Equals(ultimoDiaMes.AddDays(-1).Month) && hoy.Day.Equals(ultimoDiaMes.AddDays(-1).Day))
        {
          bool pass = medControl.InventarioFinMes();
          if (!pass)
            GuardarDatos();
        }
      }
      else if (ultimoDiaMes.ToString("dddd", new CultureInfo("es-ES")).Equals("domingo"))
      {
        if (hoy.Year.Equals(ultimoDiaMes.AddDays(-2).Year) && hoy.Month.Equals(ultimoDiaMes.AddDays(-2).Month) && hoy.Day.Equals(ultimoDiaMes.AddDays(-2).Day))
        {
          bool pass = medControl.InventarioFinMes();
          if (!pass)
            GuardarDatos();
        }
      }
      else
      {
        if (hoy.Year.Equals(ultimoDiaMes.Year) && hoy.Month.Equals(ultimoDiaMes.Month) && hoy.Day.Equals(ultimoDiaMes.Day))
        {
          bool pass = medControl.InventarioFinMes();
          if (!pass)
            GuardarDatos();
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
