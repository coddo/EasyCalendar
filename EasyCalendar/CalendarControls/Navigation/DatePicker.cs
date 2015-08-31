using System;
using System.Windows.Forms;

namespace EasyCalendar.CalendarControls.Navigation
{
    public partial class DatePicker : UserControl, IObservable
    {
        #region Constants

        private const int maxYearAddition = 100;

        #endregion

        #region Fields

        private int month;
        private int year;

        #endregion

        #region Properties

        public int Month
        {
            get
            {
                return this.month;
            }
            set
            {
                if (value > 12)
                {
                    value = 1;
                    Year++;
                }
                else if (value < 1)
                {
                    value = 1;
                    Year--;
                }

                this.month = value;

                this.monthBox.SelectedIndex = value - 1;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;

                this.yearBox.Text = value.ToString();
            }
        }

        public DateTime Date
        {
            get
            {
                return new DateTime(Year, Month, 1);
            }
            set
            {
                this.Month = value.Month;
                this.Year = value.Year;
            }
        }

        public IObserver Observer { get; set; }

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

        private bool ValidateMonth(ref int month)
        {
            for (int i = 0; i < monthBox.Items.Count; i++)
            {
                if (monthBox.Items[i].ToString() == monthBox.Text)
                {
                    month = i+1;
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
            if (!int.TryParse(yearBox.Text, out year))
                return false;

            return true;
        }

        private bool ValidateDateBoxes(out int month, out int year)
        {
            month = year = -1;

            if (monthBox.Text == string.Empty || yearBox.Text == string.Empty)
                return false;

            if (!ValidateMonth(ref month))
                return false;

            if (!ValidateYear(ref year))
                return false;

            // Check for end of year or start of year navigations
            if (month > 12)
            {
                month = 1;
                year++;
            }
            else if (month < 1)
            {
                month = 1;
                year--;
            }

            return true;
        }

        private void ParseDate()
        {
            // Parse the date
            int day = 1;
            int month;
            int year;

            if (!ValidateDateBoxes(out month, out year))
                return;

            var date = new DateTime(year, month, day);

            if (!DateTime.TryParse(date.ToString(), out date))
            {
                MessageBox.Show("The selected date is not valid!", "Wrong date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                this.Date = date;
            }

            // Update the observer
            Observer?.UpdateData();
        }

        #endregion

        private void DateBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseDate();
        }

        private void DateBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            ParseDate();
        }

        private void DatePicker_Load(object sender, EventArgs e)
        {
            //monthBox.SelectedIndexChanged += DateBoxes_SelectedIndexChanged;
            //yearBox.SelectedIndexChanged += DateBoxes_SelectedIndexChanged;
        }
    }
}
