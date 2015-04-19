using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    sealed class Sniper:Boss
    {
        private bool hiding = false;
        private int position = 1;
        public Sniper()
        {
            title = "Sniper";
        }

        public override string ToString()
        {
            if (hiding)
                return title + " (Hp: XXX/XXX)";
            return title + " (Hp: " + hp + "/" + maxhp + ")";
        }

        public override void getStats(int level)
        {
            level += 2;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(50, 76) + (level * 8.0)), 0));
            def = (int)(Math.Round((r.Next(15, 26) + (level * 8.0)), 0));
            hp = (int)(Math.Round((r.Next(100, 176) + (level * 17.5)), 0));
            spd = (int)(Math.Round((r.Next(30, 41) + (level * 8.0)), 0));
            maxhp = hp;
            this.level = level;
            base.getStats(level);
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((400 * level) / 4.75), 0));
            return xp;
        }

        public bool hide
        {
            get { return hiding; }
            set { hiding = value; }
        }

        public int location
        {
            get { return position; }
            set { position = value; }
        }

        public override void loot(bool x, BattleField field)
        {
             Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with thief: 30% chance to get an advanced or higher potion ,30% chance to get a revive(15% chance for max) ,20% chance to get a weapon, 20% chance to get armor
            {
                if (chance <= 20)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 40)
                {
                    field.currentGame().armor();//ask user who gets new armor
                }
                else if (chance <= 70)
                {
                    if (r.Next(101) <= 15)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive\r\n");

                    }
                }
                else
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion\r\n");
                    }
                    else if (level >= 25)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion\r\n");
                    }

                }

            }
            else//without if: 20% chance to get a revive(with 10% for max revive) ,50% chance to get an advanced or higher potion ,15% chance to get a weapon, 15% chance to get armor
            {
                if (chance <= 15)
                    field.currentGame().weapon();//ask user who gets new weapon
                else if (chance <= 30)
                    field.currentGame().armor();
                else if (chance <= 80)
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion\r\n");
                    }
                    else if (level >= 25)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion\r\n");
                    }
                }
                else
                {
                    if (r.Next(101) <= 10)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive\r\n");

                    }
                }
            }
        }
    }
}
