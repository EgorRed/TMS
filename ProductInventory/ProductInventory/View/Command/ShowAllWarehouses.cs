using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class ShowAllWarehouses : IExecutor
    {
        public readonly WarhousesManager _manager;

        public ShowAllWarehouses(WarhousesManager manager)
        {
            Description = "Показать список всех складов.";
            _manager = manager;
        }

        public string Description { get; }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("+----------------+");
            Console.WriteLine("| Номера складов |");
            Console.WriteLine("+----------------+");

            for (int i = 0; i < _manager.Warehouses.Count; i++)
            {
                Console.Write($"| {_manager.Warehouses[i].WarehouseIndex}");
                Console.SetCursorPosition(17, i+3);
                Console.Write("|\n");
            }
            Console.WriteLine("+----------------+");
        }
    }
}
