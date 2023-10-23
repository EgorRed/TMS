using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class RemoveProduct : IExecutor
    {
        public readonly WarhousesManager _manager;
        public string Description { get; }
        private readonly uint _warhouseIndex;

        public RemoveProduct(WarhousesManager manager, uint warhouseIndex)
        {
            _manager = manager;
            _warhouseIndex = warhouseIndex;
            Description = "Удалить товар со склада";
        }

        public void Execute() 
        {
            var warhouse = _manager.FindWarehouse(_warhouseIndex);
            while (true)
            {
                Console.Write("Введите ID товара который хотите удалить => ");
                if (uint.TryParse(Console.ReadLine(), out var id) && warhouse.FindProduct(id) != null)
                {
                    Console.Write("Введите колличество которое хотите удалить => ");
                    if (uint.TryParse(Console.ReadLine(), out var count))
                    {
                        try
                        {
                            warhouse.RemoveTheGoodsFromTheWarehouse(warhouse.FindProduct(id).Id, count);
                            return;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Нельзя удалить товара больше чем его есть на самом деле");
                        }
                        Console.WriteLine("Некоректный ввод данных");
                    }
                    Console.WriteLine("Некоректный ввод данных");
                }
            }
            
        }
    }
}
