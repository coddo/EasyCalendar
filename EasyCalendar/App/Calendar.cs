using System.Windows.Forms;

namespace EasyCalendar.App
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private void Calendar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = MousePosition.X + " " + MousePosition.Y;
        }
    }
}
