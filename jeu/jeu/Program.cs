using System;

namespace jeu
{
	class Program
    {
        static void Main(string[] args)
        {

            //on instancie affiche
            jeu Jeu = new jeu();

            //on déclare l'éxecution du timer
            Jeu.update_temps_jeu.Elapsed += Jeu.Update_temps;
            Jeu.update_temps_jeu.Enabled = true;


            //Jeu.Taptaptap_game();    //<--------------------------------------réactiver a la fin du dev.			lance le jeu tap tap tap
            Jeu.Barre_menu(Jeu.stat.onglet); //on actualise l'affichage de la barre de menu une premiere fois
            while (!Jeu.stat.fin_du_jeu)
            {
            Jeu.Choix_action();
            }

        }
    }
}