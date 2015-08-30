using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarControlItem : FlowLayoutPanel
    {
        public CalendarControlItem()
        {
            InitializeComponent();
        }

        public CalendarControlItem(Rectangle bounds) : this()
        {
            this.Location = bounds.Location;
            this.Size = bounds.Size;
        }

        public CalendarControlItem(IContainer container) : this()
        {
            container.Add(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = ClientRectangle;
            rect.Height += 1;
            rect.Width += 1;

            var pen = new Pen(Color.Blue, 2);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
