using Graphics;
using System.Collections.Generic;

namespace levels
{
    public class Decor
    {
        List<SpriteEntity> _Sprites;

        public Decor(List<SpriteEntity> Sprites)
        {
            _Sprites = Sprites;
            Display();
        }

        public List<SpriteEntity> Sprites { get => _Sprites; }

        internal void Display()
        {
            foreach (SpriteEntity spriteEntity in Sprites)
            {
                spriteEntity.Display();
            }
        }
    }
}