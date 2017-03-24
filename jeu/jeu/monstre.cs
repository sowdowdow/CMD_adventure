using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeu
{
    class monstre
    {
        private string _nom;
        private string _skin;
        private int _hp;
        private int _atk;
        private int _exp;

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
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
