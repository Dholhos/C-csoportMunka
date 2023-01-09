using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

namespace projekth
{
    internal class World
    {
        private string[,] Maze;
        private int Rows;
        private int Cols;

        public World(string[,] maze)
        {
            Maze = maze;
            Rows = Maze.GetLength(0);
            Cols = Maze.GetLength(1);

        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Maze[y, x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
        }
        public string ElementAt(int x, int y)
        {
            return Maze[y, x];
        }
        public bool Walkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            return Maze[y, x] == " " || Maze[y, x] == "X";
        }
    }
}
