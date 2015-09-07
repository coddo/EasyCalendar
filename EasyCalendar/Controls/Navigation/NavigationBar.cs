using EasyCalendar.Controls.Abstract;
using EasyCalendar.Controls.Calendar;
using System;

namespace EasyCalendar.Controls.Navigation
{
    public partial class NavigationBar : FloatingBar
    {
        #region Properties

        private new CalendarControl Parent { get; set; }

        public DatePicker DatePicker => this.datePicker;

        public DateTime Date => datePicker.Date;

        #endregion

        public NavigationBar()
        {
            InitializeComponent();
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.Parent = parent;
        }

        #region Overrides

        #endregion

        #region Methods

        #endregion

        #region Events

        private void nextButton_Click(object sender, System.EventArgs e)
        {
            datePicker.Date = datePicker.Date.AddMonths(1);
        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {
            datePicker.Date = datePicker.Date.AddMonths(-1);
        }

        #endregion
    }
}
