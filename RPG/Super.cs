using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class Super:Potion
    {
        public Super()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You healed " + x.name() + " for half their health\r\n");
            x.Heal(x.calcPercent(50));
        }
    }
}
