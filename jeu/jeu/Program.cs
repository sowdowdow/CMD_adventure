using System;
using System.Threading;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Jeu = new Game();

            Thread lifeBarThread = new Thread(LifeBar.Display);
            lifeBarThread.Start();

            //on déclare l'éxecution du timer
            Jeu._gameTimeTimer.Elapsed += Jeu.UpdateGameTime;
            Jeu._gameTimeTimer.Enabled = true;

            while (true)
            {
                if (Game._mutexLifeBar)
                {
                    Jeu.ActionChoice();
                }
            }
        }
    }
}