using EasyCalendar.Controls;
using EasyCalendar.DAL;
using EasyCalendar.DAL.Models;
using System;
using System.Windows.Forms;

namespace EasyCalendar.Forms
{
    public partial class EditEventForm : CreateEventForm
    {

        #region Fields

        private Event targetEvent;

        #endregion

        public EditEventForm(Event ev, IObserver observer) : base(ev.Date, observer)
        {
            InitializeComponent();

            this.targetEvent = ev;

            DisplayEventData();
        }

        #region Methods

        private void DisplayEventData()
        {
            this.titleBox.Text = targetEvent.Title;
            this.descriptionBox.Text = targetEvent.Details;
            this.datePicker.Value = targetEvent.Date;
            this.repeatCheckBox.Checked = targetEvent.IsRecursive;
            this.repeatDaysBox.Text = targetEvent.RecursionDays.ToString();
            this.repeatMonthsBox.Text = targetEvent.RecursionMonths.ToString();
            this.repeatYearsBox.Text = targetEvent.RecursionYears.ToString();
        }

        private Event UpdateEvent()
        {
            using (var db = new UnitOfWork())
            {
                var ev = db.EventsRepository.Get(targetEvent.Id);

                ev.Title = titleBox.Text;
                ev.Details = descriptionBox.Text;
                ev.Date = datePicker.Value;
                ev.IsRecursive = repeatCheckBox.Checked;
                ev.IsSeen = false;

                ev.RecursionDays = int.Parse(repeatDaysBox.Text);
                ev.RecursionMonths = int.Parse(repeatMonthsBox.Text);
                ev.RecursionYears = int.Parse(repeatYearsBox.Text);

                return db.EventsRepository.Update(ev);
            }
        }

        #endregion

        #region Overrides

        protected override void performActionButton_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            var ev = targetEvent = UpdateEvent();

            if (ev == null || ev.Id == Guid.Empty.ToString())
            {
                MessageBox.Show("There was an error creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            observer?.UpdateUI();

            MessageBox.Show("The event was successfully updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Event handlers

        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (var db = new UnitOfWork())
            {
                db.EventsRepository.Delete(targetEvent.Id);
            }

            observer?.UpdateUI();
            this.Close();
        }

        #endregion
    }
}
