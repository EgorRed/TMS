using ProductInventory.MyProduct;
using ProductInventory.Warehouses;

ListOfWarehouses<uint> listOfWarehouses = new ListOfWarehouses<uint>();
listOfWarehouses.AddWarehouse(2515);
listOfWarehouses.AddWarehouse(2514);
listOfWarehouses.AddWarehouse(992);
listOfWarehouses.AddWarehouse(2512);
listOfWarehouses.AddWarehouse(2518);

foreach (var item in listOfWarehouses.Warehouses)
{
    Console.WriteLine(item);
}
