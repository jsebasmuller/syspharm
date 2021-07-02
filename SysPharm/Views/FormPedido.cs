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
  public partial class FormPedido : Form
  {
    MedicamentoController medControl = new MedicamentoController(new Context());
    List<Medicamento> listaMedicamentos = new List<Medicamento>();

    public FormPedido()
    {
      InitializeComponent();
      ObtenerMedicamentos();
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

    private void btnGuardar_Click(object sender, EventArgs e)
    {

    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
  }
}
