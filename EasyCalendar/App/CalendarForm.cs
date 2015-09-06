using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
        }

        private void CalendarForm_Shown(object sender, System.EventArgs e)
        {
            calendarControl.Refresh();
        }
    }
}
