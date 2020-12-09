using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RetoWallmart.BusinessObjects;
using RetoWallmart.Context;
using RetoWallmart.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetoWallmart.DataAccess.DataService
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly MongoDBContext db = new MongoDBContext();

        public ProductsRepository(MongoDBContext dbContext)
        {
            db = dbContext;
        }

        public async Task<Response<Producto_Entity>> GetProductos(FiltrosProducto param)
        {
            Response<Producto_Entity> result = new Response<Producto_Entity>();
            
            result.Contenido = new List<Producto_Entity>();

            try
            {

                if (!string.IsNullOrEmpty(param.Description))
                {
                    long numberParam;

                    if (Int64.TryParse(param.Description.Trim(), out numberParam))
                        result.Contenido = await db.Productos.Find(filter:
                            g => g.id == numberParam
                                || g.description.Contains(param.Description)
                                || g.brand.Contains(param.Description)
                        ).ToListAsync();
                    else
                        result.Contenido = await db.Productos.Find(filter:
                            g => g.description.Contains(param.Description)
                                 || g.brand.Contains(param.Description)
                        ).ToListAsync();
                }
                else
                    result.Contenido = await db.Productos.Find(_ => true).ToListAsync();

            }
            catch(Exception err)
            {
                result.CodigoError = "E01";
                if (err.InnerException != null)
                    result.MensajeSistema = err.InnerException.Message;
                else
                    result.MensajeSistema = err.Message;
                result.MensajeHumano = "Hubo un inconveniente al recuperar los registros.";
                result.Contenido = null;
            }

            return result;

        }
    }
}
