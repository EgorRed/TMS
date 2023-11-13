using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using TMS_API_Test1.Models;
using TMS_API_Test1.Models.Interfaces;
using TMS_API_Test1.Models.Product;
using TMS_API_Test1.MyException;
using TMS_API_Test1.Service.Interfaces;

namespace TMS_API_Test1.Service
{
    public class WarhousesManagerService : IWarhousesManagerService
    {
        public Dictionary<WarhouseIndexModel, IWarehouse> Warehouses { get; }

        public WarhousesManagerService()
        {
            Warehouses = new Dictionary<WarhouseIndexModel, IWarehouse>();
        }

        public void CreateNewWarehouse(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) == null)
            {
                Warehouses.Add(warehouseIndex, new Warhouse(warehouseIndex));
            }
            else
            {
                throw new Exception("such a warehouse already exists");
            }
        }


        public void DeleteWarehouse(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                Warehouses.Remove(warehouseIndex);
            }
            else
            {
                throw new NotFoundException(warehouseIndex.Index.ToString());
            }
        }


        public List<IProductModels> GetListAllProducts(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                return FindWarehouse(warehouseIndex).AllProducts;
            }
            else
            {
                throw new Exception("Attempt to access a non-existent warehouse");
            }
        }


        public void AddProduct(WarhouseIndexModel warehouseIndex, IProductModels product)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                var warehouse = FindWarehouse(warehouseIndex);
                product.ProductIndex = (uint)product.Name.GetHashCode();
                warehouse.AddProductToTheWarehouse(product);
            }
            else
            {
                throw new NotFoundException(warehouseIndex.Index.ToString());
            }
        }


        public void RemoveProduct(WarhouseIndexModel warehouseIndex, uint productIndex, uint quantity)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                FindWarehouse(warehouseIndex).RemoveTheGoodsFromTheWarehouse(productIndex, quantity);
            }
            else
            {
                throw new NotFoundException(warehouseIndex.Index.ToString());
            }
        }

        //не реализовано
        public Dictionary<string, List<IProductModels>> GetProductCategories(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                return FindWarehouse(warehouseIndex).SplitProductsIntoCategories();
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }

        //не реализовано
        public void MovingTheProduct(WarhouseIndexModel warehouseFromWhere, WarhouseIndexModel warehouseWhere, uint productIndex, uint quantity)
        {
            var _warehouseFromWhere = FindWarehouse(warehouseFromWhere);
            var _warehouseWhere = FindWarehouse(warehouseWhere);

            if (_warehouseFromWhere != null && _warehouseWhere != null)
            {
                _warehouseFromWhere.RemoveTheGoodsFromTheWarehouse(productIndex, quantity);
                _warehouseWhere.AddProductToTheWarehouse(_warehouseFromWhere.FindProduct(productIndex));
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }

        public IWarehouse FindWarehouse(WarhouseIndexModel warehouseIndex)
        {
            return Warehouses.FirstOrDefault(x => warehouseIndex.Index == x.Key.Index).Value;
        }

    }
}
