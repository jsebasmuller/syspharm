using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Controllers
{
  public class PedidoController
  {
    private readonly Context _context;

    public PedidoController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel RegisterPedido(Pedido pedido)
    {
      var response = new ResponseViewModel();
      _context.Pedidos.Add(pedido);
      try
      {
        _context.SaveChanges();
        foreach (var detallePedido in pedido.DetallesPedido)
        {
          var medicamentoDb = _context.Medicamentos.Where(m => m.Id == detallePedido.IdMedicamento).FirstOrDefault();
          if (medicamentoDb.VlrVenta != detallePedido.VlrVenta)
          {
            medicamentoDb.VlrVenta = (medicamentoDb.VlrVenta + detallePedido.VlrVenta)/ 2;
          }
          medicamentoDb.Cantidad += detallePedido.Cantidad;
          _context.SaveChanges();
        }
        response.Respuesta = true;
        response.Mensaje = "¡Pedido registrado satisfactoriamente!";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
    }

    public List<Pedido> GetPedidos()
    {
      return _context.Pedidos.OrderByDescending(x => x.Id).ToList();
    }

    public string GetNextId(DateTime fechaAct)
    {
      DateTime fechaInicio = new DateTime(fechaAct.Year, fechaAct.Month, 1);
      DateTime fechaFinal = fechaInicio.AddMonths(1);
      var lastAnt = _context.Pedidos.Where(a => a.FechaIngreso >= fechaInicio && a.FechaIngreso < fechaFinal)
                          .OrderByDescending(a => a.Id).Select(a => a.Id).Take(1).FirstOrDefault();
      if (lastAnt == null)
      {
        return $"{fechaAct.ToString("yyyyMM")}01";
      }
      else
      {
        return $"{Convert.ToInt32(lastAnt) + 1}";
      }
    }
  }
}
