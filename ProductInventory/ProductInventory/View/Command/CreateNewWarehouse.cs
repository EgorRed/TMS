using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class CreateNewWarehouse : IExecutor
    {
        public readonly WarhousesManager _manager;

        public CreateNewWarehouse(WarhousesManager manager)
        {
            _manager = manager;
            Description = "Создать новый склад.";
        }

        public string Description { get; }

        public void Execute()
        {
            Console.Clear();
            do
            {
                Console.Write("Введите новый номер склада => ");
                if (uint.TryParse(Console.ReadLine(), out uint WarhouseID))
                {
                    try
                    {
                        _manager.CreateNewWarehouse(WarhouseID);
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Такой склад уже существует");
                    }

                }
                else
                {
                    Console.WriteLine("Недопустимое знчение");
                }
            } while (true);
        }
    }
}
