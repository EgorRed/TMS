using ProductInventory.View.Command;
using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View
{
    internal class Menu
    {
        public readonly WarhousesManager _warhousesManager;

        public Menu(WarhousesManager warhousesManager)
        {
            _warhousesManager = warhousesManager;
        }



        public void Start() 
        {
            List<IExecutor> executorList = new()
            {
                new ShowAllWarehouses(_warhousesManager),
                new CreateNewWarehouse(_warhousesManager),
                new DeleteWarehouse(_warhousesManager),
                new ChangeStock()
            };

            do
            {


                for (int i = 0; i < executorList.Count; i++)
                {
                    Console.Write(i + 1 + ") ");
                    Console.WriteLine(executorList[i].Description);
                }
                Console.Write("=> ");
                if (int.TryParse(Console.ReadLine(), out int chois))
                {             
                    switch (chois)
                    {
                        case 1:
                            executorList[0].Execute();
                            break;
                        case 2:
                            executorList[1].Execute();
                            break;
                        case 3:
                            executorList[2].Execute();
                            break;
                        case 4:
                            do
                            {
                                Console.Write("Номар склада => ");
                                if (int.TryParse(Console.ReadLine(), out var warehouseIndex))
                                {
                                    if (_warhousesManager.FindWarehouse((uint)warehouseIndex) != null)
                                    {
                                        ChangeInStock((uint)warehouseIndex);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Такого склада не существует");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Недопустимое знчение");
                                }
                            } while (true);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Такого варианта нету");
                            break;
                    }
                    

                }
                else
                {
                    Console.WriteLine("Недопустимое значение");
                }
                
            } while (true);
        }

        public void ChangeInStock(uint warhousesIndex)
        {
            List<IExecutor> executorList = new()
            {
                new ShowAllProducts(_warhousesManager, warhousesIndex),
                new AddProduct(_warhousesManager, warhousesIndex),
                new RemoveProduct(_warhousesManager, warhousesIndex)
            };


            do
            {
                for (int i = 0; i < executorList.Count; i++)
                {
                    Console.Write(i + 1 + ") ");
                    Console.WriteLine(executorList[i].Description);
                }

                Console.Write("=> ");
                if (int.TryParse(Console.ReadLine(), out int chois))
                {
                    switch (chois) 
                    {
                        case 1:
                            executorList[0].Execute();
                            break;
                        case 2:
                            executorList[1].Execute();
                            break;
                        case 3:
                            executorList[0].Execute();
                            executorList[2].Execute();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Такого варианта нету");
                            break;
                    }
                }

            } while (true);
        }
    }
}
