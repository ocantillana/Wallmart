using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using RetoWallmart.DataAccess.Infrastructure;
using System.Threading.Tasks;
using RetoWallmart.BusinessObjects;

namespace RetoWallmart.BusinessActions
{
    public class ProductsActions
    {
        private readonly IProductsRepository _context;

        private const double dscto = 0.50;
        private const int palindromeMinLength = 2;

        public ProductsActions(IProductsRepository context)
        {
            _context = context;
        }

        public async Task<Response<Producto_Entity>> GetProductos(FiltrosProducto param)
        {
            Response<Producto_Entity> result = new Response<Producto_Entity>();
            long numberParam;

            try
            {

                if (Int64.TryParse(param.Description.Trim(), out numberParam) || param.Description.Length == 0 || param.Description.Length > 3)
                {
                    result = await _context.GetProductos(param);

                    if (result.Contenido.Count < 1)
                    {
                        result.CodigoError = "E00";
                        result.MensajeHumano = "Consulta exitosa pero sin resulados para el valor indicado ('" + param.Description + "')";
                        result.MensajeSistema = "Empty resultset for param: '" + param.Description + "'";
                    }
                    else
                    {
                        result.CodigoError = "E00";
                        result.MensajeHumano = "Consulta exitosa!";
                        result.MensajeSistema = "Record(s) found for param: '" + param.Description + "'";
                    }
                }
                else
                {
                    result.Contenido = new List<Producto_Entity>();
                    result.CodigoError = "E01";
                    result.MensajeSistema = "param.length <= 3 chars.";
                    result.MensajeHumano = "Se necesita un valor más largo para ejecutar la búqueda.";
                }


                if (result.Contenido.Count > 0 && param.Description.Length >= palindromeMinLength && CommonUtils.CheckPalindrome(param.Description))
                {
                    foreach (Producto_Entity p in result.Contenido)
                    {
                        if (p.price > 0)
                            p.price = Math.Ceiling((p.price * dscto));
                    };
                }

                return result;

            }catch(Exception err)
            {
                result.Contenido = new List<Producto_Entity>();
                result.CodigoError = "E01";
                result.MensajeSistema = "Error en la consulta: " + err.InnerException.Message;
                result.MensajeHumano = "Error en la consulta!";
                return result;
            }

        }

    }
}
