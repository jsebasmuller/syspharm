using PagedList;
using SysPharm.Controllers;
using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Views
{
  public partial class FormPedido : Form
  {
    int pagina = 1;
    MedicamentoController medControl = new MedicamentoController(new Context());
    PedidoController pedControl = new PedidoController(new Context());
    IPagedList<Pedido> listaPedidos;
    private BindingList<DetallePedidoViewModel> listaDetalle = new BindingList<DetallePedidoViewModel>();
    List<Medicamento> listaMedicamentos = new List<Medicamento>();
    bool valMed = false;
    bool valPro = false;
    bool valDetP = false;

    public FormPedido()
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
      InitializeComponent();
      dtIngreso.Format = DateTimePickerFormat.Custom;
      dtIngreso.CustomFormat = "dd/MM/yyyy";
      dtSolicitud.Format = DateTimePickerFormat.Custom;
      dtSolicitud.CustomFormat = "dd/MM/yyyy";
      dtIngreso.Format = DateTimePickerFormat.Custom;
      dtIngreso.CustomFormat = "dd/MM/yyyy";
      dtSolicitud.Format = DateTimePickerFormat.Custom;
      dtSolicitud.CustomFormat = "dd/MM/yyyy";
      lblId.Text = pedControl.GetNextId(DateTime.Now);
      RefrescarListaPedidos();
      ObtenerMedicamentos();
      RefrescarListaDetalle();
    }

    public void ObtenerMedicamentos()
    {
      listaMedicamentos = medControl.GetMedicamentos();
      cmbMedicamentos.DataSource = listaMedicamentos;
      cmbMedicamentos.DisplayMember = "Nombre";
      cmbMedicamentos.ValueMember = "Id";
      AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
      foreach(var medicamento in listaMedicamentos)
      {
        collection.Add(medicamento.Nombre);
      }
      cmbMedicamentos.AutoCompleteCustomSource = collection;
      cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    private void RefrescarListaPedidos(int pagina = 1)
    {
      int paginas = 0;
      listaPedidos = pedControl.GetPedidosPag(pagina);
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaPedidos = pedControl.BuscadorPag(txtBuscar.Text, pagina);
      }
      if (pagina > listaPedidos.PageCount && listaPedidos.PageCount != 0)
      {
        paginas = 1;
        pagina = paginas;
        RefrescarListaPedidos(pagina);
      }
      listPedidos.DataSource = listaPedidos.ToList();
      btnPrev.Enabled = listaPedidos.HasPreviousPage;
      btnNext.Enabled = listaPedidos.HasNextPage;
      lblPag.Text = string.Format("Página {0} de {1}", pagina, paginas == 0 ? 1 : paginas);
      listPedidos.AutoResizeColumns();
      listPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void RefrescarListaDetalle()
    {
      listDetalles.DataSource = listaDetalle;
      listDetalles.Columns[2].HeaderText = "Registro Sanitario";
      listDetalles.Columns[5].HeaderText = "Valor de Compra";
      listDetalles.Columns[6].HeaderText = "Valor de Venta";
      listDetalles.AutoResizeColumns();
      listDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      if (ValidarCampos(sender, e))
      {
        Pedido pedido = new Pedido();
        pedido.Id = lblId.Text;
        pedido.Proveedor = txtProveedor.Text;
        pedido.FechaIngreso = dtIngreso.Value.Date;
        pedido.FechaPedido = dtSolicitud.Value.Date;
        pedido.DetallesPedido = new List<DetallePedido>();
        foreach(DataGridViewRow row in listDetalles.Rows)
        {
          if(row.Cells["Medicamento"].Value != null)
          {
            DetallePedido dPed = new DetallePedido();
            dPed.Cantidad = Int32.Parse(row.Cells["Cantidad"].Value.ToString());
            dPed.CUM = row.Cells["CUM"].Value.ToString();
            dPed.Lote = row.Cells["Lote"].Value.ToString();
            dPed.RegSanitario = row.Cells["RegSanitario"].Value.ToString();
            dPed.VlrCompra = Double.Parse(row.Cells["VlrCompra"].Value.ToString());
            dPed.VlrVenta = Double.Parse(row.Cells["VlrVenta"].Value.ToString());
            var medicamento = medControl.GetMedicamento(row.Cells["Medicamento"].Value.ToString());
            if(medicamento != null)
              dPed.IdMedicamento = medicamento.Id;
            pedido.DetallesPedido.Add(dPed);
          }
        }
        pedido.VlrTotal = pedido.DetallesPedido.Sum(x => x.Cantidad * x.VlrCompra);
        var resp = pedControl.RegisterPedido(pedido);
        if (resp.Respuesta)
        {
          var result = MessageBox.Show(resp.Mensaje, "Pedido Registrado",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            lblId.Text = pedControl.GetNextId(pedido.FechaIngreso);
            RefrescarListaPedidos(pagina);
            btnLimpiar_Click(sender, e);
          }
        }
        else
        {
          var result = MessageBox.Show(resp.Mensaje, "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
          pedControl = new PedidoController(new Context());
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

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      txtProveedor.Text = "";
      valMed = false;
      valPro = false;
      valDetP = false;
      listDetalles.Rows.Clear();
    }

    private bool ValidarCampos(object sender, EventArgs e)
    {
      if (valPro && valDetP)
      {
        return true;
      }
      else
      {
        validateProovedor(sender, e);
        validateDetallePedido(sender, e);
        return false;
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

    private void validateProovedor(object sender, EventArgs e)
    {
      if(txtProveedor.Text == "" || txtProveedor.Text == " ")
      {
        valPro = false;
        errPro.SetError(txtProveedor, "Nombre de proveedor no válido");
      }
      else
      {
        valPro = true;
        errPro.SetError(txtProveedor, "");
      }
    }

    private void validateDetallePedido(object sender, EventArgs e)
    {
      bool val = true;
      if (listDetalles.Rows.Count > 1)
      {
        val = listDetalles.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value != null && ((x.Cells[1].Value == null || string.IsNullOrWhiteSpace(x.Cells[1].Value.ToString())) || 
                                                            (x.Cells[2].Value == null || string.IsNullOrWhiteSpace(x.Cells[2].Value.ToString())) || 
                                                            (x.Cells[3].Value == null || string.IsNullOrWhiteSpace(x.Cells[3].Value.ToString())) ||
                                                            (x.Cells[4].Value == null || x.Cells[4].Value.ToString() == "0") || (x.Cells[5].Value == null || x.Cells[5].Value.ToString() == "0")));
      }
      else
      {
        if (listDetalles.Rows[0].Cells[0].Value != null)
        {
          val = listDetalles.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value != null && (x.Cells[1].Value == null || string.IsNullOrWhiteSpace(x.Cells[1].Value.ToString())) &&
                                                            (x.Cells[2].Value == null || string.IsNullOrWhiteSpace(x.Cells[2].Value.ToString())) &&
                                                            (x.Cells[3].Value == null || string.IsNullOrWhiteSpace(x.Cells[3].Value.ToString())) &&
                                                            (x.Cells[4].Value == null || x.Cells[4].Value.ToString() == "0") && (x.Cells[5].Value == null || x.Cells[5].Value.ToString() == "0"));
        }
      }
      if (val)
      {
        valDetP = false;
        errDet.SetError(listDetalles, "Faltan datos por ingresar");
      }
      else
      {
        valDetP = true;
        errDet.SetError(listDetalles, "");
      }
    }

    private void btnAddMedi_Click(object sender, EventArgs e)
    {
      if (valMed)
      {
        var detallePed = new DetallePedidoViewModel();
        detallePed.Medicamento = cmbMedicamentos.GetItemText(cmbMedicamentos.SelectedItem);
        detallePed.Cantidad = 0;
        detallePed.CUM = "";
        detallePed.Lote = "";
        detallePed.RegSanitario = "";
        detallePed.VlrCompra = 0;
        detallePed.VlrVenta = 0;
        var pass = listaDetalle.Any(x => x.Medicamento.Trim().ToLower() == detallePed.Medicamento.Trim().ToLower());
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
          listaDetalle.Add(detallePed);
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

    private void dtIngreso_ValueChanged(object sender, EventArgs e)
    {
      lblId.Text = pedControl.GetNextId(dtIngreso.Value.Date);
    }

    private void listDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if(listDetalles[5, e.RowIndex].Value != null)
      {
        listDetalles[6, e.RowIndex].Value = (Double.Parse(listDetalles[5, e.RowIndex].Value.ToString()) * 0.5) + Double.Parse(listDetalles[5, e.RowIndex].Value.ToString());
      }
      validateDetallePedido(sender, e);
    }

    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      RefrescarListaPedidos(pagina);
    }

    private void btnNext_Click(object sender, EventArgs e)
    {

    }

    private void doubleClickTables(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
      if (listaPedidos.HasPreviousPage)
      {
        RefrescarListaPedidos(--pagina);
      }
    }

    private void btnNext_Click_1(object sender, EventArgs e)
    {
      if (listaPedidos.HasNextPage)
      {
        RefrescarListaPedidos(++pagina);
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
