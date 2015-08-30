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

            this.BackColor = BACK_COLOR;
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.parent = parent;
        }
    }
}
