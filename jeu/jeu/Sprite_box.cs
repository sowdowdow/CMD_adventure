using System;

namespace jeu
{
    internal class Sprite_box
    {
        public void Affiche_sprite(int x_TopToBottom, int y_LeftToRight,string[] sprite)
        {
            Console.SetCursorPosition(x_TopToBottom, y_LeftToRight);
            foreach (var line in sprite) //display each line of the sprite + jumpline
            {
                Console.Write(line);
                Console.SetCursorPosition(x_TopToBottom, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.WindowWidth - 3,Console.WindowHeight - 2);
        }
        //skin du joueur
        public string player_base = "°v°";
        public string player_wow = "*v*";
        public string player_depressed = "-v-";
        //sprite des objets
        public string[] House1 = {
                @"  _______| |__",
                @" /            \",
                @"/______________\",
                @"|        __    |",
                @"|       | ,|   |",
                @"|_______|__|___|"
            };
        public string[] House2 = {
                @"  _____\ \_",
                @" /         \",
                @"/  __       \",
                @"| | ,|      |",
                @"|_|__|______|"
            };
        public string[] Dynosaur = {
                @"      .――――. ",
                @"    ./     0\",
                @"   ././  . \ ",
                @".__/_|―――|_| ",
            };
    }
}