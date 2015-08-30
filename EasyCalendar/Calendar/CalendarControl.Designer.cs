namespace EasyCalendar.Calendar
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
            this.navigator = new EasyCalendar.Calendar.NavigationBar();
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.navigator.BackColor = System.Drawing.Color.Transparent;
            this.navigator.Location = new System.Drawing.Point(3, 346);
            this.navigator.Name = "navigator";
            this.navigator.Opacity = 80;
            this.navigator.Size = new System.Drawing.Size(439, 76);
            this.navigator.TabIndex = 0;
            // 
            // CalendarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.navigator);
            this.DoubleBuffered = true;
            this.Name = "CalendarControl";
            this.Size = new System.Drawing.Size(452, 425);
            this.Load += new System.EventHandler(this.CalendarControl_Load);
            this.SizeChanged += new System.EventHandler(this.CalendarControl_SizeChanged);
            this.Validated += new System.EventHandler(this.CalendarControl_Validated);
            this.ResumeLayout(false);

        }

        private NavigationBar navigator;

        #endregion
    }
}
