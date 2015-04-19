using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Weapon
    {
        private int atk;
        private double crit;
        private int DoT = 0;
        private bool poison;
        private int energyDeduct;
        //private bool breakable;
        //private int uses;
        public Weapon(int level)
        {
            atk = Program.r.Next(5, 11) + (level * Program.r.Next(1, 6));
            crit = (Program.r.NextDouble() * (level / 5.0));
            crit = Math.Round(crit, 2);
            if (crit > 25)
                crit = 25;
            //uses = r.Next(25, 1001);
            //breakable = true;
            if (Program.r.Next(101) <= 25)
            {
                poison = true;
                DoT = (Program.r.Next(1 + (level / 5), 11 + (level / 5)));
            }
            else
                poison = false;
            energyDeduct = 0;

        }

        public Weapon(bool special, int level)
        {
            atk = Program.r.Next(5, 11) + (level * Program.r.Next(1, 6));
            crit = (Program.r.NextDouble() * (level / 5.0));
            crit = Math.Round(crit, 2);
            if (crit > 25)
                crit = 25;
            energyDeduct = (int)Math.Round(((Program.r.Next(1, 6) * 10 / 5) - 1) * (level / 3.0), 0);
        }

        public Weapon(int attack, double critial, bool poison, int damage, int deduct)
        {
            atk = attack;
            crit = critial;
            this.poison = poison;
            DoT = damage;
            this.energyDeduct = deduct;
        }

        public Weapon(Object x)//create default weapon
        {
            energyDeduct = 0;
            //breakable = false;
            poison = false;
            if (x is Archer)
            {
                atk = 2;
                crit = .5;
            }
            if (x is Warrior)
            {
                atk = 3;
                crit = .1;
            }
            if (x is Mage)
            {
                atk = 4;
                crit = .25;
            }
            if (x is Healer)
            {
                atk = 2;
                crit = .25;
            }
            if (x is Wizard)
            {
                atk = 3;
                crit = .25;
            }
            if (x is Theif)
            {
                atk = 2;
                crit = .15;
            }
            if (x is Guard)
            {
                atk = 3;
                crit = .1;
            }
            if (x is Rogue)
            {
                atk = 4;
                crit = .1;
            }
            if (x is Scout)
            {
                atk = 3;
                crit = .5;
            }
            string output;
            output = ((Hero)x).name() + " recieved a weapon it has:\r\n";
            output += this + "\r\n";
            ((Hero)x).setOutput(output);
        }

        /// <summary>
        /// attack bonus to hero
        /// </summary>
        public int attackbonus
        {
            get { return atk; }
        }

        /// <summary>
        /// crit bonus to hero
        /// </summary>
        public double critbonus
        {
            get { return crit; }
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
        /// <summary>
        /// the amount of poison damage
        /// </summary>
        public int poisondamage
        {
            get { return DoT; }
        }

        /// <summary>
        /// can weapon poison
        /// </summary>
        /// <returns></returns>
        public bool canPoison()
        {
            return poison;
        }

        /// <summary>
        /// get the amount of energy the team gets deducted
        /// </summary>
        public int deduction
        {
            get { return energyDeduct; }
        }

        public override String ToString()
        {
            if (energyDeduct > 0)
            {
                return "Weapon Attack Bonus: " + atk + "\r\nWeapon Critial Bonus: " + crit + "%\r\nTeam Energy Deduction: " + energyDeduct + " energy";
            }
            //if (poison && breakable)
            //    return "Weapon Attack Bonus: " + atk + "\r\nWeapon Critial Bonus: " + crit + "%\r\nWeapon Poison Effect: " + DoT + " damage per a turn" + "\r\nWeapon Uses til Breaks: " + uses;
            if (poison)
                return "Weapon Attack Bonus: " + atk + "\r\nWeapon Critial Bonus: " + crit + "%\r\nWeapon Poison Effect: " + DoT + " damage per a turn";
            //if (breakable)
            //    return "Weapon Attack Bonus: " + atk + "\r\nWeapon Critial Bonus: " + crit + "%\r\nWeapon Uses til Breaks: " + uses;
            else
                return "Weapon Attack Bonus: " + atk + "\r\nWeapon Critial Bonus: " + crit + "%";
        }

    }
}
