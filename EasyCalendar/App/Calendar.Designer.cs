namespace EasyCalendar.App
{
    partial class Calendar
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
            this.calendarControl1 = new EasyCalendar.Calendar.CalendarControl();
            this.SuspendLayout();
            // 
            // calendarControl1
            // 
            this.calendarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarControl1.Location = new System.Drawing.Point(0, 0);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(637, 549);
            this.calendarControl1.TabIndex = 0;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 549);
            this.Controls.Add(this.calendarControl1);
            this.DoubleBuffered = true;
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private EasyCalendar.Calendar.CalendarControl calendarControl1;
    }
}