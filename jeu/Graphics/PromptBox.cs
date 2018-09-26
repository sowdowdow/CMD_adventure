using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    /**
     * The prompt box is visual device allowing the player to prompt text.
     * 
     * The text input has a max length.
     * If it is not defined,it would be set to the box with
     * without the borders.
     * If it exceed the box width, the prompted text would be scrolled
     * 
     * The prompt box has a border pattern.
     * Default is empty.
     * 
     * 
     */
    class PromptBox
    {
        private byte _maxTextLength;
        private Rectangle _box;
        private char _borderPattern;

        public PromptBox(Rectangle box)
        {
            _box = box;
        }

        public PromptBox(Rectangle box, char borderPattern)
        {
            _box = box;
            _borderPattern = borderPattern;
        }

        public PromptBox(byte maxTextLength, Rectangle box, char borderPattern)
        {
            _maxTextLength = maxTextLength;
            _box = box;
            _borderPattern = borderPattern;
        }

        public byte MaxTextLength { get => _maxTextLength; }
        public Rectangle Box { get => _box; }
        public char BorderPattern { get => _borderPattern;}
    }
}
