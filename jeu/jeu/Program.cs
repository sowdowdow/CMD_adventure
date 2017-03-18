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
            Console.Title = "CMD_ adventure";   //défini le titre de la console


            af.ligH('=');
            af.centrage("Bienvenue Dans CMD_ Adventure !");
            af.ligH('=');
            af.affiche("appuyez sur une touche pour continuer...");
            Console.ReadKey(true);  // attend la saisie d'un appui sur clavier
            Console.Clear(); //efface la console
            af.ligH('=');
            af.centrage("Bienvenue Dans CMD_ Adventure !");
            af.ligH('=');
            af.centrage(af.perso_base);


            Console.ReadKey(true);
        }
    }
}
/* Référence utiles:
 * https://msdn.microsoft.com/fr-fr/library/ms228362.aspx#Anchor_4    les séquences d'éhapement de chaîne
 * https://tinyurl.com/lggakbh formatage des chaines de carac.
 * 
 * 
 */
