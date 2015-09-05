using EasyCalendar.Controls;
using EasyCalendar.Controls.Navigation;
using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
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
                eventData.RecursionDays = int.Parse(repeatDaysBox.Text);
                eventData.RecursionMonths = int.Parse(repeatMonthsBox.Text);
                eventData.RecursionYears = int.Parse(repeatYearsBox.Text);
            }

            using (var db = new UnitOfWork())
            {
                return db.EventsDataRepository.Insert(eventData);
            }
        }

        private bool CreateEvents(EventData eventData)
        {
            if (eventData.IsRecursive)
            {
                var startDate = datePicker.Value;
                var endDate = startDate.AddYears(DatePicker.MAX_YEARS_DISPLAYED);

                using (var db = new UnitOfWork())
                {
                    eventData = db.EventsDataRepository.Get(eventData.Id);

                    for (DateTime i = startDate; i <= endDate; i = i.AddDays((double)eventData.RecursionDays).AddMonths((int)eventData.RecursionMonths).AddYears((int)eventData.RecursionYears))
                    {
                        var ev = db.EventsRepository.Insert(new Event
                        {
                            EventData = eventData,
                            Date = i
                        });

                        if (ev == null)
                            return false;
                    }
                }

                return true;
            }
            else
            {
                using (var db = new UnitOfWork())
                {
                    var ev = new Event
                    {
                        Date = datePicker.Value,
                        EventData = db.EventsDataRepository.Get(eventData.Id)
                    };

                    return db.EventsRepository.Insert(ev) != null;
                }
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

            var eventData = CreateEventData();

            if (eventData == null || eventData.Id == Guid.Empty.ToString())
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var eventsCreated = CreateEvents(eventData);

            if (!eventsCreated)
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Rollback created EventData item
                using (var db = new UnitOfWork())
                {
                    db.EventsDataRepository.Delete(eventData.Id);
                }

                return;
            }

            observer?.UpdateUI();
            ClearUserInput();
        }
    }
}
