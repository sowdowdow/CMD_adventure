using jeu;
using Newtonsoft.Json;
using System;
using System.IO;

namespace game
{
    public static class Stats
    {

        //attributs a sauvegarder 
        private static Player _player = new Player();

        //attribut sans sauvegarde
        public static string _activeTab = "onglet par defaut";
        private static string _savePathString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CMD_adventure");
        private static string _saveName = @"\save.json";

        #region liste_de_sauvegarde
        //a faire        
        #endregion liste_de_sauvegarde
        public static void WriteSave()
        {
            //efface la console
            Console.Clear();
            //défini l'emplacement de la sauvegarde
            System.IO.Directory.CreateDirectory(_savePathString);
            string json = JsonConvert.SerializeObject(Player, Formatting.Indented);

            try
            {
                File.WriteAllText(_savePathString + _saveName, json);
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
            System.IO.Directory.CreateDirectory(_savePathString);
            if (System.IO.File.Exists(_savePathString + _saveName))
            {
                //read the file
                string json = File.ReadAllText(_savePathString + _saveName);

                //Json -> Object
                    Player = JsonConvert.DeserializeObject<Player>(json);
                try
                {
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

        public static Player Player { get => _player; set => _player = value; }


        //Constructeur
        public static void Initializer()
        {
            //Read the save automatically during game initialization
            ReadSave();
        }
    }
}