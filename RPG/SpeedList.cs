using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class SpeedList
    {
        private Object character;
        private double speed;
        public SpeedList(double speed, Object character)
        {
            this.speed = speed;
            this.character = character;
        }

        public double spd
        {
            get { return speed; }
        }

        public Object person
        {
            get { return character; }
        }

        public override string ToString()
        {
            return (character + "\r\nSpeed: " + speed + "\r\n");
        }
    }
}
