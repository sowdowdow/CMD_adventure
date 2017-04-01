using System;

namespace jeu
{
    internal class Sprite_box
    {
        public void Affiche_sprite(int largeur, int hauteur,string[] sprite)
        {
            Console.SetCursorPosition(largeur, hauteur);
            foreach (var ligne in sprite) //pour chaque ligne du sprite, on affiche + saut de ligne
            {
                Console.Write(ligne);
                Console.SetCursorPosition(largeur, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.WindowWidth - 3,Console.WindowHeight - 2);
        }
            public string[] Maison1 = {
                "  _______| |__",
                " /            \\",
                "/______________\\",
                "|        __    |",
                "|       | ,|   |",
                "|_______|__|___|"
            };
            public string[] Maison2 = {
                "  _____\\ \\_",
                " /         \\",
                "/  __       \\",
                "| | ,|      |",
                "|_|__|______|"
            };
    }
}