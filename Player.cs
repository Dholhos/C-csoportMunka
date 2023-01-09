using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace projekth
{
    internal class Player
    {

        public int x { get; set; }
        public int y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
            PlayerMarker = "O";
            PlayerColor = ConsoleColor.Red;
        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(x, y);
            Write(PlayerMarker);
            ResetColor();
        }

    }
}
