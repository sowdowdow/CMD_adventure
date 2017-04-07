using System;

namespace jeu
{
	class Program
    {
        static void Main(string[] args)
        {

            //on instancie affiche
            jeu Jeu = new jeu();
            Timers timers = new Timers();
            Jeu.stat.Date_premiere_partie = DateTime.UtcNow; // la valeur prise ici sera remplacé si une sauvegarde existe
            Jeu.stat.vie_joueur = Jeu.stat.Vie_max_joueur;

            //on déclare l'éxecution des différents timers
            timers.update_temps_de_jeu.Elapsed += timers.Update_temps_jouer;
            timers.update_temps_de_jeu.Enabled = true;

            Jeu.stat.Lecture_Sauvegarde();
            //Jeu.Crazy_Console_Random_Number(); //<--------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "CMD_ adventure";   //défini le titre de la console
            //Jeu.Ecran_titre();            //<--------------------------------------réactiver a la fin du dev.
            Console.Clear(); //efface la console


            //Jeu.Taptaptap_game();    /<--------------------------------------réactiver a la fin du dev.			lance le jeu tap tap tap
            Jeu.Barre_menu(Jeu.stat.onglet); //on actualise l'affichage de la barre de menu une premiere fois
            while (!Jeu.stat.fin_du_jeu)
            {
            Jeu.Choix_action();
            }

            Jeu.stat.Ecriture_Sauvegarde();
            Console.WriteLine("\nFin du jeu");
            Jeu.Wait(1500);
        }
    }
}