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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Views
{
  public partial class FormFormula : Form
  {
    int pagina = 1;
    MedicamentoController medControl = new MedicamentoController(new Context());
    FormulaController formulaControl = new FormulaController(new Context());
    UsuarioController userControl = new UsuarioController(new Context());
    ServicioController servControl = new ServicioController(new Context());
    IPagedList<FormulaViewModel> listaFormulas;
    private BindingList<DetalleFormulaViewModel> listaDetalle = new BindingList<DetalleFormulaViewModel>();
    List<Servicio> listaServicios = new List<Servicio>();
    List<Medicamento> listaMedicamentos = new List<Medicamento>();
    List<PacienteViewModel> listaMedicos = new List<PacienteViewModel>();
    List<PacienteViewModel> listaPacientes = new List<PacienteViewModel>();
    bool valMedicamento = false;
    bool valMedico = false;
    bool valPaci = false;
    bool valDeta = false;
    bool valSer = false;

    public FormFormula()
    {
      InitializeComponent();
      dtFormula.Format = DateTimePickerFormat.Custom;
      dtFormula.CustomFormat = "dd/MM/yyyy";
      dtDespacho.Format = DateTimePickerFormat.Custom;
      dtDespacho.CustomFormat = "dd/MM/yyyy";
      lblId.Text = formulaControl.GetNextId(DateTime.Now);
      lblTotal.Text = "$ 0";
      RefrescarListaFormulas();
      ObtenerMedicamentos();
      ObtenerMedicos();
      ObtenerPacientes();
      ObtenerServicios();
      RefrescarListaDetalle();
    }

    public void ObtenerMedicamentos()
    {
      listaMedicamentos = medControl.GetMedicamentos();
      cmbMedicamentos.DataSource = listaMedicamentos;
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
    }

    public void ObtenerMedicos()
    {
      listaMedicos = userControl.GetMedicos();
      cmbMedico.DataSource = listaMedicos;
      cmbMedico.DisplayMember = "Nombres";
      cmbMedico.ValueMember = "Documento";
      AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
      foreach (var medico in listaMedicos)
      {
        collection.Add(medico.Nombres);
      }
      cmbMedico.AutoCompleteCustomSource = collection;
      cmbMedico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      cmbMedico.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    public void ObtenerPacientes()
    {
      listaPacientes = userControl.GetPacientes();
      cmbPac.DataSource = listaPacientes;
      cmbPac.DisplayMember = "Nombres";
      cmbPac.ValueMember = "Documento";
      AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
      foreach (var paciente in listaPacientes)
      {
        collection.Add(paciente.Nombres);
      }
      cmbPac.AutoCompleteCustomSource = collection;
      cmbPac.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      cmbPac.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    public void ObtenerServicios()
    {
      listaServicios = servControl.GetServicios();
      cmbServicio.DataSource = listaServicios;
      cmbServicio.DisplayMember = "Nombre";
      cmbServicio.ValueMember = "Id";
      AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
      foreach (var servicio in listaServicios)
      {
        collection.Add(servicio.Nombre);
      }
      cmbServicio.AutoCompleteCustomSource = collection;
      cmbServicio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      cmbServicio.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    private void RefrescarListaFormulas(int pagina = 1)
    {
      int paginas = 0;
      listaFormulas = formulaControl.GetFormulasPag(pagina);
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaFormulas = formulaControl.BuscadorPag(txtBuscar.Text, pagina);
      }
      paginas = listaFormulas.PageCount;
      if (pagina > listaFormulas.PageCount && listaFormulas.PageCount != 0)
      {
        paginas = 1;
        pagina = paginas;
        RefrescarListaFormulas(pagina);
      }
      listFormulas.DataSource = listaFormulas.ToList();
      btnPrev.Enabled = listaFormulas.HasPreviousPage;
      btnNext.Enabled = listaFormulas.HasNextPage;
      lblPag.Text = string.Format("Página {0} de {1}", pagina, paginas == 0 ? 1 : paginas);
      listFormulas.Columns[1].HeaderText = "Fecha de Formula";
      listFormulas.Columns[2].HeaderText = "Fecha de Despacho";
      listFormulas.Columns[3].HeaderText = "Documento del Medico";
      listFormulas.Columns[4].HeaderText = "Nombre del Medico";
      listFormulas.Columns[5].HeaderText = "Documento del Paciente";
      listFormulas.Columns[6].HeaderText = "Nombre del Paciente";
      listFormulas.Columns[8].HeaderText = "Total de Medicamentos";
      listFormulas.Columns[9].HeaderText = "Total de Compra";
      listFormulas.Columns[10].HeaderText = "Total de Venta";
      listFormulas.AutoResizeColumns();
      listFormulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void RefrescarListaDetalle()
    {
      listDetalles.DataSource = listaDetalle;
      listDetalles.Columns[1].HeaderText = "Cantidad Formula";
      listDetalles.Columns[3].HeaderText = "Cantidad Pendiente";
      listDetalles.Columns[4].HeaderText = "Valor Unitario";
      listDetalles.Columns[5].HeaderText = "Valor Total";
      listDetalles.AutoResizeColumns();
      listDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private bool ValidarCampos(object sender, EventArgs e)
    {
      if (valMedico && valPaci && valSer && valDeta)
      {
        return true;
      }
      else
      {
        ValidarMedico(sender, e);
        ValidarPaciente(sender, e);
        validateDetallePedido(sender, e);
        ValidateServicio(sender, e);
        return false;
      }
    }

    private void validateDetallePedido(object sender, EventArgs e)
    {
      bool val = true;
      if(listDetalles.Rows.Count > 1)
      {
        val = listDetalles.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value != null && (x.Cells[1].Value == null || x.Cells[1].Value.ToString() == "0") &&
                                                                  (x.Cells[2].Value == null || x.Cells[2].Value.ToString() == "0"));
      }
      else
      {
        if(listDetalles.Rows[0].Cells[0].Value != null)
        {
          val = listDetalles.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value != null && (x.Cells[1].Value == null || x.Cells[1].Value.ToString() == "0") &&
                                                                  (x.Cells[2].Value == null || x.Cells[2].Value.ToString() == "0"));
        }
      }
      if (val)
      {
        valDeta = false;
        errDetalle.SetError(listDetalles, "Faltan datos por ingresar");
      }
      else
      {
        valDeta = true;
        errDetalle.SetError(listDetalles, "");
      }
    }

    private void ValidarMedico(object sender, EventArgs e)
    {
      if (cmbMedico.SelectedValue == null)
      {
        valMedico = false;
        errMedico.SetError(cmbMedico, "Debe seleccionar un medico");
      }
      else
      {
        valMedico = true;
        errMedico.SetError(cmbMedico, "");
      }
    }

    private void ValidarPaciente(object sender, EventArgs e)
    {
      if (cmbPac.SelectedValue == null)
      {
        valPaci = false;
        errPaciente.SetError(cmbPac, "Debe seleccionar un paciente");
      }
      else
      {
        valPaci = true;
        errPaciente.SetError(cmbPac, "");
      }
    }

    private void ValidateServicio(object sender, EventArgs e)
    {
      if (cmbServicio.SelectedValue == null)
      {
        valSer = false;
        errServ.SetError(cmbServicio, "Debe seleccionar un Servicio");
      }
      else
      {
        valSer = true;
        errServ.SetError(cmbServicio, "");
      }
    }

    private void validateMedicamento(object sender, EventArgs e)
    {
      if (cmbMedicamentos.SelectedItem == null)
      {
        valMedicamento = false;
        errMedicamento.SetError(cmbMedicamentos, "Debe seleccionar una opción");
      }
      else
      {
        valMedicamento = true;
        errMedicamento.SetError(cmbMedicamentos, "");
      }
    }

    private void btnAddMedi_Click(object sender, EventArgs e)
    {
      if (valMedicamento)
      {
        var detalle = new DetalleFormulaViewModel();
        var medicamento = medControl.GetMedicamento(cmbMedicamentos.GetItemText(cmbMedicamentos.SelectedItem));
        detalle.Medicamento = cmbMedicamentos.GetItemText(cmbMedicamentos.SelectedItem);
        detalle.Cantidad = 0;
        detalle.CantidadFormula = 0;
        detalle.CantidadPendiente = 0;
        detalle.VlrT = 0;
        detalle.VlrU = medicamento.VlrVenta;
        var pass = listaDetalle.Any(x => x.Medicamento.Trim().ToLower() == detalle.Medicamento.Trim().ToLower());
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
          listaDetalle.Add(detalle);
          RefrescarListaDetalle();
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

    private void dtDespacho_ValueChanged(object sender, EventArgs e)
    {
      lblId.Text = formulaControl.GetNextId(dtDespacho.Value.Date);
    }

    private void listDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if(listDetalles[0, e.RowIndex].Value != null && listDetalles[2, e.RowIndex].Value != null)
      {
        var medicamento = medControl.GetMedicamento(listDetalles[0, e.RowIndex].Value.ToString());
        if(medicamento.Cantidad <= Int32.Parse(listDetalles[2, e.RowIndex].Value.ToString()))
        {
          listDetalles[2, e.RowIndex].Value = 0;
          string message = "No hay suficientes medicamentos en inventario";
          const string caption = "¡Advertencia!";
          var result = MessageBox.Show(message, caption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
        }
        listDetalles[4, e.RowIndex].Value = medicamento.VlrVenta;
      }
      if (listDetalles[1, e.RowIndex].Value != null && listDetalles[2, e.RowIndex].Value != null)
      {
        listDetalles[3, e.RowIndex].Value = Double.Parse(listDetalles[1, e.RowIndex].Value.ToString()) - Double.Parse(listDetalles[2, e.RowIndex].Value.ToString());
      }
      if(listDetalles[2, e.RowIndex].Value != null && listDetalles[4, e.RowIndex].Value != null)
      {
        listDetalles[5, e.RowIndex].Value = Double.Parse(listDetalles[2, e.RowIndex].Value.ToString()) * Double.Parse(listDetalles[4, e.RowIndex].Value.ToString());
      }
      var sum = 0.0;
      foreach (DataGridViewRow row in listDetalles.Rows)
      {
        if (row.Cells["Medicamento"].Value != null)
        {
          if (row.Cells["Cantidad"].Value != null && row.Cells["VlrU"].Value != null)
          {
            sum += (Double.Parse(row.Cells["Cantidad"].Value.ToString()) * Double.Parse(row.Cells["VlrU"].Value.ToString()));
          }
        }
      }
      lblTotal.Text = $"$ {sum}";
      validateDetallePedido(sender, e);
    }

    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      RefrescarListaFormulas(pagina);
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      valMedicamento = false;
      valMedico = false;
      valPaci = false;
      valDeta = false;
      valSer = false;
      listDetalles.Rows.Clear();
      lblTotal.Text = "$ 0";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      if (ValidarCampos(sender, e))
      {
        Formula formula = new Formula();
        formula.Id = lblId.Text;
        formula.IdMedico = cmbMedico.SelectedValue.ToString();
        formula.IdPaciente = cmbPac.SelectedValue.ToString();
        formula.IdServicio = Int32.Parse(cmbServicio.SelectedValue.ToString());
        formula.FechaDespacho = dtDespacho.Value.Date;
        formula.FechaFormula = dtFormula.Value.Date;
        formula.DetalleFormula = new List<DetalleFormula>();
        foreach (DataGridViewRow row in listDetalles.Rows)
        {
          if (row.Cells["Medicamento"].Value != null)
          {
            DetalleFormula dFor = new DetalleFormula();
            dFor.Cantidad = Int32.Parse(row.Cells["Cantidad"].Value.ToString());
            dFor.CantidadFormula = Int32.Parse(row.Cells["CantidadFormula"].Value.ToString());
            dFor.CantidadPendiente = Int32.Parse(row.Cells["CantidadPendiente"].Value.ToString());
            dFor.PrecioVenta = Double.Parse(row.Cells["VlrU"].Value.ToString());
            var medicamento = medControl.GetMedicamento(row.Cells["Medicamento"].Value.ToString());
            if (medicamento != null)
            {
              dFor.IdMedicamento = medicamento.Id;
              dFor.PrecioCompra = medicamento.VlrCompra;
            }
            formula.DetalleFormula.Add(dFor);
          }
        }
        formula.TotalCompra = formula.DetalleFormula.Sum(x => x.Cantidad * x.PrecioCompra);
        formula.TotalVenta = formula.DetalleFormula.Sum(x => x.Cantidad * x.PrecioVenta);
        formula.TotalMedicamentos = formula.DetalleFormula.Count;
        var resp = formulaControl.RegisterFormula(formula);
        if (resp.Respuesta)
        {
          var result = MessageBox.Show(resp.Mensaje, "Formula Registrada",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            lblId.Text = formulaControl.GetNextId(formula.FechaDespacho);
            RefrescarListaFormulas(pagina);
            btnLimpiar_Click(sender, e);
          }
        }
        else
        {
          var result = MessageBox.Show(resp.Mensaje, "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
          formulaControl = new FormulaController(new Context());
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

    private void btnPrev_Click(object sender, EventArgs e)
    {
      if (listaFormulas.HasPreviousPage)
      {
        RefrescarListaFormulas(--pagina);
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (listaFormulas.HasNextPage)
      {
        RefrescarListaFormulas(++pagina);
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
        listaDetalle.RemoveAt(e.RowIndex);
      }
    }
  }
}
