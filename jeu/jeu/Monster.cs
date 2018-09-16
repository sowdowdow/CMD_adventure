namespace game
{
    class Monster
    {
        private string _name;
        private string _skin;
        private int _hp;
        private int _atk;
        private int _exp;

        //instance of monsters (NOM / SKIN / HP / ATK / EXP)
        Monster Rabbit = new Monster("rabbit", "°o'", 1, 0, 1);
        Monster Turtle = new Monster("turtle", "°,o,", 10, 2, 5);

        public Monster(string name, string skin, int hp, int atk, int exp)
        {
            _name = name;
            _skin = skin;
            _hp = hp;
            _atk = atk;
            _exp = exp;
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Skin
        {
            get
            {
                return _skin;
            }

            set
            {
                _skin = value;
            }
        }

        public int Hp
        {
            get
            {
                return _hp;
            }

            set
            {
                _hp = value;
            }
        }

        public int Atk
        {
            get
            {
                return _atk;
            }

            set
            {
                _atk = value;
            }
        }

        public int Exp
        {
            get
            {
                return _exp;
            }

            set
            {
                _exp = value;
            }
        }
    }
}
