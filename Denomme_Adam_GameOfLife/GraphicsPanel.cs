﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Change the namespace to your project's namespace.
namespace Denomme_Adam_GameOfLife
{
    internal class GraphicsPanel : Panel
    {
        // Default constructor
        public GraphicsPanel()
        {
            // Turn on double buffering.
            this.DoubleBuffered = true;

            // Allow repainting when the window is resized.
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
