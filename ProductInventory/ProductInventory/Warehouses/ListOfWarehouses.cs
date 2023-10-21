using ProductInventory.Warehouses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses
{
    
    internal class ListOfWarehouses<TWarehouseIndex> : IListOfWarehouses<TWarehouseIndex>
    {

        public List<TWarehouseIndex> Warehouses { get; }

        public ListOfWarehouses()
        {
            Warehouses = new List<TWarehouseIndex>();
        }

        public bool AddWarehouse(TWarehouseIndex warehouseIndex)
        {
            if(!Warehouses.Contains(warehouseIndex))
            {
                Warehouses.Add(warehouseIndex);
                return true;
            }               
            else
            {
                return false;
            }
        }

        public bool DeleteWarehouse(TWarehouseIndex warehouseIndex)
        {
            if (Warehouses.Contains(warehouseIndex))
            {
                Warehouses.Remove(warehouseIndex);
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
