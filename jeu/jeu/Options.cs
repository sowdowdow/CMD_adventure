using Graphics;
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
                        _drawer.CenterWrite(">>" + option + "<<");
                    }
                    else
                    {
                        Console.ForegroundColor = actualColor;
                        _drawer.CenterWrite(option);
                    }
                }
                _drawer.Cursor_StandBy();   //prevent display glitch (override)
            }

            displayOptions();    //Launching the method a first time

            void OpenOption()
            {
                //open the desired option
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
            }

            // Loop until an input is encountered
            while (!changingOfTab)
            {
                switch (Console.ReadKey().Key)  //switch for the option to select
                {
                    case ConsoleKey.DownArrow:
                        if (activeOptionNumber < options.Length - 1 && option_active == false)
                        {
                            _drawer.ClearInterface();
                            activeOptionNumber++;
                            displayOptions();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (activeOptionNumber > 0 && option_active == false)
                        {
                            _drawer.ClearInterface();
                            activeOptionNumber--;
                            displayOptions();
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        OpenOption();
                        break;
                    case ConsoleKey.Enter:
                        OpenOption();
                        break;
                    case ConsoleKey.Backspace:
                        option_active = false;
                        _drawer.ClearInterface();
                        displayOptions();
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
                        _drawer.Cursor_StandBy();
                        break;
                }
                _drawer.Cursor_StandBy();
            }
            Console.ForegroundColor = actualColor;
        }


        public void Controls()
        {
            _drawer.ClearInterface();
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

            _drawer.CenterWrite(4, informations);
        }
        public void Help()
        {
            _drawer.ClearInterface();
            switch (Stats.Player.ProgressLevel)
            {
                case 0:
                    _drawer.CenterWrite(Console.WindowHeight / 2, "Allez voir la carte");
                    break;
                default:
                    _drawer.CenterWrite(Console.WindowHeight / 2, "Vous avez triché =_='");
                    break;
            }
        }
        public void Language()
        {
            _drawer.ClearInterface();
            _drawer.CenterWrite(Console.WindowHeight / 2, "en cours de developpement");
        }

        public void Credit()
        {
            _drawer.ClearInterface();
            string firstPlay = "date de votre première partie : " + Stats.Player.DateFirstGame.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));

            //heure minute seconde
            int h = 0, m = 0, s, totalSecondPlayed;
            totalSecondPlayed = Stats.Player.GameTime;
            h = totalSecondPlayed / 3600;
            s = totalSecondPlayed % 3600;
            m = s / 60;
            s = s % 60;

            string temps_jeu_formate = h + "h" + m + "m" + s + "s";
            string temps_de_jeu = "temps de jeu : " + temps_jeu_formate;
            _drawer.ClearInterface(); // clear interface

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

            _drawer.CenterWrite(Console.WindowHeight / 2 - 5, informations);
            _drawer.CenterWrite(Console.WindowHeight - 1, Sprites._player_base);
        }
        public void SaveAndQuit()
        {
            ConsoleColor bg_actuel = Console.BackgroundColor;
            ConsoleColor fg_actuel = Console.ForegroundColor;
            int horizontalCenter = Console.WindowWidth / 2;
            int verticalCenter = Console.WindowHeight / 2;

            void drawQuitDialogBox(bool isSelected)
            {
                //align center
                string yesSelected = "║      >OUI<         NON       ║";
                string noSelected = "║       OUI         >NON<      ║";
                string[] dialogBox =
                {
                    "╔══════════════════════════════╗",
                    "║Voulez-vous vraiment quitter ?║",
                    (isSelected) ? yesSelected : noSelected,
                    "╚══════════════════════════════╝"
                };

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                _drawer.CenterWrite(verticalCenter - (dialogBox.Length / 2), dialogBox);
                //On remet les couleurs originals
                Console.BackgroundColor = bg_actuel;
                Console.ForegroundColor = fg_actuel;
                _drawer.Cursor_StandBy();
            }

            //Initialisation
            drawQuitDialogBox(false);
            //if Quit = TRUE and Enter Key => Quit the game

            bool Quit = false;
            bool exitLoop = false;

            while (exitLoop == false)
            {
                horizontalCenter = Console.WindowWidth / 2;
                drawQuitDialogBox(Quit);
                switch (Console.ReadKey().Key)
                {
                    //When left and right arrow are used
                    //the opposite option is selected
                    case ConsoleKey.LeftArrow:
                        Quit = !Quit;
                        break;
                    case ConsoleKey.RightArrow:
                        Quit = !Quit;
                        break;
                    case ConsoleKey.Enter:
                        if (Quit == true)
                        {
                            // This is the only case we can quit !
                            Stats.WriteSave();
                            Environment.Exit(0);
                        }
                        else
                        {
                            exitLoop = true;
                            // Here I need to clear the dialogBox
                            string[] cleanBox =
                            {
                                "                                ",
                                "                                ",
                                "                                ",
                                "                                ",
                            };

                        }
                        break;
                    default:
                        _drawer.Cursor_StandBy();
                        break;
                }
            }
            Console.BackgroundColor = bg_actuel;
            Console.ForegroundColor = fg_actuel;
        }
    }
}