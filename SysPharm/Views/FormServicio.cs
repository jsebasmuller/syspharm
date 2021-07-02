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
  public partial class FormServicio : Form
  {
    ServicioController servicioControl = new ServicioController(new Context());
    List<Servicio> listaServicios = new List<Servicio>();
    bool valName = false;

    public FormServicio()
    {
      InitializeComponent();
      RefrescarListaServicios();
    }

    private void RefrescarListaServicios()
    {
      listaServicios = servicioControl.GetServicios();
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaServicios = listaServicios.Where(x => x.Nombre.Trim().ToLower().Contains(txtBuscar.Text.Trim().ToLower())).ToList();
      }
      listSer.DataSource = listaServicios;
      listSer.AutoResizeColumns();
      listSer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    public bool Validar()
    {
      if (txtNomSer.Text == "" || txtNomSer.Text == " ")
      {
        errNom.SetError(txtNomSer, "El campo no puede ser vacío");
        return false;
      }
      else
      {
        errNom.SetError(txtNomSer, "");
        return true;
      }
    }

    private void btnMod_Click(object sender, EventArgs e)
    {
      if (Validar())
      {
        Servicio servicio = new Servicio();
        var pos = listSer.CurrentRow.Index;
        servicio.Id = Int32.Parse(listSer[0, pos].Value.ToString());
        servicio.Nombre = txtNomSer.Text;
        var success = servicioControl.UpdateServicio(servicio);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Servicio Modificado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaServicios();
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
          servicioControl = new ServicioController(new Context());
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
        Servicio servicio = new Servicio();
        servicio.Id = 1;
        servicio.Nombre = txtNomSer.Text;
        var success = servicioControl.RegisterServicio(servicio);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Servicio Creado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaServicios();
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
          servicioControl = new ServicioController(new Context());
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
      string message = $"¿Esta seguro que desea eliminar el servicio {txtNomSer.Text}?";
      const string caption = "Advertencia!";
      var result = MessageBox.Show(message, caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);
      if (result == System.Windows.Forms.DialogResult.Yes)
      {
        var pos = listSer.CurrentRow.Index;
        var success = servicioControl.DeleteServicio(Int32.Parse(listSer[0, pos].Value.ToString()));
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (resp == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaServicios();
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
          servicioControl = new ServicioController(new Context());
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
      var pos = listSer.CurrentRow.Index;
      txtNomSer.Text = listSer[1, pos].Value.ToString();
      tabEps.SelectedTab = tabAddSer;
    }

    private void LimpiarDatos(object sender, EventArgs e)
    {
      txtNomSer.Text = "";
    }

    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      RefrescarListaServicios();
    }
  }
}
