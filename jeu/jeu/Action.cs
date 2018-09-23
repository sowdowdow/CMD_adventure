using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Action
    {
        protected GraphicTools _drawer;

        public Action()
        {
            _drawer = new GraphicTools();

            //First: Clean the map
            _drawer.ClearInterface();
        }
    }
}