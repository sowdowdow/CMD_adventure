using System;

namespace jeu
{
    internal class jeu
    {
        //attributs du jeu
        public string perso_base = "°v°";
        public string perso_wow = "*v*";
        public string perso_deprime = "-v-";

        //on instancie stat
        public statistix stat = new statistix();

        //methodes et fonctions
        public void affiche(string text)
        {
            Console.Write(text);
        }
        public void affiche(int nb)
        {
            Console.Write(nb);
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
            string titre = "CMD_ Adventure";
            string appuyez = "appuyez sur une touche pour continuer...";
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                wait(1000 / Console.WindowWidth);
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
                wait(1000 / Console.WindowWidth);
                Console.Write('=');
            }
            Console.Write("\n");
            for (int i = 0; i < appuyez.Length; i++)
            {
                wait(20);
                Console.Write(appuyez[i]);
            }


        }
        public void descente_perso()
        {
            ligH('=');
            centrage("tap tap tap !");
            Console.WriteLine();
            ligH('=');
            for (int i = Console.CursorTop + 1;i < Console.WindowHeight; i++)
            {
                centrage(perso_base);
                wait(1000 / Console.WindowHeight);  //gestion relative dynamique de la vitesse de descente (1 sec au tot)
                Console.Write("\r");
                centrage("   ");
                Console.Write("\n");
            }
            centrage(perso_base);

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
            while (stat.taptaptap < 1000)
            {   //il faut arriver a 1000 ttt
                Console.SetCursorPosition(0, 3);
                deleteLig(3);
                stat.taptaptap++;
                Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 2);
                affiche("ttt: "+stat.taptaptap);
                Console.SetCursorPosition(0, 0);
                if (stat.taptaptap >= 10)
                {
                    Console.SetCursorPosition(0, 4);
                    affiche("\rWoaw 10 tap !");
                }
                if (stat.taptaptap >= 50)
                {
                    Console.SetCursorPosition(0, 5);
                    affiche("\r50 tap !");
                }
                if (stat.taptaptap >= 100)
                {
                    Console.SetCursorPosition(0, 6);
                    affiche("\r100 tap !!");
                }
                if (stat.taptaptap >= 200)
                {
                    Console.SetCursorPosition(0, 7);
                    affiche("\r200 tap !!!");
                }
                if (stat.taptaptap >= 500)
                {
                    Console.SetCursorPosition(0, 8);
                    affiche("\r500 tap !!!! some more for a gift :)");
                }
                if (stat.taptaptap >= 1000)
                {
                    Console.SetCursorPosition(0, 9);
                    affiche("\r1000 tap :o");
                }
                Console.SetCursorPosition(0, 0);
                Console.ReadLine();
            };
        }
        public void barre_menu()
        {
            String[] menu = { "Carte (a)", "Inventaire (z)", "Magasin (e)" , "Crdt (r)" };
            int longeur_texte_menu = 0;
            int nombre_obj_menu = 0;
            foreach (string value in menu)
            {
                longeur_texte_menu += value.Length;
                nombre_obj_menu++;
            }
            Console.SetCursorPosition(0, 0);    // Ligne 1
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            for (int i = 0; i < nombre_obj_menu; i++)   //Ligne 2
            {
                Console.Write("|");
                for (int j = 0; j < (Console.WindowWidth - longeur_texte_menu) / (nombre_obj_menu*2); j++)  //divise par 2 car 2x la même opération
                {
                    Console.Write(" ");
                }
                Console.Write(menu[i]);
                for (int j = 1; j < (Console.WindowWidth - longeur_texte_menu) / (nombre_obj_menu*2); j++)    // <-----------
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");
            // Ligne 3
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
        }
        public void barre_de_vie()
        {

        }
    }
}