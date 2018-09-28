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
        private const int _baseMaxLife = 10;
        private string _name;
        private int _money;
        private int _spentMoney;
        private int _maxLife;
        private int _life;
        private int _baseAttack;
        private int _baseDefense;
        private int _attack;
        private int _defense;
        private int _musculationLevel;
        private int _musculationSessionsCount;
        private int _totalMonstersKilled;
        private int _regenerationSpeed;

        private DateTime _dateFirstGame;
        private ushort _taptaptapScore;
        private int _progressLevel;
        private int _gameTime;

        public Player()
        {
            _name = "nameless";
            _money = 0;
            _spentMoney = 0;
            _maxLife = _baseMaxLife;
            _life = 1;
            _baseAttack = 1;
            _baseDefense = 0;
            _attack = _baseAttack;
            _defense = _baseDefense;
            _musculationLevel = 0;
            _totalMonstersKilled = 0;
            _regenerationSpeed = 1;

            _dateFirstGame = DateTime.Now;
            _taptaptapScore = 0;
            _progressLevel = 0;
            _gameTime = 0;
        }

        public static int BaseMaxLife => _baseMaxLife;
        public string Name { get => _name; set => _name = value; }
        public int Money { get => _money; set => _money = value; }
        public int SpentMoney { get => _spentMoney; set => _spentMoney = value; }
        public int MaxLife { get => _maxLife; set => _maxLife = value; }
        public int Life
        {
            get => _life;
            set
            {
                if (value < 0)
                {
                    _life = 0;
                }
                else
                {
                    _life = value;
                }
                if (value > MaxLife)
                {
                    _life = MaxLife;
                }
                else
                {
                    _life = value;
                }
            }
        }

        public void Regenerate()
        {
            Life += RegenerationSpeed;
        }

        public int BaseAttack { get => _baseAttack; set => _baseAttack = value; }
        public int BaseDefense { get => _baseDefense; set => _baseDefense = value; }
        public DateTime DateFirstGame { get => _dateFirstGame; set => _dateFirstGame = value; }
        public ushort TaptaptapScore { get => _taptaptapScore; set => _taptaptapScore = value; }
        public int ProgressLevel { get => _progressLevel; set => _progressLevel = value; }
        public int GameTime { get => _gameTime; set => _gameTime = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public int MusculationLevel { get => _musculationLevel; set => _musculationLevel = value; }
        public int TotalMonstersKilled { get => _totalMonstersKilled; set => _totalMonstersKilled = value; }
        public int RegenerationSpeed { get => _regenerationSpeed; set => _regenerationSpeed = value; }
        public int MusculationSessionsCount
        {
            get => _musculationSessionsCount;
            set
            {
                if (value > _musculationSessionsCount)
                {
                    _musculationSessionsCount = value;
                }
            }
        }
    }
}