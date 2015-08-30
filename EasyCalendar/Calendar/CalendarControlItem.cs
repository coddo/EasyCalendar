using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarControlItem : UserControl
    {
        public CalendarControlItem()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = ClientRectangle;
            rect.Location = new Point(rect.Location.X, rect.Location.Y);

            var pen = new Pen(Color.Blue, 2);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
