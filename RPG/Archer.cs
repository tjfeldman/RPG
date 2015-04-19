using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    sealed class Archer:Hero
    {
        public Archer(World world) 
        {
            title = "Archer";
            setStats(world);
        }

        new public int energy
        {
            get { return mana; }
            set { mana = value; }
        }
        new public int maxenergy
        {
            get { return maxmana; }
        }

        public override int replish()
        {
            
            int gain = 2 * (int)Math.Round(1.35 * level, 0);
            if (gain > (maxenergy / 10))
                gain = maxenergy / 10;
            if (gain + mana > maxmana)
                gain = maxmana - mana;
            mana += gain;
            return gain;
        }

        public override void use(int x)
        {
            mana -= x;
        }

        public override string LevelUp()
        {
            Random r = Program.r;
            string output = "";
            output += base.LevelUp();
            int gain = r.Next(2,6);
            atk += gain;
            output += "\r\n" +(name() + "'s attack went up " + gain);
            gain = r.Next(2,6);
            def += gain;
            output += "\r\n" +(name() + "'s defense went up " + gain);
            double g = (r.NextDouble() * r.Next(0, 3));
            if (g + crit > 50)
                g = 50 - crit;
            g = Math.Round(g, 2);
            crit += g;
            output += "\r\n" +(name() + "'s critial went up " + g + "%");
            g = (r.NextDouble() * r.Next(5, 11));
            g = Math.Round(g, 2);
            spd += g;
            output += "\r\n" +(name() + "'s speed went up " + g);
            gain = r.Next(15, 26);
            maxhp += gain;
            output += "\r\n" +(name() + "'s hitpoints went up " + gain);
            if (hp > 0)//if character is not dead, then heal hp up the amount gained
                hp += gain;
            if (hp > maxhp)
                hp = maxhp;
            gain = r.Next(3, 7);
            maxmana += gain;
            output += "\r\n" +(name() + "'s energy went up " + gain);
            mana += gain;
            if (mana > maxmana)
                mana = maxmana;
            crit = Math.Round(crit, 2);
            getBoosted();
            output += "\r\n\r\n";
            return output;
        }

        public override string ability()
        {
            return "accurate";//attacks easier to hit but attacks do less damage
        }

        public override string name()
        {
            return title;
        }

        public override string gainXP(int xp)
        {
            string output = "";
            base.gainXP(xp);
            while (this.xp >= ((level * level / 3.25) * 100))
            {
                this.xp -= (int)(Math.Round(((level * level / 3.25) * 100), 0));
                output += LevelUp();
            }
            return output;
        }

        public override string exp()
        {

            maxxp = (int)Math.Round(((level * level / 3.25) * 100), 0);
                return base.exp();
            
        }

    }


}
