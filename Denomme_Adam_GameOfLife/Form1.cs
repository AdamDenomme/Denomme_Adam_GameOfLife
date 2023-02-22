﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denomme_Adam_GameOfLife
{
    public partial class Form1 : Form
    {

        bool CountNeighborisFinite = true;

        // Int to show neighbor count
        int CountNeighbor = 0;

        // The universe array
        bool[,] universe = new bool[30, 30];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        // Alive Cell count
        int AliveCells = 0;

        // View Menu items
        bool isNeighborCountVisible;

        bool isGridVisible;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        private void RandomizeTime()
        {
            //int userSeed = 0;

            Random randTime = new Random();
            //Random randSeed = new Random(userSeed);

            for (int y = 0; y < universe.GetLength(1); y++)

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // Call Next
                    int randNum = randTime.Next(0, 2);

                    // if random number == 0 turn cell on, else, turn cell off
                    if (randNum == 0)
                    {
                        universe[x, y] = true;
                        AliveCells++;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }
                    
                }
            
            toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
            graphicsPanel1.Invalidate();
        }

        private void RandomizeSeed()
        {
            int userSeed = 0;

            Random randSeed = new Random(userSeed);

            for (int y = 0; y < universe.GetLength(1); y++)

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // Call Next
                    int randNum = randSeed.Next(0, 2);

                    // if random number == 0 turn cell on, else, turn cell off
                    if (randNum == 0)
                    {
                        universe[x, y] = true;

                        // Update alive cell count
                        AliveCells++;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }

                }
            
            toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
            graphicsPanel1.Invalidate();
        }

        // CountNeighborsFinite
        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                    {
                        continue;
                    }
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                    {
                        continue;
                    }
                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        // Count Neighbors Toroidal
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                    {
                        xCheck = (xLen - 1);
                    }
                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                    {
                        yCheck = (yLen - 1);
                    }
                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }


        // Calculate the next generation of cells
        private void NextGeneration()
        {
            // The scratchpad array
            bool[,] scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];

            for (int y = 0; y < universe.GetLength(1); y++)

                for (int x = 0; x < universe.GetLength(0); x++)
                    {
                    if (CountNeighborisFinite == true)
                    {
                        CountNeighbor = CountNeighborsFinite(x, y);
                    }
                    else if (CountNeighborisFinite == false)
                    {
                        CountNeighbor = CountNeighborsToroidal(x, y);
                    }

                    int count = CountNeighbor;

                    // Living cells with less than 2 living neighbors die in the next generation.
                    if (universe[x, y] == true && count < 2)
                    {
                        scratchPad[x, y] = false;
                    }

                    // Living cells with more than 3 living neighbors die in the next generation.
                    if (universe[x, y] == true && count > 3)
                    {
                        scratchPad[x, y] = false;
                    }

                    // Living cells with 2 or 3 living neighbors live in the next generation.
                    if (universe[x, y] == true && (count == 3 || count == 2))
                    {
                        scratchPad[x, y] = true;
                    }

                    // Dead cells with exactly 3 living neighbors live in the next generation.
                    if (universe[x, y] == false && count == 3)
                    {
                        scratchPad[x, y] = true;
                    }

                    // Dead cells without 3 living neighbors are still dead in the next generation.
                    if (universe[x, y] == false && count != 3)
                    {
                        scratchPad[x, y] = false;
                    }

                    // Update alive cell count
                    if (scratchPad[x, y] == true && universe[x, y] == false)
                    {
                        AliveCells++;
                    }
                    else if (scratchPad[x, y] == false && universe[x, y] == true)
                    {
                        AliveCells--;
                    }

                }

                // Swaps Scratchpad and Universe
                bool[,] temp = universe;
                universe = scratchPad;
                scratchPad = temp;

                // Increment generation count
                generations++;

                // Update status strip generations
                toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

                // Update status strip alive
                toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
            graphicsPanel1.Invalidate();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    if (isGridVisible)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }

                    // Displays neighbor count in cell

                    if (isNeighborCountVisible)
                    {
                        Font font = new Font("Arial", 7f);

                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        Rectangle rect = cellRect;
                        if (CountNeighborisFinite == true)
                        {
                            CountNeighbor = CountNeighborsFinite(x, y);
                        }
                        else if (CountNeighborisFinite == false)
                        {
                            CountNeighbor = CountNeighborsToroidal(x, y);
                        }

                        if (CountNeighbor == 0)
                        {

                        }
                        else
                        {
                            e.Graphics.DrawString(CountNeighbor.ToString(), font, Brushes.Black, rect, stringFormat);
                        }
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Change to floats
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Update alive cell count
                if (universe[x, y] == true)
                {
                    AliveCells++;
                    toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
                }
                if (universe[x, y] == false)
                {
                    AliveCells--;
                    toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
                }

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generations = 0;
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

            for (int y = 0; y < universe.GetLength(1); y++)

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            graphicsPanel1.Invalidate();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            NextGeneration();
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            AliveCells = 0;
            generations = 0;
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();

            for (int y = 0; y < universe.GetLength(1); y++)

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            graphicsPanel1.Invalidate();

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Count neighbor visibility
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optionsToolStripMenuItem.Checked == false)
            {
                optionsToolStripMenuItem.Checked = true;
                isNeighborCountVisible = true;
                graphicsPanel1.Invalidate();
            }
            else if (optionsToolStripMenuItem.Checked == true)
            {
                optionsToolStripMenuItem.Checked = false;
                isNeighborCountVisible = false;
                graphicsPanel1.Invalidate();
            }
        }

        private void torodialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountNeighborisFinite = false;
            finiteToolStripMenuItem.Checked = false;
            torodialToolStripMenuItem.Checked = true;
            graphicsPanel1.Invalidate();
        }

        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountNeighborisFinite = true;
            torodialToolStripMenuItem.Checked = false;
            finiteToolStripMenuItem.Checked = true;
            graphicsPanel1.Invalidate();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.Write("!");
                writer.WriteLine(dlg.FileName);

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                    {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                        {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        if (universe[x, y] == false)
                        {
                            currentRow += '.';
                        }

                    }
                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }
                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int yPos = 0;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row.StartsWith("!"))
                    {
                        continue;
                    }
                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    else
                    {
                        maxHeight++;
                    }
                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    maxWidth = row.Length;
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                universe = new bool[maxWidth, maxHeight];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row.StartsWith("!"))
                    {
                        continue;
                    }
                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    else
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then
                            // set the corresponding cell in the universe to alive.
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, yPos] = true;
                            }
                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.
                            if (row[xPos] == '.')
                            {
                                universe[xPos, yPos] = false;
                            }
                        }
                    }
                    yPos++;
                    graphicsPanel1.Invalidate();
                }
                // Close the file.
                reader.Close();

                // Update alive cell count
                AliveCells = 0;

                for (int y = 0; y < universe.GetLength(1); y++)

                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == true)
                        {
                            AliveCells++;
                        }
                    }
                toolStripStatusAlive.Text = "Alive: " + AliveCells.ToString();
            }
        }

        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeSeed();
        }

        private void fromTimeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AliveCells = 0;
            RandomizeTime();
        }

        private void toolStripStatusInterval_Click(object sender, EventArgs e)
        {

        }

        // Grid visibility
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem2.Checked == false)
            {
                toolStripMenuItem2.Checked = true;
                isGridVisible = true;
                graphicsPanel1.Invalidate();
            }
            else if (toolStripMenuItem2.Checked == true)
            {
                toolStripMenuItem2.Checked = false;
                isGridVisible = false;
                graphicsPanel1.Invalidate();
            }
        }

        // CONTEXT SENSITIVE MENU
        /***********************************************************************/

        // Back color
        private void backColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = BackColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        // Cell color
        private void cellColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        // Grid color
        private void gridColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        /***********************************************************************/

        // SETTINGS MENU
        /***********************************************************************/

        // Back color
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = BackColor;
            if(DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        // Cell color
        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }

        }

        // Grid color
        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
                graphicsPanel1.Invalidate();
            }
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int numWidth = universe.GetLength(0);
            int numHeight = universe.GetLength(1);

            OptionsDialog dlg = new OptionsDialog();

            dlg.Interval = timer.Interval;
            dlg.uWidth = universe.GetLength(0);
            dlg.uHeight = universe.GetLength(1);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                timer.Interval = dlg.Interval;
                numWidth = dlg.uWidth;
                numHeight = dlg.uHeight;

                universe = new bool [numWidth, numHeight];

                graphicsPanel1.Invalidate();
            }
        }

        /***********************************************************************/
    }
}
