﻿using System;
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
            Jeu.gameTimeTimer.Elapsed += Jeu.UpdateGameTime;
            Jeu.gameTimeTimer.Enabled = true;
            while (!Stats.fin_du_jeu)
            {
                if (Game.mutexLifeBar)
                {
                    Jeu.ActionChoice();
                }
            }
        }
    }
}