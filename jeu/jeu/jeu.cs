using System;
using System.Globalization;
using System.Timers;

namespace jeu
{
    class Jeu
    {
        //couleur UI
        public static ConsoleColor UIcolor = ConsoleColor.DarkYellow;

        //mutex barre de vie empêche l'activation simultanée de l'affichage de la barre de vie et d'une action 
        public static bool mutexLifeBar = false;

        //instance des monstres (NOM / SKIN / HP / ATK / EXP)
        Monstre lapin = new Monstre("rabbit", "°o'", 1, 0, 1);
        Monstre tortue = new Monstre("turtle", "°,o,", 10, 2, 5);
        
        public Sprite_box sprite = new Sprite_box();
        public Graphic_tools drawer = new Graphic_tools();
        public Option_menu options = new Option_menu();

        //Constructeur
        public Jeu()
        {
            Stats.Initializer(); //loading save
            Console.Title = "CMD_ Adventure";   //define console title
            //Crazy_Console_Random_Number();    //<--------------------------------réactiver a la fin du dev.
            Console.ForegroundColor = UIcolor;
            //Ecran_titre();                    //<--------------------------------réactiver a la fin du dev.
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


        public void Crazy_Console_Random_Number()
        {
            Random lol = new Random();
            int rnd;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
        }//remplie de nombres aléatoires la console
        public void Taptaptap_game()
        {
            Console.Clear();
            drawer.LigH(0, '=');
            Console.SetCursorPosition(0, 2);
            ConsoleColor fg_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            drawer.CenterWrite("tap tap tap !");
            Console.ForegroundColor = fg_actuel;
            drawer.LigH(4, '=');
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                drawer.CenterWrite(sprite.Player_base);
                drawer.Wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au total)
                Console.Write("\r");
                drawer.CenterWrite("   ");
                Console.Write("\n");
            }
            drawer.CenterWrite(sprite.Player_base);


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
        public void DisplayBarreMenu(string onglet)
        {
            String[] menu = { "Carte (a)", "Inventaire (z)", "Magasin (e)", "??? (r)", "Options (t)" };
            int longeur_texte_menu = 0;
            int nombre_obj_menu = 0;
            foreach (string value in menu)
            {
                longeur_texte_menu += value.Length;
                nombre_obj_menu++;
            }
            Console.SetCursorPosition(0, 0);    // Ligne 1
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            Console.SetCursorPosition(0, 1);    //Ligne 2
            for (int i = 0; i < nombre_obj_menu; i++)
            {
                //epacement entre les onglets
                for (int j = 0; j < (Console.WindowWidth - longeur_texte_menu) / (nombre_obj_menu * 2); j++)  //divise par 2 car 2x la même opération
                {
                    Console.Write(" ");
                }
                ConsoleColor actuel = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                //test de l'onglet actif
                if (menu[i].Contains(onglet))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(menu[i]);
                Console.ForegroundColor = actuel;
                //epacement entre les onglets
                for (int j = 1; j < (Console.WindowWidth - longeur_texte_menu) / (nombre_obj_menu * 2); j++)    // <-----------
                {
                    Console.Write(" ");
                }
                if (i < nombre_obj_menu - 1)
                {
                    Console.Write("|");
                }
            }
            // Ligne 3
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            Console.SetCursorPosition(0, 3);    //ligne 4
        }

        #region actions
        public void Choix_action()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    if (Stats.onglet != "Carte")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Carte";
                        DisplayBarreMenu(Stats.onglet);
                        drawer.DeleteLine(4, Console.WindowHeight - 1);
                        Action_Carte();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Z:
                    if (Stats.onglet != "Inventaire")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Inventaire";
                        DisplayBarreMenu(Stats.onglet);
                        drawer.DeleteLine(4, Console.WindowHeight - 1);
                        Action_Inventaire();
                        Console.Write("Vous ouvrez votre inventaire");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.E:
                    if (Stats.onglet != "Magasin")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Magasin";
                        DisplayBarreMenu(Stats.onglet);
                        drawer.DeleteLine(4, Console.WindowHeight - 1);
                        Action_Magasin();
                        Console.Write("Vous ouvrez le magasin");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.R:
                    if (Stats.onglet != "???")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "???";
                        DisplayBarreMenu(Stats.onglet);
                        drawer.DeleteLine(4, Console.WindowHeight - 1);
                        Action_What();
                        Console.Write("???");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.T:
                    if (Stats.onglet != "Options")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Options";
                        DisplayBarreMenu(Stats.onglet);
                        drawer.DeleteLine(4, Console.WindowHeight - 1);
                        Action_Option();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        drawer.Cursor_StandBy();
                    }
                    break;
                case ConsoleKey.Escape:
                    mutexLifeBar = false;
                    drawer.DeleteLine(4, Console.WindowHeight - 1);
                    options.SaveAndQuit();
                    mutexLifeBar = true;
                    break;
                default:
                    drawer.Cursor_StandBy();
                    break;
            }
        }
        public void Action_Carte()
        {
            ChoosingPlayerName();
        }

        private void ChoosingPlayerName()
        {
            sprite.display_sprite(0, 4, sprite.House1);
            sprite.display_sprite(30, 5, sprite.House2);
            sprite.display_sprite(28, 15, sprite.Dynosaur);
            drawer.Write(28, 12, "Hey You !");
            drawer.Cursor_StandBy();
        }

        public void Action_Inventaire()
        {
        }
        public void Action_Magasin()
        {

        }
        public void Action_What()
        {
        }
        public void Action_Option()
        {
            bool option_active = false;
            bool changingOfTab = false;
            int pos_curseur = 0;
            int offset = 4; //prevent from displaying over the menu bar
            String[] options = { "Contrôles", "Aide", "Langue", "Crédit", "Sauvegarder & quitter" };
            string curseur = "»»";
            ConsoleColor actualColor = Console.ForegroundColor;  //saving actual color

            void affichage_des_options()
            {
                drawer.DeleteLine(4, Console.WindowHeight - 1);
                Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, 4);
                foreach (string option in options)  //displaying each option
                {
                    drawer.Write(option);
                    Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, Console.CursorTop += 1);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;   //...

                Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + 4);                          //positionning cursor on the first line
                Console.Write(curseur);                                                         //displaying cursor at start
                drawer.Cursor_StandBy();   //prevent display glitch (override)
            }

            affichage_des_options();    //Launching the method a first time

            while (!changingOfTab)
            {
                switch (Console.ReadKey().Key)  //switch for the option to select
                {
                    case ConsoleKey.DownArrow:
                        if (pos_curseur < options.Length - 1 && option_active == false)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset); //...
                            Console.Write("  ");    //erease current cursor
                            pos_curseur++;
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset);
                            Console.Write(curseur);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (pos_curseur > 0 && option_active == false)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset); //...
                            Console.Write("  ");    //on efface le curseur courant
                            pos_curseur--;
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset);
                            Console.Write(curseur);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //we go into the desired option
                        option_active = true;
                        switch (pos_curseur)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                this.options.Controls();
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                this.options.Help();
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                this.options.Language();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                this.options.Credit();
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                this.options.SaveAndQuit();
                                break;
                            default:
                                //si jamais on rencontre une erreur
                                option_active = false;
                                Console.Write("situation impossible rencontré");
                                break;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        option_active = false;
                        affichage_des_options();
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, 4);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    #region touches_vers_retour_choix_onglet
                    case ConsoleKey.A:
                        changingOfTab = true;
                        break;
                    case ConsoleKey.Z:
                        changingOfTab = true;
                        break;
                    case ConsoleKey.E:
                        changingOfTab = true;
                        break;
                    case ConsoleKey.R:
                        changingOfTab = true;
                        break;
                    case ConsoleKey.T:
                        changingOfTab = true;
                        break;
                    #endregion touches_vers_retour_choix_onglet
                    default:
                        drawer.Cursor_StandBy();
                        break;
                }
                drawer.Cursor_StandBy();
            }
            Console.ForegroundColor = actualColor;
        }
        #endregion actions

    }
}