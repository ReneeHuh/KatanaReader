using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KatanaReader
{
    public partial class Optionform : Form
    {
        public Optionform()
        {
            InitializeComponent();
        }

        private void btTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            rtbOptions.ForeColor = dlg.Color;
        }

        private void btbackColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            rtbOptions.BackColor = dlg.Color;
        }

        private void btSpokenWordColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            //rtbOptions.BackColor = dlg.Color;
        }


    }
}
