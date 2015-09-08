using EasyCalendar.Controls.Calendar;
using EasyCalendar.DAL;
using EasyCalendar.Notifications;
using System;
using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class CalendarForm : Form
    {

        #region Fields

        private DateTime previousDate;
        private System.Windows.Forms.Timer checkDateTimer;
        private bool exitPressed = false;

        private bool blinkIconSwapVar = false;
        private System.Windows.Forms.Timer blinkTimer;

        #endregion

        public CalendarForm()
        {
            InitializeComponent();

            previousDate = DateTime.Today;

            checkDateTimer = new System.Windows.Forms.Timer { Interval = 1000 * 60 * 60 };
            checkDateTimer.Tick += checkDateTimer_Tick;

            blinkTimer = new System.Windows.Forms.Timer { Interval = 500 };
            blinkTimer.Tick += blinkTimer_Tick;

            this.contextMenuStrip.BackColor = CalendarSlot.SLOT_COLOR;
            for (int i = 0; i < this.contextMenuStrip.Items.Count; i++)
            {
                this.contextMenuStrip.Items[i].BackColor = System.Drawing.Color.Transparent;
                this.contextMenuStrip.Items[i].ForeColor = CalendarSlot.DATE_TEXT_COLOR;
                this.contextMenuStrip.Items[i].Font = new System.Drawing.Font("Mixolydian Titling", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        #region Methods

        private void RunAlarmIfNecessary()
        {
            var hasUrgentEvents = false;

            using (var db = new UnitOfWork())
            {
                hasUrgentEvents = db.EventsRepository.HasUpcomingEvents();
            }

            if (hasUrgentEvents)
            {
                StartBlinker();
                AlarmCenter.PlayAlarm();
            }
        }

        private void StartBlinker()
        {
            blinkIconSwapVar = false;

            blinkTimer.Enabled = true;
        }

        private void StopBlinker()
        {
            this.blinkTimer.Enabled = false;

            this.notifyIcon.Icon.Dispose();
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        }

        private void DisplayForm()
        {
            StopBlinker();
            AlarmCenter.InterrupAlarm();

            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Event handlers

        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            this.notifyIcon.Icon.Dispose();

            this.notifyIcon.Icon = blinkIconSwapVar ? ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))) : global::EasyCalendar.Properties.Resources.empty;

            blinkIconSwapVar = !blinkIconSwapVar;
        }

        private void checkDateTimer_Tick(object sender, System.EventArgs e)
        {
            // Run the alarm again and refresh the view only if we have passed to a new day
            if (previousDate != DateTime.Today)
            {
                calendarControl.UpdateUI();

                RunAlarmIfNecessary();

                previousDate = DateTime.Today;
            }
        }

        private void CalendarForm_Load(object sender, System.EventArgs e)
        {
            this.Visible = false;

            // Start an alarm if necessary
            RunAlarmIfNecessary();

            checkDateTimer.Enabled = true;
        }

        private void CalendarForm_Shown(object sender, System.EventArgs e)
        {
            calendarControl.Refresh();
        }

        private void CalendarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitPressed)
                return;

            e.Cancel = true;
            this.Hide();
        }

        private void CalendarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkDateTimer.Enabled)
                checkDateTimer.Enabled = false;
        }

        private void displayCalendarMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            exitPressed = true;
            Application.Exit();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (!this.Visible)
                    DisplayForm();
                else this.Hide();
        }

        #endregion
    }
}
