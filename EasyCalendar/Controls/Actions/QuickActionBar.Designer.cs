namespace EasyCalendar.Controls.Actions
{
    partial class QuickActionBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rescheduleRecurrentEventsButton = new System.Windows.Forms.Button();
            this.refreshPageButton = new System.Windows.Forms.Button();
            this.navigateToCurrentDateButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rescheduleRecurrentEventsButton
            // 
            this.rescheduleRecurrentEventsButton.BackColor = System.Drawing.Color.Transparent;
            this.rescheduleRecurrentEventsButton.BackgroundImage = global::EasyCalendar.Properties.Resources.reschedule;
            this.rescheduleRecurrentEventsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rescheduleRecurrentEventsButton.FlatAppearance.BorderSize = 0;
            this.rescheduleRecurrentEventsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rescheduleRecurrentEventsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rescheduleRecurrentEventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rescheduleRecurrentEventsButton.Location = new System.Drawing.Point(121, 7);
            this.rescheduleRecurrentEventsButton.Name = "rescheduleRecurrentEventsButton";
            this.rescheduleRecurrentEventsButton.Size = new System.Drawing.Size(50, 50);
            this.rescheduleRecurrentEventsButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.rescheduleRecurrentEventsButton, "Perform a cleanup on events. Especially useful for events that have been missed a" +
        "nd need to be repeated on another date");
            this.rescheduleRecurrentEventsButton.UseVisualStyleBackColor = false;
            this.rescheduleRecurrentEventsButton.Click += new System.EventHandler(this.rescheduleRecurrentEventsButton_Click);
            // 
            // refreshPageButton
            // 
            this.refreshPageButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshPageButton.BackgroundImage = global::EasyCalendar.Properties.Resources.refresh;
            this.refreshPageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshPageButton.FlatAppearance.BorderSize = 0;
            this.refreshPageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.refreshPageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.refreshPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshPageButton.Location = new System.Drawing.Point(65, 7);
            this.refreshPageButton.Name = "refreshPageButton";
            this.refreshPageButton.Size = new System.Drawing.Size(50, 50);
            this.refreshPageButton.TabIndex = 4;
            this.toolTip.SetToolTip(this.refreshPageButton, "Refresh the events for the page you are on");
            this.refreshPageButton.UseVisualStyleBackColor = false;
            this.refreshPageButton.Click += new System.EventHandler(this.refreshPageButton_Click);
            // 
            // navigateToCurrentDateButton
            // 
            this.navigateToCurrentDateButton.BackColor = System.Drawing.Color.Transparent;
            this.navigateToCurrentDateButton.BackgroundImage = global::EasyCalendar.Properties.Resources.now;
            this.navigateToCurrentDateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navigateToCurrentDateButton.FlatAppearance.BorderSize = 0;
            this.navigateToCurrentDateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.navigateToCurrentDateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.navigateToCurrentDateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navigateToCurrentDateButton.Location = new System.Drawing.Point(9, 7);
            this.navigateToCurrentDateButton.Name = "navigateToCurrentDateButton";
            this.navigateToCurrentDateButton.Size = new System.Drawing.Size(50, 50);
            this.navigateToCurrentDateButton.TabIndex = 3;
            this.toolTip.SetToolTip(this.navigateToCurrentDateButton, "Jump back to current date");
            this.navigateToCurrentDateButton.UseVisualStyleBackColor = false;
            this.navigateToCurrentDateButton.Click += new System.EventHandler(this.navigateToCurrentDateButton_Click);
            // 
            // QuickActionBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rescheduleRecurrentEventsButton);
            this.Controls.Add(this.refreshPageButton);
            this.Controls.Add(this.navigateToCurrentDateButton);
            this.MaximumSize = new System.Drawing.Size(180, 65);
            this.Name = "QuickActionBar";
            this.Size = new System.Drawing.Size(180, 65);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button navigateToCurrentDateButton;
        private System.Windows.Forms.Button refreshPageButton;
        private System.Windows.Forms.Button rescheduleRecurrentEventsButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
