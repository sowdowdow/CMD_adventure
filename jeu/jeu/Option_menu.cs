using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Options : Action
    {
        public Options()
        {
            bool option_active = false;
            bool changingOfTab = false;
            int pos_curseur = 0;
            int offset = 4; //prevent from displaying over the menu bar
            String[] options = { "Contrôles", "Aide", "Langue", "Crédit", "Sauvegarder & quitter" };
            string curseur = ">>";
            ConsoleColor actualColor = Console.ForegroundColor;  //saving actual color

            void affichage_des_options()
            {
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
                                Controls();
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Help();
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Language();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Credit();
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                SaveAndQuit();
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


        public void Controls()
        {
            drawer.ClearInterface();
            drawer.CenterWrite(4, "Pour changer d'onglet :");
            drawer.CenterWrite(5, "A Z E R T");
            drawer.HorizontalLine(6, '+');
            drawer.CenterWrite(7, "Pour vous déplacer dans les menus :");
            drawer.CenterWrite(8, "/\\");
            drawer.CenterWrite(9, "<  >");
            drawer.CenterWrite(9, "\\/");
            drawer.HorizontalLine(10, '+');
        }
        public void Help()
        {
            drawer.ClearInterface();
            switch (Stats.ProgressLevel)
            {
                case 0:
                    drawer.CenterWrite(Console.WindowHeight / 2, "Allez voir la carte");
                    break;
                default:
                    drawer.CenterWrite(Console.WindowHeight / 2, "Vous avez triché =_='");
                    break;
            }
        }
        public void Language()
        {
            drawer.ClearInterface();
            drawer.CenterWrite(Console.WindowHeight / 2, "en cours de developpement");
        }

        public void Credit()
        {
            drawer.ClearInterface();
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
            int i = Console.WindowHeight / 2 - 5; //line n°
            drawer.DeleteLine(i, Console.WindowHeight - 1); //clear console
            drawer.CenterWrite(i, "Imaginé, réalisé et codé par : Sowdowdow");    //center the text at line 4
            i++;
            drawer.CenterWrite(i, "début dev. : 2017");      //...
            i++;
            drawer.CenterWrite(i, "fin dev. : ~");      //...
            i++;
            drawer.CenterWrite(i, "inspiré de CandyBox2");      //...
            i += 2;
            drawer.CenterWrite(temps_de_jeu); //space the statistics from other things displayed
            i++;
            drawer.CenterWrite(i, premiere_partie);//...

            drawer.CenterWrite(Console.WindowHeight - 1, sprites.player_base);
        }
        public void SaveAndQuit()
        {
            ConsoleColor bg_actuel = Console.BackgroundColor;
            ConsoleColor fg_actuel = Console.ForegroundColor;

            int centre_horizontal = Console.WindowWidth / 2;
            int centre_vertical = Console.WindowHeight / 2;
            string[] yesNo = { "NON", "OUI" };
            string espace = "             ";
            void Quit_True()
            {
                drawer.CenterWrite((Console.WindowHeight / 2) - 2, "Voulez-vous vraiment quitter ?");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(centre_horizontal - espace.Length / 2, centre_vertical);
                Console.Write(yesNo[1]);
                //On remet les couleurs originals
                Console.BackgroundColor = bg_actuel;
                Console.ForegroundColor = fg_actuel;
                Console.Write(espace + yesNo[0]);
                drawer.Cursor_StandBy();
            }
            void Quit_False()
            {
                drawer.CenterWrite((Console.WindowHeight / 2) - 2, "Voulez-vous vraiment quitter ?");
                Console.SetCursorPosition(centre_horizontal - espace.Length / 2, centre_vertical);
                Console.Write(yesNo[1] + espace);

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write(yesNo[0]);
                //Put back the original colors
                Console.BackgroundColor = bg_actuel;
                Console.ForegroundColor = fg_actuel;
                drawer.Cursor_StandBy();
            }
            //Initialisation
            Quit_False();
            //if Quit = TRUE and Enter Key => Quit the game
            bool Quit = false;
            bool exitLoop = false;

            while (exitLoop == false)
            {
                centre_horizontal = Console.WindowWidth / 2;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Quit == true)
                        {
                            Quit = false;
                            Quit_False();
                        }
                        else
                        {
                            Quit = true;
                            Quit_True();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Quit == true)
                        {
                            Quit = false;
                            Quit_False();
                        }
                        else
                        {
                            Quit = true;
                            Quit_True();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (Quit == true)
                        {
                            Stats.fin_du_jeu = true;
                            Stats.WriteSave();
                            exitLoop = true;
                        }
                        else
                        {
                            exitLoop = true;
                        }
                        break;
                    default:
                        drawer.Cursor_StandBy();
                        break;
                }
            }
            Console.BackgroundColor = bg_actuel;
            Console.ForegroundColor = fg_actuel;
        }
    }
}