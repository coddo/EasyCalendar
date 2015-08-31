namespace EasyCalendar.CalendarControls.Navigation
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
            this.dayBox = new System.Windows.Forms.ComboBox();
            this.monthBox = new System.Windows.Forms.ComboBox();
            this.yearBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dayBox
            // 
            this.dayBox.FormattingEnabled = true;
            this.dayBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.dayBox.Location = new System.Drawing.Point(3, 3);
            this.dayBox.Name = "dayBox";
            this.dayBox.Size = new System.Drawing.Size(54, 21);
            this.dayBox.TabIndex = 0;
            this.dayBox.SelectedIndexChanged += new System.EventHandler(this.dayBox_SelectedIndexChanged);
            this.dayBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dayBox_KeyDown);
            // 
            // monthBox
            // 
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
            "November"});
            this.monthBox.Location = new System.Drawing.Point(63, 3);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(158, 21);
            this.monthBox.TabIndex = 1;
            this.monthBox.SelectedIndexChanged += new System.EventHandler(this.dayBox_SelectedIndexChanged);
            this.monthBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dayBox_KeyDown);
            // 
            // yearBox
            // 
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Location = new System.Drawing.Point(227, 3);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(80, 21);
            this.yearBox.TabIndex = 2;
            this.yearBox.SelectedIndexChanged += new System.EventHandler(this.dayBox_SelectedIndexChanged);
            this.yearBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dayBox_KeyDown);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.monthBox);
            this.Controls.Add(this.dayBox);
            this.Name = "DatePicker";
            this.Size = new System.Drawing.Size(310, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox dayBox;
        private System.Windows.Forms.ComboBox monthBox;
        private System.Windows.Forms.ComboBox yearBox;
    }
}
