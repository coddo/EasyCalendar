using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarControl : UserControl
    {
        public CalendarControl()
        {
            InitializeComponent();
        }

        private void RenderCalendar()
        {
            // Clear controls
            this.Controls.Clear();

            // Compute item size
            Size size = ComputeItemSize();

            // Add items
            for (int row = 0; row < 7; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    var bounds = new Rectangle
                    {
                        Size = size,
                        Location = new Point(row * size.Width + 1, column * size.Height + 1)
                    };

                    this.Controls.Add(new CalendarControlItem(bounds));
                }
            }
        }

        private Size ComputeItemSize() => new Size(this.Width / 7 - 1, this.Height / 6 - 1);

        private void CalendarControl_SizeChanged(object sender, EventArgs e)
        {
            RenderCalendar();
        }
    }
}
