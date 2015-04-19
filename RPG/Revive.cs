using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class Revive:Potion
    {
        public Revive()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You revived " + x.name() + " back to half health\r\n");
            x.Heal(x.calcPercent(50));
        }
    }
}
