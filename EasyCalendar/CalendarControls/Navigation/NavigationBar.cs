using EasyCalendar.CalendarControls.Calendar;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EasyCalendar.CalendarControls.Navigation
{
    public partial class NavigationBar : UserControl
    {
        #region Constants

        public static readonly Color NAVI_COLOR = ColorTranslator.FromHtml("#EA902D");

        public const int FLOW_HEIGHT = 30;

        #endregion

        #region Properties

        private new CalendarControl Parent { get; set; }

        public DatePicker DatePicker => this.datePicker;

        public DateTime Date => datePicker.Date;

        #endregion

        public NavigationBar()
        {
            InitializeComponent();
        }

        public NavigationBar(CalendarControl parent) : this()
        {
            this.Parent = parent;
        }

        #region Methods

        private bool IsPointerOverChild()
        {
            if (previousButton.ClientRectangle.Contains(previousButton.PointToClient(MousePosition)))
                return true;

            if (nextButton.ClientRectangle.Contains(nextButton.PointToClient(MousePosition)))
                return true;

            //if (datePicker.ClientRectangle.Contains(datePicker.PointToClient(MousePosition)))
            //    return true;

            return false;
        }

        #endregion

        #region Events

        private void NavigationBar_Load(object sender, System.EventArgs e)
        {
            this.BackColor = NAVI_COLOR;
        }

        private void nextButton_Click(object sender, System.EventArgs e)
        {
            datePicker.Date = datePicker.Date.AddMonths(1);
        }

        private void previousButton_Click(object sender, System.EventArgs e)
        {
            datePicker.Date = datePicker.Date.AddMonths(-1);
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

        #endregion
    }
}
