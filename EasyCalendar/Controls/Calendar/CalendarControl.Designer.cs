namespace EasyCalendar.Controls.Calendar
{
    partial class CalendarControl
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
            this.navigator = new EasyCalendar.Controls.Navigation.NavigationBar();
            this.quickActionBar = new EasyCalendar.Controls.Actions.QuickActionBar();
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.navigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.navigator.Date = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.navigator.Location = new System.Drawing.Point(3, 346);
            this.navigator.MaximumSize = new System.Drawing.Size(336, 61);
            this.navigator.Name = "navigator";
            this.navigator.Size = new System.Drawing.Size(336, 61);
            this.navigator.TabIndex = 0;
            // 
            // quickActionBar
            // 
            this.quickActionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.quickActionBar.Location = new System.Drawing.Point(3, 266);
            this.quickActionBar.Name = "quickActionBar";
            this.quickActionBar.Size = new System.Drawing.Size(207, 61);
            this.quickActionBar.TabIndex = 1;
            // 
            // CalendarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.quickActionBar);
            this.Controls.Add(this.navigator);
            this.DoubleBuffered = true;
            this.Name = "CalendarControl";
            this.Size = new System.Drawing.Size(452, 425);
            this.Load += new System.EventHandler(this.CalendarControl_Load);
            this.SizeChanged += new System.EventHandler(this.CalendarControl_SizeChanged);
            this.ResumeLayout(false);

        }

        private EasyCalendar.Controls.Navigation.NavigationBar navigator;

        #endregion

        private Actions.QuickActionBar quickActionBar;
    }
}
