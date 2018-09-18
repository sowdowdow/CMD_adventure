using System;
using System.Threading;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Jeu = new Game();

            Thread thread1 = new Thread(LifeBar.Display);
            thread1.Start();

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