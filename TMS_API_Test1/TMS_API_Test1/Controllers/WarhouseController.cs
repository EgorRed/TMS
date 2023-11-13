using Microsoft.AspNetCore.Mvc;
using TMS_API_Test1.Models;
using TMS_API_Test1.Models.Product;
using TMS_API_Test1.MyException;
using TMS_API_Test1.Service.Interfaces;

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
            _warhouses.CreateNewWarehouse(index);
            //try
            //{
            //    _warhouses.CreateNewWarehouse(index);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            return Ok();
        }
 
        [HttpPost]
        public IActionResult DeleteWarhouse([FromBody] WarhouseIndexModel index)
        {
            try
            {
                _warhouses.DeleteWarehouse(index);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        public List<WarhouseIndexModel> GetAllWarhouse()
        {
            var WarhouseIndex = new List<WarhouseIndexModel>();
            foreach (var item in _warhouses.Warehouses)
            {
                WarhouseIndex.Add(item.Key);
            }
            return WarhouseIndex;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto product)
        {
            try
            {
                _warhouses.AddProduct(product.WarhouseIndex, new ProductModels()
                {
                    ProductIndex = 0,
                    Name = product.Name,
                    ProductType = product.ProductType,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    PriceTotal = (product.Quantity * product.Price)

                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        public ProductListModel GetProduct(WarhouseIndexModel index)
        {
            ProductListModel productListModel = new ProductListModel()
            {
                productList = _warhouses.GetListAllProducts(index)
            };
            return productListModel;
        }

        [HttpPost]
        public IActionResult RemoveProduct(SpecificProductModel product)
        {
            try
            {
                _warhouses.RemoveProduct(product.warhouseIndex, product.ProductId, product.Quantity);
            }
            catch (NotFoundException ex)
            {
                return  BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}
