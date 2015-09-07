namespace EasyCalendar.Controls.Calendar
{
    partial class CalendarSlot
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dayOfWeekLabel = new System.Windows.Forms.Label();
            this.addEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Mixolydian Titling", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.Black;
            this.dateLabel.Location = new System.Drawing.Point(37, 151);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(142, 18);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "12 September 2015";
            this.dateLabel.TextChanged += new System.EventHandler(this.dateLabel_TextChanged);
            // 
            // flowPanel
            // 
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(200, 147);
            this.flowPanel.TabIndex = 5;
            // 
            // dayOfWeekLabel
            // 
            this.dayOfWeekLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dayOfWeekLabel.AutoSize = true;
            this.dayOfWeekLabel.Font = new System.Drawing.Font("Mixolydian Titling", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayOfWeekLabel.ForeColor = System.Drawing.Color.Black;
            this.dayOfWeekLabel.Location = new System.Drawing.Point(3, 153);
            this.dayOfWeekLabel.Name = "dayOfWeekLabel";
            this.dayOfWeekLabel.Size = new System.Drawing.Size(38, 16);
            this.dayOfWeekLabel.TabIndex = 6;
            this.dayOfWeekLabel.Text = "MON";
            // 
            // addEvent
            // 
            this.addEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addEvent.BackColor = System.Drawing.Color.Transparent;
            this.addEvent.BackgroundImage = global::EasyCalendar.Properties.Resources.addEvent;
            this.addEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addEvent.FlatAppearance.BorderSize = 0;
            this.addEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEvent.Location = new System.Drawing.Point(171, 147);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(20, 20);
            this.addEvent.TabIndex = 7;
            this.addEvent.UseVisualStyleBackColor = false;
            this.addEvent.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // CalendarSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.addEvent);
            this.Controls.Add(this.dayOfWeekLabel);
            this.Controls.Add(this.dateLabel);
            this.Name = "CalendarSlot";
            this.Size = new System.Drawing.Size(200, 172);
            this.SizeChanged += new System.EventHandler(this.CalendarSlot_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Label dayOfWeekLabel;
        private System.Windows.Forms.Button addEvent;
    }
}
