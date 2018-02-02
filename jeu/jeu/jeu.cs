using System;
using System.Globalization;
using System.Timers;

namespace jeu
{
    class Jeu
    {
        //couleur UI
        public static ConsoleColor couleurUI = ConsoleColor.DarkYellow;

        //mutex barre de vie empêche l'activation simultanée de l'affichage de la barre de vie et d'une action 
        public static bool mutexLifeBar = false;

        //instance des monstres (NOM / SKIN / HP / ATK / EXP)
        monstre lapin = new monstre("rabbit", "°o'", 1, 0, 1);
        monstre tortue = new monstre("turtle", "°,o,", 10, 2, 5);
        
        public Sprite_box sprite = new Sprite_box();

        //Constructeur
        public Jeu()
        {
            Stats.Initializer(); //loading save
            Console.Title = "CMD_ adventure";   //define console title
            //Crazy_Console_Random_Number();    //<--------------------------------réactiver a la fin du dev.
            Console.ForegroundColor = couleurUI;
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

        //methodes et fonctions
        #region METHODE_AFFICHAGE
        public static void Curseur_repos()
        {
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);
        }
        public void Affiche(string text)
        {
            Console.Write(text);
        }//console.write()
        public void Affiche(int nb)
        {
            Console.Write(nb);
        }//console.write(int)
        public void LigH(int hauteur, char car)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(car);
            }
        }//affiche une ligne de 1 caractères
        public void LigH(int hauteur, char car, char car2)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth / 2; i++)
            {
                Console.Write(car);
                Console.Write(car2);
            }
        }//affiche une ligne de 2 caractères
        public void Ecran_titre()
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
                Centrage(titre[i]);
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
        }//affiche l'animation du Titre
        public void Centrage(string obj)
        {
            int taille_obj = obj.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(obj);
        }//affiche un objet au centre de la ligne actuelle
        public static void Centrage(int ligne, string obj)
        {
            Console.CursorTop = ligne;
            int taille_obj = obj.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(obj);
        }//affiche un objet au centre de la ligne actuelle
        public static void Wait(int temps)
        {
            System.Threading.Thread.Sleep(temps);
        }//met en pause la console (en MilliSec)
        public void DeleteLig(int ligne)
        { //suppression de ligne
            Console.SetCursorPosition(0, ligne);
            Console.CursorVisible = false;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, ligne);
        }//supprime une ligne a l'ordonné souhaité
        public void DeleteLig(int ligne_d, int ligne_f)

        {   //suppression de ligne d -> f
            for (int j = ligne_d; j < ligne_f; j++)
            {
                Console.SetCursorPosition(0, j);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.CursorVisible = false;
                    Console.Write(" ");
                }
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, ligne_d);
        }//supprime toutes les lignes de D a F
        #endregion METHODE_AFFICHAGE
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
            LigH(0, '=');
            Console.SetCursorPosition(0, 2);
            ConsoleColor fg_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Centrage("tap tap tap !");
            Console.ForegroundColor = fg_actuel;
            LigH(4, '=');
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                Centrage(sprite.perso_base);
                Wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au total)
                Console.Write("\r");
                Centrage("   ");
                Console.Write("\n");
            }
            Centrage(sprite.perso_base);


            //Boucle du jeu ttt (il faut arriver a 1000 ttt)
            while (Stats.Taptaptap < 1000)
            {
                Console.SetCursorPosition(0, 3);
                DeleteLig(3);
                Console.ReadKey();
                Stats.Taptaptap++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                Affiche("ttt: " + Stats.Taptaptap);
                if (Stats.Taptaptap == 10)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("Woaw 10 tap !");
                }
                if (Stats.Taptaptap == 50)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("50 tap !");
                }
                if (Stats.Taptaptap == 100)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("100 tap !!");
                }
                if (Stats.Taptaptap == 200)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("200 tap !!! keep the key pressed ;)");
                }
                if (Stats.Taptaptap == 500)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("500 tap !!!! some more for a gift :)");
                }
                if (Stats.Taptaptap >= 1000)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("1000 tap :o");
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
                        DeleteLig(6);
                        DeleteLig(5);
                        DeleteLig(Console.WindowHeight - 2);
                        Console.SetCursorPosition(0, 5);
                        Console.Write("Conversion !");
                        break;
                    case ConsoleKey.N:
                        DeleteLig(6);
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
                        DeleteLig(6);
                        Console.Write("Vous n'avez pas choisi :/");
                        break;
                }
                Console.CursorVisible = false;
            }
            Console.ReadKey();
            Console.Clear();
        }//mini jeu de début de partie
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
                        DeleteLig(4, Console.WindowHeight - 1);
                        Action_Carte();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        Curseur_repos();
                    }
                    break;
                case ConsoleKey.Z:
                    if (Stats.onglet != "Inventaire")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Inventaire";
                        DisplayBarreMenu(Stats.onglet);
                        DeleteLig(4, Console.WindowHeight - 1);
                        Action_Inventaire();
                        Console.Write("Vous ouvrez votre inventaire");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        Curseur_repos();
                    }
                    break;
                case ConsoleKey.E:
                    if (Stats.onglet != "Magasin")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Magasin";
                        DisplayBarreMenu(Stats.onglet);
                        DeleteLig(4, Console.WindowHeight - 1);
                        Action_Magasin();
                        Console.Write("Vous ouvrez le magasin");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        Curseur_repos();
                    }
                    break;
                case ConsoleKey.R:
                    if (Stats.onglet != "???")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "???";
                        DisplayBarreMenu(Stats.onglet);
                        DeleteLig(4, Console.WindowHeight - 1);
                        Action_What();
                        Console.Write("???");
                        mutexLifeBar = true;
                    }
                    else
                    {
                        Curseur_repos();
                    }
                    break;
                case ConsoleKey.T:
                    if (Stats.onglet != "Options")
                    {
                        mutexLifeBar = false;
                        Stats.onglet = "Options";
                        DisplayBarreMenu(Stats.onglet);
                        DeleteLig(4, Console.WindowHeight - 1);
                        Action_Option();
                        mutexLifeBar = true;
                    }
                    else
                    {
                        Curseur_repos();
                    }
                    break;
                case ConsoleKey.Escape:
                    mutexLifeBar = false;
                    DeleteLig(4, Console.WindowHeight - 1);
                    Option_SauvegarderEtQuitter();
                    mutexLifeBar = true;
                    break;
                default:
                    Curseur_repos();
                    break;
            }
        }
        public void Action_Carte()
        {
            sprite.Affiche_sprite(0, 4, sprite.Maison1);
            sprite.Affiche_sprite(30, 5, sprite.Maison2);
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
            bool changement_onglet = false;
            int pos_curseur = 0;
            int offset = 4; //on ne doit pas afficher par dessus la barre de menu
            String[] options = { "Contrôles", "Aide", "Langue", "Crédit", "Sauvegarder & quitter" };
            string curseur = "=>";
            ConsoleColor actuel = Console.ForegroundColor;  //change la couleur

            void affichage_des_options()
            {
                DeleteLig(4, Console.WindowHeight - 1);
                Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, 4);
                foreach (string option in options)  //affichage de chaque optin
                {
                    Affiche(option);
                    Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, Console.CursorTop += 1);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;   //...

                Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + 4);                          //on positionne le curseur sur la première ligne
                Console.Write(curseur);                                                         //afficher le curseur dès le départ
                Curseur_repos();   //évite de ré-écrire sur l'affichage
            }

            affichage_des_options();    //on lance la boucle

            while (!changement_onglet)
            {
                switch (Console.ReadKey().Key)  //switch pour le choix de l'option a choisir.
                {
                    case ConsoleKey.DownArrow:
                        if (pos_curseur < options.Length - 1 && option_active == false)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset); //...
                            Console.Write("  ");    //on efface le curseur courant
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
                        //on rentre dans l'option voulue
                        option_active = true;
                        switch (pos_curseur)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Option_Controles();
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Option_Aide();
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Option_Langue();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Option_Credit();
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Option_SauvegarderEtQuitter();
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
                        changement_onglet = true;
                        break;
                    case ConsoleKey.Z:
                        changement_onglet = true;
                        break;
                    case ConsoleKey.E:
                        changement_onglet = true;
                        break;
                    case ConsoleKey.R:
                        changement_onglet = true;
                        break;
                    case ConsoleKey.T:
                        changement_onglet = true;
                        break;
                    #endregion touches_vers_retour_choix_onglet
                    default:
                        Curseur_repos();
                        break;
                }
                Curseur_repos();
            }
            Console.ForegroundColor = actuel;
        }
        #endregion actions
        #region Option_
        public void Option_Controles()
        {
            DeleteLig(4, Console.WindowHeight - 1);
            Centrage(4, "Pour changer d'onglet :");
            Centrage(5, "A Z E R T");
            LigH(6, '+');
            Centrage(7, "Pour vous déplacer dans les menus :");
            Centrage(8, "/\\");
            Centrage(9, "<  >");
            Centrage(9, "\\/");
            LigH(10, '+');
        }
        public void Option_Aide()
        {
            DeleteLig(4, Console.WindowHeight - 1);
            switch (Stats.ProgressLevel)
            {
                case 0:
                    Centrage(Console.WindowHeight / 2, "Allez voir la carte");
                    break;
                default:
                    Centrage(Console.WindowHeight / 2, "Vous avez triché =_='");
                    break;
            }
        }
        public void Option_Langue()
        {
            DeleteLig(4, Console.WindowHeight - 1);
            Centrage(Console.WindowHeight / 2, "en cours de developpement");
        }

        public void Option_Credit()
        {
            DeleteLig(4, Console.WindowHeight - 1);
            string premiere_partie = "date de votre première partie : " + Stats.DateFirstGame.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));

            //heure minute seconde
            int h = 0, m = 0, s;
            s = Stats.GameTime;
            h = s / 3600;
            s = s % 3600;
            m = s / 60;
            s = s % 60;

            string temps_jeu_formate = h + "h" + m + "m" + s + "s";
            string temps_de_jeu = "temps de jeu : " + temps_jeu_formate;
            int i = Console.WindowHeight / 2 - 5; //n° ligne
            DeleteLig(i, Console.WindowHeight - 1); //on efface la console
            Centrage(i, "Imaginé, réalisé et codé par : Sowdowdow");    //on centre le texte a la ligne 4
            i++;
            Centrage(i, "début dev. : 2017");      //...
            i++;
            Centrage(i, "fin dev. : ~");      //...
            i++;
            Centrage(i, "inspiré de CandyBox2");      //...
            i += 2;
            Centrage(temps_de_jeu); //on espace les statistiques
            i++;
            Centrage(i, premiere_partie);//...

            Centrage(Console.WindowHeight - 1, sprite.perso_base);
        }
        public void Option_SauvegarderEtQuitter()
        {
            ConsoleColor bg_actuel = Console.BackgroundColor;
            ConsoleColor fg_actuel = Console.ForegroundColor;

            int centre_horizontal = Console.WindowWidth / 2;
            int centre_vertical = Console.WindowHeight / 2;
            string[] yesno = { "NON", "OUI" };
            string espace = "             ";
            void Quit_True()
            {
                Centrage((Console.WindowHeight / 2) - 2, "Voulez-vous vraiment quitter ?");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(centre_horizontal - espace.Length / 2, centre_vertical);
                Console.Write(yesno[1]);
                //On remet les couleurs originals
                Console.BackgroundColor = bg_actuel;
                Console.ForegroundColor = fg_actuel;
                Console.Write(espace + yesno[0]);
                Curseur_repos();
            }
            void Quit_False()
            {
                Centrage((Console.WindowHeight / 2) - 2, "Voulez-vous vraiment quitter ?");
                Console.SetCursorPosition(centre_horizontal - espace.Length / 2, centre_vertical);
                Console.Write(yesno[1] + espace);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(yesno[0]);
                //On remet les couleurs originals
                Console.BackgroundColor = bg_actuel;
                Console.ForegroundColor = fg_actuel;
                Curseur_repos();
            }
            //Initialisation
            Quit_False();
            //si la valeur quitter = VRAI et touche entrée => on quitte
            bool quitter = false;
            bool sortie_boucle = false;

            while (sortie_boucle == false)
            {
                centre_horizontal = Console.WindowWidth / 2;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (quitter == true)
                        {
                            quitter = false;
                            Quit_False();
                        }
                        else
                        {
                            quitter = true;
                            Quit_True();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (quitter == true)
                        {
                            quitter = false;
                            Quit_False();
                        }
                        else
                        {
                            quitter = true;
                            Quit_True();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (quitter == true)
                        {
                            Stats.fin_du_jeu = true;
                            Stats.Ecriture_Sauvegarde();
                            sortie_boucle = true;
                        }
                        else
                        {
                            sortie_boucle = true;
                        }
                        break;
                    default:
                        Curseur_repos();
                        break;
                }
            }
            Console.BackgroundColor = bg_actuel;
            Console.ForegroundColor = fg_actuel;
        }
        #endregion Option_

    }
}