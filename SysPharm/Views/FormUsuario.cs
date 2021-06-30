﻿using SysPharm.Controllers;
using SysPharm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Views
{
  public partial class FormUsuario : Form
  {
    UsuarioController userControl = new UsuarioController(new Context());
    List<TipoDocumento> listTDoc;
    List<TipoDocumento> listTUsu = new List<TipoDocumento>();
    bool valNames = false;
    bool valDoc = false;
    bool valTDoc = false;
    bool valDir = false;
    bool valTel = false;
    bool valTUs = false;

    public FormUsuario()
    {
      InitializeComponent();
      RefrescarListaPacientes();
      RefrescarListaMedicos();
      ObtenerTipoDocumentos();
      ObtenerTipoUsuario();
    }

    private void RefrescarListaPacientes()
    {
      listUsuarios.DataSource = userControl.GetPacientes();
      listUsuarios.Columns[1].HeaderText = "Tipo de Documento";
      listUsuarios.Columns[3].HeaderText = "Dirección";
      listUsuarios.Columns[4].HeaderText = "Teléfono";
      listUsuarios.AutoResizeColumns();
      listUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void RefrescarListaMedicos()
    {
      listMedicos.DataSource = userControl.GetMedicos();
      listMedicos.Columns[1].HeaderText = "Tipo de Documento";
      listMedicos.Columns[3].HeaderText = "Dirección";
      listMedicos.Columns[4].HeaderText = "Teléfono";
      listMedicos.AutoResizeColumns();
      listMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void ObtenerTipoDocumentos()
    {
      cmbTDoc.DataSource = userControl.GetTipoDocumentos();
      listTDoc = userControl.GetTipoDocumentos();
      cmbTDoc.DisplayMember = "Nombre";
      cmbTDoc.ValueMember = "Id";
    }

    private void ObtenerTipoUsuario()
    {
      listTUsu.Add(new TipoDocumento() { Id = 1, Nombre = "Medico" });
      listTUsu.Add(new TipoDocumento() { Id = 2, Nombre = "Paciente" });
      cmbTUsu.DataSource = listTUsu;
      cmbTUsu.DisplayMember = "Nombre";
      cmbTUsu.ValueMember = "Id";
    }

    private bool ValidarCampos(object sender, EventArgs e)
    {
      if (valNames && valTDoc && valTel && valTUs && valDir && valDoc)
      {
        return true;
      }
      else
      {
        ValidarDireccion(sender, e);
        ValidarDocumento(sender, e);
        ValidarNombres(sender, e);
        ValidarTelefono(sender, e);
        ValidarTipoDocumento(sender, e);
        ValidarTipoUsuario(sender, e);
        return false;
      }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      if (ValidarCampos(sender, e))
      {
        Usuario usuario = new Usuario();
        usuario.Documento = txtDoc.Text;
        usuario.IdTipoDocumento = Int32.Parse(cmbTDoc.SelectedValue.ToString());
        usuario.Nombres = txtNombres.Text;
        usuario.Telefono = txtTel.Text;
        usuario.TipoUsuario = cmbTUsu.GetItemText(cmbTUsu.SelectedItem);
        usuario.Direccion = txtDireccion.Text;
        var success = userControl.RegisterUser(usuario);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Usuario Creado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaPacientes();
            RefrescarListaMedicos();
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

    private void ValidarNombres(object sender, EventArgs e)
    {
      Regex Nombres = new Regex(@"^([A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚÄËÏÖÜäëïöüñáéíóúÑ\'])?$");
      if (txtNombres.Text == "" || txtNombres.Text == " " || !Nombres.IsMatch(txtNombres.Text))
      {
        valNames = false;
        errNames.SetError(txtNombres, "Nombre Inválido");
      }
      else
      {
        valNames = true;
        errNames.SetError(txtNombres, "");
      }
    }

    private void ValidarDocumento(object sender, EventArgs e)
    {
      Regex Doc = new Regex(@"^([0-9])*$");
      if (txtDoc.Text == "" || txtDoc.Text == " " || !Doc.IsMatch(txtDoc.Text))
      {
        valDoc = false;
        errDoc.SetError(txtDoc, "Documento Inválido");
      }
      else
      {
        valDoc = true;
        errDoc.SetError(txtDoc, "");
      }
    }

    private void ValidarTipoDocumento(object sender, EventArgs e)
    {
      if (cmbTDoc.SelectedValue == null)
      {
        valTDoc = false;
        errTDoc.SetError(cmbTDoc, "Debe seleccionar una opción");
      }
      else
      {
        valTDoc = true;
        errTDoc.SetError(cmbTDoc, "");
      }
    }

    private void ValidarDireccion(object sender, EventArgs e)
    {
      if (txtDireccion.Text == "" || txtDireccion.Text == " ")
      {
        valDir = false;
        errDir.SetError(txtDireccion, "Dirección Inválida");
      }
      else
      {
        valDir = true;
        errDir.SetError(txtDireccion, "");
      }
    }

    private void ValidarTipoUsuario(object sender, EventArgs e)
    {
      if (cmbTUsu.SelectedItem == null)
      {
        valTUs = false;
        errTUsu.SetError(cmbTUsu, "Debe seleccionar una opción");
      }
      else
      {
        valTUs = true;
        errTUsu.SetError(cmbTUsu, "");
      }
    }

    private void ValidarTelefono(object sender, EventArgs e)
    {
      Regex Tel = new Regex(@"^([0-9])*$");
      if (txtTel.Text == "" || txtTel.Text == " " || !Tel.IsMatch(txtTel.Text))
      {
        valTel = false;
        errTel.SetError(txtTel, "Teléfono Inválida");
      }
      else
      {
        valTel = true;
        errTel.SetError(txtTel, "");
      }
    }

    private void LimpiarDatos(object sender, EventArgs e)
    {
      txtDireccion.Text = "";
      txtDoc.Text = "";
      txtNombres.Text = "";
      txtTel.Text = "";
    }

    private void doubleClickTables(string table)
    {
      btnGuardar.Visible = false;
      btnLimpiar.Visible = false;
      btnCancel.Visible = true;
      btnDel.Visible = true;
      btnMod.Visible = true;
      var pos = table == "paciente" ? listUsuarios.CurrentRow.Index : listMedicos.CurrentRow.Index;
      txtDoc.Text = table == "paciente" ? listUsuarios[0, pos].Value.ToString() : listMedicos[0, pos].Value.ToString();
      txtDoc.ReadOnly = true;
      cmbTDoc.SelectedValue = table == "paciente" ? listTDoc.Where(x => x.Nombre == listUsuarios[1, pos].Value.ToString()).FirstOrDefault().Id : listTDoc.Where(x => x.Nombre == listMedicos[1, pos].Value.ToString()).FirstOrDefault().Id;
      txtNombres.Text = table == "paciente" ? listUsuarios[2, pos].Value.ToString() : listMedicos[2, pos].Value.ToString();
      txtDireccion.Text = table == "paciente" ? listUsuarios[3, pos].Value.ToString() : listMedicos[3, pos].Value.ToString();
      cmbTUsu.SelectedValue = table == "paciente" ? listTUsu.Where(x => x.Nombre == "Paciente").FirstOrDefault().Id : listTUsu.Where(x => x.Nombre == "Medico").FirstOrDefault().Id;
      txtTel.Text = table == "paciente" ? listUsuarios[4, pos].Value.ToString() : listMedicos[4, pos].Value.ToString();
      tabUser.SelectedTab = tabAddUser;

    }

    private void doubleClickTableMedico(object sender, DataGridViewCellEventArgs e)
    {
      doubleClickTables("medico");
    }

    private void doubleClickTablePaciente(object sender, DataGridViewCellEventArgs e)
    {
      doubleClickTables("paciente");
    }

    private void btnMod_Click(object sender, EventArgs e)
    {
      if (ValidarCampos(sender, e))
      {
        Usuario usuario = new Usuario();
        usuario.Documento = txtDoc.Text;
        usuario.IdTipoDocumento = Int32.Parse(cmbTDoc.SelectedValue.ToString());
        usuario.Nombres = txtNombres.Text;
        usuario.Telefono = txtTel.Text;
        usuario.TipoUsuario = cmbTUsu.GetItemText(cmbTUsu.SelectedItem);
        usuario.Direccion = txtDireccion.Text;
        var success = userControl.UpdateUser(usuario);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Usuario Modificado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaPacientes();
            RefrescarListaMedicos();
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnCancel.Visible = false;
            txtDoc.ReadOnly = false;
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

    private void btnDel_Click(object sender, EventArgs e)
    {
      string message = $"¿Esta seguro que desea eliminar el usuario {txtNombres.Text}?";
      const string caption = "Advertencia!";
      var result = MessageBox.Show(message, caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);
      if(result == System.Windows.Forms.DialogResult.Yes)
      {
        var success = userControl.DeleteUser(txtDoc.Text);
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (resp == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaPacientes();
            RefrescarListaMedicos();
            LimpiarDatos(sender, e);
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnCancel.Visible = false;
            txtDoc.ReadOnly = false;
            btnMod.Visible = false;
            btnDel.Visible = false;
          }
        }
        else
        {
          var resp = MessageBox.Show(success.Mensaje, "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          userControl = new UsuarioController(new Context());
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      LimpiarDatos(sender, e);
      btnGuardar.Visible = true;
      btnLimpiar.Visible = true;
      btnCancel.Visible = false;
      txtDoc.ReadOnly = false;
      btnMod.Visible = false;
      btnDel.Visible = false;
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      if(saveFile.ShowDialog() == DialogResult.OK)
      {
        var success = userControl.DescargarPlantilla(saveFile.FileName);
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
          userControl = new UsuarioController(new Context());
        }
      }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      if(openFile.ShowDialog() == DialogResult.OK)
      {
        var success = userControl.BulkLoadUsuarios(openFile.FileName);
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "¡Carga!",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          RefrescarListaPacientes();
          RefrescarListaMedicos();
        }
        else
        {
          var resp = MessageBox.Show(success.Mensaje, "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          userControl = new UsuarioController(new Context());
        }
      }
    }
  }
}
