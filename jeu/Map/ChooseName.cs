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

            sprites.Add(new SpriteEntity(Sprite_box._house1, 0, 4));
            sprites.Add(new SpriteEntity(Sprite_box._house2, 30, 5));
            sprites.Add(new SpriteEntity(Sprite_box._dynosaur, 28, 15));

            Decor = new Decor(sprites);
        }
        public override void Play()
        {
            string[] dialogContent =
{
                "Hey Toi !",
                "Je ne t'ai jamais vu ici. . .",
                "Inventer un dialogue ici"
            };
            Dialog dialog = new Dialog(28, 12, 20, 4);
            dialog.AddSentences(dialogContent);
            dialog.Display();
        }
    }
}
