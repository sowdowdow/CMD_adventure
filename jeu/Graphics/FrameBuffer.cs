using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    /**
     * This class aim to improve performances
     * 
     * The operation Console.Write() take a lot of time.
     * So to reduce it to the minimum,
     * FrameBuffer is using a function Display()
     * in order to make only one Console.Write()
     * per frame.
     * 
     * Please note that the buffuring is not taking 
     * the UI in count.
     * 
     * So the buffer start to row 5.
     */
    public class FrameBuffer
    {
        private char[,] _bufferArray;
        public FrameBuffer()
        {
            _bufferArray = new char[Console.WindowWidth, Console.WindowHeight - 4];
            for (int character = 0; character < _bufferArray.Length; character++)
            {
                _bufferArray[character / Height, character / Width] = ' ';
            }
        }
        public int Width
        {
            get
            {
                return _bufferArray.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _bufferArray.GetLength(1);
            }
        }

        public void AddSprite(string[] sprite, int X, int Y)
        {
            SpriteEntity spriteBuffer = new SpriteEntity(sprite, new Point(X, Y));

            if (!spriteBuffer.IsInWindowBoundaries(true))
            {
                throw new Exception("Sprite out of boundaries");
            }


            for (int line = 0; line < sprite.Length; line++)
            {
                for (int character = 0; character < sprite[line].Length; character++)
                {
                    _bufferArray[character + X, line + Y] = sprite[line][character];
                }
            }
        }

        public void Display()
        {
            string stringBuffer = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    stringBuffer += _bufferArray[x, y];
                }
            }
            stringBuffer = stringBuffer.Substring(0, stringBuffer.Length - 1);
            Console.SetCursorPosition(0, 4);
            Console.Write(stringBuffer);
        }
    }
}
