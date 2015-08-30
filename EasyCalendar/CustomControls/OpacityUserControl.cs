using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCalendar.CustomControls
{
    public partial class OpacityUserControl : UserControl
    {
        public bool drag = false;
        public bool enable = false;

        private int opacity = 100;

        private int alpha = 255;

        public OpacityUserControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
        }

        public int Opacity
        {
            get
            {
                if (opacity > 100)
                {
                    opacity = 100;
                }
                else if (opacity < 1)
                {
                    opacity = 1;
                }
                return this.opacity;
            }
            set
            {
                this.opacity = value;
                if (this.Parent != null)
                {
                    Parent.Invalidate(this.Bounds, true);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            Color formColor = this.Parent.BackColor;
            Brush backColor = default(Brush);

            alpha = (opacity * 255) / 100;

            if (drag)
            {
                Color dragBckColor = default(Color);

                if (BackColor != Color.Transparent)
                {
                    int Rb = BackColor.R * alpha / 255 + formColor.R * (255 - alpha) / 255;
                    int Gb = BackColor.G * alpha / 255 + formColor.G * (255 - alpha) / 255;
                    int Bb = BackColor.B * alpha / 255 + formColor.B * (255 - alpha) / 255;
                    dragBckColor = Color.FromArgb(Rb, Gb, Bb);
                }
                else
                {
                    dragBckColor = formColor;
                }

                alpha = 255;
                backColor = new SolidBrush(Color.FromArgb(alpha, dragBckColor));
            }
            else
            {
                backColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor));
            }

            if (this.BackColor != Color.Transparent | drag)
            {
                graphics.FillRectangle(backColor, bounds);
            }

            backColor.Dispose();
            graphics.Dispose();

            base.OnPaint(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                Parent.Invalidate(this.Bounds, true);
            }

            base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnParentBackColorChanged(e);
        }
    }
}
