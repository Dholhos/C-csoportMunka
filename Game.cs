using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace projekth
{
    internal class Game
    {
        private World myWorld;
        private Player currentPlayer;
        public void Start()
        {
            CursorVisible = false;

            string[,] maze = 
            {
                { "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒" },
                { "▒", " ", " ", " ", "▒", " ", " ", " ", " ", "▒" },
                { "▒", " ", "▒", " ", "▒", " ", "▒", "▒", " ", "▒" },
                { "▒", "▒", "▒", " ", "▒", " ", " ", " ", " ", "▒" },
                { "▒", " ", " ", " ", " ", "▒", " ", "▒", " ", "▒" },
                { "▒", "▒", "▒", "▒", " ", " ", " ", "▒", " ", "▒" },
                { "▒", " ", " ", "▒", " ", "▒", " ", "▒", " ", "▒" },
                { "▒", "▒", " ", "▒", " ", "▒", " ", "▒", " ", "▒" },
                { "▒", " ", " ", " ", " ", " ", " ", " ", "X", "▒" },
                { "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒", "▒" }
             };

            myWorld = new World(maze);
            currentPlayer = new Player(1, 1);

            GameLoop();

        }
        private void DisplayIn()
        {
            ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Maze!");
            Console.WriteLine("");
            Console.WriteLine("Instructions");
            Console.WriteLine("> fUse the WASD keys to move.");
            Console.Write("> Try to reach the goal, which looks like this: ");
            Console.WriteLine("X");
            Console.WriteLine("> Press any key to start!");
            ReadKey(true);
        }
        private void DisplayOut()
        {
            Clear();
            Console.WriteLine("You escaped!");
            Console.WriteLine("Press any key to exit!");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            Clear();
            myWorld.Draw();
            currentPlayer.Draw();
        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key; 
            switch(key)
            {
                case ConsoleKey.W:
                    if (myWorld.Walkable(currentPlayer.x, currentPlayer.y - 1))
                    {
                        currentPlayer.y -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (myWorld.Walkable(currentPlayer.x - 1, currentPlayer.y))
                    {
                        currentPlayer.x -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (myWorld.Walkable(currentPlayer.x, currentPlayer.y + 1))
                    {
                        currentPlayer.y += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (myWorld.Walkable(currentPlayer.x + 1, currentPlayer.y))
                    {
                        currentPlayer.x += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void GameLoop()
        {
            DisplayIn();
            ForegroundColor = ConsoleColor.White;
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();

                string elementAtPlayer = myWorld.ElementAt(currentPlayer.x, currentPlayer.y);
                if (elementAtPlayer == "X")
                {
                    break;
                }
                System.Threading.Thread.Sleep(20);
            }
            DisplayOut();
        }
    }
}
