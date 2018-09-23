using System.Collections.Generic;

namespace levels
{
    /**
     * The level class is used to
     * define a visual map
     */
    internal abstract class Level
    {
        Decor _Decor;
        byte[] _Floor;
        List<Monster> _Monsters;


        public abstract void Play();

        internal Decor Decor { get => _Decor; set => _Decor = value; }
        public byte[] Floor { get => _Floor; set => _Floor = value; }
        internal List<Monster> Monsters { get => _Monsters; set => _Monsters = value; }
    }
}