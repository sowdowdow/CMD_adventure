using System;
using System.Collections.Generic;

namespace jeu
{
    internal class statistix
    {
        //attributs a sauvegarder
        private int taptaptap;
        private DateTime temps_de_jeu;
        private int money;
        private int vie_max_joueur = 10;
        private string nom_joueur = "nameless";
        private int joueur_ATK = 1; //puissance d'attaque du joueur
        #region liste_de_sauvegarde
//a faire
        #endregion liste_de_sauvegarde
        public void Ecriture_Sauvegarde()
        {
            heure_fin_partie = DateTime.Now; // par défaut sinon la lecture de l'attribut temps de jeu sera invalide
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = { taptaptap.ToString(), temps_de_jeu.ToString(), money.ToString(), vie_max_joueur.ToString(), nom_joueur.ToString(), joueur_ATK.ToString() };
            System.IO.File.WriteAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt", lines);
        }
        public void Lecture_Sauvegarde()
        {
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = null;
            if (System.IO.File.Exists(@"C: \Users\Public\SAVE_CMD_adventure"))
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt");
                int.TryParse(lines[0], out taptaptap);
                DateTime.TryParse(lines[1], out temps_de_jeu);
                int.TryParse(lines[2], out money);
                int.TryParse(lines[3], out vie_max_joueur);
                lines[4] = nom_joueur;
                int.TryParse(lines[4], out joueur_ATK);
            }
            else
            {
                System.Console.WriteLine("Sauvegarde inexistante.");
                System.Threading.Thread.Sleep(1000);
            }
        }
        //attribut sans sauvegarde
        public int vie_joueur;
        public bool fin_du_jeu = false;
        public string onglet = "onglet par defaut";
        public DateTime heure_debut_partie;
        public DateTime heure_fin_partie;


        #region accesseurs
        public int Taptaptap { get => taptaptap; set => taptaptap = value; }
        public DateTime Temps_de_jeu { get => temps_de_jeu + (heure_debut_partie - DateTime.UtcNow); set => temps_de_jeu = value; } //gestion du temps total joué
        public int Money { get => money; set => money = value; }
        public int Vie_max_joueur { get => vie_max_joueur; set => vie_max_joueur = value; }
        public string Nom_joueur { get => nom_joueur; set => nom_joueur = value; }
        #endregion accesseurs
    }
}