using ProductInventory.MyProduct;
using ProductInventory.MyProduct.Interfaces;
using ProductInventory.Warehouses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses
{
    internal class Warhouse<TWarehouseIndex> : IWarehouse<TWarehouseIndex>
    {
        

        public TWarehouseIndex WarehouseIndex { get; }

        public List<IProduct> AllProducts { get; }

        public Warhouse(TWarehouseIndex warehouseIndex)
        {
            WarehouseIndex = warehouseIndex;
            AllProducts = new List<IProduct>();
        }

        public void AddProductToTheWarehouse(IProduct product)
        {
            if (FindProduct(product.Id) == null) 
            {
                product.SetPriceTotal();
                AllProducts.Add(product);
            }
            else
            {
                FindProduct(product.Id).Quantity += product.Quantity;
                FindProduct(product.Id).SetPriceTotal();
            }
        }

        public void RemoveTheGoodsFromTheWarehouse(uint productIndex, uint quantity)
        {
            if (FindProduct(productIndex) != null)
            {
                var product = FindProduct(productIndex);
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    if(product.Quantity == 0)
                        AllProducts.Remove(product);

                }                    
                else
                    throw new Exception("You can't delete more than you actually have");
            }
            else
            {
                throw new Exception("The specified product does not exist");
            }
        }

        public void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity)
        {

            FindProduct(productIndex).Quantity = quantity;
            FindProduct(productIndex).SetPriceTotal();
        }

        public Dictionary<string, List<IProduct>> SplitProductsIntoCategories()
        {
            var ProductsCategories = new Dictionary<string, List<IProduct>>();
            foreach (var product in AllProducts)
            {
                if (ProductsCategories.ContainsKey(product.ProductType))
                {
                    ProductsCategories[product.ProductType].Add(product);
                }
                else if (!ProductsCategories.ContainsKey(product.ProductType))
                {
                    ProductsCategories.Add(product.ProductType, new List<IProduct>());
                    ProductsCategories[product.ProductType].Add(product);
                }
            }
            return ProductsCategories;
        }



        public IProduct FindProduct(uint productIndex)
        {
            return AllProducts.FirstOrDefault(x => x.Id == productIndex);
        }
    }
}
