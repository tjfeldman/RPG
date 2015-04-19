using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    sealed class Theif:Hero
    {
        public Theif(World world)
        {
            title = "Thief";
            setStats(world);
        }

        public override string LevelUp()
        {
            Random r = Program.r;
            string output = "";
            output += base.LevelUp();
            int gain = r.Next(2, 6);
            atk += gain;
            output += "\r\n" +(name() + "'s attack went up " + gain);
            gain = r.Next(1, 4);
            def += gain;
            output += "\r\n" +(name() + "'s defense went up " + gain);
            double g = (r.NextDouble() * r.Next(0, 3));
            if (g + crit > 15)
                g = 15 - crit;
            g = Math.Round(g, 2);
            crit += g;
            output += "\r\n" +(name() + "'s critial went up " + g + "%");
            g = (r.NextDouble() * r.Next(5, 11));
            g = Math.Round(g, 2);
            spd += g;
            output += "\r\n" +(name() + "'s speed went up " + g);
            gain = r.Next(5, 16);
            maxhp += gain;
            output += "\r\n" +(name() + "'s hitpoints went up " + gain);
            if (hp > 0)//if character is not dead, then heal hp up the amount gained
                hp += gain;
            if (hp > maxhp)
                hp = maxhp;
            crit = Math.Round(crit, 2);
            getBoosted();
            output += "\r\n\r\n";
            return output;
        }

        public override string ability()
        {
            return "loot";//chance to increase loot(does not stack)
        }

        public override string name()
        {
            return title;
        }

        public override string gainXP(int xp)
        {
            string output = "";
            base.gainXP(xp);
            while (this.xp >= ((level * level / 4.6) * 100))
            {
                this.xp -= (int)(Math.Round(((level * level / 4.6) * 100), 0));
                output += LevelUp();
            }
            return output;
        }

        public override string exp()
        {

            maxxp = (int)Math.Round(((level * level / 4.6) * 100), 0);
                return base.exp();
            
        }

    }
}
