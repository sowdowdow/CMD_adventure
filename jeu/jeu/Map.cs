using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Map : Action
    {
        public Map()
        {
            switch (Stats.ProgressLevel)
            {
                case 0:
                    ChoosingPlayerName();
                    break;
                case 1:
                    DiscoveringTheMap();
                    break;
                default:
                    throw new Exception("Default case should not be called");
            }

        }
        private void ChoosingPlayerName()
        {
            sprites.DisplaySprite(0, 4, sprites.house1);
            sprites.DisplaySprite(30, 5, sprites.house2);
            sprites.DisplaySprite(28, 15, sprites.dynosaur);
            drawer.Write(28, 12, "Hey Toi !");
            drawer.Cursor_StandBy();
        }
        private void DiscoveringTheMap()
        {

        }
    }
}