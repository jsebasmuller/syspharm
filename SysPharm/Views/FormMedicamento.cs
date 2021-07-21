using PagedList;
using SysPharm.Controllers;
using SysPharm.Models;
using SysPharm.Models.ViewModel;
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
    int pagina = 1;
    MedicamentoController medControl = new MedicamentoController(new Context());
    private BindingList<MedicamentoVencidoViewModel> listaVencidos = new BindingList<MedicamentoVencidoViewModel>();
    IPagedList<Medicamento> listaMedicamentos;
    bool valNombre = false;
    bool valVlrC = false;
    bool valVlrV = false;
    bool valMed = false;
    bool valDetMedVen = false;

    public FormMedicamento()
    {
      InitializeComponent();
      RefrescarListaMedicamentos(pagina);
    }

    private void RefrescarListaMedicamentos(int pagina=1)
    {
      int paginas = 0;
      listaMedicamentos = medControl.GetMedicamentosPag(pagina);
      var listaMedicamentosCmb = medControl.GetMedicamentos();
      cmbMedicamentos.DataSource = listaMedicamentosCmb;
      cmbMedicamentos.DisplayMember = "Nombre";
      cmbMedicamentos.ValueMember = "Id";
      AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
      foreach (var medicamento in listaMedicamentos)
      {
        collection.Add(medicamento.Nombre);
      }
      cmbMedicamentos.AutoCompleteCustomSource = collection;
      cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.CustomSource;
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaMedicamentos = medControl.BuscadorPag(txtBuscar.Text, pagina);
      }
      paginas = listaMedicamentos.PageCount;
      if (pagina > listaMedicamentos.PageCount && listaMedicamentos.PageCount != 0)
      {
        paginas = 1;
        pagina = paginas;
        RefrescarListaMedicamentos(pagina);
      }
      listMedicamentos.DataSource = listaMedicamentos.ToList();
      btnPrev.Enabled = listaMedicamentos.HasPreviousPage;
      btnNext.Enabled = listaMedicamentos.HasNextPage;
      lblPag.Text = string.Format("Página {0} de {1}", pagina, paginas == 0 ? 1 : paginas);
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
            RefrescarListaMedicamentos(pagina);
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
            RefrescarListaMedicamentos(pagina);
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
      valNombre = false;
      valVlrC = false;
      valVlrV = false;
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
            RefrescarListaMedicamentos(pagina);
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
          RefrescarListaMedicamentos(pagina);
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
      RefrescarListaMedicamentos(pagina);
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
      if (listaMedicamentos.HasPreviousPage)
      {
        RefrescarListaMedicamentos(--pagina);
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (listaMedicamentos.HasNextPage)
      {
        RefrescarListaMedicamentos(++pagina);
      }
    }

    private bool ValidarMedicamentosVencidos(object sender, EventArgs e)
    {
      if (valDetMedVen)
      {
        return true;
      }
      else
      {
        validateDetallePedido(sender, e);
        return false;
      }
    }

    private void validateDetallePedido(object sender, EventArgs e)
    {
      bool val = listDetalles.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value != null && (x.Cells[1].Value == null || x.Cells[1].Value.ToString() == "0"));
      if (val)
      {
        valDetMedVen = false;
        errMedVen.SetError(listDetalles, "Faltan datos por ingresar");
      }
      else
      {
        valDetMedVen = true;
        errMedVen.SetError(listDetalles, "");
      }
    }

    private void validateMedicamento(object sender, EventArgs e)
    {
      if (cmbMedicamentos.SelectedItem == null)
      {
        valMed = false;
        errMedi.SetError(cmbMedicamentos, "Debe seleccionar una opción");
      }
      else
      {
        valMed = true;
        errMedi.SetError(cmbMedicamentos, "");
      }
    }

    private void RefrescarListaVencidos()
    {
      listDetalles.DataSource = listaVencidos;
      listDetalles.Columns[2].Visible = false;
      listDetalles.Columns[3].Visible = false;
      listDetalles.AutoResizeColumns();
      listDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void btnAddMedi_Click(object sender, EventArgs e)
    {
      if (valMed)
      {
        var detalleMed = new MedicamentoVencidoViewModel();
        detalleMed.Medicamento = cmbMedicamentos.GetItemText(cmbMedicamentos.SelectedItem);
        var pass = listaVencidos.Any(x => x.Medicamento.Trim().ToLower() == detalleMed.Medicamento.Trim().ToLower());
        if (pass)
        {
          string message = "El medicamento seleccionado ya ha sido agregado";
          const string caption = "Advertencia";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
        }
        else
        {
          listaVencidos.Add(detalleMed);
          RefrescarListaVencidos();
        }
      }
      else
      {
        string message = "Debe seleccionar un medicamento";
        const string caption = "Error";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
      }
    }

    private void doubleClickTable(object sender, DataGridViewCellEventArgs e)
    {
      string message = $"¿Esta seguro que desea eliminar el medicamento?";
      const string caption = "Advertencia!";
      var result = MessageBox.Show(message, caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);
      if (result == System.Windows.Forms.DialogResult.Yes)
      {
        listaVencidos.RemoveAt(e.RowIndex);
      }
    }

    private void listDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (listDetalles[1, e.RowIndex].Value != null)
      {
        var medicamento = medControl.GetMedicamento(listDetalles[0, e.RowIndex].Value.ToString());
        if (medicamento.Cantidad < Int32.Parse(listDetalles[1, e.RowIndex].Value.ToString()))
        {
          listDetalles[1, e.RowIndex].Value = 0;
          string message = "Registro una cantidad mayor a la que hay en inventario";
          const string caption = "¡Advertencia!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
        }
      }
      validateDetallePedido(sender, e);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (ValidarMedicamentosVencidos(sender, e))
      {
        List<MedicamentoVencido> listMedVen = new List<MedicamentoVencido>();
        
        foreach (DataGridViewRow row in listDetalles.Rows)
        {
          if (row.Cells["Medicamento"].Value != null)
          {
            MedicamentoVencido medVen = new MedicamentoVencido();
            medVen.Cantidad = Int32.Parse(row.Cells["Cantidad"].Value.ToString());
            var medicamento = medControl.GetMedicamento(row.Cells["Medicamento"].Value.ToString());
            if (medicamento != null)
            {
              medVen.IdMedicamento = medicamento.Id;
              medVen.ValorCompra = medicamento.VlrCompra;
            }
            medVen.FechaRegistro = DateTime.Now;
            listMedVen.Add(medVen);
          }
        }
        var resp = medControl.RegisterMedicamentoVencido(listMedVen);
        if (resp.Respuesta)
        {
          var result = MessageBox.Show(resp.Mensaje, "Pedido Registrado",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            RefrescarListaMedicamentos(pagina);
            listDetalles.Rows.Clear();
          }
        }
        else
        {
          var result = MessageBox.Show(resp.Mensaje, "Error",
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
  }
}
