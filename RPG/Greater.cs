using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    sealed class Greater:Enemy
    {
        public Greater()
        {
            title = "greater";
        }

         public override void getStats(int level)
        {
            level++;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(5, 16) + (level * 3.5)), 0));
            def = (int)(Math.Round((r.Next(30, 41) + (level * 3.5)), 0));
            hp = (int)(Math.Round((r.Next(35, 46) + (level * 12.75)), 0));
            spd = (int)(Math.Round((r.Next(10, 16) + (level * 3.5)), 0));
            maxhp = hp;
            this.level = level;
            getName();
            base.getStats(level);

        }

        private void getName()
        {
            string[] names = { "Brick", "Wall", "Stone", "Marble", "Great Wall of this Game" };
            Random r = Program.r;
            title = names[r.Next(0, names.Length)];
        }

        public override string name()
        {
            return "" + title;         
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((125 * level) / 3.25), 0));
            return xp;
        }

        public override void loot(bool x, BattleField field)
        {
            Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with theif: 40% to get an advanced potion or higher ,20% to get a revive(10% to get max revive) ,15% to get a weapon, 25% to get armor 
            {
                if (chance <= 25)
                {
                    field.currentGame().armor();//ask user who gets new armor
                }
                else if (chance <= 40)
                {
                    field.currentGame().weapon();
                }
                else if (chance <= 60)
                {
                    if (r.Next(101) <= 10)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive potion from\r\n");
                    }
                }
                else
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion \r\n");
                    }
                    else if (level >= 20)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion \r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion \r\n");
                    }

                }
               

            }
            else//without theif: 60% to get an advance potion or higher, 15% chance to get a revive(5% chance to get a max revive) ,10% to get a weapon, 15% to get armor
            {
                if (chance <= 15)
                {
                    if (r.Next(101) <= 5)
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
                else if (chance <= 25)
                {
                    field.currentGame().weapon();//ask user who gets new weapon

                }
                else if (chance <= 40)
                {
                    field.currentGame().armor();
                }
                else
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
                        field.Output.Text += ("You looted 1 advanced potion \r\n");
                    }
                }
            }
        }
    }
}
