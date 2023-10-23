using ProductInventory.MyProduct;
using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class AddProduct : IExecutor
    {
        public readonly WarhousesManager _manager;
        public string Description { get; }
        private readonly uint _warhouseIndex;

        public AddProduct(WarhousesManager manager, uint warhouseIndex)
        {
            _manager = manager;
            _warhouseIndex = warhouseIndex;
            Description = "Добавить товар на склад";
        }

        public void Execute()
        {
            Console.Clear();
            var warhouse = _manager.FindWarehouse(_warhouseIndex);
            var product = new Product();
           
            while (true) 
            {
                Console.Write("Введите уникальный ID =>");
                if(uint.TryParse(Console.ReadLine(), out var id))
                {
                    product.Id = id;
                    break;
                }             
                else
                    Console.WriteLine("Неверное значение, по пробуй ещё раз");
            }

            Console.Write("Введите название продукта =>");
            product.Name = Console.ReadLine();

            Console.Write("Введите тип продукта =>");
            product.ProductType = Console.ReadLine();

            while (true)
            {
                Console.Write("Введите введите количество =>");
                if (uint.TryParse(Console.ReadLine(), out var quantity))
                {
                    product.Quantity = quantity;
                    break;
                }
                else
                    Console.WriteLine("Неверное значение, по пробуй ещё раз");
            }

            while (true)
            {
                Console.Write("Введите начальную цену продукта =>");
                if (decimal.TryParse(Console.ReadLine(), out var price))
                {
                    product.Price = price;
                    break;
                }
                else
                    Console.WriteLine("Неверное значение, по пробуй ещё раз");
            }

            product.SetPriceTotal();
            warhouse.AddProductToTheWarehouse(product);

        }
    }
}
