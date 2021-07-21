using SysPharm.Controllers;
using SysPharm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Views
{
  public partial class FormInforme : Form
  {
    InformeController infoControl = new InformeController(new Context());
    public FormInforme()
    {
      InitializeComponent();
      dateTimePicker1.Format = DateTimePickerFormat.Custom;
      dateTimePicker1.CustomFormat = "MMMM/yyyy";
      dateTimePicker1.ShowUpDown = true;
    }

    private void btnDownInfMon_Click(object sender, EventArgs e)
    {
      if (saveRepMon.ShowDialog() == DialogResult.OK)
      {
        var success = infoControl.ReportMonth(dateTimePicker1.Value.Date, saveRepMon.FileName);
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "¡Descarga!",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
        }
        else
        {
          var resp = MessageBox.Show(success.Mensaje, "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          infoControl = new InformeController(new Context());
        }
      }
    }
  }
}
