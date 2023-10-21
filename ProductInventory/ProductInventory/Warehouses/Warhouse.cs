using ProductInventory.Warehouses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses
{
    internal class Warhouse<TProduct, TWarehouseIndex> : IWarehouse<TProduct, TWarehouseIndex>
    {
        

        public TWarehouseIndex _WarehouseIndex { get; }

        public List<TProduct> _AllProducts { get; }

        public Dictionary<string, List<TProduct>> _ProductCategories { get; }

        public Warhouse(TWarehouseIndex warehouseIndex)
        {
            _WarehouseIndex = warehouseIndex;
            _AllProducts = new List<TProduct>();
            _ProductCategories = new Dictionary<string, List<TProduct>>();
        }

        public void AddProductToTheWarehouse(uint productIndex, uint quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveTheGoodsFromTheWarehouse(uint productIndex, uint quantity)
        {
            throw new NotImplementedException();
        }

        void IWarehouse<TProduct, TWarehouseIndex>.ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity)
        {
            throw new NotImplementedException();
        }

        void IWarehouse<TProduct, TWarehouseIndex>.SplitProductsIntoCategories()
        {
            throw new NotImplementedException();
        }
    }
}
