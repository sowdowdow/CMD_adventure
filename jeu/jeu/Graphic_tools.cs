using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class GraphicTools
    {
        //methodes et fonctions
        #region METHODE_AFFICHAGE
        public void Cursor_StandBy()
        {
            //place the cursor down right the console in pause
            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);
        }
        public void Write(string text)
        {
            Console.Write(text);
        }//console.write()
        public void Write(int nb)
        {
            Console.Write(nb);
        }//console.write(int)
        public void Write(int x_LeftToRightm, int y_TopToBottom, string textToDisplay)
        {
            Console.SetCursorPosition(x_LeftToRightm, y_TopToBottom);
            Console.Write(textToDisplay);
        }
        public void HorizontalLine(int hauteur, char car)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(car);
            }
        }//affiche une ligne de 1 caractères
        public void HorizontalLine(int hauteur, char car, char car2)
        {
            Console.SetCursorPosition(0, hauteur);
            for (int i = 0; i < Console.BufferWidth / 2; i++)
            {
                Console.Write(car);
                Console.Write(car2);
            }
        }//affiche une ligne de 2 caractères
        public void TitleScreen()
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
                CenterWrite(titre[i]);
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
        public void CenterWrite(string text)
        {
            int taille_obj = text.Length / 2;
            Console.CursorLeft = Console.BufferWidth / 2 - taille_obj;
            Console.Write(text);
        }//affiche un objet au centre de la ligne actuelle
        public void CenterWrite(int ligne, string obj)
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
        public void DeleteLine(int ligne)
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
        public void DeleteLine(int ligne_d, int ligne_f)

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

        public void ClearInterface()
        {
            DeleteLine(4, Console.WindowHeight - 1);
        }
        #endregion METHODE_AFFICHAGE
    }
}