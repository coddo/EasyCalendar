using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        public static readonly Color BACK_COLOR = ColorTranslator.FromHtml("#4D5965");
        public static readonly Color TEXT_COLOR = ColorTranslator.FromHtml("#D1B800");

        private static readonly string DATE_FORMAT_LONG = "dd MMMM yyyy";
        private static readonly string DATE_FORMAT_SHORT = "dd/MM/yyyy";

        public CalendarSlot()
        {
            InitializeComponent();

            this.BackColor = BACK_COLOR;
            dateLabel.ForeColor = TEXT_COLOR;
        }

        private void RenderDateLabel()
        {
            // Render the format of the date
            //

            // Reposition the label
            this.dateLabel.Left = this.Width / 2 - this.dateLabel.Width / 2;
        }

        private void CalendarSlot_SizeChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }

        private void dateLabel_TextChanged(object sender, System.EventArgs e)
        {
            RenderDateLabel();
        }
    }
}
