using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TMS_API_Test1.Models;
using TMS_API_Test1.Service;

namespace TMS_API_Test1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarhouseController : ControllerBase
    {
        private readonly IWarhousesManagerService _warhouses; 

        public WarhouseController(IWarhousesManagerService warhouses)
        {
            _warhouses = warhouses;
        }

        [HttpPost]
        public IActionResult AddWarhouse([FromBody] WarhouseIndexModel index)
        {
            try
            {
                _warhouses.CreateNewWarehouse(index);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }       

            return Ok();
        }

        [HttpGet]
        public List<WarhouseIndexModel> GetAllWarhouse()
        {
            var WarhouseIndex = new List<WarhouseIndexModel>();
            foreach (var item in _warhouses.Warehouses)
            {
                WarhouseIndex.Add(item.Key);
            }
            return WarhouseIndex;
        }

        [HttpGet]
        public IEnumerable<ProductModels> GetProduct(WarhouseIndexModel index)
        {
            return (IEnumerable<ProductModels>)_warhouses.GetListAllProducts(index);
        }

        [HttpPost]
        public IActionResult AddProduct(WarhouseIndexModel index, ProductDto product)
        {
            try
            {
                _warhouses.AddProduct(index, new ProductModels()
                {
                    Name = product.Name,
                    ProductType = product.ProductType,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    PriceTotal = (product.Quantity * product.Price)

                }); ;
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok();
        }

        //[HttpPost]
        //public IEnumerable<ProductModels> GetProductItems(WarhouseIndex index)
        //{
        //    return (IEnumerable<ProductModels>)_warhouses.GetListAllProducts(index);
        //}
    }
}
