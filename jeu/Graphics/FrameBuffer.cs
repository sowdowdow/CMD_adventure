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
            // TODO
        }

        public void Display()
        {
            string stringBuffer = "";
            foreach (char character in _bufferArray)
            {
                stringBuffer += character;
            }
            Console.SetCursorPosition(0, 4);
            Console.Write(stringBuffer);
        }
    }
}
