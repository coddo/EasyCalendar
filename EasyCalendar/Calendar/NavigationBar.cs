using EasyCalendar.CustomControls;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class NavigationBar : UserControl
    {
        private static readonly Color BACK_COLOR = ColorTranslator.FromHtml("#726E6D");

        private CalendarControl parent;

        public NavigationBar()
        {
            InitializeComponent();

            this.BackColor = BACK_COLOR;
            nextButton.BackColor = BACK_COLOR;
            previousButton.BackColor = BACK_COLOR;

            //this.Opacity = 50;
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.parent = parent;
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {

        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
