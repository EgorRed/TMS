using ProductInventory.MyProduct.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses.Interfaces
{
    internal interface IWarehouse<TWarehouseIndex>
    {
        public TWarehouseIndex WarehouseIndex { get; }
        public List<IProduct> AllProducts { get; }

        //добавить определённое количество продукта
        public void AddProductToTheWarehouse(IProduct product);

        //удалить определённое количество продукта
        public void RemoveTheGoodsFromTheWarehouse(uint productIndex, uint quantity);

        //изменить количество продукта
        public void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity);

        //разбить продукты на котегории
        public Dictionary<string, List<IProduct>> SplitProductsIntoCategories();

        public IProduct FindProduct(uint productIndex);
    }
}
