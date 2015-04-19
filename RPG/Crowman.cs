using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Crowman:Boss
    {
        private bool hiding = false;
        public Crowman()
        {
            title = "Crowman";
        }

        public override string ToString()
        {
            if (hiding)
                return title + " (Hp: XXX/XXX)";
            return title + " (Hp: " + hp + "/" + maxhp + ")";
        }

        public int quarter()
        {
            return (int)Math.Round((maxhealth / 4.0), 0);
        }

        public override void getStats(int level)
        {
            level += 3;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(45, 61) + (level * 15.0)), 0));
            def = (int)(Math.Round((r.Next(45, 61) + (level * 10.0)), 0));
            hp = (int)(Math.Round((r.Next(250, 351) + (level * 25.0)), 0));
            spd = (int)(Math.Round((r.Next(45, 61) + (level * 12.5)), 0));
            maxhp = hp;
            hiding = false;
            this.level = level;
            base.getStats(level);
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((1000 * level) / 5.25), 0));
            return xp;
        }

        public bool hide
        {
            get { return hiding; }
            set { hiding = value; }
        }

        public override void loot(bool x, BattleField field)
        {
            Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with thief: 20% chance to get an advanced or higher potion ,20% chance to get a revive(15% chance for max) ,30% chance to get a weapon, 30% chance to get armor
            {
                if (chance <= 30)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 60)
                {
                    field.currentGame().armor();//ask user who gets new armor
                }
                else if (chance <= 80)
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
            else//without if: 30% chance to get a revive(with 10% for max revive) ,30% chance to get an advanced or higher potion ,20% chance to get a weapon, 20% chance to get armor
            {
                if (chance <= 20)
                    field.currentGame().weapon();//ask user who gets new weapon
                else if (chance <= 40)
                    field.currentGame().armor();
                else if (chance <= 70)
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
