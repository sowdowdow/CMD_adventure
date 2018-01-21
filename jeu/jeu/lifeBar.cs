﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu
{
    static class LifeBar
    {
        public static void Display()
        {
            string vie = "Vie: " + Stats.vie_joueur + "/" + Stats.Vie_max_joueur;
            double coefficient_barre_de_vie = 1 + ((Stats.Vie_max_joueur - Stats.vie_joueur) / Stats.Vie_max_joueur);
            ConsoleColor fond_actuel = Console.BackgroundColor;
            ConsoleColor couleur_actuel = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;   //en vert foncé pour la visibilité
            Console.CursorVisible = false; //évite un glitch visuel
            Console.SetCursorPosition(0, 3);
            for (int i = 0; i < Console.WindowWidth * coefficient_barre_de_vie; i++)
            {
                Console.Write(' '); //on colorie le fond
            }
            Jeu.Centrage(3, vie);
            Console.ForegroundColor = Jeu.couleurUI;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = true;
            Jeu.Curseur_repos();
        }
    }
}