using System;
using System.Windows.Forms;

namespace EasyCalendar.CalendarControls.Navigation
{
    public partial class DatePicker : UserControl
    {
        #region Constants

        private const int maxYearAddition = 100;

        #endregion

        #region Fields

        private DateTime date;

        #endregion

        #region Properties

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                this.date = value;

                this.dayBox.SelectedIndex = date.Day - 1;
                this.monthBox.SelectedIndex = date.Month;
                this.yearBox.SelectedIndex = date.Year - DateTime.Now.Year;
            }
        }

        #endregion

        public DatePicker()
        {
            InitializeComponent();

            PopulateYearBox();
            this.Date = DateTime.Now.Date;
        }

        #region Overrides

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            this.dayBox.Font = this.Font;
            this.monthBox.Font = this.Font;
            this.yearBox.Font = this.Font;
        }

        #endregion

        #region Methods

        private void PopulateYearBox()
        {
            int startYear = DateTime.Now.Year;

            for (int year = startYear; year < startYear + maxYearAddition; year++)
            {
                yearBox.Items.Add(year);
            }
        }

        private bool ValidateDay(ref int day)
        {
            if (!int.TryParse(dayBox.Text, out day))
                return false;

            for (int i = 0; i < dayBox.Items.Count; i++)
            {
                if (day == int.Parse(dayBox.Items[i].ToString()))
                    return true;
            }

            MessageBox.Show("The entered day is either invalid or it is out of bounds!", "Invalid day", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }

        private bool ValidateMonth(ref int month)
        {
            for (int i = 0; i < monthBox.Items.Count; i++)
            {
                if (monthBox.Items[i].ToString() == monthBox.Text)
                {
                    month = i;
                    break;
                }
            }
            if (month == -1)
            {
                MessageBox.Show("The name of the month is invalid!", "Spelling error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool ValidateYear(ref int year)
        {
            if (!int.TryParse(dayBox.Text, out year))
                return false;

            return true;
        }

        private bool ValidateDateBoxes(out int day, out int month, out int year)
        {
            day = month = year = -1;

            if (dayBox.Text == string.Empty || monthBox.Text == string.Empty || yearBox.Text == string.Empty)
                return false;

            if (!ValidateDay(ref day))
                return false;

            if (!ValidateMonth(ref month))
                return false;

            if (!ValidateYear(ref year))
                return false;

            return true;
        }

        private void ParseDate()
        {
            int day;
            int month;
            int year;

            if (!ValidateDateBoxes(out day, out month, out year))
                return;

            //var day = dayBox.SelectedIndex + 1;
            //var month = monthBox.SelectedIndex;
            //var year = yearBox.SelectedIndex + DateTime.Now.Year;

            var date = new DateTime(year, month, day);

            if (!DateTime.TryParse(date.ToString(), out date))
            {
                MessageBox.Show("The selected date is not valid!", "Wrong date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                this.Date = date;
            }
        }

        #endregion

        private void dayBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseDate();
        }

        private void dayBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            ParseDate();
        }
    }
}
