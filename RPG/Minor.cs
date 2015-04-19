using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    sealed class Minor:Enemy
    {
        public Minor()
        {
            title = "minor";
        }

        public override void getStats(int level)
        {
            if (level > 3)
                level -= 2;
            else
                level = 1;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(10, 16) + (level * 2.5)), 0));
            def = (int)(Math.Round((r.Next(10,16) + (level * 2.5 )), 0));
            hp = (int)(Math.Round((r.Next(10,16) + (level * 10.5)),0));
            spd = (int)(Math.Round((r.Next(5, 16) + (level * 2.5)), 0));
            maxhp = hp;
            this.level = level;
            getName();
            base.getStats(level);
        }

        private void getName()
        {
            string[] names = {"Inky", "Blinky", "Clyde", "Pinky"};
            Random r = Program.r;
            title = names[r.Next(0, names.Length)];
        }

        public override string name()
        {
            return title;
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((25 * level) / 2.25),0));
            return xp;
        }

        public override void loot(bool x, BattleField field)
        {
            Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with theif: 60% to get a potion based on level, 20% chance to get a revive(5% chance for max), 10% to get a weapon, 10% to get armor
            {
                if (chance <= 10)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 10)
                {
                    field.currentGame().armor();//ask user who gets new armor
                }
                else if (chance <= 40)
                {
                    if (r.Next(101) <= 5)
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
                    else if (level >= 5)
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Basic());
                        field.Output.Text += ("You looted 1 basic potion\r\n");
                    }
                }

            }
            else//without theif: 70% to get a potion based on level, 10% chance to get a revive, 5% to get a weapon, 5% to get armor, 10% to get nothing
            {
                if (chance <= 70)
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion\r\n");
                    }
                    else if (level >= 25)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion from\r\n");
                    }
                    else if (level >= 5)
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion from\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Basic());
                        field.Output.Text += ("You looted 1 basic potion\r\n");
                    }
                }
                else if (chance <= 80)
                {
                    Program.AddLoot(new Revive());
                    field.Output.Text += ("You looted 1 revive potion\r\n");
                }
                else if (chance <= 85)
                {
                    field.currentGame().weapon();
                }
                else if (chance <= 90)
                {
                    field.currentGame().armor();
                }
                
            }
        }
    }
}
