﻿using System;
using System.Globalization;

namespace jeu
{
    internal class jeu
    {
        //skin du joueur
        public string perso_base = "°v°";
        public string perso_wow = "*v*";
        public string perso_deprime = "-v-";
        //instance des monstres (NOM / SKIN / HP / ATK / EXP)
        monstre lapin = new monstre("lapin", "°o'", 1, 0, 1);
        monstre tortue = new monstre("tortue", "°,o,", 10, 2, 5);

        //on instancie stat / sprite
        public statistix stat = new statistix();
        public Sprite_box sprite = new Sprite_box();

        //methodes et fonctions
        #region METHODE_AFFICHAGE
        public void Affiche(string text)
        {
            Console.Write(text);
        }//console.write()
        public void Affiche(int nb)
        {
            Console.Write(nb);
        }//console.write(int)
        public void LigH(char car)
        {
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(car);
            }
        }//affiche une ligne de 1 caractères
        public void LigH(char car, char car2)
        {
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
                "   ___  __  __  ___       _      _                 _                   ",
                "  / __||  \\/  ||   \\     /_\\  __| |__ __ ___  _ _ | |_  _  _  _ _  ___ ",
                " | (__ | |\\/| || |) |   / _ \\/ _` |\\ V // -_)| ' \\|  _|| || || '_|/ -_)",
                "  \\___||_|  |_||___/___/_/ \\_\\__,_| \\_/ \\___||_||_|\\__| \\_,_||_|  \\___|",
                "                   |___|                                                "};
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
        }//affiche l'animation du Titre
        public void Centrage(string obj)
        {
            int taille_obj = obj.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(obj);
        }//affiche un objet au centre de la ligne actuelle
        public void Centrage(int ligne,string obj)
        {
            Console.CursorTop = ligne;
            int taille_obj = obj.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(obj);
        }//affiche un objet au centre de la ligne actuelle
        public void Wait(int temps)
        {
            System.Threading.Thread.Sleep(temps);
        }//met en pause la console (en MilliSec)
        public void DeleteLig(int ligne)
        { //suppression de ligne
            Console.SetCursorPosition(0, ligne);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, ligne);
        }//supprime une ligne a l'ordonné souhaité
        public void DeleteLig(int ligne_d, int ligne_f)

        {   //suppression de ligne d -> f
            for (int j = ligne_d; j < ligne_f; j++)
            {
                Console.SetCursorPosition(0, j);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, ligne_d);
        }//supprime toutes les lignes de D a F
        #endregion METHODE_AFFICHAGE
        public void Crazy_Console_Random_Number()
        {
            Random lol = new Random();
            int rnd;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 10e3; i++)
            {
                rnd = lol.Next(0, Console.WindowHeight);
                Console.CursorTop = rnd;
                Console.Write(rnd);
                if (Console.ForegroundColor == ConsoleColor.Green)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
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
            Console.SetCursorPosition(0, 0);
            LigH('=');
            Console.SetCursorPosition(0, 2);
            ConsoleColor fg_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Centrage("tap tap tap !");
            Console.ForegroundColor = fg_actuel;
            Console.SetCursorPosition(0, 4);
            LigH('=');
            for (int i = Console.CursorTop + 1; i < Console.WindowHeight; i++)
            {
                Centrage(perso_base);
                Wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au total)
                Console.Write("\r");
                Centrage("   ");
                Console.Write("\n");
            }
            Centrage(perso_base);


            //Boucle du jeu ttt (il faut arriver a 1000 ttt)
            while (stat.Taptaptap < 1000)
            {
                Console.SetCursorPosition(0, 3);
                DeleteLig(3);
                Console.ReadKey();
                stat.Taptaptap++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                Affiche("ttt: " + stat.Taptaptap);
                if (stat.Taptaptap == 10)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("Woaw 10 tap !");
                }
                if (stat.Taptaptap == 50)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("50 tap !");
                }
                if (stat.Taptaptap == 100)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("100 tap !!");
                }
                if (stat.Taptaptap == 200)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("200 tap !!!");
                }
                if (stat.Taptaptap == 500)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("500 tap !!!! some more for a gift :)");
                }
                if (stat.Taptaptap >= 1000)
                {
                    Console.SetCursorPosition(0, 5);
                    DeleteLig(5);
                    Affiche("1000 tap :o");
                }
                Console.SetCursorPosition(0, 5);
            };
            //après 1000 ttt le joueur obtient la barre de titre
            Console.Write("réclamer quelque-chose contre {0} ttt ? (O/N)", stat.Taptaptap);
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
        public void Barre_menu(string onglet)
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
            Barre_de_vie();     //appel de la méthode barre de vie
        }

        public void Barre_de_vie()
        {
            Console.SetCursorPosition(0, 3);
            ConsoleColor actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Affiche("Vie: ");
            Console.ForegroundColor = actuel;
            ConsoleColor couleur_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = Console.CursorLeft; i < Console.WindowWidth; i++)
            {
                Console.Write('█'); //■
            }
            Console.ForegroundColor = couleur_actuel;
        }
        public void Choix_action()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    stat.onglet = "Carte";
                    Barre_menu(stat.onglet);
                    DeleteLig(4, Console.WindowHeight - 1);
                    Action_Carte();
                    Console.Write("Vous ouvrez la carte");
                    break;
                case ConsoleKey.Z:
                    stat.onglet = "Inventaire";
                    Barre_menu(stat.onglet);
                    DeleteLig(4, Console.WindowHeight - 1);
                    Action_Inventaire();
                    Console.Write("Vous ouvrez votre inventaire");
                    break;
                case ConsoleKey.E:
                    stat.onglet = "Magasin";
                    Barre_menu(stat.onglet);
                    DeleteLig(4, Console.WindowHeight - 1);
                    Action_Magasin();
                    Console.Write("Vous ouvrez le magasin");
                    break;
                case ConsoleKey.R:
                    stat.onglet = "???";
                    Barre_menu(stat.onglet);
                    DeleteLig(4, Console.WindowHeight - 1);
                    Action_What();
                    Console.Write("???");
                    break;
                case ConsoleKey.T:
                    stat.onglet = "Options";
                    Barre_menu(stat.onglet);
                    DeleteLig(4, Console.WindowHeight - 1);
                    Action_Option();
                    break;
                default:
                    break;
            }
        }
        #region actions
        public void Action_Carte()
        {

        }
        public void Action_Inventaire()
        {
        }
        public void Action_Magasin()
        {

        }
        public void Action_Aide()
        {
            stat.onglet = "Aide";
        }
        public void Action_What()
        {
        }
        public void Action_Option()
        {
            bool changement_onglet = false;
            string curseur = "=>";
            int pos_curseur = 0;
            int offset = 4; //on ne doit pas afficher par dessus la barre de menu
            String[] options = { "Contrôles", "Aide", "Langue", "Crédit", "Sauvegarder & quitter" };
            Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, 4);
            foreach (string option in options)  //affichage de chaque optin
            {
                Affiche(option);
                Console.SetCursorPosition(curseur.Length + Console.WindowWidth / 2, Console.CursorTop += 1);
            }
            ConsoleColor actuel = Console.ForegroundColor;  //change la couleur
            Console.ForegroundColor = ConsoleColor.Yellow;   //...

            Console.SetCursorPosition(Console.WindowWidth / 2, 4);                          //on positionne le curseur sur la première ligne
            Console.Write(curseur);                                                         //afficher le curseur dès le départ
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);   //évite de ré-écrire sur l'affichage
            while (!changement_onglet)
            {
                switch (Console.ReadKey().Key)  //switch pour le choix de l'option a choisir.
                {
                    case ConsoleKey.DownArrow:
                        if (pos_curseur < options.Length - 1)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset); //...
                            Console.Write("  ");    //on efface le curseur courant
                            pos_curseur++;
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset);
                            Console.Write(curseur);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (pos_curseur > 0)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset); //...
                            Console.Write("  ");    //on efface le curseur courant
                            pos_curseur--;
                            Console.SetCursorPosition(Console.WindowWidth / 2, pos_curseur + offset);
                            Console.Write(curseur);
                        }
                        break;
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
                    case ConsoleKey.Enter:
                        //on rentre dans l'option voulue
                        if (pos_curseur == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Option_Credit();
                        }
                        else
                        {
                            Console.Write("Choississez avec les flèches !");
                        }
                        Console.SetCursorPosition(0, 4);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        break;
                }
                Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);
            }
            Console.ForegroundColor = actuel;
        }
        public void Option_Controles()
        {

        }
        public void Option_Aide()
        {

        }
        public void Option_Langue()
        {

        }

        public void Option_Credit()
        {
            DeleteLig(4, Console.WindowHeight - 1);
            Centrage(4,"Imaginé par Sowdowdow");    //on centre le texte a la ligne 4
            Centrage(5,"Codé par Sowdowdow");       //...
            Centrage(6,"Réalisé par Sowdowdow");      //...
            string premiere_partie = "première partie : " + stat.Temps_de_jeu.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));
            Centrage(7,premiere_partie);//...
        }
        public void Option_SauvegarderEtQuitter()
        {

        }

        #endregion actions
    }
}