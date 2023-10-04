using System;
using System.Threading;
//using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Start
    {
        public Start()
        {
            window = new WindowSnake();
        }

        public Start(in WindowSnake window)
        {
            this.window = window;
        }

        public void Play()
        {

            ConsoleKeyInfo key = Console.ReadKey(true);

            Snake snake = new(window);

            Thread RKey = new(() =>
            {
                while (key.Key != ConsoleKey.Escape)
                {
                    key = Console.ReadKey(true);
                };
            });
            RKey.Start();

            window.UpdateWindowWithSnake(snake.GetPositions(), snake.GetPoints());
            while (true)
            {
                Thread.Sleep(100);
                DisplayFrames();


                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (!snake.S_up())
                        {
                            Console.WriteLine("press \"Esc\" to exit");
                            RKey.Join();
                            return;
                        }
                        break;
                    case ConsoleKey.A:
                        if (!snake.S_left())
                        {
                            Console.WriteLine("press \"Esc\" to exit");
                            RKey.Join();
                            return;
                        }
                        break;
                    case ConsoleKey.S:
                        if (!snake.S_down())
                        {
                            Console.WriteLine("press \"Esc\" to exit");
                            RKey.Join();
                            return;
                        }
                        break;
                    case ConsoleKey.D:
                        if (!snake.S_right())
                        {
                            Console.WriteLine("press \"Esc\" to exit");
                            RKey.Join();
                            return;
                        }
                        break;
                    case ConsoleKey.Escape:
                        RKey.Join();
                        return;

                    default:
                        break;
                }
            }

        }


        private void DisplayFrames()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < window.arr.GetLength(0); i++)
            {
                for (int j = 0; j < window.arr.GetLength(1); j++)
                {
                    Console.Write(window.arr[i, j]);
                }
                Console.WriteLine();
            }
        }


        private WindowSnake window;
    }
}
