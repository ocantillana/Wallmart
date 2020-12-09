using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetoWallmart.BusinessActions;
using RetoWallmart.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoWallmart.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsActions _context;

        public ProductsController(ProductsActions context)
        {
            _context = context;
        }

        // GET api/values/5
        [HttpPost]
        [Route("GetItems")]
        public async Task<Response<Producto_Entity>> Get([FromBody] FiltrosProducto param)
        {
            return await _context.GetProductos(param);
        }


    }
}
