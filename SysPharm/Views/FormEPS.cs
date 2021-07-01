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
  public partial class FormEPS : Form
  {
    EPSController epsControl = new EPSController(new Context());
    bool valName = false;

    public FormEPS()
    {
      InitializeComponent();
      RefrescarListaEPS();
    }

    private void RefrescarListaEPS()
    {
      listEPS.DataSource = epsControl.GetEps();
      listEPS.AutoResizeColumns();
      listEPS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    public bool Validar()
    {
      if (txtNomEps.Text == "" || txtNomEps.Text == " ")
      {
        errNomEps.SetError(txtNomEps, "El campo no puede ser vacío");
        return false;
      }
      else
      {
        errNomEps.SetError(txtNomEps, "");
        return true;
      }
    }

    private void btnMod_Click(object sender, EventArgs e)
    {
      if (Validar())
      {
        Eps eps = new Eps();
        var pos = listEPS.CurrentRow.Index;
        eps.Id = Int32.Parse(listEPS[0, pos].Value.ToString());
        eps.Nombre = txtNomEps.Text;
        var success = epsControl.UpdateEPS(eps);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡EPS Modificada!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaEPS();
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnCancel.Visible = false;
            btnMod.Visible = false;
            btnDel.Visible = false;
            LimpiarDatos(sender, e);
          }
        }
        else
        {
          string message = success.Mensaje;
          const string caption = "Error";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          epsControl = new EPSController(new Context());
        }
      }
      else
      {
        const string message = "Faltan campos por llenar";
        const string caption = "Advertencia!";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
      }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      if (Validar())
      {
        Eps eps = new Eps();
        eps.Id = 1;
        eps.Nombre = txtNomEps.Text;
        var success = epsControl.RegisterEPS(eps);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡EPS Creada!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaEPS();
            LimpiarDatos(sender, e);
          }
        }
        else
        {
          string message = success.Mensaje;
          const string caption = "Error";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          epsControl = new EPSController(new Context());
        }
      }
      else
      {
        const string message = "Faltan campos por llenar";
        const string caption = "Advertencia!";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
      }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      string message = $"¿Esta seguro que desea eliminar la EPS {txtNomEps.Text}?";
      const string caption = "Advertencia!";
      var result = MessageBox.Show(message, caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);
      if (result == System.Windows.Forms.DialogResult.Yes)
      {
        var pos = listEPS.CurrentRow.Index;
        var success = epsControl.DeleteEPS(Int32.Parse(listEPS[0, pos].Value.ToString()));
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (resp == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaEPS();
            LimpiarDatos(sender, e);
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnCancel.Visible = false;
            btnMod.Visible = false;
            btnDel.Visible = false;
          }
        }
        else
        {
          var resp = MessageBox.Show(success.Mensaje, "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          epsControl = new EPSController(new Context());
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      LimpiarDatos(sender, e);
      btnGuardar.Visible = true;
      btnLimpiar.Visible = true;
      btnCancel.Visible = false;
      btnMod.Visible = false;
      btnDel.Visible = false;
    }

    private void doubleClickTablePaciente(object sender, DataGridViewCellEventArgs e)
    {
      btnGuardar.Visible = false;
      btnLimpiar.Visible = false;
      btnCancel.Visible = true;
      btnDel.Visible = true;
      btnMod.Visible = true;
      var pos = listEPS.CurrentRow.Index;
      txtNomEps.Text = listEPS[1, pos].Value.ToString();
      tabEps.SelectedTab = tabAddEps;
    }

    private void LimpiarDatos(object sender, EventArgs e)
    {
      txtNomEps.Text = "";
    }
  }
}
