using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        #region Constants

        private const int MAX_WIDTH_FOR_DATE_RESIZE = 1350;

        private static readonly string DATE_FORMAT_LONG = "d MMMM yyyy";
        private static readonly string DATE_FORMAT_SHORT = "d/MM/yyyy";

        public static readonly Color SLOT_COLOR = ColorTranslator.FromHtml("#272728");
        public static readonly Color SLOT_COLOR_TODAY = ColorTranslator.FromHtml("#2C2D2F");
        public static readonly Color DATE_TEXT_COLOR = ColorTranslator.FromHtml("#CC9056");
        public static readonly Color DAYOFWEEK_TEXT_COLOR = ColorTranslator.FromHtml("#DAD5CB");

        private DateTime date;

        #endregion

        #region Properties

        private bool isToday;
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

        }

        #endregion
    }
}
