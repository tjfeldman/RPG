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
    /// <summary>
    /// askes if user is sure on their choice
    /// </summary>
   
    public partial class Confirm : Form
    {
        Confirmation confirm;
        bool quit= false;
        bool revive = false;
        bool move = false;
        bool closing = false;
        public Confirm(Confirmation x)
        {
            InitializeComponent();
            confirm = x;
        }

        public Confirm(Confirmation x, string prompt)
        {
            InitializeComponent();
            confirm = x;
            Prompt.Text = prompt;
        }

        public Confirm(Confirmation x, string prompt, string type)
        {
            InitializeComponent();
            confirm = x;
            Prompt.Text = prompt;
            if (type.Equals("quit"))
                quit = true;
            else if (type.Equals("revive"))
                revive = true;
            else if (type.Equals("move"))
                move = true;
            else if (type.Equals("close"))
                closing = true;
        }
        /// <summary>
        /// return yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yes_Click(object sender, EventArgs e)
        {
            confirm.sure = true;
            this.Close();
        }

        /// <summary>
        /// returns no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void No_Click(object sender, EventArgs e)
        {
            confirm.sure = false;
            this.Close();  
        }

        private void Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (quit)
            {
                ((BattleField)confirm).currentGame().quit((BattleField)confirm);
            }
            if (revive)
            {
                ((BattleField)confirm).currentGame().willUse(false, (BattleField)confirm);
            }
            if (move)
            {
                ((GoTo)confirm).submit();
            }
            if (closing)
            {
                if (confirm is GoTo)
                    ((GoTo)confirm).Close();
                else
                    ((Dungeon)confirm).CloseSave();
            }
        }

    }
}
