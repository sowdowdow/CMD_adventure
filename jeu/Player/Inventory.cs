using Graphics;
using System;
using System.Collections.Generic;

namespace jeu
{
    public class Inventory
    {
        private Stuff _stuff;
        private List<InventoryObjects> _objects;

        public Stuff Stuff { get => _stuff; set => _stuff = value; }
        public List<InventoryObjects> Objects { get => _objects; set => _objects = value; }

        public Inventory()
        {
            Stuff = new Stuff();
            Objects = new List<InventoryObjects>();
        }

        public override string ToString()
        {
            return Stuff.ToString() + "\n" + Objects.ToArray().ToString();
        }

        public void Display()
        {

            // Drawing the borders and frame
            FrameBuffer frameBuffer = new FrameBuffer();
            char borderStyleV = '|';
            char borderStyleH = '~';

            frameBuffer.AddHorizontalLine(0, borderStyleH);
            frameBuffer.AddHorizontalLine(Console.WindowHeight - 5, borderStyleH);
            frameBuffer.AddHorizontalLine(6, borderStyleH);

            frameBuffer.AddVerticalLine(0, borderStyleV);
            frameBuffer.AddVerticalLine(9, borderStyleV);
            frameBuffer.AddVerticalLine(80, borderStyleV);
            frameBuffer.AddVerticalLine(Console.WindowWidth - 1, borderStyleV);

            // Drawing the actual weapon
            frameBuffer.AddSprite(Stuff.Weapon.Sprite, 1, 1);
            frameBuffer.AddText(Stuff.Weapon.Name + " :", 11, 1);
            frameBuffer.AddText(Stuff.Weapon.Description, 11, 2);
            frameBuffer.AddText($"ATK : {Stuff.Weapon.Attack}, DEF : {Stuff.Weapon.Defense}", 11, 4);
            frameBuffer.AddText($"HP: { Stuff.Weapon.Life} SPD: { Stuff.Weapon.Speed}", 11, 5);

            // Drawing the player and his stats
            frameBuffer.AddText("HERENAMEPLYR", 95, 1); //center player name !
            frameBuffer.AddSprite(Sprites._player_base, 99, 2);



            //Displaying the frame ✅
            frameBuffer.Display();
        }
    }
}