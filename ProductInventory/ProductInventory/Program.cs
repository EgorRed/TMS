using ProductInventory;
using ProductInventory.MyProduct;
using ProductInventory.View;
using ProductInventory.Warehouses;
using ProductInventory.WarehousesFileProvider;

WarhousesManager warhousesManager = new WarhousesManager("..\\..\\..\\Data");
try
{
    Menu menu = new Menu(warhousesManager);
    menu.Start();
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}