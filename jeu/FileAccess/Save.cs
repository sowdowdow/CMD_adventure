using Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public static class Save
    {
        public static void Write<T>(T Player)
        {
            Console.Clear();
            Loader loader = new Loader(0, 0);

            // define the save directory if it 
            // does not already exists
            Directory.CreateDirectory(FileVars._gameDirectory);
            string json = JsonConvert.SerializeObject(Player, Formatting.Indented);

            try
            {
                File.WriteAllText(FileVars._gameDirectory + FileVars._saveName, json);
                Console.Write("Partie sauvegardée");
            }
            catch (Exception)
            {
                Console.Write("Echec sauvegarde");
            }
            System.Threading.Thread.Sleep(1000);
        }

        public static void Read<T>(ref T Player)
        {
            System.IO.Directory.CreateDirectory(FileVars._gameDirectory);
            if (System.IO.File.Exists(FileVars._gameDirectory + FileVars._saveName))
            {
                //read the file
                string json = File.ReadAllText(FileVars._gameDirectory + FileVars._saveName);

                //Json -> Object
                Player = JsonConvert.DeserializeObject<T>(json);
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
    }
}