using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu
{
    class Program
    {
        static void Main(string[] args)
        {

            //on instancie affiche
            jeu Jeu = new jeu();
            Jeu.stat.Temps_de_jeu = DateTime.Now; // la valeur prise ici sera remplacé si une sauvegarde existe
            Jeu.stat.heure_debut_partie = DateTime.Now; //lecture de l'heure actuel (utile si le jeu n'a pas de sauvegarde)

            Jeu.stat.Lecture_Sauvegarde();
            //Jeu.Crazy_Console_Random_Number(); //<--------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "CMD_ adventure";   //défini le titre de la console
            //Jeu.Ecran_titre();            //<--------------------------------------réactiver a la fin du dev.
            Console.Clear(); //efface la console

            Jeu.stat.Taptaptap = 999; //commande de triche

            Jeu.Taptaptap_game();    //lance le jeu tap tap tap
            while (!Jeu.stat.fin_du_jeu)
            {
            Jeu.Barre_menu(Jeu.stat.onglet); //on actualise l'affichage de la barre de menu
            Jeu.Choix_action();
            }

            Jeu.stat.Ecriture_Sauvegarde();
            Console.WriteLine("\nFin du jeu");
            Console.ReadLine();
        }
    }
}