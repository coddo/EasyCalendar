using EasyCalendar.Controls;
using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using System;
using System.Windows.Forms;

namespace EasyCalendar.Forms
{
    public partial class CreateEventForm : Form
    {
        private IObserver observer;

        public CreateEventForm(DateTime date, IObserver observer)
        {
            InitializeComponent();

            this.datePicker.Value = date;
            this.observer = observer;
        }

        private bool VerifyFields()
        {


            if (datePicker.Value < DateTime.Now)
            {
                MessageBox.Show("The event date cannot be earlier than today!", "Bad date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (titleBox.Text == string.Empty)
            {
                MessageBox.Show("The event must have a title set!", "No title", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (repeatCheckBox.Enabled)
            {
                if (repeatDaysBox.Text == string.Empty || repeatYearsBox.Text == string.Empty || repeatMonthsBox.Text == string.Empty)
                {
                    MessageBox.Show("The fields for repeating the event cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            var recursionDays = -1;
            var recursionMonths = -1;
            var recursionYears = -1;

            if (!int.TryParse(repeatDaysBox.Text, out recursionDays) || !int.TryParse(repeatMonthsBox.Text, out recursionMonths) || !int.TryParse(repeatYearsBox.Text, out recursionYears))
            {
                MessageBox.Show("The fields for repeating the event do not contain valid values!", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (recursionDays < 0 || recursionMonths < 0 || recursionYears < 0)
            {
                MessageBox.Show("The fields for repeating the event cannot contain negative values", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                Seen = false,
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

        private void ClearUserInput()
        {
            titleBox.Clear();
            descriptionBox.Clear();

            repeatDaysBox.Text = "0";
            repeatMonthsBox.Text = "0";
            repeatYearsBox.Text = "0";

            repeatCheckBox.Checked = false;
        }

        private void repeatCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            repeatPanel.Visible = repeatCheckBox.Checked;
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            var eventData = CreateEvent();

            if (eventData == null || eventData.Id == Guid.Empty.ToString())
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            observer?.UpdateUI();
            ClearUserInput();
        }
    }
}
