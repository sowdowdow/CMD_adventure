using System;
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
            Graphic_tools drawer = new Graphic_tools();
            while (true)
            {
                if (Jeu.mutexLifeBar)
                {
                    Jeu.mutexLifeBar = false;
                    string vie = "Vie: " + Stats.vie_joueur + "/" + Stats.MaxPlayerLife;
                    double coefficient_barre_de_vie = 1 + ((Stats.MaxPlayerLife - Stats.vie_joueur) / Stats.MaxPlayerLife);

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
                    drawer.CenterWrite(3, vie);
                    Console.ForegroundColor = Jeu.UIcolor;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    drawer.Cursor_StandBy();
                    Jeu.mutexLifeBar = true;
                    drawer.Wait(1000);
                }
            }
        }
    }
}
