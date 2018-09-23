using System;

namespace Graphics
{
    /**
     * This class represent a visual entity
     * of a sprite.
     */
    public class SpriteEntity
    {
        string[] _Sprite;
        Point _Coordinates;

        public SpriteEntity(string[] Sprite, Point Coordinates)
        {
            _Sprite = Sprite;
            _Coordinates = Coordinates;
        }

        public SpriteEntity(string[] Sprite, int X, int Y)
        {
            _Sprite = Sprite;
            _Coordinates = new Point(X, Y);
        }

        //Display the spriteEntity on his coordinates
        public void Display()
        {
            Console.SetCursorPosition(Coordinates.Abscissa, Coordinates.Ordinate);
            foreach (var line in Sprite)
            {
                Console.Write(line);
                Console.SetCursorPosition(Coordinates.Abscissa, Console.CursorTop + 1);
            }
            new GraphicTools().Cursor_StandBy();
        }

        public string[] Sprite { get => _Sprite; }
        public Point Coordinates { get => _Coordinates; set => _Coordinates = value; }
    }
}
