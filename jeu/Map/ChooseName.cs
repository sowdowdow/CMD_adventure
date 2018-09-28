using game;
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

            sprites.Add(new SpriteEntity(Sprites._neighbourhood1, Console.WindowWidth / 3, 4));
            sprites.Add(new SpriteEntity(Sprites._house1, (int)(Console.WindowWidth * 0.2), (int)(Console.WindowHeight * 0.5)));
            sprites.Add(new SpriteEntity(Sprites._house2, (int)(Console.WindowWidth * 0.8), (int)(Console.WindowHeight * 0.5)));
            sprites.Add(new SpriteEntity(Sprites._dottedFloor1, (int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.9)));
            sprites.Add(new SpriteEntity(Sprites._dynosaur1, (int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.7)));

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

            Point dialogPoint = new Point((int)(Console.WindowWidth * 0.4), (int)(Console.WindowHeight * 0.5));
            Point dialogPoint2 = new Point((int)(Console.WindowWidth * 0.6), (int)(Console.WindowHeight * 0.7));

            Dialog dialog = new Dialog(dialogPoint, dialogPoint2);
            dialog.AddSentences(dialogContent);
            dialog.Display();

            // Here prompting the player name
            Point promptPoint = new Point((int)(Console.WindowWidth * 0.6), (int)(Console.WindowHeight * 0.5));
            PromptBox namePrompt = new PromptBox(12, promptPoint, ':');
            string playerName;

            bool sure = false;
            do
            {
                playerName = namePrompt.Prompt();
                namePrompt.Clear();
                dialog = new Dialog(dialogPoint, dialogPoint2);
                dialog.AddSentence(playerName + ", c'est vraiment ton nom ?");
                dialog.Display();

                TwoChoicesPromptBox nameChoiceSure = new TwoChoicesPromptBox(promptPoint);
                sure = nameChoiceSure.Prompt();
            } while (!sure);

            // Here the player name is definitely chosen
            Stats.Player.Name = playerName;

            dialog = new Dialog(dialogPoint, dialogPoint2);

            dialog.AddSentence("Eh bien " + playerName + " ravi de te rencontrer !");

            string secondSentence = (playerName.ToLower() == "tyrex") 
                ? "Figure-toi que c'est mon nom aussi :)"
                : "Moi c'est Tyrex, mais je n'aime pas spécialement parler . . .";
            dialog.AddSentence(secondSentence);

            dialog.AddSentence("Mais laisse-moi te montrer un endroit génial !");
            dialog.Display();

            Stats.Player.ProgressLevel++;
        }
    }
}
