using RetoWallmart.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetoWallmart.DataAccess.Infrastructure
{
    public interface IProductsRepository
    {
        Task<Response<Producto_Entity>> GetProductos(FiltrosProducto param);
    }
}
