
using System;
using System.Windows.Forms;

namespace Student_Performance_Tracking_App
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.taskListView = new System.Windows.Forms.DataGridView();
            this.calender = new System.Windows.Forms.MonthCalendar();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BreakingCheckBox = new System.Windows.Forms.CheckBox();
            this.showReportButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gradeButton = new System.Windows.Forms.Button();
            this.subjectListView = new System.Windows.Forms.DataGridView();
            this.deleteSubjectButton = new System.Windows.Forms.Button();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.currentKnowledgeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.recordStopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(942, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Performance Tracking App";
            // 
            // taskListView
            // 
            this.taskListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskListView.Location = new System.Drawing.Point(245, 207);
            this.taskListView.Name = "taskListView";
            this.taskListView.Size = new System.Drawing.Size(709, 400);
            this.taskListView.TabIndex = 1;
            this.taskListView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.TaskListView_CellBeginEdit);
            this.taskListView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaskListView_CellEndEdit);
            // 
            // calender
            // 
            this.calender.Location = new System.Drawing.Point(9, 369);
            this.calender.Name = "calender";
            this.calender.TabIndex = 2;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(5, 240);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(233, 35);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(6, 281);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(233, 35);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(5, 322);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(233, 35);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(5, 199);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(233, 35);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Add/Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(10, 114);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(409, 20);
            this.taskTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(948, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // BreakingCheckBox
            // 
            this.BreakingCheckBox.AutoSize = true;
            this.BreakingCheckBox.Location = new System.Drawing.Point(119, 94);
            this.BreakingCheckBox.Name = "BreakingCheckBox";
            this.BreakingCheckBox.Size = new System.Drawing.Size(54, 17);
            this.BreakingCheckBox.TabIndex = 6;
            this.BreakingCheckBox.Text = "Breaking";
            this.BreakingCheckBox.UseVisualStyleBackColor = true;
            // 
            // showReportButton
            // 
            this.showReportButton.Location = new System.Drawing.Point(6, 534);
            this.showReportButton.Name = "showReportButton";
            this.showReportButton.Size = new System.Drawing.Size(233, 35);
            this.showReportButton.TabIndex = 3;
            this.showReportButton.Text = "Show Report";
            this.showReportButton.UseVisualStyleBackColor = true;
            this.showReportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(10, 65);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(203, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Session/Task";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(10, 161);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(203, 20);
            this.durationTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duration (h m)";
            // 
            // gradeButton
            // 
            this.gradeButton.Location = new System.Drawing.Point(6, 574);
            this.gradeButton.Name = "gradeButton";
            this.gradeButton.Size = new System.Drawing.Size(233, 35);
            this.gradeButton.TabIndex = 3;
            this.gradeButton.Text = "Predict grades";
            this.gradeButton.UseVisualStyleBackColor = true;
            this.gradeButton.Click += new System.EventHandler(this.gradeButton_Click);
            // 
            // subjectListView
            // 
            this.subjectListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectListView.Location = new System.Drawing.Point(431, 65);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(373, 128);
            this.subjectListView.TabIndex = 8;
            // 
            // deleteSubjectButton
            // 
            this.deleteSubjectButton.Location = new System.Drawing.Point(810, 170);
            this.deleteSubjectButton.Name = "deleteSubjectButton";
            this.deleteSubjectButton.Size = new System.Drawing.Size(144, 23);
            this.deleteSubjectButton.TabIndex = 9;
            this.deleteSubjectButton.Text = "Delete";
            this.deleteSubjectButton.UseVisualStyleBackColor = true;
            this.deleteSubjectButton.Click += new System.EventHandler(this.removeSubjectButton_Click);
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Location = new System.Drawing.Point(810, 141);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(144, 23);
            this.addSubjectButton.TabIndex = 9;
            this.addSubjectButton.Text = "Add";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            this.addSubjectButton.Click += new System.EventHandler(this.addSubjectButton_Click);
            // 
            // currentKnowledgeTextBox
            // 
            this.currentKnowledgeTextBox.Location = new System.Drawing.Point(810, 112);
            this.currentKnowledgeTextBox.Name = "currentKnowledgeTextBox";
            this.currentKnowledgeTextBox.Size = new System.Drawing.Size(144, 20);
            this.currentKnowledgeTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(811, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current Knowladge %";
            // 
            // subject
            // 
            this.subject.AutoSize = true;
            this.subject.Location = new System.Drawing.Point(428, 48);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(48, 13);
            this.subject.TabIndex = 12;
            this.subject.Text = "Subjects";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(811, 67);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(143, 20);
            this.subjectTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(811, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Subject";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(219, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Subject";
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(222, 160);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(197, 21);
            this.subjectComboBox.TabIndex = 14;
            // 
            // recordStopButton
            // 
            this.recordStopButton.Location = new System.Drawing.Point(231, 64);
            this.recordStopButton.Name = "recordStopButton";
            this.recordStopButton.Size = new System.Drawing.Size(127, 43);
            this.recordStopButton.TabIndex = 15;
            this.recordStopButton.Text = "Record";
            this.recordStopButton.UseVisualStyleBackColor = true;
            this.recordStopButton.Click += new System.EventHandler(this.recordStopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 613);
            this.Controls.Add(this.recordStopButton);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.currentKnowledgeTextBox);
            this.Controls.Add(this.addSubjectButton);
            this.Controls.Add(this.deleteSubjectButton);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.BreakingCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.gradeButton);
            this.Controls.Add(this.showReportButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.calender);
            this.Controls.Add(this.taskListView);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Student Performance Tracking App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView taskListView;
        private System.Windows.Forms.MonthCalendar calender;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox BreakingCheckBox;
        private System.Windows.Forms.Button showReportButton;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button gradeButton;
        private System.Windows.Forms.DataGridView subjectListView;
        private System.Windows.Forms.Button deleteSubjectButton;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.TextBox currentKnowledgeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox subjectComboBox;
        private Button recordStopButton;
    }
}

