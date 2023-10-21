using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.MyProduct.Interfaces
{
    internal interface IProduct
    {
        uint Id { get; set; }
        string Name { get; set; }
        string ProductType { get; set; }
        uint Quantity { get; set; }
        decimal Price { get; set; }
        void ParseString(string stringProduct);
        string GetString();
    }
}
