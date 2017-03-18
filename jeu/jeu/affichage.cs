using System;

namespace jeu
{
    internal class affichage
    {
        public void affiche(string text)
        {
            Console.WriteLine(text);
        }
        public void ligH(char car)
        {
            for(int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(car);
            }
        }
        public void ligH(char car,char car2)
        {
            for (int i = 0; i < Console.BufferWidth/2; i++)
            {
                Console.Write(car);
                Console.Write(car2);
            }
        }
    }
}