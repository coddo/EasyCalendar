﻿using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using EasyCalendar.Forms;
using System;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarEventItem : Panel
    {
        #region Constants

        private const int NOTIFICATION_DAYS = 7;

        #endregion

        #region Fields

        private Event ev;
        private DateTime slotDate;
        private IObserver observer;

        #endregion

        #region Properties

        public Event Event => this.ev;

        public bool IsSeen { get; set; }

        #endregion

        public CalendarEventItem(Event ev, DateTime slotDate, IObserver observer)
        {
            InitializeComponent();

            this.ev = ev;
            this.slotDate = slotDate;
            this.observer = observer;
            this.IsSeen = ev.IsSeen;

            SetAppropriateImage();
        }

        public CalendarEventItem(Event ev, DateTime slotDate, IObserver observer, bool isSeen) : this(ev, slotDate, observer)
        {
            this.IsSeen = isSeen;
        }

        #region Methods

        private string Status()
        {
            string willTakePlaceStatus = "Will take place in " + (slotDate - DateTime.Today).TotalDays + " days";
            string hasTakenPlaceStatus = "Has taken place " + -(slotDate - DateTime.Today).TotalDays + " days ago";

            string status = "Status: ";

            if (slotDate < DateTime.Today && !this.IsSeen)
                return status + "Missed\n\n" + hasTakenPlaceStatus;

            else if (slotDate == DateTime.Today)
                return status + "TODAY!!!";

            else if (slotDate > DateTime.Today)
                return status + willTakePlaceStatus;
            else
                return status + hasTakenPlaceStatus;
        }

        private void SetAppropriateImage()
        {
            if (slotDate < DateTime.Today && !this.IsSeen)
                this.BackgroundImage = global::EasyCalendar.Properties.Resources.missed;

            else if (slotDate == DateTime.Today)
                this.BackgroundImage = global::EasyCalendar.Properties.Resources.today;

            else if (slotDate > DateTime.Today)
            {
                if ((slotDate - DateTime.Today).TotalDays <= NOTIFICATION_DAYS)
                    this.BackgroundImage = global::EasyCalendar.Properties.Resources.upcoming;
                else
                    this.BackgroundImage = global::EasyCalendar.Properties.Resources.normal;
            }
            else
                this.BackgroundImage = global::EasyCalendar.Properties.Resources.passed;
        }

        #endregion

        #region Event handlers

        private void EventItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.toolTip.ToolTipTitle = ev.Title.ToUpper();

                string message = "";
                if (ev.Details != null && ev.Details.Length > 0)
                    message += ev.Details + "\n\n";

                message += slotDate.ToString(CalendarSlot.DATE_FORMAT_LONG) + "\n\n" + Status();

                if (ev.IsRecursive)
                    message += "\n\nRepeats once every: " + ev.RecursionYears + " years, " + ev.RecursionMonths + " months and " + ev.RecursionDays + " days";

                this.toolTip.Show(message.ToUpper(), this);

                // Mark it as seen
                using (var db = new UnitOfWork())
                {
                    ev = db.EventsRepository.Get(ev.Id);

                    if (slotDate <= DateTime.Today && ev.IsSeen == this.IsSeen)
                    {
                        ev.IsSeen = this.IsSeen = true;
                        SetAppropriateImage();

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

        #endregion
    }
}
