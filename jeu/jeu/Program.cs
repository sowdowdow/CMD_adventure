﻿using System;
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
<<<<<<< HEAD
            Console.ForegroundColor = ConsoleColor.DarkYellow;          //-------------objectif gerer la couleur
            Console.Title = "CMD_ adventure";   //défini le titre de la console
            //af.ecran_titre();            //<--------------------------------------réactiver a la fin du dev.
            Console.ReadKey(true);  // attend la saisie d'un appui sur clavier
            Console.Clear(); //efface la console
            af.descente_perso();    //fait descendre le personnage en bas de la console
            af.taptaptap_game();    //lance le jeu tap tap tap

            Console.ReadLine();
=======
            Console.Title = "CMD_ adventure";   //défini le titre de la console


            //af.ecran_titre();            <--------------------------------------réactiver a la fin du dev.
            Console.ReadKey(true);  // attend la saisie d'un appui sur clavier
            Console.Clear(); //efface la console

            af.descente_perso();    //fait descendre le personnage en bas de la console

            Console.ReadKey(true);
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
        }
    }
}
/* Référence utiles:
 * https://msdn.microsoft.com/fr-fr/library/ms228362.aspx#Anchor_4    les séquences d'éhapement de chaîne
 * https://tinyurl.com/lggakbh formatage des chaines de carac.
 * 
 * 
<<<<<<< HEAD
 */
=======
 */
>>>>>>> 13e21d82148039fac17498d9db9114bef3f97f9b
