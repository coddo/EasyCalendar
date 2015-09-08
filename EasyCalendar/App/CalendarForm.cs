using EasyCalendar.Controls.Calendar;
using EasyCalendar.DAL;
using EasyCalendar.Notifications;
using System;
using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class CalendarForm : Form
    {
        private DateTime previousDate;
        private Timer timer;
        private bool exitPressed = false;

        public CalendarForm()
        {
            InitializeComponent();

            previousDate = DateTime.Today;

            this.contextMenuStrip.BackColor = CalendarSlot.SLOT_COLOR;
            for (int i = 0; i < this.contextMenuStrip.Items.Count; i++)
            {
                this.contextMenuStrip.Items[i].BackColor = System.Drawing.Color.Transparent;
                this.contextMenuStrip.Items[i].ForeColor = CalendarSlot.DATE_TEXT_COLOR;
                this.contextMenuStrip.Items[i].Font = new System.Drawing.Font("Mixolydian Titling", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void RunAlarmIfNecessary()
        {
            using (var db = new UnitOfWork())
            {
                if (db.EventsRepository.HasUpcomingEvents())
                    AlarmCenter.PlayAlarm();
            }
        }

        private void Timer_Tick(object sender, System.EventArgs e)
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
            // Start an alarm if necessary
            RunAlarmIfNecessary();

            timer = new Timer
            {
                Interval = 1000 * 60 * 60,
            };

            timer.Tick += Timer_Tick;
            timer.Start();
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
            if (timer.Enabled)
                timer.Enabled = false;
        }

        private void displayCalendarMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            exitPressed = true;
            Application.Exit();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Show();
        }
    }
}
