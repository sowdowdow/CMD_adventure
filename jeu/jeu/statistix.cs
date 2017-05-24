using System;
using System.Collections.Generic;

namespace jeu
{
    internal class statistix
    {
        //attributs a sauvegarder
        private int taptaptap;
        private DateTime date_premiere_partie;
        private int money;
        private int vie_max_joueur = 10;
        private string nom_joueur = "nameless";
        private int joueur_ATK = 1; //puissance d'attaque du joueur
        private int niveau_progression = 0;
        private int temps_de_jeu = 0;   //temps de jeu en secondes
        #region liste_de_sauvegarde
        //a faire
        #endregion liste_de_sauvegarde
        public void Ecriture_Sauvegarde()
        {
            //efface la console
            Console.Clear();
            //défini l'emplacement de la sauvegarde
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = { taptaptap.ToString(), temps_de_jeu.ToString(), money.ToString(), vie_max_joueur.ToString(), nom_joueur.ToString(), Joueur_ATK.ToString(), Niveau_progression.ToString(), date_premiere_partie.ToString() };
            try
            {
                System.IO.File.WriteAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt", lines);
                Console.Write("Partie sauvegardée");
            }
            catch (Exception)
            {
                Console.Write("Echec sauvegarde");
            }
            System.Threading.Thread.Sleep(1000);

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
                DateTime.TryParse(lines[1], out date_premiere_partie);
                int.TryParse(lines[2], out money);
                int.TryParse(lines[3], out vie_max_joueur);
                lines[4] = nom_joueur;
                int.TryParse(lines[4], out joueur_ATK);
                int.TryParse(lines[5], out niveau_progression);
                int.TryParse(lines[6], out temps_de_jeu);
            }
            else
            {
                System.Console.WriteLine("Sauvegarde inexistante.");
                System.Threading.Thread.Sleep(1000);
            }
        }

        //attribut sans sauvegarde
        public static int vie_joueur = 0;
        public bool fin_du_jeu = false;
        public string onglet = "onglet par defaut";


        #region accesseurs
        public int Taptaptap { get => taptaptap; set => taptaptap = value; }
        public int Temps_de_jeu { get => temps_de_jeu; set => temps_de_jeu = value; } //gestion du temps total joué
        public int Money { get => money; set => money = value; }
        public int Vie_max_joueur { get => vie_max_joueur; set => vie_max_joueur = value; }
        public string Nom_joueur { get => nom_joueur; set => nom_joueur = value; }
        public int Joueur_ATK { get => joueur_ATK; set => joueur_ATK = value; }
        public int Niveau_progression { get => niveau_progression; set => niveau_progression = value; }
        public DateTime Date_premiere_partie { get => date_premiere_partie; set => date_premiere_partie = value; } //date de la premiere partie
        #endregion accesseurs


        //Constructeur
        public statistix()
        {
            //La lecture de la sauvegarde = automatique --> au démarrage du jeu appel de ce constructeur
            Lecture_Sauvegarde();
        }


        //Destructeur
        ~statistix()
        {
            //L'écriture de la sauvegarde = automatique --> appel de ce destructeur
            Ecriture_Sauvegarde();
        }
    }
}