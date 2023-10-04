using System;
using System.Collections.Generic;


namespace ConsoleSnake
{
    struct Position
    {
        public int X_cord { get; set; }
        public int Y_cord { get; set; }
    }

    class Snake
    {
        public Snake(in WindowSnake window)
        {
            this.window = window;
            SetHeadPosition(window);
        }

        public Snake(in int width = 30, in int height = 10)
        {
            window = new WindowSnake(width, height);
            SetHeadPosition(window);
        }

        public bool S_up()
        {
            char cell = window.arr[headPosition.Y_cord - 1, headPosition.X_cord];
            lastHeadPosition = headPosition;
            if (cell == ' ')
            {
                headPosition.Y_cord--;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                headPosition.Y_cord--;
                SnakeMagnification(headPosition);
                return true;
            }
            return false;
        }
        public bool S_left()
        {
            char cell = window.arr[headPosition.Y_cord, headPosition.X_cord - 1];
            lastHeadPosition = headPosition;
            if (cell == ' ')
            {
                headPosition.X_cord--;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                headPosition.X_cord--;
                SnakeMagnification(headPosition);
                return true;
            }
            return false;
        }
        public bool S_right()
        {
            char cell = window.arr[headPosition.Y_cord, headPosition.X_cord + 1];
            lastHeadPosition = headPosition;
            if (cell == ' ')
            {
                headPosition.X_cord++;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                headPosition.X_cord++;
                SnakeMagnification(headPosition);
                return true;
            }
            return false;
        }
        public bool S_down()
        {
            char cell = window.arr[headPosition.Y_cord + 1, headPosition.X_cord];
            lastHeadPosition = headPosition;
            if (cell == ' ')
            {
                headPosition.Y_cord++;
                SnakeUpdate();
                return true;
            }
            else if (cell == '+')
            {
                headPosition.Y_cord++;
                SnakeMagnification(headPosition);
                return true;
            }
            return false;
        }


        public ref List<Position> GetPositions()
        {
            return ref positionsSnake;
        }

        public int GetPoints()
        {
            return positionsSnake.Count - 1;
        }

        private void SnakeMagnification(in Position headPosition)
        {
            window.AppleUpdate();
            positionsSnake.Add(headPosition);
            SnakeUpdate();
        }

        private void SetHeadPosition(in WindowSnake window)
        {
            headPosition.X_cord = window.width / 2;
            headPosition.Y_cord = window.height / 2;
            positionsSnake.Add(headPosition);
        }

        private void SnakeUpdate()
        {
            positionsSnake.RemoveAt(0);
            positionsSnake.Insert(0, headPosition);
            if (positionsSnake.Count > 1)
            {
                positionsSnake.Insert(1, lastHeadPosition);
                positionsSnake.RemoveAt(positionsSnake.Count - 1);
            }
            window.UpdateWindowWithSnake(positionsSnake, positionsSnake.Count - 1);
        }


        private List<Position> positionsSnake = new();
        private Position headPosition;
        private Position lastHeadPosition;
        private WindowSnake window;
    }
}
