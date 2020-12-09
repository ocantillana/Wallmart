using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetoWallmart.API.Controllers;
using RetoWallmart.BusinessActions;
using RetoWallmart.BusinessObjects;
using RetoWallmart.Context;
using RetoWallmart.DataAccess.DataService;
using RetoWallmart.DataAccess.Infrastructure;
using System;
using System.Threading.Tasks;

namespace RetoWallmart.API.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        
        [TestMethod]
        public async Task Get_ShouldReturnResponseObjTypeProductWithAllObj()
        {
            //Arrange:
            MongoDBContext db = new MongoDBContext();
            IProductsRepository _contextDA = new ProductsRepository(db);
            ProductsActions _contextActions = new ProductsActions(_contextDA);
            ProductsController pController = new ProductsController(_contextActions);

            FiltrosProducto param = new FiltrosProducto{ Description = "" };

            //Act:
            Response<Producto_Entity> response = await pController.Get(param);

            //CollectionAssert:
            var responseErrorCode = response.CodigoError;
            var responseSystemMsg = response.MensajeSistema;
            var responseHumanMsg = response.MensajeHumano;
            var responseList = response.Contenido;

            Assert.AreEqual("E00", responseErrorCode);
            Assert.AreEqual("Record(s) found for param: 3000", responseSystemMsg);
            Assert.AreEqual("Consulta exitosa!", responseHumanMsg);
            Assert.AreEqual(3000, responseList.Count);
        }
        

    }
}
