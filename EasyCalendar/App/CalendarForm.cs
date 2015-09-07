using EasyCalendar.DAL;
using EasyCalendar.Notifications;
using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
        }

        private void CalendarForm_Load(object sender, System.EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                if (db.EventsRepository.HasUpcomingEvents())
                    AlarmCenter.PlayAlarm();
            }
        }

        private void CalendarForm_Shown(object sender, System.EventArgs e)
        {
            calendarControl.Refresh();
        }
    }
}
