using System;
using System.Threading;

namespace jeu
{
	class Program
    {
        static void Main(string[] args)
        {
            Jeu Jeu = new Jeu();

            Jeu.DisplayBarreMenu(Stats.onglet); //refresh menu bar before thread start to prevent visual glitch
            Thread thread1 = new Thread(LifeBar.Display);
            thread1.Start();

            //on déclare l'éxecution du timer
            Jeu.update_temps_jeu.Elapsed += Jeu.UpdateGameTime;
            Jeu.update_temps_jeu.Enabled = true;
            //Jeu.Taptaptap_game();    //<--------------------------------------réactiver a la fin du dev.			lance le jeu tap tap tap
            while (!Stats.fin_du_jeu)
            {
                if (Jeu.mutexLifeBar)
                {
                    Jeu.Choix_action();
                }
            }
        }
    }
}