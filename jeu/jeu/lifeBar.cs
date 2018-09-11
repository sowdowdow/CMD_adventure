using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    static class LifeBar
    {
        public static void Display()
        {
            GraphicTools drawer = new GraphicTools();
            while (true)
            {
                if (Game.mutexLifeBar)
                {
                    Game.mutexLifeBar = false;
                    string vie = "Vie: " + Stats.vie_joueur + "/" + Stats.MaxPlayerLife;
                    double coefficient_barre_de_vie = 1 + ((Stats.MaxPlayerLife - Stats.vie_joueur) / Stats.MaxPlayerLife);

                    ConsoleColor previousBackColor = Console.BackgroundColor;
                    ConsoleColor previousForeColor = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.White;
                    //dark green for visibility
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    //avoid visual glitch
                    Console.CursorVisible = false;

                    Console.SetCursorPosition(0, 3);
                    string greenBackground = "";
                    for (int i = 0; i < Console.WindowWidth * coefficient_barre_de_vie; i++)
                    {
                        greenBackground += ' ';
                    }
                    //coloring background
                    Console.Write(greenBackground); 
                    drawer.CenterWrite(3, vie);

                    Console.ForegroundColor = previousForeColor;
                    Console.BackgroundColor = previousBackColor;

                    Console.CursorVisible = true;
                    drawer.Cursor_StandBy();
                    Game.mutexLifeBar = true;
                    drawer.Wait(1000);
                }
            }
        }
    }
}
