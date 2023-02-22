namespace Denomme_Adam_GameOfLife
{
    partial class SeedDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Randomize = new System.Windows.Forms.Button();
            this.labelSeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownSeed
            // 
            this.numericUpDownSeed.Location = new System.Drawing.Point(69, 57);
            this.numericUpDownSeed.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownSeed.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numericUpDownSeed.Name = "numericUpDownSeed";
            this.numericUpDownSeed.Size = new System.Drawing.Size(84, 20);
            this.numericUpDownSeed.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(52, 102);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(133, 102);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Randomize
            // 
            this.Randomize.Location = new System.Drawing.Point(159, 54);
            this.Randomize.Name = "Randomize";
            this.Randomize.Size = new System.Drawing.Size(75, 23);
            this.Randomize.TabIndex = 3;
            this.Randomize.Text = "Randomize";
            this.Randomize.UseVisualStyleBackColor = true;
            // 
            // labelSeed
            // 
            this.labelSeed.AutoSize = true;
            this.labelSeed.Location = new System.Drawing.Point(31, 59);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(32, 13);
            this.labelSeed.TabIndex = 4;
            this.labelSeed.Text = "Seed";
            // 
            // SeedDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 143);
            this.Controls.Add(this.labelSeed);
            this.Controls.Add(this.Randomize);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDownSeed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seed Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.Label labelSeed;
    }
}