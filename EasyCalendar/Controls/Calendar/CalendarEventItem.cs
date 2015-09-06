using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using EasyCalendar.Forms;
using System;
using System.Drawing;
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
        public bool IsSeen { get; set; }

        public CalendarEventItem(Event ev, DateTime slotDate, IObserver observer)
        {
            InitializeComponent();

            this.ev = ev;
            this.slotDate = slotDate;
            this.observer = observer;
            this.IsSeen = ev.IsSeen;
        }

        public CalendarEventItem(Event ev, DateTime slotDate, IObserver observer, bool isSeen) : this(ev, slotDate, observer)
        {
            this.IsSeen = isSeen;
        }

        private string Status()
        {
            string status = "Status: ";

            if (ev.Date < DateTime.Today && !this.IsSeen)
                return status + "Missed";

            else if (slotDate == DateTime.Today)
                return status + "TODAY!!!";

            else if (slotDate > DateTime.Today)
                return status + "Will take place in " + (slotDate - DateTime.Today).TotalDays + " days";
            else
                return status + "Has taken place " + -(slotDate - DateTime.Today).TotalDays + " days ago";
        }

        private void EventItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.toolTip.ToolTipTitle = ev.Title.ToUpper();

                string message = "";
                if (ev.Details != null && ev.Details.Length > 0)
                    message += ev.Details + "\n\n";
                message += ev.Date.ToString(CalendarSlot.DATE_FORMAT_LONG) + "\n\n" + Status();

                if (ev.IsRecursive)
                    message += "\n\nRepeats once every: " + ev.RecursionYears + " years, " + ev.RecursionMonths + " months and " + ev.RecursionDays + " days";

                this.toolTip.Show(message.ToUpper(), this);

                // Mark it as seen
                if (ev.Date <= DateTime.Today && ev.IsSeen == this.IsSeen)
                {
                    using (var db = new UnitOfWork())
                    {
                        ev = db.EventsRepository.Get(ev.Id);

                        ev.IsSeen = this.IsSeen = true;

                        db.EventsRepository.Update(ev);
                    }
                }
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
