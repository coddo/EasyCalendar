﻿namespace EasyCalendar.Controls.Navigation
{
    partial class DatePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthBox = new System.Windows.Forms.ComboBox();
            this.yearBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // monthBox
            // 
            this.monthBox.Font = new System.Drawing.Font("Mixolydian Titling", 14F);
            this.monthBox.FormattingEnabled = true;
            this.monthBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthBox.Location = new System.Drawing.Point(4, 4);
            this.monthBox.Margin = new System.Windows.Forms.Padding(4);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(148, 31);
            this.monthBox.TabIndex = 1;
            this.monthBox.SelectedIndexChanged += new System.EventHandler(this.DateBoxes_SelectedIndexChanged);
            this.monthBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateBoxes_KeyDown);
            // 
            // yearBox
            // 
            this.yearBox.Font = new System.Drawing.Font("Mixolydian Titling", 14F);
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Location = new System.Drawing.Point(160, 4);
            this.yearBox.Margin = new System.Windows.Forms.Padding(4);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(75, 31);
            this.yearBox.TabIndex = 2;
            this.yearBox.SelectedIndexChanged += new System.EventHandler(this.DateBoxes_SelectedIndexChanged);
            this.yearBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateBoxes_KeyDown);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.monthBox);
            this.Font = new System.Drawing.Font("Mixolydian Titling", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(239, 39);
            this.Name = "DatePicker";
            this.Size = new System.Drawing.Size(239, 39);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox monthBox;
        private System.Windows.Forms.ComboBox yearBox;
    }
}
