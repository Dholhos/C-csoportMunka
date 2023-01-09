//'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
//Kell egy ellenörző hogy van e a pályán szoba és van e kijárat és bejárat
//Functionba kell rakni :((
//Le kell tudni menteni a térképet
//Megoldani vhogy hogy be lehessen fejezni
//Hozzá adni hogy időre menjen

//Be lehet tölteni és szerkeszteni régi térképeket
//El lehet nevezni a mentett térképet
//
// Define the dimensions of the maze
using System.Security.Cryptography;

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

    // Set the position of the end of the maze
    int endRow = 9;
    int endColumn = 19;

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
    int countRoom = 0;
    int countEnd = 0;
    Console.WriteLine(countEnd);
    Console.WriteLine(countRoom);

    if (nyelvValaszto == 2)
    {
        Console.WriteLine("A nyílak lenyomásával tud mozogni");
        Console.WriteLine("Az f1 gomb lenyomásával tud rajzolni '╬' karaktert");
        Console.WriteLine("Az f2 gomb lenyomásával tud rajzolni '═' karaktert");
        Console.WriteLine("Az f3 gomb lenyomásával tud rajzolni '╦' karaktert");
        Console.WriteLine("Az f4 gomb lenyomásával tud rajzolni '╩' karaktert");
        Console.WriteLine("Az f5 gomb lenyomásával tud rajzolni '║' karaktert");
        Console.WriteLine("Az f6 gomb lenyomásával tud rajzolni '╣' karaktert");
        Console.WriteLine("Az f7 gomb lenyomásával tud rajzolni '╠' karaktert");
        Console.WriteLine("Az f8 gomb lenyomásával tud rajzolni '╗' karaktert");
        Console.WriteLine("Az f9 gomb lenyomásával tud rajzolni '╝' karaktert");
        Console.WriteLine("Az f10 gomb lenyomásával tud rajzolni '╚' karaktert");
        Console.WriteLine("Az f12 gomb lenyomásával tud rajzolni '╔' karaktert");
        Console.WriteLine("Az space gomb lenyomásával tud rajzolni ',' karaktert");
        Console.WriteLine("Az 'R' gomb lenyomásával tud rajzolni '█' karaktert");
        
    }
    else if (nyelvValaszto == 1)
    {
        Console.WriteLine("You can move with the arrow bottuns");
        Console.WriteLine("The f1 key is drawing a '╬' shape");
        Console.WriteLine("The f2 key is drawing a '═' shape");
        Console.WriteLine("The f3 key is drawing a '╦' shape");
        Console.WriteLine("The f4 key is drawing a '╩' shape");
        Console.WriteLine("The f5 key is drawing a '║' shape");
        Console.WriteLine("The f6 key is drawing a '╣' shape");
        Console.WriteLine("The f7 key is drawing a '╠' shape");
        Console.WriteLine("The f8 key is drawing a '╗' shape");
        Console.WriteLine("The f9 key is drawing a'╝' shape");
        Console.WriteLine("The f10 key is drawing a '╚' shape");
        Console.WriteLine("The f12 key is drawing a '╔' shape");
        Console.WriteLine("The space key is drawing a ',' shape");
        Console.WriteLine("The 'R' key is drawing a '█' shape");
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


    if (countRoom == 0 && countEnd == 0)
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
            Console.WriteLine("Most teljesithető a pálya");
        }
        else if (nyelvValaszto == 1)
        {
            Console.WriteLine("The maze is doable");
        }
    }
        // Check if the player has reached the end of the maze
        if (jatekosKezdoSor == endRow && jatekosKezdoOszlop == endColumn)
    {
        // If so, the player has won the game
        hasWon = true;
    }
    else
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
        }
        foreach (char data in maze)
        {
            if (data == '=')
            {
                countEnd++;
            }
            else if (data == '█')
            {
                countRoom++;
            }
        }
    }
    
}


    // Display a message to the player if they have won the game
    if (hasWon)
    {
        Console.WriteLine("Congratulations! You have reached the end of the maze!");
    }

    // Wait for the player to press a key before closing the game
    Console.ReadKey();

