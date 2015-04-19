using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class NoTargetException : NullReferenceException
    {
        public NoTargetException():base()
        {
        }

        public NoTargetException(string msg):base(msg)
        {
            new Popup(msg).Show();
        }
    }
}
