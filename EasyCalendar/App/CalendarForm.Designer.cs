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
            this.calendarControl = new EasyCalendar.Controls.Calendar.CalendarControl();
            this.SuspendLayout();
            // 
            // calendarControl
            // 
            this.calendarControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(128)))), ((int)(((byte)(44)))));
            this.calendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(128)))), ((int)(((byte)(44)))));
            this.calendarControl.Location = new System.Drawing.Point(0, 0);
            this.calendarControl.Name = "calendarControl";
            this.calendarControl.Size = new System.Drawing.Size(637, 549);
            this.calendarControl.TabIndex = 0;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(637, 549);
            this.Controls.Add(this.calendarControl);
            this.DoubleBuffered = true;
            this.Name = "CalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy Calendar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.CalendarForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private EasyCalendar.Controls.Calendar.CalendarControl calendarControl;
    }
}