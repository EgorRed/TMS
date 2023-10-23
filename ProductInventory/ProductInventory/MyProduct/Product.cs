using ProductInventory.MyProduct.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.MyProduct
{
    internal class Product : IProduct
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? ProductType { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal { get; set; }

        public void SetPriceTotal()
        {
            PriceTotal = Price * Quantity;
        }

        public string GetString()
        {
            return $"{Id}|{Name}|{ProductType}|{Quantity}|{Price}|{PriceTotal}";
        }

        public void ParseString(string stringProduct)
        {
            var prod = stringProduct.Split('|');
            Id = uint.Parse(prod[0]);
            Name = prod[1];
            ProductType = prod[2];
            Quantity = uint.Parse(prod[3]);
            Price = decimal.Parse(prod[4]);
        }
    }
}
