using Graphics;
using System;
using System.Globalization;
using System.Text;
using System.Timers;

namespace game
{
    class Game
    {
        //couleur UI
        public static ConsoleColor _UIcolor = ConsoleColor.DarkYellow;

        //mutex barre de vie empêche l'activation simultanée de l'affichage de la barre de vie et d'une action 
        public static bool _mutexLifeBar = false;

        public GraphicTools _drawer = new GraphicTools();
        public Options _options = new Options();

        //Constructeur
        public Game()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(120, 30);
            Stats.Initializer(); //loading save
            Console.Title = "CMD_ Adventure";   //define console title
            //CrazyConsoleRandomNumber();    //<--------------------------------réactiver a la fin du dev.
            Console.ForegroundColor = _UIcolor;
            //drawer.TitleScreen();                    //<--------------------------------réactiver a la fin du dev.
            //Taptaptap_game();                 //<--------------------------------réactiver a la fin du dev.
            _mutexLifeBar = true;
        }

        //Timer refresh game time every seconds
        #region timer
        public Timer _gameTimeTimer = new System.Timers.Timer(1000)
        {
            AutoReset = true
        };

        public void UpdateGameTime(object source, ElapsedEventArgs e)
        {
            //1 seconde de plus au temps de jeu
            Stats.Player.GameTime++;
            //boucle de régéneration de la vie du joueur
            if (_mutexLifeBar == true)
            {
                Stats.Player.Regenerate();
            }
        }
        #endregion timer

        /**fill the console with random numbers
         * on random spots
         * in red or Yellow color
         */
        public void CrazyConsoleRandomNumber()
        {
            Random lol = new Random();
            int rnd;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < 10e3; i++)
            {
                rnd = lol.Next(0, Console.WindowHeight);
                Console.CursorTop = rnd;
                Console.Write(rnd);
                if (Console.ForegroundColor == ConsoleColor.DarkYellow)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }
            for (int i = 0; i < 10e3; i++)
            {
                rnd = lol.Next(0, Console.WindowHeight);
                Console.CursorTop = rnd;
                Console.Write(' ');
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        public void Taptaptap_game()
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
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                _drawer.CenterWrite(Sprite_box._player_base);
                _drawer.Wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au total)
                Console.Write("\r");
                _drawer.CenterWrite("   ");
                Console.Write("\n");
            }
            _drawer.CenterWrite(Sprite_box._player_base);
            Console.CursorVisible = true;


            //Boucle du jeu ttt (il faut arriver a 1000 ttt)
            while (Stats.Player.TaptaptapScore < 1000)
            {
                Console.SetCursorPosition(0, 3);
                _drawer.DeleteLine(3);
                Console.ReadKey();
                Stats.Player.TaptaptapScore++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                _drawer.Write("ttt: " + Stats.Player.TaptaptapScore);
                switch (Stats.Player.TaptaptapScore)
                {
                    case 10:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("Woaw 10 tap !");
                        break;
                    case 50:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("50 tap !");
                        break;
                    case 100:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("100 tap !!");
                        break;
                    case 200:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("100 tap !!");
                        break;
                    case 500:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("500 tap !!!! some more for a gift :)");
                        break;
                    case 1000:
                        Console.SetCursorPosition(0, 5);
                        _drawer.DeleteLine(5);
                        _drawer.Write("1000 tap :o");
                        break;
                    default:
                        break;
                }
                Console.SetCursorPosition(0, 5);
            };
            //après 1000 ttt le joueur obtient la barre de titre
            Console.Write("réclamer quelque-chose contre {0} ttt ? (O/N)", Stats.Player.TaptaptapScore);
            bool YES = false;
            int emoji = 0;

            while (!YES)
            {
                Console.SetCursorPosition(0, 6);
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
                        switch (emoji)
                        {
                            case 0:
                                Console.Write(".-.");
                                emoji++;
                                break;
                            case 1:
                                Console.Write(".o.");
                                emoji++;
                                break;
                            case 2:
                                Console.Write("._.");
                                emoji++;
                                break;
                            case 3:
                                Console.Write(".__.");
                                emoji++;
                                break;
                            case 4:
                                Console.Write(".___.");
                                emoji++;
                                break;
                            case 5:
                                Console.Write("-___-");
                                emoji++;
                                break;
                            case 6:
                                Console.Write("-.-");
                                emoji = 0;
                                break;
                            default:
                                Console.Write("._.");
                                break;
                        }
                        break;
                    default:
                        _drawer.DeleteLine(6);
                        Console.Write("Vous n'avez pas choisi :/");
                        break;
                }
                Console.CursorVisible = false;
            }
            Console.ReadKey();
            Console.Clear();
        }//mini-game at the beginning of the party

        #region actions
        public void ActionChoice()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    if (Stats._activeTab != "Carte")
                    {
                        _mutexLifeBar = false;
                        Stats._activeTab = "Carte";
                        MenuBar.Display();
                        Map map = new Map();
                        _mutexLifeBar = true;
                    }
                    else
                    {
                        _drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Z:
                    if (Stats._activeTab != "Inventaire")
                    {
                        _mutexLifeBar = false;
                        Stats._activeTab = "Inventaire";
                        MenuBar.Display();
                        Inventory inventory = new Inventory();
                        _mutexLifeBar = true;
                    }
                    else
                    {
                        _drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.E:
                    if (Stats._activeTab != "Magasin")
                    {
                        _mutexLifeBar = false;
                        Stats._activeTab = "Magasin";
                        MenuBar.Display();
                        Shop shop = new Shop();
                        _mutexLifeBar = true;
                    }
                    else
                    {
                        _drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.R:
                    if (Stats._activeTab != "???")
                    {
                        _mutexLifeBar = false;
                        Stats._activeTab = "???";
                        MenuBar.Display();
                        What what = new What();
                        _mutexLifeBar = true;
                    }
                    else
                    {
                        _drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.T:
                    if (Stats._activeTab != "Options")
                    {
                        _mutexLifeBar = false;
                        Stats._activeTab = "Options";
                        MenuBar.Display();
                        Options options = new Options();
                        _mutexLifeBar = true;
                    }
                    else
                    {
                        _drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Escape:
                    _mutexLifeBar = false;
                    _options.SaveAndQuit();
                    _mutexLifeBar = true;
                    break;
                default:
                    _drawer.Cursor_StandBy();
                    break;
            }
        }
        #endregion actions

    }
}


