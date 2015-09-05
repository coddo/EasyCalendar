using EasyCalendar.DAL.Models;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarEventItem : Button
    {
        private Event ev;

        public Event Event => this.ev;

        public CalendarEventItem(Event ev)
        {
            InitializeComponent();

            this.ev = ev;
        }

        private void EventItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }

            else if (e.Button == MouseButtons.Right)
            {

            }
        }
    }
}
