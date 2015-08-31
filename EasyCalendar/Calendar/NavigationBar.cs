using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EasyCalendar.Calendar
{
    public partial class NavigationBar : UserControl
    {
        public const int FLOW_HEIGHT = 30;

        private CalendarControl parent;

        public NavigationBar()
        {
            InitializeComponent();
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.parent = parent;
        }

        private bool IsPointerOverChild()
        {
            if (previousButton.ClientRectangle.Contains(previousButton.PointToClient(MousePosition)))
                return true;

            if (nextButton.ClientRectangle.Contains(nextButton.PointToClient(MousePosition)))
                return true;

            if (datePicker.ClientRectangle.Contains(datePicker.PointToClient(MousePosition)))
                return true;

            return false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = this.ClientRectangle;
            var pen = new Pen(CalendarSlot.TEXT_COLOR, 3);

            e.Graphics.DrawRectangle(pen, rect);

        }

        private void NavigationBar_Load(object sender, System.EventArgs e)
        {
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {

        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {

        }

        private void NavigationBar_MouseEnterAnimate(object sender, System.EventArgs e)
        {
            if (IsPointerOverChild())
                return;

            this.MouseEnter -= this.NavigationBar_MouseEnterAnimate;
            this.MouseLeave -= this.NavigationBar_MouseLeaveAnimate;

            this.MouseEnter += this.NavigationBar_MouseEnter;

            new Thread(() =>
            {
                var transitionDistance = FLOW_HEIGHT + this.Height;

                this.Invoke((MethodInvoker)(() =>
                {
                    while (transitionDistance > 0)
                    {
                        this.Top--;

                        transitionDistance--;
                        this.Refresh();

                        Thread.Sleep(new TimeSpan(1));
                    }
                }));
            }).Start();
        }

        private void NavigationBar_MouseEnter(object sender, System.EventArgs e)
        {
            this.MouseLeave += this.NavigationBar_MouseLeaveAnimate;

            this.MouseEnter -= NavigationBar_MouseEnter;
        }

        private void NavigationBar_MouseLeaveAnimate(object sender, System.EventArgs e)
        {
            if (IsPointerOverChild())
                return;

            this.MouseEnter -= NavigationBar_MouseEnter;

            this.MouseEnter -= this.NavigationBar_MouseEnterAnimate;
            this.MouseLeave -= this.NavigationBar_MouseLeaveAnimate;

            new Thread(() =>
            {
                var transitionDistance = FLOW_HEIGHT + this.Height;

                this.Invoke((MethodInvoker)(() =>
                {
                    while (transitionDistance > 0)
                    {
                        this.Top++;

                        transitionDistance--;

                        this.Refresh();

                        Thread.Sleep(new TimeSpan(1));
                    }

                    this.MouseEnter += this.NavigationBar_MouseEnterAnimate;
                }));
            }).Start();
        }

        private void NavigationBar_MouseLeave(object sender, System.EventArgs e)
        {
        }

        private void datePicker_ValueChanged(object sender, System.EventArgs e)
        {

        }
    }
}
