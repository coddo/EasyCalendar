using EasyCalendar.DAL.Models;
using EasyCalendar.Forms;
using System;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarEventItem : Panel
    {
        private const int NOTIFICATION_DAYS = 7;
        private const int ALARM_DAYS = 3;

        private Event ev;
        private DateTime slotDate;
        private IObserver observer;

        public Event Event => this.ev;

        public CalendarEventItem(Event ev, DateTime slotDate, IObserver observer)
        {
            InitializeComponent();

            this.ev = ev;
            this.slotDate = slotDate;
            this.observer = observer;
        }

        private string Status()
        {
            string status = "Status: ";

            if (ev.Date < DateTime.Today)
                if (ev.Seen)
                    return status + "Passed";
                else return status + "Missed";

            else if (ev.Date == DateTime.Today)
                return status + "TODAY!!!";

            else
                return status + "Will take place in " + (slotDate - DateTime.Today).TotalDays + " days";
        }

        private void EventItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.toolTip.ToolTipTitle = ev.Title.ToUpper();
                this.toolTip.Show(ev.Details + "\n\n" + ev.Date.ToString(CalendarSlot.DATE_FORMAT_LONG) + "\n\n" + Status(), this);
            }

            else if (e.Button == MouseButtons.Right)
            {
                new EditEventForm(ev, observer).ShowDialog();
            }
        }

        private void CalendarEventItem_Leave(object sender, EventArgs e)
        {
            this.toolTip.Hide(this);
        }
    }
}
