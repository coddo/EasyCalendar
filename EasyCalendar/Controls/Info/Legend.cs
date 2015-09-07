using EasyCalendar.Controls.Abstract;

namespace EasyCalendar.Controls.Info
{
    public partial class Legend : FloatingBar
    {
        public Legend()
        {
            InitializeComponent();

            /*passedLabel.ForeColor = CalendarSlot.DATE_TEXT_COLOR;
            missedLabel.ForeColor = CalendarSlot.DATE_TEXT_COLOR;
            todayLabel.ForeColor = CalendarSlot.DATE_TEXT_COLOR;
            upcomingLabel.ForeColor = CalendarSlot.DATE_TEXT_COLOR;
            normalLabel.ForeColor = CalendarSlot.DATE_TEXT_COLOR;*/
        }

        protected internal override int WaitTimeNanoS => 10000;
    }
}
