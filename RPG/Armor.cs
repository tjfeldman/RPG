using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Armor
    {
        private int def;
        private int hp;
        private int regen = 0;
        private bool heal;
        //private bool breakable;
        //private int uses;
        public Armor(int level)
        {
            def = Program.r.Next(5, 11) + (level * Program.r.Next(1, 6));
            hp = (Program.r.Next(10, 21) + (level & Program.r.Next(1, 6)));
            //uses = r.Next(25, 1001);
            //breakable = true;
            if (Program.r.Next(101) <= 25)
            {
                heal = true;
                regen = (Program.r.Next(1 + (level / 5), 11 + (level / 5)));
            }
            else
                heal = false;

        }

        public Armor(bool special, Hero you)
        {
            def = Program.r.Next(5, 11) + (you.level * Program.r.Next(1, 6));
            hp = (Program.r.Next(10, 21) + (you.level & Program.r.Next(1, 6)));
            heal = true;
            double percent = Program.r.NextDouble();
            while (percent < .25 || percent > .5)
            {
                percent = Program.r.NextDouble();
            }
            regen = (int)Math.Round((you.maxhealth + hp) * (percent), 0);
        }

        public Armor(int hp, int def, bool heal, int regen)
        {
            this.hp = hp;
            this.def = def;
            this.heal = heal;
            this.regen = regen;
        }

        public Armor(Object x)//create default weapon
        {
            //breakable = false;
            heal = false;
            if (x is Archer)
            {
                def = 3;
                hp = 5;
            }
            if (x is Warrior)
            {
                def = 5;
                hp = 10;
            }
            if (x is Mage)
            {
                def = 2;
                hp = 15;
            }
            if (x is Healer)
            {
                def = 3;
                hp = 10;
            }
            if (x is Wizard)
            {
                def = 2;
                hp = 15;
            }
            if (x is Theif)
            {
                def = 3;
                hp = 5;
            }
            if (x is Guard)
            {
                def = 5;
                hp = 10;
            }
            if (x is Rogue)
            {
                def = 4;
                hp = 5;
            }
            if (x is Scout)
            {
                def = 3;
                hp = 5;
            }
            string output;
            output = ((Hero)x).name() + " recieved some armor it has:\r\n";
            output += this + "\r\n";
            ((Hero)x).setOutput(output);
        }

        public int defensebonus
        {
            get { return def; }
        }

        public int hpbonus
        {
            get { return hp; }
        }
        /*
        public bool canbreak()
        {
            return breakable;
        }

        public void use()
        {
            uses--;
        }

        public int strength()
        {
            if (breakable)
                return uses;
            return 1;
        }
         * */

        public bool canRegen()
        {
            return heal;
        }

        public int regenhealth
        {
            get { return regen; }
        }

        public override String ToString()
        {
            //if (heal && breakable)
            //    return "Armor Defense Bonus: " + def + "\r\nArmor Health Bonus: " + hp + "\r\nArmor Regen: " + regen + " health per a turn" + "\r\nArmor Uses til Breaks: " + uses;
            if (heal)
                return "Armor Defense Bonus: " + def + "\r\nArmor Health Bonus: " + hp + "\r\nArmor Regen: " + regen + " health per a turn";
            //if (breakable)
            //    return "Armor Defense Bonus: " + def + "\r\nArmor Health Bonus: " + hp + "\r\nArmor Uses til Breaks: " + uses;
            else
                return "Armor Defense Bonus: " + def + "\r\nArmor Health Bonus: " + hp;
        }
    }
}
