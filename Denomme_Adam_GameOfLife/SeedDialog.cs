﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denomme_Adam_GameOfLife
{
    public partial class SeedDialog : Form
    {
        public SeedDialog()
        {
            InitializeComponent();
        }

        // Randomizes Seed in UpDown
        private void Randomize_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            numericUpDownSeed.Value = rnd.Next();
        }
        // Get set for the userSeed
        public int Seed
        {
            get { return (int)numericUpDownSeed.Value; }
            set { numericUpDownSeed.Value = value; }
        }

    }
}
