namespace Denomme_Adam_GameOfLife
{
    partial class OptionsDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelTimerInterval = new System.Windows.Forms.Label();
            this.labeluWidth = new System.Windows.Forms.Label();
            this.labeluHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(48, 144);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(129, 144);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(183, 23);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownInterval.TabIndex = 2;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(183, 49);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWidth.TabIndex = 3;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(183, 75);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownHeight.TabIndex = 4;
            // 
            // labelTimerInterval
            // 
            this.labelTimerInterval.AutoSize = true;
            this.labelTimerInterval.Location = new System.Drawing.Point(31, 25);
            this.labelTimerInterval.Name = "labelTimerInterval";
            this.labelTimerInterval.Size = new System.Drawing.Size(136, 13);
            this.labelTimerInterval.TabIndex = 5;
            this.labelTimerInterval.Text = "Timer Interval (milliseconds)";
            // 
            // labeluWidth
            // 
            this.labeluWidth.AutoSize = true;
            this.labeluWidth.Location = new System.Drawing.Point(31, 49);
            this.labeluWidth.Name = "labeluWidth";
            this.labeluWidth.Size = new System.Drawing.Size(110, 13);
            this.labeluWidth.TabIndex = 6;
            this.labeluWidth.Text = "Width of the Universe";
            // 
            // labeluHeight
            // 
            this.labeluHeight.AutoSize = true;
            this.labeluHeight.Location = new System.Drawing.Point(31, 75);
            this.labeluHeight.Name = "labeluHeight";
            this.labeluHeight.Size = new System.Drawing.Size(113, 13);
            this.labeluHeight.TabIndex = 7;
            this.labeluHeight.Text = "Height of the Universe";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(253, 179);
            this.Controls.Add(this.labeluHeight);
            this.Controls.Add(this.labeluWidth);
            this.Controls.Add(this.labelTimerInterval);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelTimerInterval;
        private System.Windows.Forms.Label labeluWidth;
        private System.Windows.Forms.Label labeluHeight;
    }
}