using EasyCalendar.Controls.Abstract;
using EasyCalendar.Controls.Calendar;
using EasyCalendar.DAL;
using System;

namespace EasyCalendar.Controls.Actions
{
    public partial class QuickActionBar : FloatingBar
    {
        public new CalendarControl Parent { get; set; }

        public QuickActionBar()
        {
            InitializeComponent();
        }

        private void navigateToCurrentDateButton_Click(object sender, System.EventArgs e)
        {
            if (Parent != null)
                Parent.Date = DateTime.Today;
        }

        private void refreshPageButton_Click(object sender, System.EventArgs e)
        {
            Parent?.UpdateUI();
        }

        private void rescheduleRecurrentEventsButton_Click(object sender, System.EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                db.EventsRepository.RescheduleRecursiveEvents();
            }

            Parent?.UpdateUI();
        }
    }
}
