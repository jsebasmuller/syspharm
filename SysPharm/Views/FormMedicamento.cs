using SysPharm.Controllers;
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
  public partial class FormMedicamento : Form
  {
    MedicamentoController medControl = new MedicamentoController(new Context());
    List<Medicamento> listaMedicamentos = new List<Medicamento>();
    bool valNombre = false;
    bool valVlrC = false;
    bool valVlrV = false;

    public FormMedicamento()
    {
      InitializeComponent();
      RefrescarListaMedicamentos();
    }

    private void RefrescarListaMedicamentos()
    {
      listaMedicamentos = medControl.GetMedicamentos();
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaMedicamentos = listaMedicamentos.Where(x => x.Cantidad.ToString().Contains(txtBuscar.Text.Trim()) ||
                                            x.Nombre.Trim().ToLower().Contains(txtBuscar.Text.Trim().ToLower()) ||
                                            x.VlrCompra.ToString().Trim().Contains(txtBuscar.Text.Trim()) ||
                                            x.VlrVenta.ToString().Trim().ToLower().Contains(txtBuscar.Text.Trim().ToLower())).ToList();
      }
      listMedicamentos.DataSource = listaMedicamentos;
      listMedicamentos.Columns[3].HeaderText = "Valor de Compra";
      listMedicamentos.Columns[4].HeaderText = "Valor de Venta";
      listMedicamentos.AutoResizeColumns();
      listMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private bool ValidarCampos(object sender, EventArgs e)
    {
      if (valNombre && valVlrC && valVlrV)
      {
        return true;
      }
      else
      {
        ValidarNombre(sender, e);
        ValidarVlrC(sender, e);
        ValidarVlrV(sender, e);
        return false;
      }
    }

    private void ValidarNombre(object sender, EventArgs e)
    {
      if (txtNom.Text == "" || txtNom.Text == " ")
      {
        valNombre = false;
        errNom.SetError(txtNom, "Campo Obligatorio");
      }
      else
      {
        valNombre = true;
        errNom.SetError(txtNom, "");
      }
    }

    private void ValidarVlrC(object sender, EventArgs e)
    {
      Regex val = new Regex(@"^([0-9])*$");
      if (txtVlrC.Text == "" || txtVlrC.Text == " " || !val.IsMatch(txtVlrC.Text))
      {
        valVlrC = false;
        errVlrC.SetError(txtVlrC, "El valor debe ser un número");
      }
      else
      {
        valVlrC = true;
        errVlrC.SetError(txtVlrC, "");
      }
    }

    private void ValidarVlrV(object sender, EventArgs e)
    {
      Regex val = new Regex(@"^([0-9])*$");
      if (txtVlrV.Text == "" || txtVlrV.Text == " " || !val.IsMatch(txtVlrV.Text))
      {
        valVlrV = false;
        errVlrV.SetError(txtVlrV, "El valor debe ser un número");
      }
      else
      {
        valVlrV = true;
        errVlrV.SetError(txtVlrV, "");
      }
    }

    private void btnMod_Click(object sender, EventArgs e)
    {
      if (ValidarCampos(sender, e))
      {
        Medicamento medicamento = new Medicamento();
        var pos = listMedicamentos.CurrentRow.Index;
        medicamento.Id = Int32.Parse(listMedicamentos[0, pos].Value.ToString());
        medicamento.Nombre = txtNom.Text;
        medicamento.VlrCompra = Double.Parse(txtVlrC.Text);
        medicamento.VlrVenta = Double.Parse(txtVlrV.Text);
        medicamento.Cantidad = Int32.Parse(listMedicamentos[2, pos].Value.ToString());
        var success = medControl.UpdateMedicamento(medicamento);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Medicamento Modificado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaMedicamentos();
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
          medControl = new MedicamentoController(new Context());
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
      if (ValidarCampos(sender, e))
      {
        Medicamento medicamento = new Medicamento();
        medicamento.Id = 1;
        medicamento.Nombre = txtNom.Text;
        medicamento.VlrCompra = Double.Parse(txtVlrC.Text);
        medicamento.VlrVenta = Double.Parse(txtVlrV.Text);
        medicamento.Cantidad = 0;
        var success = medControl.RegisterMedicamento(medicamento);
        if (success.Respuesta)
        {
          string message = success.Mensaje;
          const string caption = "¡Medicamento Creado!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaMedicamentos();
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
          medControl = new MedicamentoController(new Context());
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

    private void doubleClickTables(object sender, DataGridViewCellEventArgs e)
    {
      btnGuardar.Visible = false;
      btnLimpiar.Visible = false;
      btnCancel.Visible = true;
      btnDel.Visible = true;
      btnMod.Visible = true;
      var pos = listMedicamentos.CurrentRow.Index;
      txtNom.Text = listMedicamentos[1, pos].Value.ToString();
      txtVlrC.Text = listMedicamentos[3, pos].Value.ToString();
      txtVlrV.Text = listMedicamentos[4, pos].Value.ToString();
      tabMedicamentos.SelectedTab = tabAddMed;
    }

    private void LimpiarDatos(object sender, EventArgs e)
    {
      txtNom.Text = "";
      txtVlrC.Text = "";
      txtVlrV.Text = "";
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      string message = $"¿Esta seguro que desea eliminar el medicamento {txtNom.Text}?";
      const string caption = "Advertencia!";
      var result = MessageBox.Show(message, caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);
      if (result == System.Windows.Forms.DialogResult.Yes)
      {
        var pos = listMedicamentos.CurrentRow.Index;
        var id = Int32.Parse(listMedicamentos[0, pos].Value.ToString());
        var success = medControl.DeleteMedicamento(id);
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          if (resp == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaMedicamentos();
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
          medControl = new MedicamentoController(new Context());
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

    private void btnDown_Click(object sender, EventArgs e)
    {
      if (saveFile.ShowDialog() == DialogResult.OK)
      {
        var success = medControl.DescargarPlantilla(saveFile.FileName);
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
          medControl = new MedicamentoController(new Context());
        }
      }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      if (openFile.ShowDialog() == DialogResult.OK)
      {
        var success = medControl.BulkLoadUsuarios(openFile.FileName);
        if (success.Respuesta)
        {
          var resp = MessageBox.Show(success.Mensaje, "¡Carga!",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.None);
          RefrescarListaMedicamentos();
        }
        else
        {
          var resp = MessageBox.Show(success.Mensaje, "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
          medControl = new MedicamentoController(new Context());
        }
      }
    }

    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      RefrescarListaMedicamentos();
    }
  }
}
