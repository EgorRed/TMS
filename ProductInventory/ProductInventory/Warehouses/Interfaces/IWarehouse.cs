using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses.Interfaces
{
    internal interface IWarehouse<TProduct, TWarehouseIndex>
    {
        public TWarehouseIndex _WarehouseIndex { get; }
        public List<TProduct> _AllProducts { get; }
        public Dictionary<string, List<TProduct>> _ProductCategories { get; }

        //добавить определённое количество продукта
        public void AddProductToTheWarehouse(uint productIndex, uint quantity);

        //удалить определённое количество продукта
        public void RemoveTheGoodsFromTheWarehouse(uint productIndex, uint quantity);

        //изменить количество продукта
        protected void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity);

        //разбить продукты на котегории
        protected void SplitProductsIntoCategories();
    }
}
