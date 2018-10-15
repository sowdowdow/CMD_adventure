using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics
{
    public class GraphicTools
    {
        public void Cursor_StandBy()
        {
            //place the cursor down right the console in pause
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Write(int nb)
        {
            Console.Write(nb);
        }

        public void Write(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public void VerticalLine(int Left, char printedChararcter)
        {
            int top = 4;
            Console.SetCursorPosition(Left, top);
            while (top < Console.BufferHeight -1)
            {
                if (Console.CursorTop < Console.BufferHeight - 1)
                {
                    Console.CursorTop++;
                }
                else
                {
                    break;
                }
                Console.Write(printedChararcter);
                Console.SetCursorPosition(Left, Console.CursorTop);
            }
        }

        //display a line of 1 character
        public void HorizontalLine(int hauteur, char printedChararcter)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(printedChararcter);
            }
        }

        //display a line with 2 characters alternated
        public void HorizontalLine(int hauteur, char car, char car2)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth / 2; i++)
            {
                Console.Write(car);
                Console.Write(car2);
            }
        }

        //Display the title animation
        public void TitleScreen()
        {
            Console.Clear();
            Console.CursorLeft = 0;
            string[] titre = {
                @"   ___  __  __  ___       _      _                 _                   ",
                @"  / __||  \/  ||   \     /_\  __| |__ __ ___  _ _ | |_  _  _  _ _  ___ ",
                @" | (__ | |\/| || |) |   / _ \/ _` |\ V // -_)| ' \|  _|| || || '_|/ -_)",
                @"  \___||_|  |_||___/___/_/ \_\__,_| \_/ \___||_||_|\__| \_,_||_|  \___|",
                @"                   |___|                                                "};
            string appuyez = "appuyez pour continuer...";
            Console.CursorTop = (Console.WindowHeight / 2) - titre.Length;
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Wait(1000 / Console.WindowWidth);
                Console.Write('-');
            }
            for (int i = 0; i < Console.BufferWidth / 2 - (titre.Length / 2); i++)
            {
                Console.Write(" ");
            }
            ConsoleColor fg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < titre.Length; i++)  //on affiche le titre
            {
                Wait(200);
                CenterWrite(titre[i]);
                Console.CursorTop++;
            }
            Console.ForegroundColor = fg;
            Wait(1000);
            Console.Write("\n");
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Wait(1000 / Console.WindowWidth);
                Console.Write('-');
            }
            for (int i = 0; i < appuyez.Length; i++)
            {
                Wait(20);
                Console.Write(appuyez[i]);
            }
            Console.ReadKey(true);  // attend la saisie d'un appui sur clavier
            Console.Clear(); //efface la console
        }

        //display a string horizontally centered
        public void CenterWrite(string text)
        {
            int taille_obj = text.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(text);
        }

        //display a string horizontally centered on the specified line
        public void CenterWrite(int ligne, string text)
        {
            Console.CursorTop = ligne;
            int taille_obj = text.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(text);
        }

        //display strings horizontally centered from the specified line
        public void CenterWrite(int line, String[] strings)
        {
            foreach (String text in strings)
            {
                CenterWrite(line, text);
                line++;
            }
        }

        public void Wait(int temps)
        {
            System.Threading.Thread.Sleep(temps);
        }//met en pause la console (en MilliSec)

        // Clear the specified Line
        public void DeleteLine(int line)
        {
            Console.CursorVisible = false;

            string lineCleaner = "";
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                lineCleaner += " ";
            }

            Console.SetCursorPosition(0, line);
            Console.Write(lineCleaner);
            Cursor_StandBy();

            Console.CursorVisible = true;
        }


        public void DeleteLine(int startLine, int endLine)

        {
            // suppressing multiple rows of lines
            Console.CursorVisible = false;
            string lineCleaner = "";
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                lineCleaner += " ";
            }

            Console.SetCursorPosition(0, startLine);
            for (int j = startLine; j <= endLine; j++)
            {
                Console.Write(lineCleaner);
                try
                {
                    Console.SetCursorPosition(0, j);
                }
                catch (Exception e)
                {
                    Console.Title = e.Message;
                    throw;
                }
            }

            Console.SetCursorPosition(0, startLine);
            Console.CursorVisible = true;
        }

        //delete all the lines not in the UI bar
        public void ClearInterface()
        {
            DeleteLine(4, Console.WindowHeight - 1);
        }

        /**fill the console with random numbers
 * on random spots
 * in red or Yellow color
 */
        public void CrazyConsoleRandomNumber()
        {
            Random randNumber = new Random();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.CursorVisible = false;

            // write
            for (int i = 0; i < 5000; i++)
            {
                Console.CursorTop = randNumber.Next(0, Console.WindowHeight - 1);
                Console.Write('*');
                if (Console.ForegroundColor == ConsoleColor.DarkYellow)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }

            // clean
            for (int i = 0; i < 7000; i++)
            {
                Console.CursorTop = randNumber.Next(0, Console.WindowHeight - 1);
                Console.Write(' ');
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = false;
        }
    }
}