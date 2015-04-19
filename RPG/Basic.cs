using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public sealed class Basic : Potion
    {
        public Basic()
        {
        }

        public override void use(Hero x, BattleField field)
        {
            field.Output.Text += ("You healed " + x.name() + " for 25 health\r\n");
            x.Heal(25);
        }
    }
}
