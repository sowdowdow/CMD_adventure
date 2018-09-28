using Graphics;
using System;
using System.Collections.Generic;

namespace levels
{
    /**
     * The LevelsList class
     * Contain the whole list of all 
     * the available levels
     */
    public class LevelsList
    {
        private List<Level> _Levels;

        public LevelsList()
        {
            Levels = new List<Level>();
            // Here is the list of all the levels available
            Levels.Add(new ChooseName());
        }

        public void PlayLevel(int level)
        {
            try
            {
                Levels[level].Play();
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write("Vous avez fini mon jeu .-.");
                new GraphicTools().Cursor_StandBy();
            }
        }

        internal List<Level> Levels { get => _Levels; set => _Levels = value; }
    }
}
