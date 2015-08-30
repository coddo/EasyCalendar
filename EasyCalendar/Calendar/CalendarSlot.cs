using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        private static readonly Color BACK_COLOR = ColorTranslator.FromHtml("#4D5965");
        private static readonly Color BORDER_COLOR = ColorTranslator.FromHtml("#CD802C");
        private static readonly Color TEXT_COLOR = ColorTranslator.FromHtml("#D1B800");

        public CalendarSlot()
        {
            InitializeComponent();

            this.BackColor = BACK_COLOR;
            dateLabel.ForeColor = TEXT_COLOR;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = ClientRectangle;
            rect.Location = new Point(rect.Location.X, rect.Location.Y);

            var pen = new Pen(BORDER_COLOR, 2);

            e.Graphics.DrawRectangle(pen, rect);
        }


        private void CalendarSlot_SizeChanged(object sender, System.EventArgs e)
        {
            RepositionDateLabel();
        }

        private void dateLabel_TextChanged(object sender, System.EventArgs e)
        {
            RepositionDateLabel();
        }

        private void RepositionDateLabel()
        {
            this.dateLabel.Left = this.Width / 2 - this.dateLabel.Width / 2;
        }
    }
}
