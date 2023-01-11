//'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
//Functionba kell rakni :((
//Le kell tudni menteni a térképet
//Hozzá adni hogy időre menjen

//Be lehet tölteni és szerkeszteni régi térképeket
//El lehet nevezni a mentett térképet
//
using System;
using System.Data.Common;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

bool hasWon = false;
const int palyaSorok = 20;
const int palyaOszlopok = 20;
    // Create the maze as a two-dimensional array of characters
    char[,] maze = new char[palyaSorok, palyaOszlopok]
    {
                { ',', ',', ',', ',', ',', ',', ',', ',', ',', ',',',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                { ',', ',', ',', ',', ',', ',', ',', ',', ',', ',',',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                { ',', ',', ',', ',', ',', ',', ',', ',', ',', ',',',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                { ',', ',', ',', ',', ',', ',', ',', ',', ',', ',',',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','},
                {',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ',', ','}
    };

    // Set the starting position for the player
    int jatekosKezdoSor = 0;
    int jatekosKezdoOszlop = 0;

    // Set the initial direction for the player's movement
    string instructions = "down";

// Keep track of whether the player has won the game


// Continue running the game until the player has won or quits
Console.WriteLine("Kérem válasszon nyelvet Angol(1) vagy Magyar(2)");
double nyelvValaszto = Convert.ToDouble(Console.ReadLine());

while (!hasWon)
    {
    // Clear the console before each frame
    Console.Clear();


    if (nyelvValaszto == 2)
    {
        Console.WriteLine("A 'W' gombok lenyomásával tud  felfelé mozogni.");
        Console.WriteLine("A 'S' gombok lenyomásával tud hátrafelé mozogni.");
        Console.WriteLine("A 'A' gombok lenyomásával tud balra mozogni.");
        Console.WriteLine("A 'D' gombok lenyomásával tud jobbra mozogni.");
        Console.WriteLine("Az f1 gomb lenyomásával tud rajzolni '╬' karaktert.");
        Console.WriteLine("Az f2 gomb lenyomásával tud rajzolni '═' karaktert.");
        Console.WriteLine("Az f3 gomb lenyomásával tud rajzolni '╦' karaktert.");
        Console.WriteLine("Az f4 gomb lenyomásával tud rajzolni '╩' karaktert.");
        Console.WriteLine("Az f5 gomb lenyomásával tud rajzolni '║' karaktert.");
        Console.WriteLine("Az f6 gomb lenyomásával tud rajzolni '╣' karaktert.");
        Console.WriteLine("Az f7 gomb lenyomásával tud rajzolni '╠' karaktert.");
        Console.WriteLine("Az f8 gomb lenyomásával tud rajzolni '╗' karaktert.");
        Console.WriteLine("Az f9 gomb lenyomásával tud rajzolni '╝' karaktert.");
        Console.WriteLine("Az f10 gomb lenyomásával tud rajzolni '╚' karaktert.");
        Console.WriteLine("Az f12 gomb lenyomásával tud rajzolni '╔' karaktert.");
        Console.WriteLine("Az space gomb lenyomásával tud rajzolni ',' karaktert.");
        Console.WriteLine("Az 'R' gomb lenyomásával tud rajzolni '█' karaktert.");
       // Console.WriteLine("Az 'Home' gomb lenyomásával tudja lementeni a labitintust.");
        Console.WriteLine("Az 'End' gomb lenyomásával tudja abba hagyni a labirintus szerkesztését.");
    }
    else if (nyelvValaszto == 1)
    {
        Console.WriteLine("You can move forward with 'W' button.");
        Console.WriteLine("You can move backwards with 'S' button.");
        Console.WriteLine("You can move left with 'A' button.");
        Console.WriteLine("You can move right with 'D' button.");
        Console.WriteLine("The f1 key is drawing a '╬' shape.");
        Console.WriteLine("The f2 key is drawing a '═' shape.");
        Console.WriteLine("The f3 key is drawing a '╦' shape.");
        Console.WriteLine("The f4 key is drawing a '╩' shape.");
        Console.WriteLine("The f5 key is drawing a '║' shape.");
        Console.WriteLine("The f6 key is drawing a '╣' shape.");
        Console.WriteLine("The f7 key is drawing a '╠' shape.");
        Console.WriteLine("The f8 key is drawing a '╗' shape.");
        Console.WriteLine("The f9 key is drawing a'╝' shape.");
        Console.WriteLine("The f10 key is drawing a '╚' shape.");
        Console.WriteLine("The f12 key is drawing a '╔' shape.");
        Console.WriteLine("The space key is drawing a ',' shape.");
        Console.WriteLine("The 'R' key is drawing a '█' shape.");
       // Console.WriteLine("The 'Home' key is saveing the maze.");
        Console.WriteLine("You can stop the editing if you press the 'end' button.");
    }

    // Draw the maze to the console
    for (int row = 0; row < palyaOszlopok; row++)
        {
            for (int col = 0; col < palyaOszlopok; col++)
            {
                // If the current position is the player's position, draw the player's character
                if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                {
                    Console.Write('@');
                }
                else
                {
                    Console.Write(maze[row, col]);
                }
            }

            // Move to the next line after drawing each row of the maze
            Console.WriteLine();
        }

    char ends = '═';
    int countEnd = 0;
    char rooms = '█';
    int countRoom = 0;


    for (int i = 0; i < maze.GetLength(0); i++)
    {
        for (int j = 0; j < maze.GetLength(1); j++)
        {
            if (maze[i, j] == rooms)
            {
                countEnd++;
            }
        }
    }
    for (int i = 0; i < maze.GetLength(0); i++)
    {
        for (int j = 0; j < maze.GetLength(1); j++)
        {
            if (maze[i, j] == rooms)
            {
                countRoom++;
            }
        }
    }
    
    
    if (countRoom >= 1 && countEnd == 2)
    {
        if (nyelvValaszto == 2)
        {
            Console.WriteLine(countRoom + "db szoba van a pályán");
        }
        else if (nyelvValaszto == 1)
        {
            Console.WriteLine("There are as many room(s) as " + countRoom);
        }
    }
    else if (countRoom == 0 && countEnd == 1)
    {
        if (nyelvValaszto == 2)
        {
            Console.WriteLine("Még nincsen terem létrehozva ezen a pályán.");
            Console.WriteLine("Még nincsen kijárat vagy bejárat létrehozva ezen a pályán.");
        }
        else if (nyelvValaszto == 1)
        {
            Console.WriteLine("There are no room in the maze.");
            Console.WriteLine("There are no exit or start at the maze yet.");
        }
    }
    else if (countRoom == 0 && countEnd == 2)
    {
        if (nyelvValaszto == 2)
        {
            Console.WriteLine("Még nincsen terem létrehozva ezen a pályán.");
        }
        else if (nyelvValaszto == 1)
        {
            Console.WriteLine("There are no room in the maze.");
        }
    }
    else
    {
        if (nyelvValaszto == 2)
        {
            Console.WriteLine("Még nincsen terem létrehozva ezen a pályán.");
            Console.WriteLine("Még nincsen se kijárat, se bejárat létrehozva ezen a pályán.");
        }
        else if (nyelvValaszto == 1)
        {
            Console.WriteLine("There are no room in the maze.");
            Console.WriteLine("There are no exit and no start at the maze yet.");
        }
    }
    hasWon = false;
    // Check if the player has reached the end of the maze

    if (!hasWon)     
    {
        // Get the player's input for the next move
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        // Update the direction based on the player's input
        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
                instructions = "up";
                break;
            case ConsoleKey.S:
                instructions = "down";
                break;
            case ConsoleKey.A:
                instructions = "left";
                break;
            case ConsoleKey.D:
                instructions = "right";
                break;
            case ConsoleKey.F1:
                instructions = "drawCrossroads";
                break;
            case ConsoleKey.F2:
                instructions = "drawRoad";
                break;
            case ConsoleKey.F3:
                instructions = "drawCrossroadsDown";
                break;
            case ConsoleKey.F4:
                instructions = "drawCrossroadsUp";
                break;
            case ConsoleKey.F5:
                instructions = "drawLine";
                break;
            case ConsoleKey.F6:
                instructions = "drawLineLeft";
                break;
            case ConsoleKey.F7:
                instructions = "drawLineRight";
                break;
            case ConsoleKey.F8:
                instructions = "drawLeftBottomCorner";
                break;
            case ConsoleKey.F9:
                instructions = "drawLeftTopCorner";
                break;
            case ConsoleKey.F10:
                instructions = "drawRightTopCorner";
                break;
            case ConsoleKey.F12:
                instructions = "drawRightBottomCorner";
                break;
            case ConsoleKey.Spacebar:
                instructions = "drawAnEmptySpace";
                break;
            case ConsoleKey.R:
                instructions = "drawARoom";
                break;
            case ConsoleKey.End:
                instructions = "endTheEditing";
                break;
            case ConsoleKey.Home:
                instructions = "saveTheFile";
                break;
        }

        // Move the player in the selected direction
        switch (instructions)
        {
            case "up":
                jatekosKezdoSor--;
                break;
            case "down":
                jatekosKezdoSor++;
                break;
            case "left":
                jatekosKezdoOszlop--;
                break;
            case "right":
                jatekosKezdoOszlop++;
                break;
            case "drawCrossroads":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╬';
                        }
                    }
                }
                break;
            case "drawRoad":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '═';
                        }
                    }
                }
                break;
            case "drawCrossroadsDown":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╦';
                        }
                    }
                }
                break;
            case "drawCrossroadsUp":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╩';
                        }
                    }
                }
                break;
            case "drawLine":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '║';
                        }
                    }
                }
                break;
            case "drawLineLeft":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╣';
                        }
                    }
                }
                break;
            case "drawLineRight":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╠';
                        }
                    }
                }
                break;
            case "drawLeftBottomCorner":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╗';
                        }
                    }
                }
                break;
            case "drawLeftTopCorner":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╝';
                        }
                    }
                }
                break;
            case "drawRightTopCorner":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╚';
                        }
                    }
                }
                break;
            case "drawRightBottomCorner":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '╔';
                        }
                    }
                };
                break;
            case "drawAnEmptySpace":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = ',';
                        }
                    }
                }
                break;
            case "drawARoom":
                for (int row = 0; row < palyaSorok; row++)
                {
                    for (int col = 0; col < palyaOszlopok; col++)
                    {
                        if (row == jatekosKezdoSor && col == jatekosKezdoOszlop)
                        {
                            maze[row, col] = '█';
                        }
                    }
                }
                break;
            case "endTheEditing":
                hasWon = true;
            break;
            case "saveTheFile":
                using (StreamWriter sw = new StreamWriter("maze.txt"))
                {
                    for (int i = 0; i < maze.GetLength(0); i++)
                    {
                        for (int j = 0; j < maze.GetLength(1); j++)
                        {
                            sw.Write(maze[i, j] + " ");
                        }
                        sw.WriteLine();
                    }
                }
                    break;
        }
        /*
        int rows = maze.GetLength(0);
        int columns = maze.GetLength(1);
        char value = '=';
        for (int i = 0; i < rows; i++)
        {
            if (maze[i, 0] == value || maze[i, columns - 1] == value)
            {
                countEnd++;
            }
        }
        */

       
        foreach (char data in maze)
        {
             if (data == '█')
            {
                countRoom++;
            }
        }
        
    }
    
}
if (hasWon == true)
{
    if (nyelvValaszto == 2)
    {
        Console.WriteLine("Befejezte a labititus szerkesztést(nyomjon le egy gombot a prgram bezárásához)");
    }
    else if (nyelvValaszto == 1)
    {
        Console.WriteLine("You are finished the the editing(press a buttons to close the code)");
    }
}



