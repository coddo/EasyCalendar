using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using EasyCalendar.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        #region Constants

        private const int MAX_WIDTH_FOR_DATE_RESIZE = 1350;

        public static readonly string DATE_FORMAT_LONG = "d MMMM yyyy";
        public static readonly string DATE_FORMAT_SHORT = "d/MM/yyyy";

        public static readonly Color SLOT_COLOR = ColorTranslator.FromHtml("#272728");
        public static readonly Color SLOT_COLOR_TODAY = ColorTranslator.FromHtml("#2C2D2F");
        public static readonly Color DATE_TEXT_COLOR = ColorTranslator.FromHtml("#CC9056");
        public static readonly Color DAYOFWEEK_TEXT_COLOR = ColorTranslator.FromHtml("#DAD5CB");

        private DateTime date;

        #endregion

        #region Fields

        private bool isToday;

        #endregion

        #region Properties

        public IObserver Observer { get; set; }

        public bool IsToday
        {
            get
            {
                return isToday;
            }
            set
            {
                isToday = value;

                this.BackColor = isToday ? SLOT_COLOR : SLOT_COLOR_TODAY;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;

                RenderDateLabel();
            }
        }

        public string DayOfWeek
        {
            get
            {
                return dayOfWeekLabel.Text;
            }
            set
            {
                dayOfWeekLabel.Text = value;
            }
        }

        #endregion

        public CalendarSlot()
        {
            InitializeComponent();

            this.BackColor = SLOT_COLOR;
            this.dateLabel.ForeColor = DATE_TEXT_COLOR;
            this.dayOfWeekLabel.ForeColor = DAYOFWEEK_TEXT_COLOR;
            this.addEvent.FlatAppearance.MouseDownBackColor = CalendarControl.CALENDAR_CONTROL_COLOR;
            this.addEvent.FlatAppearance.MouseOverBackColor = DATE_TEXT_COLOR;
        }

        #region Methods

        public void LoadEvents(ref List<Event> events)
        {
            this.flowPanel.Controls.Clear();

            for (int i = 0; i < events.Count; i++)
            {
                // Deal with non-repeating events
                if (!events[i].IsRecursive)
                {
                    if (events[i].Date == this.Date)
                    {
                        this.flowPanel.Controls.Add(new CalendarEventItem(events[i], this.Date, Observer));

                        events.RemoveAt(i--);
                    }

                    continue;
                }

                // Deal with repeating events
                DateTime date = events[i].Date;

                if (this.Date >= DateTime.Today) // Move forward in time for active events
                    for (; date < this.Date; date = date.AddDays((double)events[i].RecursionDays).AddMonths((int)events[i].RecursionMonths).AddYears((int)events[i].RecursionYears)) ;

                if (date == this.Date)
                    this.flowPanel.Controls.Add(new CalendarEventItem(events[i], this.Date, Observer));

            }
        }

        private void RenderDateLabel()
        {
            // Render the format of the date
            if (this.Width * CalendarControl.COLUMNS < MAX_WIDTH_FOR_DATE_RESIZE)
                this.dateLabel.Text = date.ToString(DATE_FORMAT_SHORT);
            else
                this.dateLabel.Text = date.ToString(DATE_FORMAT_LONG).ToUpper();

            // Reposition the label
            this.dateLabel.Left = this.Width / 2 - this.dateLabel.Width / 2;
        }

        #endregion

        #region Events

        private void CalendarSlot_SizeChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }

        private void dateLabel_TextChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            new CreateEventForm(this.date, Observer).ShowDialog();
        }

        #endregion
    }
}
