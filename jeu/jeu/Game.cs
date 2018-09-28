using Graphics;
using jeu;
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
            // Loading the save
            Stats.Initializer();
            GraphicTools _drawer = new GraphicTools();
            Console.Title = "CMD_ Adventure";   //define console title
            //_drawer.CrazyConsoleRandomNumber();    //<--------------------------------réactiver a la fin du dev.
            Console.ForegroundColor = _UIcolor;
            //_drawer.TitleScreen();                    //<--------------------------------réactiver a la fin du dev.
            new Taptaptap();                 //<--------------------------------réactiver a la fin du dev.
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
            //add 1 second to game time
            Stats.Player.GameTime++;

            //player regeneration loop
            if (_mutexLifeBar == true)
            {
                Stats.Player.Regenerate();
            }
        }
        #endregion timer

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


