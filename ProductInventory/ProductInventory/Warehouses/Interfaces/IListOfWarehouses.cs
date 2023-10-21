using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses.Interfaces
{
    internal interface IListOfWarehouses<TWarehouseIndex>
    {
        public List<TWarehouseIndex> Warehouses { get; } //Список складов
        public bool AddWarehouse(TWarehouseIndex warehouseIndex); //Добавить новый склад
        public bool DeleteWarehouse(TWarehouseIndex warehouseIndex); //Удалить склад
    }
}
