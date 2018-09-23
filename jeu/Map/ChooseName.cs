using Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace levels
{
    class ChooseName : Level
    {
        public ChooseName()
        {
            List<SpriteEntity> sprites = new List<SpriteEntity>();

            sprites.Add(new SpriteEntity(Sprite_box._neighbourhood1, Console.WindowWidth / 3, 4));
            sprites.Add(new SpriteEntity(Sprite_box._house1, (int)(Console.WindowWidth * 0.2), (int)(Console.WindowHeight * 0.5)));
            sprites.Add(new SpriteEntity(Sprite_box._house2, (int)(Console.WindowWidth * 0.8), (int)(Console.WindowHeight * 0.5)));
            sprites.Add(new SpriteEntity(Sprite_box._dottedFloor1, (int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.9)));
            sprites.Add(new SpriteEntity(Sprite_box._dynosaur1, (int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.7)));

            Decor = new Decor(sprites);
        }
        public override void Play()
        {
            string[] dialogContent =
{
                "Hey Toi !",
                "Je ne t'ai jamais vu ici. . .",
                "Tu es un aventurier ??",
                "Dis moi, quel-est ton nom ?"
            };
            Dialog dialog = new Dialog((int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.5), (int)(Console.WindowWidth * 0.2), (int)(Console.WindowHeight * 0.2));
            dialog.AddSentences(dialogContent);
            dialog.Display();

            // Here PromptBox todo
        }
    }
}
