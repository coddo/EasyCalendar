using EasyCalendar.DAL;
using EasyCalendar.Notifications;
using System;
using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class CalendarForm : Form
    {
        private DateTime previousDate;

        public CalendarForm()
        {
            InitializeComponent();

            previousDate = DateTime.Today;
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

            var timer = new Timer
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
    }
}
