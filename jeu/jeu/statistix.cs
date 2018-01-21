using System;
using System.Collections.Generic;

namespace jeu
{
    public static class Stats
    {
        //attributs a sauvegarder
        private static int taptaptap;
        private static DateTime date_premiere_partie;
        private static int money;
        private static int vie_max_joueur = 10;
        private static string nom_joueur = "nameless";
        private static int joueur_ATK = 1; //puissance d'attaque du joueur
        private static int niveau_progression = 0;
        private static int temps_de_jeu = 0;   //temps de jeu en secondes
        #region liste_de_sauvegarde
        //a faire
        #endregion liste_de_sauvegarde
        public static void Ecriture_Sauvegarde()
        {
            //efface la console
            Console.Clear();
            //défini l'emplacement de la sauvegarde
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] attributs_sauvegarde = {
                Taptaptap.ToString(),
                Temps_de_jeu.ToString(),
                Money.ToString(),
                Vie_max_joueur.ToString(),
                Nom_joueur.ToString(),
                Joueur_ATK.ToString(),
                Niveau_progression.ToString(),
                Date_premiere_partie.ToString() };
            try
            {
                System.IO.File.WriteAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.save", attributs_sauvegarde);
                Console.Write("Partie sauvegardée");
            }
            catch (Exception)
            {
                Console.Write("Echec sauvegarde");
            }
            System.Threading.Thread.Sleep(1000);

        }
        public static void Lecture_Sauvegarde()
        {
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = null;
            if (System.IO.File.Exists(@"C: \Users\Public\SAVE_CMD_adventure\save.save"))
            {
                //lecture du fichier
                lines = System.IO.File.ReadAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.save");
                //lecture des variables
                try
                {
                    Taptaptap = int.Parse(lines[0]);
                    Temps_de_jeu = int.Parse(lines[1]);
                    Money = int.Parse(lines[2]);
                    Vie_max_joueur = int.Parse(lines[3]);
                    Nom_joueur = lines[4];
                    Joueur_ATK = int.Parse(lines[5]);
                    Niveau_progression = int.Parse(lines[6]);
                    Date_premiere_partie = DateTime.Parse(lines[7]);
                }
                catch (Exception e)
                {
                    Console.Write("Sauvegarde corrompue : \n" + e.Message);
                    
                    for (int i = 0; i < 6; i++) //temps de visibilité du message en secondes
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(".");
                    }
                }
            }
            else
            {
                System.Console.WriteLine(@"/!\ Sauvegarde inexistante");
                System.Threading.Thread.Sleep(1000);
            }
        }

        //attribut sans sauvegarde
        public static int vie_joueur = 1;
        public static bool fin_du_jeu = false;
        public static string onglet = "onglet par defaut";


        #region accesseurs
        public static int Taptaptap { get => taptaptap; set => taptaptap = value; }
        public static int Temps_de_jeu { get => temps_de_jeu; set => temps_de_jeu = value; } //gestion du temps total joué
        public static int Money { get => money; set => money = value; }
        public static int Vie_max_joueur { get => vie_max_joueur; set => vie_max_joueur = value; }
        public static string Nom_joueur { get => nom_joueur; set => nom_joueur = value; }
        public static int Joueur_ATK { get => joueur_ATK; set => joueur_ATK = value; }
        public static int Niveau_progression { get => niveau_progression; set => niveau_progression = value; }
        public static DateTime Date_premiere_partie { get => date_premiere_partie; set => date_premiere_partie = value; } //date de la premiere partie
        #endregion accesseurs


        //Constructeur
        public static void Initializer()
        {
            // la valeur prise ici sera remplacé si une sauvegarde existe
            Date_premiere_partie = DateTime.UtcNow;
            //La lecture de la sauvegarde = automatique --> au démarrage du jeu appel de ce constructeur
            Lecture_Sauvegarde();
        }
    }
}