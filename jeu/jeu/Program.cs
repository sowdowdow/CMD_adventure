using System;

namespace jeu
{
	class Program
    {
        static void Main(string[] args)
        {

            //on instancie affiche
            jeu Jeu = new jeu();
            Jeu.stat.Date_premiere_partie = DateTime.UtcNow; // la valeur prise ici sera remplacé si une sauvegarde existe
            statistix.vie_joueur = Jeu.stat.Vie_max_joueur;

            //on déclare l'éxecution du timer
            Jeu.update_temps_jeu.Elapsed += Jeu.Update_temps;
            Jeu.update_temps_jeu.Enabled = true;

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

            Jeu.Wait(1500);
        }
    }
}