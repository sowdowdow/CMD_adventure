using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace game
{
    public class Options : Action
    {
        public Options()
        {
            bool option_active = false;
            bool changingOfTab = false;
            int activeOptionNumber = 0;
            String[] options = { "Contrôles", "Aide", "Langue", "Crédit", "Sauvegarder & quitter" };
            int numberOfOptions = options.Length;
            int longestOption = options.OrderByDescending(s => s.Length).First().Length;
            // 4 is the size of the menu bar
            int freeVerticalSpace = Console.WindowHeight - 4;
            int freeHorizontalSpace = Console.WindowWidth;
            string cursor = ">>";
            ConsoleColor actualColor = Console.ForegroundColor;  //saving actual color


            void displayOptions()
            {
                // initial cursor position
                Console.SetCursorPosition(freeHorizontalSpace / 2, (freeVerticalSpace - numberOfOptions) / 2);
                foreach (string option in options)  //displaying each option
                {
                    Console.SetCursorPosition((option.Length + Console.WindowWidth) / 2, Console.CursorTop += 2);
                    if (option == options[activeOptionNumber])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //displaying cursor at start
                        drawer.CenterWrite(cursor + option);
                    }
                    else
                    {
                        Console.ForegroundColor = actualColor;
                        drawer.CenterWrite(option);
                    }
                }
                drawer.Cursor_StandBy();   //prevent display glitch (override)
            }

            displayOptions();    //Launching the method a first time

            // Loop until an input is encountered
            while (!changingOfTab)
            {
                switch (Console.ReadKey().Key)  //switch for the option to select
                {
                    case ConsoleKey.DownArrow:
                        if (activeOptionNumber < options.Length - 1 && option_active == false)
                        {
                            drawer.ClearInterface();
                            activeOptionNumber++;
                            displayOptions();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (activeOptionNumber > 0 && option_active == false)
                        {
                            drawer.ClearInterface();
                            activeOptionNumber--;
                            displayOptions();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //we go into the desired option
                        option_active = true;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        switch (activeOptionNumber)
                        {
                            case 0:
                                Controls();
                                break;
                            case 1:
                                Help();
                                break;
                            case 2:
                                Language();
                                break;
                            case 3:
                                Credit();
                                break;
                            case 4:
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
                        drawer.ClearInterface();
                        displayOptions();
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
            string[] informations = {
                "",
                "Pour changer d'onglet :",
                "A Z E R T",
                "",
                "-------------------------------------",
                "",
                "Pour vous déplacer dans les menus :",
                "/\\",
                "<  >",
                "\\/",
                "",
                "-------------------------------------",
            };

            drawer.CenterWrite(4, informations);
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
            string firstPlay = "date de votre première partie : " + Stats.DateFirstGame.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));

            //heure minute seconde
            int h = 0, m = 0, s, totalSecondPlayed;
            totalSecondPlayed = Stats.GameTime;
            h = totalSecondPlayed / 3600;
            s = totalSecondPlayed % 3600;
            m = s / 60;
            s = s % 60;

            string temps_jeu_formate = h + "h" + m + "m" + s + "s";
            string temps_de_jeu = "temps de jeu : " + temps_jeu_formate;
            drawer.ClearInterface(); // clear interface

            string[] informations = {
                "Imaginé, réalisé et codé par : Sowdowdow",
                "début dev. : 2017",
                "fin dev. : ~",
                "inspiré de CandyBox2",
                "",
                "",
                temps_de_jeu,
                firstPlay,
            };

            drawer.CenterWrite(Console.WindowHeight / 2 - 5, informations);
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
                            // This is the only case we can quit !
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

            Environment.Exit(0);
        }
    }
}