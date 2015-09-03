﻿namespace EasyCalendar.Forms
{
    partial class CreateEventForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.repeatCheckBox = new System.Windows.Forms.CheckBox();
            this.repeatPanel = new System.Windows.Forms.Panel();
            this.repeatYearsLabel = new System.Windows.Forms.Label();
            this.repeatMonthsLabel = new System.Windows.Forms.Label();
            this.repeatDaysLabel = new System.Windows.Forms.Label();
            this.repeatYearsBox = new System.Windows.Forms.TextBox();
            this.repeatMonthsBox = new System.Windows.Forms.TextBox();
            this.repeatDaysBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.createEventButton = new System.Windows.Forms.Button();
            this.repeatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(15, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(40, 18);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(15, 70);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(92, 18);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Description:";
            // 
            // repeatCheckBox
            // 
            this.repeatCheckBox.AutoSize = true;
            this.repeatCheckBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatCheckBox.Location = new System.Drawing.Point(18, 165);
            this.repeatCheckBox.Name = "repeatCheckBox";
            this.repeatCheckBox.Size = new System.Drawing.Size(78, 22);
            this.repeatCheckBox.TabIndex = 2;
            this.repeatCheckBox.Text = "Repeat";
            this.repeatCheckBox.UseVisualStyleBackColor = true;
            this.repeatCheckBox.CheckedChanged += new System.EventHandler(this.repeatCheckBox_CheckedChanged);
            // 
            // repeatPanel
            // 
            this.repeatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repeatPanel.Controls.Add(this.repeatYearsLabel);
            this.repeatPanel.Controls.Add(this.repeatMonthsLabel);
            this.repeatPanel.Controls.Add(this.repeatDaysLabel);
            this.repeatPanel.Controls.Add(this.repeatYearsBox);
            this.repeatPanel.Controls.Add(this.repeatMonthsBox);
            this.repeatPanel.Controls.Add(this.repeatDaysBox);
            this.repeatPanel.Location = new System.Drawing.Point(15, 193);
            this.repeatPanel.Name = "repeatPanel";
            this.repeatPanel.Size = new System.Drawing.Size(515, 74);
            this.repeatPanel.TabIndex = 3;
            this.repeatPanel.Visible = false;
            // 
            // repeatYearsLabel
            // 
            this.repeatYearsLabel.AutoSize = true;
            this.repeatYearsLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatYearsLabel.Location = new System.Drawing.Point(441, 10);
            this.repeatYearsLabel.Name = "repeatYearsLabel";
            this.repeatYearsLabel.Size = new System.Drawing.Size(47, 18);
            this.repeatYearsLabel.TabIndex = 6;
            this.repeatYearsLabel.Text = "Years";
            // 
            // repeatMonthsLabel
            // 
            this.repeatMonthsLabel.AutoSize = true;
            this.repeatMonthsLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatMonthsLabel.Location = new System.Drawing.Point(226, 10);
            this.repeatMonthsLabel.Name = "repeatMonthsLabel";
            this.repeatMonthsLabel.Size = new System.Drawing.Size(58, 18);
            this.repeatMonthsLabel.TabIndex = 5;
            this.repeatMonthsLabel.Text = "Months";
            // 
            // repeatDaysLabel
            // 
            this.repeatDaysLabel.AutoSize = true;
            this.repeatDaysLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatDaysLabel.Location = new System.Drawing.Point(30, 10);
            this.repeatDaysLabel.Name = "repeatDaysLabel";
            this.repeatDaysLabel.Size = new System.Drawing.Size(44, 18);
            this.repeatDaysLabel.TabIndex = 4;
            this.repeatDaysLabel.Text = "Days";
            // 
            // repeatYearsBox
            // 
            this.repeatYearsBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatYearsBox.Location = new System.Drawing.Point(412, 39);
            this.repeatYearsBox.Name = "repeatYearsBox";
            this.repeatYearsBox.Size = new System.Drawing.Size(100, 27);
            this.repeatYearsBox.TabIndex = 2;
            this.repeatYearsBox.Text = "0";
            // 
            // repeatMonthsBox
            // 
            this.repeatMonthsBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatMonthsBox.Location = new System.Drawing.Point(204, 39);
            this.repeatMonthsBox.Name = "repeatMonthsBox";
            this.repeatMonthsBox.Size = new System.Drawing.Size(100, 27);
            this.repeatMonthsBox.TabIndex = 1;
            this.repeatMonthsBox.Text = "0";
            // 
            // repeatDaysBox
            // 
            this.repeatDaysBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatDaysBox.Location = new System.Drawing.Point(3, 39);
            this.repeatDaysBox.Name = "repeatDaysBox";
            this.repeatDaysBox.Size = new System.Drawing.Size(100, 27);
            this.repeatDaysBox.TabIndex = 0;
            this.repeatDaysBox.Text = "0";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(15, 116);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 18);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date:";
            // 
            // titleBox
            // 
            this.titleBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.Location = new System.Drawing.Point(113, 22);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(414, 27);
            this.titleBox.TabIndex = 5;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionBox.Location = new System.Drawing.Point(113, 67);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(414, 27);
            this.descriptionBox.TabIndex = 7;
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Location = new System.Drawing.Point(113, 110);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(414, 27);
            this.datePicker.TabIndex = 8;
            // 
            // createEventButton
            // 
            this.createEventButton.Font = new System.Drawing.Font("Mixolydian Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createEventButton.Location = new System.Drawing.Point(380, 279);
            this.createEventButton.Name = "createEventButton";
            this.createEventButton.Size = new System.Drawing.Size(150, 35);
            this.createEventButton.TabIndex = 9;
            this.createEventButton.Text = "Create event";
            this.createEventButton.UseVisualStyleBackColor = true;
            this.createEventButton.Click += new System.EventHandler(this.createEventButton_Click);
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 324);
            this.Controls.Add(this.createEventButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.repeatPanel);
            this.Controls.Add(this.repeatCheckBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateEvent";
            this.repeatPanel.ResumeLayout(false);
            this.repeatPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.CheckBox repeatCheckBox;
        private System.Windows.Forms.Panel repeatPanel;
        private System.Windows.Forms.TextBox repeatYearsBox;
        private System.Windows.Forms.TextBox repeatDaysBox;
        private System.Windows.Forms.Label repeatYearsLabel;
        private System.Windows.Forms.Label repeatMonthsLabel;
        private System.Windows.Forms.Label repeatDaysLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox repeatMonthsBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button createEventButton;
    }
}