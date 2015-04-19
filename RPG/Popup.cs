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
    public partial class Popup : Form
    {
        public Popup(string prompt)
        {
            InitializeComponent();
            Prompt.Text = prompt;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
