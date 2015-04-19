using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Ninja:Enemy
    {
        public Ninja()
        {
            title = "ninja";
        }

        public override void getStats(int level)
        {
            level++;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(40, 56) + (level * 6.5)), 0));
            def = (int)(Math.Round((r.Next(5,16) + (level * 3.5 )), 0));
            hp = (int)(Math.Round((r.Next(20,36) + (level * 12.5)),0));
            spd = (int)(Math.Round((r.Next(35, 46) + (level * 5.5)), 0));
            maxhp = hp;
            this.level = level;
            getName();
            base.getStats(level);
        }

        private void getName()
        {
            string[] names = {"Ryu", "Akali", "Ayana", "Gray Fox", "Koga", "Raiden"};
            Random r = Program.r;
            title = names[r.Next(0, names.Length)];
        }

        public override string name()
        {
            return title;
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((250 * level) / 2.75),0));
            return xp;
        }

        public override void loot(bool x, BattleField field)
        {
            Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with theif: 40% to get an advanced or higher potion, 30% chance to get a revive(15% chance for max), 20% to get a weapon, 10% to get armor
            {
                if (chance <= 20)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 10)
                {
                    field.currentGame().armor();//ask user who gets new armor
                }
                else if (chance <= 60)
                {
                    if (r.Next(101) <= 15)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive potion\r\n");
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
            else//without theif: 40% to get an advanced or higher, 40% chance to get a revive(10% max revive), 10% to get a weapon, 10% to get armor
            {
                if (chance <= 40)
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion \r\n");
                    }
                    else if (level >= 25)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion \r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion\r\n");
                    }
                }
                else if (chance <= 80)
                {
                    if (r.Next(101) <= 10)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive potion \r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive potion \r\n");
                    }
                }
                else if (chance <= 90)
                {
                    field.currentGame().weapon();
                }
                else
                {
                    field.currentGame().armor();
                }
            }
        }
    }
}
