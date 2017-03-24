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
            affichage af = new affichage();

            af.stat.Lecture_Sauvegarde();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "CMD_ adventure";   //défini le titre de la console
            //af.ecran_titre();            //<--------------------------------------réactiver a la fin du dev.
            Console.ReadKey(true);  // attend la saisie d'un appui sur clavier
            Console.Clear(); //efface la console

            af.barre_menu();





            af.descente_perso();    //fait descendre le personnage en bas de la console
            af.taptaptap_game();    //lance le jeu tap tap tap
            af.stat.Ecriture_Sauvegarde();
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