using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.CalendarControls.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        #region Constants

        public static readonly Color SLOT_COLOR = ColorTranslator.FromHtml("#4D4D4D");
        public static readonly Color TEXT_COLOR = ColorTranslator.FromHtml("#EFAE12");

        private static readonly string DATE_FORMAT_LONG = "d MMMM yyyy";
        private static readonly string DATE_FORMAT_SHORT = "d/MM/yyyy";

        private DateTime date;

        #endregion

        public CalendarSlot()
        {
            InitializeComponent();

            this.BackColor = SLOT_COLOR;
            dateLabel.ForeColor = TEXT_COLOR;

            date = DateTime.Now;
        }

        #region Methods

        private void RenderDateLabel()
        {
            // Render the format of the date
            if (this.Width * 7 < 1000)
                this.dateLabel.Text = date.ToString(DATE_FORMAT_SHORT);
            else
                this.dateLabel.Text = date.ToString(DATE_FORMAT_LONG);

            // Reposition the label
            this.dateLabel.Left = this.Width / 2 - this.dateLabel.Width / 2;
        }

        #endregion

        #region Events

        private void CalendarSlot_SizeChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }

        private void dateLabel_TextChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }

        #endregion
    }
}
