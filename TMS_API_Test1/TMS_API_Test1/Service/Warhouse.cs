﻿using TMS_API_Test1.Models;
using TMS_API_Test1.MyException;
using TMS_API_Test1.Models.Interfaces;
using TMS_API_Test1.Models.Product;

namespace TMS_API_Test1.Service
{
    public class Warhouse : IWarehouse
    {


        public WarhouseIndexModel WarehouseIndex { get; }

        public List<IProductModels> AllProducts { get; }

        public Warhouse(WarhouseIndexModel warehouseIndex)
        {
            WarehouseIndex = warehouseIndex;
            AllProducts = new List<IProductModels>();
        }

        public void AddProductToTheWarehouse(IProductModels product)
        {
            if (FindProduct(product.ProductIndex) == null)
            {
                product.SetPriceTotal();
                AllProducts.Add(product);
            }
            else
            {
                FindProduct(product.ProductIndex).Quantity += product.Quantity;
                FindProduct(product.ProductIndex).SetPriceTotal();
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
                    if (product.Quantity == 0)
                        AllProducts.Remove(product);

                }
                else
                    throw new Exception("You can't delete more than you actually have");
            }
            else
            {
                throw new NotFoundException(productIndex.ToString());
            }
        }

        public void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity)
        {

            FindProduct(productIndex).Quantity = quantity;
            FindProduct(productIndex).SetPriceTotal();
        }

        public Dictionary<string, List<IProductModels>> SplitProductsIntoCategories()
        {
            var ProductsCategories = new Dictionary<string, List<IProductModels>>();
            foreach (var product in AllProducts)
            {
                if (ProductsCategories.ContainsKey(product.ProductType))
                {
                    ProductsCategories[product.ProductType].Add(product);
                }
                else if (!ProductsCategories.ContainsKey(product.ProductType))
                {
                    ProductsCategories.Add(product.ProductType, new List<IProductModels>());
                    ProductsCategories[product.ProductType].Add(product);
                }
            }
            return ProductsCategories;
        }



        public IProductModels FindProduct(uint productIndex)
        {
            return AllProducts.FirstOrDefault(x => x.ProductIndex == productIndex);
        }
    }
}
