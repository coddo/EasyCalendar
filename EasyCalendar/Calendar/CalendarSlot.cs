using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class CalendarSlot : UserControl
    {
        private static readonly Color SLOT_COLOR = ColorTranslator.FromHtml("#78866B");
        private static readonly Color BORDER_COLOR = ColorTranslator.FromHtml("#E9AB17");
        private static readonly Color TEXT_COLOR = ColorTranslator.FromHtml("#493D26");

        public CalendarSlot()
        {
            InitializeComponent();

            this.BackColor = SLOT_COLOR;
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
