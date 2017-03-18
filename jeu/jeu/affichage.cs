using System;

namespace jeu
{
    internal class affichage
    {
<<<<<<< HEAD
        //attributs du jeu
        public string perso_base = "°v°";
        public string perso_wow = "*v*";
        public string perso_deprime = "-v-";


        //définition de l'objet stat
        statistix stat = new statistix();


        //methodes et fonctions
=======
        public string perso_base = "°v°";
        public string perso_wow = "*v*";
        public string perso_deprime = "-v-";
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
        public void affiche(string text)
        {
            Console.WriteLine(text);
        }
        public void affiche(int nb)
        {
            Console.WriteLine(nb);
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
<<<<<<< HEAD
            string titre = "CMD_ Adventure";
            string appuyez = "appuyez sur une touche pour continuer...";
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                wait(1000 / Console.WindowWidth);
                Console.Write('=');
            }

=======
            string titre = "CMD_ Adventure !";
            string appuyez = "appuyez sur une touche pour continuer...";
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                wait(10);
                Console.Write('=');
            }
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
            for (int i = 0; i < Console.BufferWidth / 2 - (titre.Length / 2); i++)
            {
                Console.Write(" ");
            }
<<<<<<< HEAD
=======

>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
            for (int i = 0; i < titre.Length; i++)
            {
                wait(200);
                Console.Write(titre[i]);
            }
            wait(1000);
            Console.Write("\n");
            for (int i = 0; i < Console.BufferWidth; i++)
            {
<<<<<<< HEAD
                wait(1000 / Console.WindowWidth);
                Console.Write('=');
            }
            Console.Write("\n");
=======
                wait(10);
                Console.Write('=');
            }

>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
            for (int i = 0; i < appuyez.Length; i++)
            {
                wait(20);
                Console.Write(appuyez[i]);
            }


        }
        public void descente_perso()
        {
            ligH('=');
<<<<<<< HEAD
            centrage("tap tap tap !");
=======
            Console.Write("\n");
            centrage("Bienvenue Dans CMD_ Adventure !");
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
            Console.WriteLine();
            ligH('=');
            for (int i = Console.CursorTop + 1;i < Console.WindowHeight; i++)
            {
                centrage(perso_base);
<<<<<<< HEAD
                wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au tot)
=======
                wait(100);
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
                Console.Write("\r");
                centrage("   ");
                Console.Write("\n");
            }
            centrage(perso_base);
<<<<<<< HEAD

=======
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
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
            Console.Write(obj);
        }
<<<<<<< HEAD
        public void wait(int temps)
        {
            System.Threading.Thread.Sleep(temps);   //temps d'attente de la console en MilliSec.
        }
        public void deleteLig(int ligne)
        { //suppression de ligne
            Console.SetCursorPosition(0, ligne);
            for(int i = 0;i < Console.WindowWidth;i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, ligne);
        }
        public void deleteLig(int ligne_d,int ligne_f)

        {   //suppression de ligne d -> f
            for(int j = ligne_d;j < ligne_f; j++)
            {
                Console.SetCursorPosition(0, j);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
            }         
            Console.SetCursorPosition(0, ligne_d);
        }
        public void taptaptap_game()
        {
            stat.taptaptap = 0;
            while (stat.taptaptap < 1000)
            {
                Console.SetCursorPosition(0, 3);
                deleteLig(3);
                stat.taptaptap++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                affiche("ttt: "+stat.taptaptap);
                Console.SetCursorPosition(0, 3);
                if (stat.taptaptap == 10)
                {
                    Console.SetCursorPosition(0, 4);
                    affiche("\rWoaw 10 tap !");
                }
                if (stat.taptaptap == 50)
                {
                    Console.SetCursorPosition(0, 5);
                    affiche("\r50 tap !");
                }
                if (stat.taptaptap == 100)
                {
                    Console.SetCursorPosition(0, 6);
                    affiche("\r100 tap !!");
                }
                if (stat.taptaptap == 200)
                {
                    Console.SetCursorPosition(0, 7);
                    affiche("\r200 tap !!!");
                }
                if (stat.taptaptap == 500)
                {
                    Console.SetCursorPosition(0, 8);
                    affiche("\r500 tap !!!! some more for a gift :)");
                }
                if (stat.taptaptap == 1000)
                {
                    Console.SetCursorPosition(0, 9);
                    affiche("\r1000 tap :o");
                }
                Console.ReadLine();
            };
        }
=======
        public void wait(Int16 temps)
        {
            System.Threading.Thread.Sleep(temps);   //temps d'attente de la console en MilliSec.
        }
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
    }
}