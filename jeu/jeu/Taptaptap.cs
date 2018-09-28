using game;
using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu
{
    /**
    * mini-game at the beginning of the party
    * 
    * Allow the player to get the UI
    */
    class Taptaptap
    {
        GraphicTools _drawer;

        /**
         * Taptaptap is a mini-game.
         * 
         * Auto-launching at instanciation
         */
        public Taptaptap()
        {
            _drawer = new GraphicTools();
            if (Stats.Player.TaptaptapScore < 1000)
            {
                StartingAnimation();
                Play();
            }
            MenuBar.Display();
        }

        private void Play()
        {
            // Mini-Game loop
            // finish with a score of 1K
            while (Stats.Player.TaptaptapScore < 1000)
            {
                _drawer.DeleteLine(3);
                _drawer.Cursor_StandBy();
                Console.ReadKey();
                Stats.Player.TaptaptapScore++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                _drawer.Write("ttt: " + Stats.Player.TaptaptapScore);

                switch (Stats.Player.TaptaptapScore)
                {
                    case 10:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("Woaw 10 tap !");
                        break;
                    case 50:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("50 tap !");
                        break;
                    case 100:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("100 tap !!");
                        break;
                    case 200:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("100 tap !!");
                        break;
                    case 500:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("500 tap !!!! presque :)");
                        break;
                    case 1000:
                        _drawer.DeleteLine(5);
                        Console.SetCursorPosition(0, 5);
                        _drawer.Write("1000 tap :o");
                        break;
                    default:
                        break;
                }
                _drawer.Cursor_StandBy();
            };


            // After 1000ttt, the player can
            // request the UI
            _drawer.DeleteLine(5);
            Console.SetCursorPosition(0, 5);
            Console.Write("réclamer quelque-chose contre {0} ttt ? (O/N)", Stats.Player.TaptaptapScore);
            bool YES = false;
            Random emojiID = new Random();

            while (!YES)
            {
                _drawer.Cursor_StandBy();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.O:
                        YES = true;
                        _drawer.DeleteLine(6);
                        _drawer.DeleteLine(5);
                        _drawer.DeleteLine(Console.WindowHeight - 2);
                        Console.SetCursorPosition(0, 5);
                        Console.Write("Conversion !");
                        break;
                    case ConsoleKey.N:
                        _drawer.DeleteLine(6);
                        Console.SetCursorPosition(0, 6);
                        string[] emojis = { ".-.", ".o.", "._.", ".__.", ".___.", "-___-", "-.-", "._." };
                        int emoji = emojiID.Next(emojis.Length);
                        Console.Write(emojis[emoji]);
                        break;
                    default:
                        _drawer.DeleteLine(6);
                        Console.SetCursorPosition(0, 6);
                        Console.Write("Vous n'avez pas choisi :/");
                        break;
                }
            }
            Console.Clear();
        }

        private void StartingAnimation()
        {
            Console.Clear();
            _drawer.HorizontalLine(0, '=');
            Console.SetCursorPosition(0, 2);
            ConsoleColor fg_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            _drawer.CenterWrite("tap tap tap !");
            Console.ForegroundColor = fg_actuel;
            _drawer.HorizontalLine(4, '=');
            Console.CursorVisible = false;

            // display the player sprite fall
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                _drawer.CenterWrite(Sprites._player_base);
                // the duration is 1 sec
                // so each line last a division by
                // the number of lines
                _drawer.Wait(1000 / Console.WindowHeight);
                Console.Write("\r");
                _drawer.CenterWrite("   ");
                Console.Write("\n");
            }
            _drawer.CenterWrite(Sprites._player_base);
            Console.CursorVisible = true;
        }
    }
}
