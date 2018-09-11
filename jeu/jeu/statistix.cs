using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace game
{
    public static class Stats
    {
        //attributs a sauvegarder
        private static ushort taptaptap;
        private static DateTime dateFirstGame;
        private static int money;
        private static ushort maxPlayerLife = 10;
        private static string playerName = "nameless";
        private static int player_ATK = 1; //puissance d'attaque du joueur
        private static byte progressLevel = 0;
        private static int gameTime = 0;   //temps de jeu en secondes

        //attribut sans sauvegarde
        public static int vie_joueur = 1;
        public static string activeTab = "onglet par defaut";
        private static string savePathString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CMD_adventure");
        private static string saveName = @"\save.json";

        #region liste_de_sauvegarde
        //a faire        
        #endregion liste_de_sauvegarde
        public static void WriteSave()
        {
            //efface la console
            Console.Clear();
            //défini l'emplacement de la sauvegarde
            System.IO.Directory.CreateDirectory(savePathString);

            JObject attributs_sauvegarde = new JObject(
                new JProperty("Taptaptap", Taptaptap),
                new JProperty("GameTime", GameTime),
                new JProperty("Money", Money),
                new JProperty("MaxPlayerLife", MaxPlayerLife),
                new JProperty("PlayerName", PlayerName),
                new JProperty("Player_ATK", Player_ATK),
                new JProperty("ProgressLevel", ProgressLevel),
                new JProperty("DateFirstGame", DateFirstGame)
             );

            try
            {
                File.WriteAllText(savePathString + saveName, attributs_sauvegarde.ToString(Formatting.Indented));
                Console.Write("Partie sauvegardée");
            }
            catch (Exception)
            {
                Console.Write("Echec sauvegarde");
            }
            System.Threading.Thread.Sleep(1000);

        }
        public static void ReadSave()
        {
            System.IO.Directory.CreateDirectory(savePathString);
            string json = null;
            if (System.IO.File.Exists(savePathString + saveName))
            {
                //lecture du fichier
                json = File.ReadAllText(savePathString + saveName);
                JObject parsedJson = JObject.Parse(json);
                //lecture des variables
                try
                {

                    Taptaptap = ushort.Parse(parsedJson["Taptaptap"].ToString());
                    GameTime = int.Parse(parsedJson["GameTime"].ToString());
                    Money = int.Parse(parsedJson["Money"].ToString());
                    MaxPlayerLife = ushort.Parse(parsedJson["MaxPlayerLife"].ToString());
                    PlayerName = parsedJson["PlayerName"].ToString();
                    Player_ATK = int.Parse(parsedJson["Player_ATK"].ToString());
                    ProgressLevel = byte.Parse(parsedJson["ProgressLevel"].ToString());
                    DateFirstGame = DateTime.Parse(parsedJson["DateFirstGame"].ToString());
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
        public static ushort Taptaptap { get => taptaptap; set => taptaptap = value; }
        public static int GameTime { get => gameTime; set => gameTime = value; } //gestion du temps total joué
        public static int Money { get => money; set => money = value; }
        public static ushort MaxPlayerLife { get => maxPlayerLife; set => maxPlayerLife = value; }
        public static string PlayerName { get => playerName; set => playerName = value; }
        public static int Player_ATK { get => player_ATK; set => player_ATK = value; }
        public static byte ProgressLevel { get => progressLevel; set => progressLevel = value; }
        public static DateTime DateFirstGame { get => dateFirstGame; set => dateFirstGame = value; } //date de la premiere partie
        #endregion accesseurs


        //Constructeur
        public static void Initializer()
        {
            // la valeur prise ici sera remplacé si une sauvegarde existe
            DateFirstGame = DateTime.UtcNow;
            //La lecture de la sauvegarde = automatique --> au démarrage du jeu appel de ce constructeur
            ReadSave();
        }
    }
}