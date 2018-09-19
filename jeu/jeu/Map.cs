using jeu;
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
            switch (Stats.Player.ProgressLevel)
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
            _sprites.DisplaySprite(0, 4, _sprites._house1);
            _sprites.DisplaySprite(30, 5, _sprites._house2);
            _sprites.DisplaySprite(28, 15, _sprites._dynosaur);

            string[] dialogContent =
            {
                "Hey Toi !",
                "Je ne t'ai jamais vu ici. . .",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };
            Dialog dialog = new Dialog(28, 12, 20, 4);
            dialog.AddSentences(dialogContent);
            dialog.Display();
        }
        private void DiscoveringTheMap()
        {

        }
    }
}