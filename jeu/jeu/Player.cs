using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    /**
     * This class define all the caracteristics
     * from the player
     */
    public class Player
    {
        private const int baseMaxLife = 10;
        private string name;
        private int money;
        private int spentMoney;
        private int maxLife;
        private int life;
        private int baseAttack;
        private int baseDefense;
        private int attack;
        private int defense;
        private int musculationLevel;
        private int totalMonstersKilled;
        private int regenerationSpeed;

        private DateTime dateFirstGame;
        private ushort taptaptapScore;
        private int progressLevel;
        private int gameTime;

        public Player()
        {
            name = "nameless";
            money = 0;
            spentMoney = 0;
            maxLife = baseMaxLife;
            life = 1;
            baseAttack = 1;
            baseDefense = 0;
            attack = baseAttack;
            defense = baseDefense;
            musculationLevel = 0;
            totalMonstersKilled = 0;
            regenerationSpeed = 1;

            dateFirstGame = DateTime.Now;
            taptaptapScore = 0;
            progressLevel = 0;
            gameTime = 0;
        }

        public static int BaseMaxLife => baseMaxLife;
        public string Name { get => name; set => name = value; }
        public int Money { get => money; set => money = value; }
        public int SpentMoney { get => spentMoney; set => spentMoney = value; }
        public int MaxLife { get => maxLife; set => maxLife = value; }
        public int Life { get => life; set => life = value; }
        public int BaseAttack { get => baseAttack; set => baseAttack = value; }
        public int BaseDefense { get => baseDefense; set => baseDefense = value; }
        public DateTime DateFirstGame { get => dateFirstGame; set => dateFirstGame = value; }
        public ushort TaptaptapScore { get => taptaptapScore; set => taptaptapScore = value; }
        public int ProgressLevel { get => progressLevel; set => progressLevel = value; }
        public int GameTime { get => gameTime; set => gameTime = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int MusculationLevel { get => musculationLevel; set => musculationLevel = value; }
        public int TotalMonstersKilled { get => totalMonstersKilled; set => totalMonstersKilled = value; }
        public int RegenerationSpeed { get => regenerationSpeed; set => regenerationSpeed = value; }
    }
}