namespace EasyCalendar.App
{
    partial class CalendarForm
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
            this.calendarControl = new EasyCalendar.Calendar.CalendarControl();
            this.navigationBar1 = new EasyCalendar.Calendar.NavigationBar();
            this.SuspendLayout();
            // 
            // calendarControl
            // 
            this.calendarControl.BackColor = System.Drawing.Color.Transparent;
            this.calendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarControl.Location = new System.Drawing.Point(0, 0);
            this.calendarControl.Name = "calendarControl";
            this.calendarControl.Size = new System.Drawing.Size(637, 549);
            this.calendarControl.TabIndex = 0;
            // 
            // navigationBar1
            // 
            this.navigationBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(110)))), ((int)(((byte)(109)))));
            this.navigationBar1.Location = new System.Drawing.Point(254, 12);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Opacity = 50;
            this.navigationBar1.Size = new System.Drawing.Size(371, 64);
            this.navigationBar1.TabIndex = 1;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(637, 549);
            this.Controls.Add(this.navigationBar1);
            this.Controls.Add(this.calendarControl);
            this.DoubleBuffered = true;
            this.Name = "CalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.CalendarForm_SizeChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Calendar_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private EasyCalendar.Calendar.CalendarControl calendarControl;
        private Calendar.NavigationBar navigationBar1;
    }
}