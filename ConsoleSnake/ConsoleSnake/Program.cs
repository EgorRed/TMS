using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowSnake window = new(40, 20);
            Start start = new(window);
            Console.WriteLine("Нажмите любую кнопку для начала");
            start.Play();

        }
    }
}
