using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class ShowAllProducts : IExecutor
    {
        public readonly WarhousesManager _manager;
        public string Description { get; }
        private readonly uint _warhouseIndex;

        public ShowAllProducts(WarhousesManager manager, uint warhouseIndex)
        {
            _manager = manager;
            _warhouseIndex = warhouseIndex;
            Description = "Показать все продукты";
        }

        public void Execute()
        {
            Console.Clear();
            var warhouse = _manager.FindWarehouse(_warhouseIndex);
            Console.WriteLine("+----------------+----------------------+----------------------+------------+--------------+-------------+");
            Console.WriteLine("| Уникальный код |       Название       |     Тип продукта     | Количество | сумма за шт. | общая сумма |");
            Console.WriteLine("+----------------+----------------------+----------------------+------------+--------------+-------------+");

            for (int i = 0; i < warhouse.AllProducts.Count; i++)
            {
                Console.Write($"| {warhouse.AllProducts[i].Id}");
                Console.SetCursorPosition(17, i + 3);
                Console.Write($"| {warhouse.AllProducts[i].Name}");
                Console.SetCursorPosition(40, i + 3);
                Console.Write($"| {warhouse.AllProducts[i].ProductType}");
                Console.SetCursorPosition(63, i + 3);
                Console.Write($"| {warhouse.AllProducts[i].Quantity}");
                Console.SetCursorPosition(76, i + 3);
                Console.Write($"| {warhouse.AllProducts[i].Price}");
                Console.SetCursorPosition(91, i + 3);
                Console.Write($"| {warhouse.AllProducts[i].PriceTotal}");
                Console.SetCursorPosition(105, i + 3);
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("+----------------+----------------------+----------------------+------------+--------------+-------------+");
        }
    }
}
