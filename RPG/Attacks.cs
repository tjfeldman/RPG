using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    
    public class Attacks
    {
        private string name;
        private double power;
        private int acc;
        public Attacks(string name, double power, int acc)
        {
            this.name = name;
            this.power = power;
            this.acc = acc;
        }

        /// <summary>
        /// returns attack name
        /// </summary>
        /// <returns></returns>
        public string attackName()
        {
            return name;
        }

        /// <summary>
        /// returns attack power
        /// </summary>
        /// <returns></returns>
        public double basePower()
        {
            return power;
        }

        /// <summary>
        /// returns the accucary of the attack
        /// </summary>
        /// <returns></returns>
        public int accucary()
        {
            return acc;
        }
            
    }
}
