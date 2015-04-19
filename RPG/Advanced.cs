using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class Advanced:Potion 
    {
        public Advanced()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You healed " + x.name() + " for 100 health\r\n");
            x.Heal(100);
        }
    }
}
