using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.CalendarControls.Calendar
{
    public partial class CalendarControl : UserControl
    {
        #region Constants

        public static readonly Color CALENDAR_CONTROL_COLOR = ColorTranslator.FromHtml("#D8852A");

        #endregion

        #region Fields

        private List<CalendarSlot> slots = new List<CalendarSlot>();

        #endregion

        public CalendarControl()
        {
            InitializeComponent();

            // Generate calendar slots
            CreateCalendarSlots();
        }

        #region Methods

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

        private Size ComputeItemSize() => new Size(this.Width / 7 - 2, this.Height / 6 - 2);

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

                    slot.Left = 2 + column * size.Width + 2 * column;
                    slot.Top = 3 + row * size.Height + 2 * row;
                    slot.Size = size;
                }
            }
        }

        #endregion

        #region Events

        private void RepositionNavigationBar()
        {
            navigator.Left = this.Width / 2 - navigator.Width / 2;
            navigator.Top = this.Height - 5;
        }

        private void CalendarControl_SizeChanged(object sender, EventArgs e)
        {
            RenderSlots();
            RepositionNavigationBar();
        }

        private void CalendarControl_Load(object sender, EventArgs e)
        {
            this.BackColor = CALENDAR_CONTROL_COLOR;
        }

        #endregion
    }
}
