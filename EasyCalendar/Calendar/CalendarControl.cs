using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarControl : UserControl
    {
        private List<CalendarSlot> slots = new List<CalendarSlot>();

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
                    var slot = new CalendarSlot();

                    slots.Add(slot);
                    this.Controls.Add(slot);
                }
            }
        }

        private Size ComputeItemSize() => new Size(this.Width / 7 - 1, this.Height / 6 - 1);

        private void RepositionNavigationBar()
        {

        }

        private void RenderSlots()
        {
            // Compute item size
            Size size = ComputeItemSize();

            // Resize and relocate items
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    var slot = slots[row * 7 + column];

                    slot.Left = column * size.Width + 3;
                    slot.Top = row * size.Height + 3;
                    slot.Size = size;
                }
            }

            Controls[0].Visible = true;
            //Controls[2].Location = new Point(3, 25 + 3);

            this.Refresh();
        }

        private void CalendarControl_SizeChanged(object sender, EventArgs e)
        {
            RenderSlots();
            RepositionNavigationBar();
        }
    }
}
