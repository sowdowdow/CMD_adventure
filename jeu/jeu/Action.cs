using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Action
    {
        protected Sprite_box sprites;
        protected GraphicTools drawer;

        public Action()
        {
            this.sprites = new Sprite_box();
            this.drawer = new GraphicTools();

            //First: Clean the map
            drawer.ClearInterface();
        }
    }
}