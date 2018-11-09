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
        /// <summary>
        /// [Width, Height]
        /// _bufferArray is an array used to bufferize 
        /// every character displayed on the screen.
        /// </summary>
        private char[,] _bufferArray;
        readonly int UIoffset = 4;
        public FrameBuffer()
        {
            _bufferArray = new char[Console.WindowWidth, Console.WindowHeight - 4];
            for (int character = 0; character < _bufferArray.Length; character++)
            {
                _bufferArray[character / Height, character / Width] = ' ';
            }
        }

        /// <summary>
        /// Draw a line of one character on a fixed height
        /// </summary>
        /// <param name="Top">Position of the line from top of the console + 4</param>
        /// <param name="printedCharacter">The character used as a blueprint</param>
        public void AddHorizontalLine(int Top, char printedCharacter)
        {
            if (Top < 0)
                throw new Exception("Top must be greater than 0");
            if (Top > Console.WindowHeight - UIoffset - 1)
                throw new Exception("You must provide a top smaller than Console Height - 4 (UIoffset)");

            for (int left = 0; left < Console.WindowWidth; left++)
            {
                //_bufferArray[left, Top] = printedCharacter;
                _bufferArray[left, Top] = printedCharacter;
            }
        }

        /// <summary>
        /// Draw a Vertical line of one character on a fixed left
        /// </summary>
        /// <param name="Left">Position of the line from left of the console, starting from 0</param>
        /// <param name="printedChararcter">The character used as a blueprint</param>
        public void AddVerticalLine(int Left, char printedChararcter)
        {
            if (Left < 0)
                throw new Exception("Left must be greater than 0");
            if (Left > Console.WindowWidth - 1)
                throw new Exception("You must provide a top smaller than Console Width");

            for (int top = 0; top < Console.WindowHeight - UIoffset - 1; top++)
            {
                _bufferArray[Left, top] = printedChararcter;
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

        /// <summary>
        /// Add a sprite in the buffer that would be rendered in the next Display()
        /// </summary>
        /// <param name="sprite">The sprite to add</param>
        /// <param name="X">Position from Left of the console</param>
        /// <param name="Y">Position from Top of the console (+4 offset from UI)</param>
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

        public void AddSprite(string sprite, int X, int Y)
        {
            AddSprite(new string[] { sprite }, X, Y);
        }

        public void AddText(string text, int X, int Y)
        {
            SpriteEntity spriteBuffer = new SpriteEntity(new string[] { text }, new Point(X, Y));

            if (!spriteBuffer.IsInWindowBoundaries(true))
            {
                throw new Exception("Sprite out of boundaries");
            }
            for (int character = 0; character < text.Length; character++)
            {
                _bufferArray[character + X, Y] = text[character];
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
