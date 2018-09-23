using System.Collections.Generic;

namespace levels
{
    public class LevelsList
    {
        private List<Level> _Levels;

        public LevelsList()
        {
            Levels = new List<Level>();
            Levels.Add(new ChooseName());
        }

        public void PlayLevel(int level)
        {
            Levels[level].Play();
        }

        internal List<Level> Levels { get => _Levels; set => _Levels = value; }
    }
}
