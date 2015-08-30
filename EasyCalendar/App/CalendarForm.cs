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

        private void Calendar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = MousePosition.X + " " + MousePosition.Y;
        }

        private void CalendarForm_SizeChanged(object sender, System.EventArgs e)
        {
            Text = $"{Size.Width} x {Size.Height}";
        }
    }
}
