using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarControl : UserControl
    {
        public CalendarControl()
        {
            InitializeComponent();

            // Generate calendar slots and arrange them
            CreateCalendarSlots();
        }

        private void CreateCalendarSlots()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    this.Controls.Add(new CalendarControlItem());
                }
            }
        }

        private void RenderCalendarSlots()
        {
            // Compute item size
            Size size = ComputeItemSize();

            // Resize and relocate items
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    var slot = this.Controls[row * 7 + column];

                    slot.Size = size;
                    slot.Location = new Point(column * size.Width + 3, row * size.Height + 3);
                }
            }

            this.Refresh();
        }

        private Size ComputeItemSize() => new Size(this.Width / 7 - 1, this.Height / 6 - 1);

        private void CalendarControl_SizeChanged(object sender, EventArgs e)
        {
            RenderCalendarSlots();
        }
    }
}
