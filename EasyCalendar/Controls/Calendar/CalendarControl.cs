﻿using EasyCalendar.Controls.Navigation;
using EasyCalendar.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

        #region Threads

        private Thread rendererThread;

        #endregion

        #region Properties

        public DateTime Date
        {
            get
            {
                return navigator.Date;
            }

            set
            {
                navigator.Date = value;
            }
        }

        #endregion

        public CalendarControl()
        {
            InitializeComponent();

            // Generate calendar slots
            CreateCalendarSlots();

            // Initialize UI rendering thread
            rendererThread = new Thread(LoadDatesOntoCalendar);
        }

        #region Methods

        private void LoadDatesOntoCalendar()
        {
            var date = navigator.Date;
            var addition = 0;

            int index = (int)date.DayOfWeek - 1;
            if (index < 0) // Sunday
                index = COLUMNS - 1;

            // Fix dates on the slots
            date = date.AddDays(-index);
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++, addition++)
                {
                    var newDate = date.AddDays(addition);

                    slots[i * COLUMNS + j].IsToday = DateTime.Today.Equals(newDate);

                    slots[i * COLUMNS + j].Invoke((MethodInvoker)(() =>
                    {
                        slots[i * COLUMNS + j].Date = newDate;

                    }));
                }
            }

            // Load events for all the slots
            using (var db = new UnitOfWork())
            {
                var events = db.EventsRepository.GetActiveEventsAsList(slots[0].Date, slots[ROWS * COLUMNS - 1].Date);

                for (int i = 0; i < ROWS; i++)
                {
                    for (int j = 0; j < COLUMNS; j++, addition++)
                    {
                        slots[i * COLUMNS + j].Invoke((MethodInvoker)(() =>
                        {
                            slots[i * COLUMNS + j].LoadEvents(ref events);
                        }));
                    }
                }
            }
        }

        public void UpdateUI()
        {
            if (rendererThread.IsAlive)
                rendererThread.Abort();

            this.Refresh();

            rendererThread = new Thread(LoadDatesOntoCalendar);
            rendererThread.Start();
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
                        DayOfWeek = ShortenedDayOfWeek(column),
                        Observer = this
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

        private void RepositionFloatingBars()
        {
            navigator.Left = this.Width / 2 - navigator.Width / 2;
            navigator.Top = this.Height - 5;

            quickActionBar.Left = 30;
            quickActionBar.Top = navigator.Top;

            legendBox.Left = this.Width - legendBox.Width - 30;
            legendBox.Top = navigator.Top;
        }

        #endregion

        #region Events

        private void CalendarControl_SizeChanged(object sender, EventArgs e)
        {
            RenderSlots();
            RepositionFloatingBars();
        }

        private void CalendarControl_Load(object sender, EventArgs e)
        {
            this.BackColor = CALENDAR_CONTROL_COLOR;

            this.navigator.DatePicker.Observer = this;
            this.navigator.DatePicker.Date = DateTime.Now;

            this.quickActionBar.Parent = this;
        }

        #endregion
    }
}
