using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Helpers
{
  public static class IRangeValidatorExtension
  {
    public static bool IsNotNullOrEmpty(this IRange value, string field, ref string error)
    {
      string err = "";
      if (string.IsNullOrEmpty(value.Value))
      {
        err = $"El campo {field} es vacio";
        error += (string.IsNullOrEmpty(error) ? "" : ", ") + err;
      }
      return string.IsNullOrEmpty(err) ? true : false;
    }

    public static bool IsNumber(this IRange value, string field, ref string error)
    {
      string err = "";
      if (string.IsNullOrEmpty(value.Value))
      {
        err = $"El campo {field} es vacio";
        error += (string.IsNullOrEmpty(error) ? "" : ", ") + err;
      }
      else if (Double.IsNaN(value.Number))
      {
        err = $"El campo {field} es numerico";
        error += (string.IsNullOrEmpty(error) ? "" : ", ") + err;
      }
      return string.IsNullOrEmpty(err) ? true : false;
    }

    public static bool IsDate(this IRange value, string field, ref string error)
    {
      string err = "";
      if (string.IsNullOrEmpty(value.Value))
      {
        err = $"El campo {field} es vacio";
        error += (string.IsNullOrEmpty(error) ? "" : ", ") + err;
      }
      else
      {
        err = $"El campo {field} no es una fecha valida";
        if (value.DateTime == DateTime.MinValue)
        {
          error += (string.IsNullOrEmpty(error) ? "" : ", ") + err;
        }
      }
      return string.IsNullOrEmpty(err) ? true : false;
    }
  }
}
