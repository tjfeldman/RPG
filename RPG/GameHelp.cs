using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RPG
{
    public partial class GameHelp : Form
    {
        /// <summary>
        /// show the help text
        /// </summary>
        public GameHelp()
        {
            InitializeComponent();
            using (FileStream fs = File.OpenRead("Help.txt"))
            {
                using (TextReader reader = new StreamReader(fs))
                    Helper.Text = reader.ReadToEnd();
            }
        }


    }
}
