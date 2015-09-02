namespace EasyCalendar.Controls.Navigation
{
    partial class NavigationBar
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
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.datePicker = new EasyCalendar.Controls.Navigation.DatePicker();
            this.SuspendLayout();
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.Color.Transparent;
            this.previousButton.BackgroundImage = global::EasyCalendar.Properties.Resources.previous;
            this.previousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.previousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(21, 13);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(50, 50);
            this.previousButton.TabIndex = 2;
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.BackgroundImage = global::EasyCalendar.Properties.Resources.next;
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(310, 13);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(50, 50);
            this.nextButton.TabIndex = 1;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // datePicker
            // 
            this.datePicker.BackColor = System.Drawing.Color.Transparent;
            this.datePicker.Date = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.datePicker.Location = new System.Drawing.Point(78, 18);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4);
            this.datePicker.MaximumSize = new System.Drawing.Size(225, 44);
            this.datePicker.Month = 8;
            this.datePicker.Name = "datePicker";
            this.datePicker.Observer = null;
            this.datePicker.Size = new System.Drawing.Size(225, 44);
            this.datePicker.TabIndex = 3;
            this.datePicker.Year = 2015;
            // 
            // NavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.MaximumSize = new System.Drawing.Size(381, 78);
            this.Name = "NavigationBar";
            this.Size = new System.Drawing.Size(381, 78);
            this.Load += new System.EventHandler(this.NavigationBar_Load);
            this.MouseEnter += new System.EventHandler(this.NavigationBar_MouseEnterAnimate);
            this.MouseLeave += new System.EventHandler(this.NavigationBar_MouseLeaveAnimate);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private DatePicker datePicker;
    }
}
