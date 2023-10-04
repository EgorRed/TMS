using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleSnake
{
    class WindowSnake
    {
        public WindowSnake(in int width = 30, in int height = 10)
        {
            this.width = width;
            this.height = height;
            char[,] arr = new char[height, width];
            this.arr = arr;
            AppleUpdate();
            UpdateWindow();
        }

        public void UpdateWindowWithSnake(in List<Position> position, in int points)
        {
            UpdateWindow();
            arr[positionApple.Y_cord, positionApple.X_cord] = aplle;
            foreach (Position pos in position)
            {
                arr[pos.Y_cord, pos.X_cord] = '*';
            }
            arr[position.First().Y_cord, position.First().X_cord] = '@';
            Console.WriteLine($"Points: {points}");
        }

        public void AppleUpdate()
        {
            aplle = ' ';
            AppleGeneration();
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == 0 || i == arr.GetLength(0) - 1)
                        arr[i, j] = '═';

                    else if (j == 0 || j == arr.GetLength(1) - 1)
                        arr[i, j] = '║';
                    else
                        arr[i, j] = ' ';
                }
            }
            arr[0, 0] = '╔';
            arr[0, arr.GetLength(1) - 1] = '╗';
            arr[arr.GetLength(0) - 1, 0] = '╚';
            arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1] = '╝';
        }

        private void AppleGeneration()
        {
            Random rand = new();
            positionApple.X_cord = rand.Next(1, width - 1);
            positionApple.Y_cord = rand.Next(1, height - 1);
            aplle = '+';
        }

        public int width { get; }
        public int height { get; }
        public char[,] arr { get; }
        private char aplle;
        private Position positionApple;
    }
}
