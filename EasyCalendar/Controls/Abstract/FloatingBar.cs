﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace EasyCalendar.Controls.Abstract
{
    public abstract partial class FloatingBar : UserControl
    {
        public const int FLOW_HEIGHT = 30;

        public FloatingBar()
        {
            InitializeComponent();
        }

        private bool IsPointerOverChild()
        {
            foreach (var control in this.Controls.Cast<Control>())
            {
                if (control.ClientRectangle.Contains(control.PointToClient(MousePosition)))
                    return true;
            }

            return false;
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
    }
}
