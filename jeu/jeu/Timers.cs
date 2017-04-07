using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu
{
    class Timers
    {
        public System.Timers.Timer update_temps_de_jeu = new System.Timers.Timer(1000)  //on update toute les secondes
        {
            AutoReset = true
        };
        
        public void Update_temps_jouer(object source, System.Timers.ElapsedEventArgs e)
        {
            statistix.Temps_de_jeu++;
        }
    }
}
