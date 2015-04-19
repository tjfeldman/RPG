using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class Mega:Potion
    {
        public Mega()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You healed " + x.name() + " back to full health\r\n");
            x.Heal(x.calcPercent(100));
        }
    }
}
