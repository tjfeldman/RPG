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
    public partial class ItemInfo : Form
    {
        public ItemInfo()
        {
            InitializeComponent();
            using (FileStream fs = File.OpenRead("ItemHelp.txt"))
            {
                using (TextReader reader = new StreamReader(fs))
                   Helper.Text = reader.ReadToEnd();
            }
        }

    }
}
