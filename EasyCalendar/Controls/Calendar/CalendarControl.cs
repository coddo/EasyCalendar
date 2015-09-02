using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Calendar
{
    public partial class CalendarControl : UserControl, IObserver
    {
        #region Constants

        public const int ROWS = 6;
        public const int COLUMNS = 7;

        public static readonly Color CALENDAR_CONTROL_COLOR = ColorTranslator.FromHtml("#5D797D");

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

        public void UpdateData()
        {
            var date = navigator.Date;
            var addition = 0;
            
            int index = (int)date.DayOfWeek - 1;
            if (index < 0) // Sunday
                index = COLUMNS - 1;

            date = date.AddDays(-index);
            for(int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++, addition++)
                {
                    var newDate = date.AddDays(addition);

                    slots[i * COLUMNS + j].Date = newDate;
                    slots[i * COLUMNS + j].IsToday = DateTime.Today.Equals(newDate);
                }
            }

        }

        #endregion

        #region Methods for UI

        private void CreateCalendarSlots()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    var slot = new CalendarSlot
                    {
                        DayOfWeek = ShortenedDayOfWeek(column)
                    };

                    slots.Add(slot);
                    this.Controls.Add(slot);
                }
            }
        }

        private Size ComputeItemSize() => new Size(this.Width / COLUMNS - 2, this.Height / ROWS - 2);

        private void RenderSlots()
        {
            // Compute item size
            Size size = ComputeItemSize();

            // Resize and relocate items
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    var slot = slots[row * COLUMNS + column];

                    slot.Left = 2 + column * size.Width + 2 * column;
                    slot.Top = 3 + row * size.Height + 2 * row;
                    slot.Size = size;
                }
            }
        }

        private string ShortenedDayOfWeek(int slotColumn)
        {
            switch (slotColumn)
            {
                case 0: return "MON";
                case 1: return "TUE";
                case 2: return "WED";
                case 3: return "THU";
                case 4: return "FRI";
                case 5: return "SAT";
                case ROWS: return "SUN";
            }

            return "";
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

            this.navigator.DatePicker.Observer = this;
            this.navigator.DatePicker.Date = DateTime.Now;
        }

        #endregion
    }
}
