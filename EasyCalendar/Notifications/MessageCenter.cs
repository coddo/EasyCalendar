using System.Windows.Forms;

namespace EasyCalendar.Notifications
{
    public static class MessageCenter
    {
        public static class Error
        {
            public static void EventCreationError()
            {
                MessageBox.Show("There was an error while creating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            public static void EventUpdatingError()
            {
                MessageBox.Show("There was an error while updating the event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class Stop
        {
            public static void InvalidMonthName()
            {
                MessageBox.Show("The name of the month is invalid!", "Spelling error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void InvalidDateSelection()
            {
                MessageBox.Show("The selected date is not valid!", "Wrong date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void EventDateBeforeToday()
            {
                MessageBox.Show("The event date cannot be before today!", "Bad date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void NoTitleSet()
            {
                MessageBox.Show("The event must have a title set!", "No title", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void EmptyRepeatFields()
            {
                MessageBox.Show("The fields for repeating the event cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void InvalidRepeatDataValues()
            {
                MessageBox.Show("The fields for repeating the event do not contain valid values!", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            public static void NegativeRepeatDataValues()
            {
                MessageBox.Show("The fields for repeating the event cannot contain negative values", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static class Info
        {
            public static void EventUpdated()
            {
                MessageBox.Show("The event was successfully updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static class Confirmation
        {
            public static DialogResult ConfirmDeleteEvent()
            {
                return MessageBox.Show("Are you sure that you want to delete this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
    }
}
