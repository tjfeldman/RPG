using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class CharacterInfo
    {
        private string title;
        private int health;
        private int mana;
        private int attack;
        private int defense;
        private double critial;
        private double speed;
        public CharacterInfo(string title, int health, int mana, int attack, int defense, double critial, double speed)
        {
            this.title = title;
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.critial = critial;
            this.speed = speed;
        }

        public int hp()
        {
            return health;
        }

        public int energy()
        {
            return mana;
        }

        public string name()
        {
            return title;
        }

        public int atk()
        {
            return attack;
        }

        public int def()
        {
            return defense;
        }

        public double crit()
        {
            return critial;
        }

        public double spd()
        {
            return speed;
        }
    }
}
