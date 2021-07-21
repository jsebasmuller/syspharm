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
  public partial class FormArqueo : Form
  {
    //private BindingList<ArqueoViewModel> listaArqueo = new BindingList<ArqueoViewModel>();
    MedicamentoController medControl = new MedicamentoController(new Context());
    IPagedList<ArqueoViewModel> listaArqueo;
    List<ArqueoViewModel> listaTemp = new List<ArqueoViewModel>();
    int pagina = 1;

    public FormArqueo()
    {
      InitializeComponent();
      RefrescarMedicamentos(pagina);
    }

    private void RefrescarMedicamentos(int pagina = 1)
    {
      var medicamentos = medControl.GetMedicamentos();
      int paginas = 0;
      listaArqueo = medicamentos.Select(x => new ArqueoViewModel()
      {
        Medicamento = x.Nombre,
        CantidadInventario = x.Cantidad,
        CantidadFisico = listaTemp.Count == 0 ? 0 : listaTemp.Where(l => l.Medicamento == x.Nombre).Select(l => (int?) l.CantidadFisico).FirstOrDefault() ?? 0,
        Diferencia = listaTemp.Count == 0 ? 0 : listaTemp.Where(l => l.Medicamento == x.Nombre).Select(l => (int?) l.CantidadFisico).FirstOrDefault() - x.Cantidad ?? 0
      }).ToPagedList(pagina, 13);
      if (!txtBuscar.Text.Trim().Equals(""))
      {
        listaArqueo = listaArqueo.Where(x => x.Medicamento.Trim().ToLower().Contains(txtBuscar.Text.Trim().ToLower())).ToPagedList(pagina, 13);
      }
      paginas = listaArqueo.PageCount;
      if (pagina > listaArqueo.PageCount && listaArqueo.PageCount != 0)
      {
        paginas = 1;
        pagina = paginas;
        RefrescarMedicamentos(pagina);
      }
      listArqueo.DataSource = listaArqueo.ToList();
      btnPrev.Enabled = listaArqueo.HasPreviousPage;
      btnNext.Enabled = listaArqueo.HasNextPage;
      lblPag.Text = string.Format("Página {0} de {1}", pagina, paginas == 0 ? 1 : paginas);
      listArqueo.AutoResizeColumns();
      listArqueo.Columns[1].HeaderText = "Cantidad Inventario";
      listArqueo.Columns[2].HeaderText = "Cantidad Físico";
      listArqueo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      RefrescarMedicamentos(pagina);
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
      if (listaArqueo.HasPreviousPage)
      {
        RefrescarMedicamentos(--pagina);
      }
    }

    private void btnNext_Click_1(object sender, EventArgs e)
    {
      if (listaArqueo.HasNextPage)
      {
        RefrescarMedicamentos(++pagina);
      }
    }

    private void listDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (listArqueo[2, e.RowIndex].Value != null)
      {
        listArqueo[3, e.RowIndex].Value = (Int32.Parse(listArqueo[2, e.RowIndex].Value.ToString()) - Int32.Parse(listArqueo[1, e.RowIndex].Value.ToString()));
        if(!listaTemp.Any(x => x.Medicamento == listArqueo[0, e.RowIndex].Value.ToString()))
        {
          listaTemp.Add(new ArqueoViewModel()
          {
            Medicamento = listArqueo[0, e.RowIndex].Value.ToString(),
            CantidadInventario = Int32.Parse(listArqueo[1, e.RowIndex].Value.ToString()),
            CantidadFisico = Int32.Parse(listArqueo[2, e.RowIndex].Value.ToString()),
            Diferencia = Int32.Parse(listArqueo[2, e.RowIndex].Value.ToString()) - Int32.Parse(listArqueo[1, e.RowIndex].Value.ToString())
          });
        }
        else
        {
          var temp = listaTemp.Where(x => x.Medicamento == listArqueo[0, e.RowIndex].Value.ToString()).FirstOrDefault();
          temp.CantidadFisico = Int32.Parse(listArqueo[2, e.RowIndex].Value.ToString());
          temp.Diferencia = temp.CantidadFisico - temp.CantidadInventario;
        }
      }
    }

    private void Limpiar()
    {
      listaTemp = new List<ArqueoViewModel>();
      RefrescarMedicamentos(pagina);
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
      if(listaTemp.Count != 0)
      {
        var resp = medControl.Arqueo(listaTemp);
        if (resp.Respuesta)
        {
          var result = MessageBox.Show(resp.Mensaje, "Arqueo Registrado",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.None);
          if (result == System.Windows.Forms.DialogResult.OK)
          {
            Limpiar();
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
        const string message = "No ha registrado datos aún";
        const string caption = "Advertencia!";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
      }
    }
  }
}
