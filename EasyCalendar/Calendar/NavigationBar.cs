using EasyCalendar.CustomControls;
using System.Drawing;

namespace EasyCalendar.Calendar
{
    public partial class NavigationBar : OpacityUserControl
    {
        private static readonly Color BACK_COLOR = ColorTranslator.FromHtml("#726E6D");

        private CalendarControl parent;

        public NavigationBar()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            base.Refresh();
            nextButton.Refresh();
            previousButton.Refresh();
            datePicker.Refresh();
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.parent = parent;
        }

        private void NavigationBar_Load(object sender, System.EventArgs e)
        {
            this.BackColor = BACK_COLOR;
            nextButton.BackColor = Color.Transparent;
            previousButton.BackColor = Color.Transparent;
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {

        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
