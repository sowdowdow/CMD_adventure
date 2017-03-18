using System;

namespace jeu
{
    internal class affichage
    {
        public string perso_base = "°v°";
        public string perso_wow = "*v*";
        public string perso_deprime = "-v-";
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
        public void centrage(string obj)
        {
            int taille_obj = obj.Length/2;
            for (int i = 0; i < Console.BufferWidth / 2 - taille_obj; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(obj);
        }
    }
}