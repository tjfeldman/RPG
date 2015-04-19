using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class MaxRevive:Potion
    {
        public MaxRevive()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You revived " + x.name() + " back to full health\r\n");
            x.Heal(x.calcPercent(100));
        }
    }
}
