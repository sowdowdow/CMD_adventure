using System;
using System.Collections.Generic;

namespace jeu
{
    public static class Stats
    {
        //attributs a sauvegarder
        private static int taptaptap;
        private static DateTime dateFirstGame;
        private static int money;
        private static int maxPlayerLife = 10;
        private static string playerName = "nameless";
        private static int player_ATK = 1; //puissance d'attaque du joueur
        private static int progressLevel = 0;
        private static int gameTime = 0;   //temps de jeu en secondes

        //attribut sans sauvegarde
        public static int vie_joueur = 1;
        public static bool fin_du_jeu = false;
        public static string onglet = "onglet par defaut";
        private static string SavePathString = @"%APPDATA%\CMD_adventure";

        #region liste_de_sauvegarde
        //a faire
        #endregion liste_de_sauvegarde
        public static void Ecriture_Sauvegarde()
        {
            //efface la console
            Console.Clear();
            //défini l'emplacement de la sauvegarde
            System.IO.Directory.CreateDirectory(SavePathString);
            string[] attributs_sauvegarde = {
                Taptaptap.ToString(),
                GameTime.ToString(),
                Money.ToString(),
                MaxPlayerLife.ToString(),
                PlayerName.ToString(),
                Player_ATK.ToString(),
                ProgressLevel.ToString(),
                DateFirstGame.ToString() };
            try
            {
                System.IO.File.WriteAllLines(SavePathString+@"\save.save", attributs_sauvegarde);
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
            System.IO.Directory.CreateDirectory(SavePathString);
            string[] lines = null;
            if (System.IO.File.Exists(SavePathString + @"\save.save"))
            {
                //lecture du fichier
                lines = System.IO.File.ReadAllLines(SavePathString + @"\save.save");
                //lecture des variables
                try
                {
                    Taptaptap = int.Parse(lines[0]);
                    GameTime = int.Parse(lines[1]);
                    Money = int.Parse(lines[2]);
                    MaxPlayerLife = int.Parse(lines[3]);
                    PlayerName = lines[4];
                    Player_ATK = int.Parse(lines[5]);
                    ProgressLevel = int.Parse(lines[6]);
                    DateFirstGame = DateTime.Parse(lines[7]);
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



        #region accesseurs
        public static int Taptaptap { get => taptaptap; set => taptaptap = value; }
        public static int GameTime { get => gameTime; set => gameTime = value; } //gestion du temps total joué
        public static int Money { get => money; set => money = value; }
        public static int MaxPlayerLife { get => maxPlayerLife; set => maxPlayerLife = value; }
        public static string PlayerName { get => playerName; set => playerName = value; }
        public static int Player_ATK { get => player_ATK; set => player_ATK = value; }
        public static int ProgressLevel { get => progressLevel; set => progressLevel = value; }
        public static DateTime DateFirstGame { get => dateFirstGame; set => dateFirstGame = value; } //date de la premiere partie
        #endregion accesseurs


        //Constructeur
        public static void Initializer()
        {
            // la valeur prise ici sera remplacé si une sauvegarde existe
            DateFirstGame = DateTime.UtcNow;
            //La lecture de la sauvegarde = automatique --> au démarrage du jeu appel de ce constructeur
            Lecture_Sauvegarde();
        }
    }
}