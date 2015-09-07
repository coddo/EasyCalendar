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
            this.components = new System.ComponentModel.Container();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.datePicker = new EasyCalendar.Controls.Navigation.DatePicker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.previousButton.Location = new System.Drawing.Point(7, 6);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(50, 50);
            this.previousButton.TabIndex = 2;
            this.toolTip.SetToolTip(this.previousButton, "Navigate to previous month");
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
            this.nextButton.Location = new System.Drawing.Point(279, 6);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(50, 50);
            this.nextButton.TabIndex = 1;
            this.toolTip.SetToolTip(this.nextButton, "Navigate to next month");
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // datePicker
            // 
            this.datePicker.BackColor = System.Drawing.Color.Transparent;
            this.datePicker.Date = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.datePicker.Font = new System.Drawing.Font("Mixolydian Titling", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Location = new System.Drawing.Point(57, 12);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4);
            this.datePicker.MaximumSize = new System.Drawing.Size(239, 41);
            this.datePicker.Month = 8;
            this.datePicker.Name = "datePicker";
            this.datePicker.Observer = null;
            this.datePicker.Size = new System.Drawing.Size(222, 40);
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
            this.MaximumSize = new System.Drawing.Size(336, 61);
            this.Name = "NavigationBar";
            this.Size = new System.Drawing.Size(336, 61);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private DatePicker datePicker;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
