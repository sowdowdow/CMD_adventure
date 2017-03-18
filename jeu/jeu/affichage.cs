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
        public void ecran_titre()
        {
            string titre = "CMD_ Adventure !";
            string appuyez = "appuyez sur une touche pour continuer...";
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                wait(10);
                Console.Write('=');
            }
            for (int i = 0; i < Console.BufferWidth / 2 - (titre.Length / 2); i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < titre.Length; i++)
            {
                wait(200);
                Console.Write(titre[i]);
            }
            wait(1000);
            Console.Write("\n");
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                wait(10);
                Console.Write('=');
            }

            for (int i = 0; i < appuyez.Length; i++)
            {
                wait(20);
                Console.Write(appuyez[i]);
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
        public void wait(Int16 temps)
        {
            System.Threading.Thread.Sleep(temps);   //temps d'attente de la console en MilliSec.
        }
    }
}