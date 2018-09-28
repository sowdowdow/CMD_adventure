using FileAccess;
using jeu;

namespace game
{
    public static class Stats
    {

        //attributs a sauvegarder 
        private static Player _player = new Player();

        //attribut sans sauvegarde
        public static string _activeTab = "onglet par defaut";

        public static Player Player { get => _player; set => _player = value; }


        // used to initialize the game
        public static void Initializer()
        {
            //Read the save automatically during game initialization
            Save.Read(ref _player);
        }

        public static void WriteSave()
        {
            Save.Write(_player);
        }
    }
}