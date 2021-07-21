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
  public partial class FormContraseña : Form
  {
    bool valPassAct = false;
    bool valPassNue = false;
    bool valPassNueR = false;
    UsuarioController userControl = new UsuarioController(new Context());

    public FormContraseña()
    {
      InitializeComponent();
    }

    public void ValidarDatos(object sender, EventArgs e)
    {
      ValidarPassAct(sender, e);
      ValidarPassNue(sender, e);
      ValidarPassNueR(sender, e);
    }

    private void ValidarPassAct(object sender, EventArgs e)
    {
      if(passAct.Text != "")
      {
        bool isTrue = userControl.Login(passAct.Text);
        if (isTrue)
        {
          valPassAct = true;
          errPassAct.SetError(passAct, "");
        }
        else
        {
          valPassAct = false;
          errPassAct.SetError(passAct, "La contraseña no coincide");
        }
      }
      else
      {
        valPassAct = false;
        errPassAct.SetError(passAct, "Campo Requerido");
      }
    }

    private void ValidarPassNue(object sender, EventArgs e)
    {
      if (passNue.Text != "")
      {
        valPassNue = true;
        errPassNue.SetError(passNue, "");
      }
      else
      {
        valPassNue = false;
        errPassNue.SetError(passNue, "Campo Requerido");
      }
    }

    private void ValidarPassNueR(object sender, EventArgs e)
    {
      if(passReN.Text != "")
      {
        if(passNue.Text != "" && passNue.Text == passReN.Text)
        {
          valPassNueR = true;
          errPassNueR.SetError(passReN, "");
        }
        else
        {
          valPassNueR = false;
          errPassNueR.SetError(passReN, "Las contraseñas no coinciden");
        }
      }
      else
      {
        valPassNueR = false;
        errPassNueR.SetError(passReN, "Campo Requerido");
      }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      ValidarDatos(sender, e);
      if (valPassAct && valPassNue && valPassNueR)
      {
        Ingreso ingreso = new Ingreso();
        ingreso.IsActive = true;
        ingreso.Password = passNue.Text;
        var success = userControl.ChangePass(ingreso);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Cambio de Contraseña!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
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
          userControl = new UsuarioController(new Context());
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

    private void LimpiarDatos(object sender, EventArgs e)
    {
      valPassAct = false;
      valPassNue = false;
      valPassNueR = false;
      passAct.Text = "";
      passNue.Text = "";
      passReN.Text = "";
    }
  }
}
