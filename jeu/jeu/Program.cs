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

            Jeu.stat.Lecture_Sauvegarde();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "CMD_ adventure";   //défini le titre de la console
            Jeu.Ecran_titre();            //<--------------------------------------réactiver a la fin du dev.
            Console.Clear(); //efface la console

            Jeu.stat.Taptaptap = 999;

            Jeu.Descente_perso();    //fait descendre le personnage en bas de la console
            Jeu.Taptaptap_game();    //lance le jeu tap tap tap

            Jeu.Barre_menu();
            Jeu.Choix_action();

            Jeu.stat.Ecriture_Sauvegarde();
            Console.WriteLine("\nFin du jeu");
            Console.ReadLine();
        }
    }
}
/* Référence utiles:
 * https://msdn.microsoft.com/fr-fr/library/ms228362.aspx#Anchor_4    les séquences d'éhapement de chaîne
 * https://tinyurl.com/lggakbh formatage des chaines de carac.
 * 
 * 
 */