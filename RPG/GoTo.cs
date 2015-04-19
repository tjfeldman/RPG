using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class GoTo : Form , Confirmation
    {
        private Dungeon dungeon;
        private bool sent = false;
        private bool close = false;
        public GoTo(Dungeon x)
        {
            InitializeComponent();
            dungeon = x;
            Areas.Maximum = x.getAreas();
            Areas.Minimum = 0;
        }

        public bool sure
        {
            get { return close; }
            set { close = value; }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            new Confirm(this, "Are you sure you want to go to this area?\r\nYou will ruin all your current progress", "move").Show();
        }

        public void submit()
        {
            if (sure)
            {
                dungeon.setArea((int)Areas.Value);
                this.Close();
            }
        }

        private void GoTo_FormClosing(object sender, FormClosingEventArgs e)
        {
            sent = sure;
            if (!sent)
            {
                new Confirm(this, "You haven't selected a new area.\r\nAre you sure you want to exit?", "close").Show();
                e.Cancel = true;
            }
        }

    }
}
