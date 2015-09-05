namespace EasyCalendar.Forms
{
    partial class EditEventForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // performActionButton
            // 
            this.performActionButton.Text = "Update event";
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.BackColor = System.Drawing.Color.Red;
            this.deleteEventButton.Font = new System.Drawing.Font("Mixolydian Titling", 12F);
            this.deleteEventButton.ForeColor = System.Drawing.Color.White;
            this.deleteEventButton.Location = new System.Drawing.Point(15, 279);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(150, 35);
            this.deleteEventButton.TabIndex = 10;
            this.deleteEventButton.Text = "Delete event";
            this.deleteEventButton.UseVisualStyleBackColor = false;
            this.deleteEventButton.Click += new System.EventHandler(this.deleteEventButton_Click);
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 324);
            this.Controls.Add(this.deleteEventButton);
            this.Name = "EditEventForm";
            this.Text = "EditEventForm";
            this.Controls.SetChildIndex(this.repeatCheckBox, 0);
            this.Controls.SetChildIndex(this.titleBox, 0);
            this.Controls.SetChildIndex(this.descriptionBox, 0);
            this.Controls.SetChildIndex(this.datePicker, 0);
            this.Controls.SetChildIndex(this.performActionButton, 0);
            this.Controls.SetChildIndex(this.deleteEventButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteEventButton;
    }
}