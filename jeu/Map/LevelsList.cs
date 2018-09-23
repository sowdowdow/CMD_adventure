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
            Levels[level].Play();
        }

        internal List<Level> Levels { get => _Levels; set => _Levels = value; }
    }
}
