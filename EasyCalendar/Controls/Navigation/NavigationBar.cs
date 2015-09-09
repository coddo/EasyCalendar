using EasyCalendar.Controls.Abstract;
using EasyCalendar.Controls.Calendar;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EasyCalendar.Controls.Navigation
{
    public partial class NavigationBar : FloatingBar
    {
        #region Constants

        public static readonly Color NAVI_COLOR = ColorTranslator.FromHtml("#95B5BB");

        #endregion

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

        private void NavigationBar_Load(object sender, System.EventArgs e)
        {
            this.BackColor = NAVI_COLOR;
        }

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
