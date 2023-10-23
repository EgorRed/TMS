using ProductInventory.MyProduct.Interfaces;
using ProductInventory.Warehouses;
using ProductInventory.Warehouses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    internal class WarhousesManager
    {
        public List<IWarehouse<uint>> Warehouses { get; }


        public WarhousesManager()
        {
            Warehouses = new List<IWarehouse<uint>>();
        }
        public WarhousesManager(List<IWarehouse<uint>> warehouses) : this()
        {
            
        }


        public void CreateNewWarehouse(uint warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) == null)
            {

                Warehouses.Add(new Warhouse<uint>(warehouseIndex));
            }
            else
            {
                throw new Exception("such a warehouse already exists");
            }
        }


        public void DeleteWarehouse(uint warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                Warehouses.Remove(FindWarehouse(warehouseIndex));
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public List<IProduct> GetListAllProducts(uint warehouseIndex)
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


        public void AddProduct(uint warehouseIndex, IProduct product) 
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                FindWarehouse(warehouseIndex).AddProductToTheWarehouse(product);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public void RemoveProduct(uint warehouseIndex, uint productIndex, uint quantity)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                FindWarehouse(warehouseIndex).RemoveTheGoodsFromTheWarehouse(productIndex, quantity);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public Dictionary<string, List<IProduct>> GetProductCategories(uint warehouseIndex)
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

        public void MovingTheProduct(uint warehouseFromWhere, uint warehouseWhere, uint productIndex, uint quantity)
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

        public IWarehouse<uint> FindWarehouse(uint warehouseIndex)
        {
            return Warehouses.Find(x => x.WarehouseIndex == warehouseIndex);
        }

    }
}
