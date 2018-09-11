using System;
using System.Globalization;
using System.Text;
using System.Timers;

namespace game
{
    class Game
    {
        //couleur UI
        public static ConsoleColor UIcolor = ConsoleColor.DarkYellow;

        //mutex barre de vie empêche l'activation simultanée de l'affichage de la barre de vie et d'une action 
        public static bool mutexLifeBar = false;

        public Sprite_box sprite = new Sprite_box();
        public GraphicTools drawer = new GraphicTools();
        public Options options = new Options();

        //Constructeur
        public Game()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(120, 30);
            Stats.Initializer(); //loading save
            Console.Title = "CMD_ Adventure";   //define console title
            //CrazyConsoleRandomNumber();    //<--------------------------------réactiver a la fin du dev.
            Console.ForegroundColor = UIcolor;
            //drawer.TitleScreen();                    //<--------------------------------réactiver a la fin du dev.
            //Taptaptap_game();                 //<--------------------------------réactiver a la fin du dev.
            mutexLifeBar = true;
        }

        //Timer refresh game time every seconds
        #region timer
        public Timer gameTimeTimer = new System.Timers.Timer(1000)
        {
            AutoReset = true
        };

        public void UpdateGameTime(object source, ElapsedEventArgs e)
        {
            //1 seconde de plus au temps de jeu
            Stats.GameTime++;
            //boucle de régéneration de la vie du joueur
            if (Stats.vie_joueur < Stats.MaxPlayerLife && mutexLifeBar == true)
            {
                Stats.vie_joueur++;
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
            drawer.HorizontalLine(0, '=');
            Console.SetCursorPosition(0, 2);
            ConsoleColor fg_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            drawer.CenterWrite("tap tap tap !");
            Console.ForegroundColor = fg_actuel;
            drawer.HorizontalLine(4, '=');
            Console.CursorVisible = false;
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                drawer.CenterWrite(sprite.player_base);
                drawer.Wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au total)
                Console.Write("\r");
                drawer.CenterWrite("   ");
                Console.Write("\n");
            }
            drawer.CenterWrite(sprite.player_base);
            Console.CursorVisible = true;


            //Boucle du jeu ttt (il faut arriver a 1000 ttt)
            while (Stats.Taptaptap < 1000)
            {
                Console.SetCursorPosition(0, 3);
                drawer.DeleteLine(3);
                Console.ReadKey();
                Stats.Taptaptap++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                drawer.Write("ttt: " + Stats.Taptaptap);
                switch (Stats.Taptaptap)
                {
                    case 10:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("Woaw 10 tap !");
                        break;
                    case 50:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("50 tap !");
                        break;
                    case 100:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("100 tap !!");
                        break;
                    case 200:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("100 tap !!");
                        break;
                    case 500:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("500 tap !!!! some more for a gift :)");
                        break;
                    case 1000:
                        Console.SetCursorPosition(0, 5);
                        drawer.DeleteLine(5);
                        drawer.Write("1000 tap :o");
                        break;
                    default:
                        break;
                }
                Console.SetCursorPosition(0, 5);
            };
            //après 1000 ttt le joueur obtient la barre de titre
            Console.Write("réclamer quelque-chose contre {0} ttt ? (O/N)", Stats.Taptaptap);
            bool YES = false;
            int emoji = 0;

            while (!YES)
            {
                Console.SetCursorPosition(0, 6);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.O:
                        YES = true;
                        drawer.DeleteLine(6);
                        drawer.DeleteLine(5);
                        drawer.DeleteLine(Console.WindowHeight - 2);
                        Console.SetCursorPosition(0, 5);
                        Console.Write("Conversion !");
                        break;
                    case ConsoleKey.N:
                        drawer.DeleteLine(6);
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
                        drawer.DeleteLine(6);
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
                    if (Stats.activeTab != "Carte")
                    {
                        mutexLifeBar = false;
                        Stats.activeTab = "Carte";
                        MenuBar.Display();
                        Map map = new Map();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Z:
                    if (Stats.activeTab != "Inventaire")
                    {
                        mutexLifeBar = false;
                        Stats.activeTab = "Inventaire";
                        MenuBar.Display();
                        Inventory inventory = new Inventory();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.E:
                    if (Stats.activeTab != "Magasin")
                    {
                        mutexLifeBar = false;
                        Stats.activeTab = "Magasin";
                        MenuBar.Display();
                        Shop shop = new Shop();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.R:
                    if (Stats.activeTab != "???")
                    {
                        mutexLifeBar = false;
                        Stats.activeTab = "???";
                        MenuBar.Display();
                        What what = new What();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.T:
                    if (Stats.activeTab != "Options")
                    {
                        mutexLifeBar = false;
                        Stats.activeTab = "Options";
                        MenuBar.Display();
                        Options options = new Options();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Escape:
                    mutexLifeBar = false;
                    options.SaveAndQuit();
                    mutexLifeBar = true;
                    break;
                default:
                    drawer.Cursor_StandBy();
                    break;
            }
        }
        #endregion actions

    }
}


