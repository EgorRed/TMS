using ProductInventory;
using ProductInventory.MyProduct;
using ProductInventory.View;

WarhousesManager warhousesManager = new WarhousesManager();
Menu menu = new Menu(warhousesManager);
menu.Start();


