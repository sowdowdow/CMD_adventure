using System;

namespace jeu
{
	class Program
    {
        static void Main(string[] args)
        {

            //on instancie affiche
            Jeu Jeu = new Jeu();

            //on déclare l'éxecution du timer
            Jeu.update_temps_jeu.Elapsed += Jeu.UpdateGameTime;
            Jeu.update_temps_jeu.Enabled = true;
            //Jeu.Taptaptap_game();    //<--------------------------------------réactiver a la fin du dev.			lance le jeu tap tap tap
            Jeu.Barre_menu(Stats.onglet); //on actualise l'affichage de la barre de menu une premiere fois
            while (!Stats.fin_du_jeu)
            {
            Jeu.Choix_action();
            }

        }
    }
}