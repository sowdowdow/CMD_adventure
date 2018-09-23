using jeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using levels;

namespace game
{
    public class Map : Action
    {
        public Map()
        {
            LevelsList levelsList = new LevelsList();
            levelsList.PlayLevel(Stats.Player.ProgressLevel);
        }
    }
}