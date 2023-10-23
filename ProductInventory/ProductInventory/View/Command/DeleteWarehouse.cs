using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class DeleteWarehouse : IExecutor
    {
        public readonly WarhousesManager _manager;
        public string Description { get; }

        public DeleteWarehouse(WarhousesManager manager)
        {
            _manager = manager;
            Description = "Удалить склад";
        }

        public void Execute()
        {
            Console.Clear();
            ShowAllWarehouses show = new ShowAllWarehouses(_manager);
            show.Execute();
            do
            {
                Console.Write("Введите номер склада который хотите удалить => ");
                if (uint.TryParse(Console.ReadLine(), out uint WarhouseID))
                {
                    try
                    {
                        _manager.DeleteWarehouse(WarhouseID);
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Такого склада не существует");
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
