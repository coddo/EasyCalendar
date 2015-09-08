using EasyCalendar.Controls;
using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using EasyCalendar.Notifications;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Forms
{
    public partial class CreateEventForm : Form
    {
        #region Constants

        public static readonly Color FORM_BACK_COLOR = ColorTranslator.FromHtml("#DAD5CB");

        #endregion
        #region Fields 

        protected IObserver observer;

        #endregion

        [Obsolete("Designer only", true)]
        public CreateEventForm()
        {
            InitializeComponent();
        }

        public CreateEventForm(DateTime date, IObserver observer)
        {
            InitializeComponent();

            this.BackColor = FORM_BACK_COLOR;

            this.datePicker.Value = date;
            this.observer = observer;
        }

        #region Methods

        protected bool VerifyFields()
        {
            if (datePicker.Value < DateTime.Today)
            {
                MessageCenter.Stop.EventDateBeforeToday();
                return false;
            }

            if (titleBox.Text == string.Empty)
            {
                MessageCenter.Stop.NoTitleSet();
                return false;
            }

            if (repeatCheckBox.Enabled)
            {
                if (repeatDaysBox.Text == string.Empty || repeatYearsBox.Text == string.Empty || repeatMonthsBox.Text == string.Empty)
                {
                    MessageCenter.Stop.EmptyRepeatFields();
                    return false;
                }
            }

            var recursionDays = -1;
            var recursionMonths = -1;
            var recursionYears = -1;

            if (!int.TryParse(repeatDaysBox.Text, out recursionDays) || !int.TryParse(repeatMonthsBox.Text, out recursionMonths) || !int.TryParse(repeatYearsBox.Text, out recursionYears))
            {
                MessageCenter.Stop.InvalidRepeatDataValues();
                return false;
            }
            else if (recursionDays < 0 || recursionMonths < 0 || recursionYears < 0)
            {
                MessageCenter.Stop.NegativeRepeatDataValues();
                return false;
            }

            return true;
        }

        private Event CreateEvent()
        {
            var ev = new Event
            {
                Title = titleBox.Text,
                Details = descriptionBox.Text,
                IsRecursive = repeatCheckBox.Checked,
                IsSeen = false,
                Date = datePicker.Value,
            };

            if (ev.IsRecursive)
            {
                ev.RecursionDays = int.Parse(repeatDaysBox.Text);
                ev.RecursionMonths = int.Parse(repeatMonthsBox.Text);
                ev.RecursionYears = int.Parse(repeatYearsBox.Text);
            }

            using (var db = new UnitOfWork())
            {
                return db.EventsRepository.Insert(ev);
            }
        }

        protected void ClearUserInput()
        {
            titleBox.Clear();
            descriptionBox.Clear();

            repeatDaysBox.Text = "0";
            repeatMonthsBox.Text = "0";
            repeatYearsBox.Text = "0";

            repeatCheckBox.Checked = false;
        }

        #endregion

        #region Event handlers

        private void repeatCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            repeatPanel.Visible = repeatCheckBox.Checked;
        }

        protected virtual void performActionButton_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            var ev = CreateEvent();

            if (ev == null || ev.Id == Guid.Empty.ToString())
            {
                MessageCenter.Error.EventCreationError();
                return;
            }

            observer?.UpdateUI();
            ClearUserInput();
        }

        #endregion
    }
}
