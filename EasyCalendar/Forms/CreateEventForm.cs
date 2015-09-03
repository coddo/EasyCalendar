using EasyCalendar.Controls;
using EasyCalendar.Controls.Navigation;
using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using EasyCalendar.DAL.Repositories.Events;
using System;
using System.Collections.Generic;
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

        private EventData CreateEventData()
        {
            var eventData = new EventData
            {
                Title = titleBox.Text,
                Details = descriptionBox.Text,
                IsRecursive = repeatCheckBox.Checked
            };

            if (eventData.IsRecursive)
            {
                var date = datePicker.Value;

                date.AddDays(int.Parse(repeatDaysBox.Text));
                date.AddMonths(int.Parse(repeatMonthsBox.Text));
                date.AddYears(int.Parse(repeatYearsBox.Text));

                eventData.RecursionDays = (int)(date - datePicker.Value).TotalDays;
            }

            using (var db = new UnitOfWork())
            {
                return db.EventsDataRepository.Insert(eventData);
            }
        }

        private Event[] CreateEvents(EventData eventData)
        {
            var startDate = datePicker.Value;
            var endDate = startDate.AddYears(DatePicker.MAX_YEARS_DISPLAYED);

            List<Event> eventsList = new List<Event>();
            for (DateTime i = startDate; i <= endDate; i = i.AddDays((double)eventData.RecursionDays))
            {
                eventsList.Add(new Event
                {
                    EventData = eventData,
                    Date = i,
                });
            }

            var events = eventsList.ToArray();
            using (var db = new UnitOfWork())
            {
                return db.EventsRepository.InsertAll(events);
            }
        }

        private void ClearUserInput()
        {
            titleBox.Clear();
            descriptionBox.Clear();
            repeatDaysBox.Clear();
            repeatMonthsBox.Clear();
            repeatYearsBox.Clear();

            repeatCheckBox.Checked = false;
            datePicker.Value = DateTime.Today;
        }

        private void repeatCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            repeatPanel.Visible = repeatCheckBox.Checked;
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            var eventData = CreateEventData();

            if (eventData == null || eventData.Id == Guid.Empty)
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var events = CreateEvents(eventData);

            if (events == null || events.Length == 0)
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            observer?.UpdateUI();
            ClearUserInput();
        }
    }
}
