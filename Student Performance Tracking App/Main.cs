using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Performance_Tracking_App
{
    public partial class MainForm : Form
    {
        private TaskService _taskService;
        private bool isEditing;
        private int editingIndex;

        private DateTime startTime;
        private bool isRecording = false;

        public MainForm(TaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;
            isEditing = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            ConfigureTaskListView();
        }

        private async Task LoadDataAsync()
        {
            await _taskService.LoadTaskEntriesAsync();
            await _taskService.LoadSubjectEntriesAsync();
            taskListView.DataSource = _taskService.GetTaskEntries();
            subjectListView.DataSource = _taskService.GetSubjectEntries();
            subjectComboBox.DataSource = _taskService.GetSubjectEntries();
            subjectComboBox.DisplayMember = "Subject";
            subjectComboBox.ValueMember = "Id";
        }

        private void ConfigureTaskListView()
        {
            taskListView.Columns["Date"].DefaultCellStyle.Format = "d";
            taskListView.Columns["Date"].Width = 100;
            taskListView.Columns["Date"].ReadOnly = true;
            taskListView.Columns["Breaking"].Width = 50;
            taskListView.Columns["Duration"].Width = 70;
            taskListView.Columns["Subject"].Width = 100;
            taskListView.Columns["Task"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            taskListView.Columns["Subject"].DisplayIndex = 3;
            taskListView.Columns["Subject"].HeaderText = "Subject";
            taskListView.Columns["SubjectId"].Visible = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (taskListView.CurrentCell != null)
            {
                isEditing = true;
                editingIndex = taskListView.CurrentCell.RowIndex;
                var task = _taskService.GetTaskEntries()[editingIndex];

                taskTextBox.Text = task.Task;
                BreakingCheckBox.Checked = task.Breaking;
                dateTimePicker.Value = task.Date;
                durationTextBox.Text = task.Duration.ToString();
                subjectComboBox.SelectedItem = task.Subject;
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (taskListView.CurrentCell != null)
            {
                await _taskService.DeleteTaskAsync(taskListView.CurrentCell.RowIndex);
                await RefreshTaskGrid();
            }
        }

        private int ParseDuration(string durationText)
        {
            int totalMinutes = 0;

            if (string.IsNullOrWhiteSpace(durationText))
            {
                return totalMinutes;
            }

            var durationParts = durationText.Split(' ');
            foreach (var part in durationParts)
            {
                if (part.EndsWith("h"))
                {
                    if (int.TryParse(part.TrimEnd('h'), out int hours))
                    {
                        totalMinutes += hours * 60;
                    }
                }
                else if (part.EndsWith("m"))
                {
                    if (int.TryParse(part.TrimEnd('m', 'i', 'n'), out int minutes))
                    {
                        totalMinutes += minutes;
                    }
                }
                else if (int.TryParse(part, out int minutes))
                {
                    totalMinutes += minutes;
                }
            }

            return totalMinutes;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskTextBox.Text))
            {
                MessageBox.Show("Task description is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(durationTextBox.Text))
            {
                MessageBox.Show("Duration is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (subjectComboBox.SelectedItem == null)
            {
                MessageBox.Show("Subject is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDate = dateTimePicker.Value.Date;
            int duration = ParseDuration(durationTextBox.Text);
            var selectedSubject = (SubjectEntry)subjectComboBox.SelectedItem;

            var taskEntry = new TaskEntry
            {
                Date = selectedDate,
                Breaking = BreakingCheckBox.Checked,
                Task = taskTextBox.Text,
                Duration = duration,
                SubjectId = selectedSubject.Id,
                Subject = selectedSubject
            };

            if (isEditing)
            {
                taskEntry.Id = _taskService.GetTaskEntries()[editingIndex].Id; // Set the Id for editing
                await _taskService.EditTaskAsync(editingIndex, taskEntry);
            }
            else
            {
                await _taskService.AddTaskAsync(taskEntry);
            }

            ClearForm();
            isEditing = false;
            await RefreshTaskGrid();
        }

        private async Task RefreshTaskGrid()
        {
            await _taskService.LoadTaskEntriesAsync();
            taskListView.DataSource = null;
            taskListView.DataSource = _taskService.GetTaskEntries();
            ConfigureTaskListView();
        }

        private async void reportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = calender.SelectionStart;
                DateTime endDate = calender.SelectionEnd;
                string report = await _taskService.GenerateWeeklyReportAsync(startDate, endDate);

                var messageBox = new Report(report);
                messageBox.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void gradeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = calender.SelectionStart;
                DateTime endDate = calender.SelectionEnd;
                string report = await _taskService.GetGradePredictionReportAsync(startDate, endDate);
                MessageBox.Show(report, "Grade Prediction Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            taskTextBox.Text = "";
            BreakingCheckBox.Checked = false;
            dateTimePicker.Value = DateTime.Now;
            durationTextBox.Text = "";
        }

        private void TaskListView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == taskListView.Columns["Date"].Index)
            {
                e.Cancel = true;
            }
        }

        private void TaskListView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < taskListView.Rows.Count)
            {
                var row = taskListView.Rows[e.RowIndex].DataBoundItem as TaskEntry;
                if (row.Date == default(DateTime))
                {
                    row.Date = DateTime.Now.Date;
                }

                if (row.Breaking == null)
                {
                    row.Breaking = false;
                }
            }
        }

        private async void addSubjectButton_Click(object sender, EventArgs e)
        {
            string subject = subjectTextBox.Text;
            int currentKnowledge;
            if (int.TryParse(currentKnowledgeTextBox.Text, out currentKnowledge) && !string.IsNullOrWhiteSpace(subject))
            {
                var subjectEntry = new SubjectEntry { Subject = subject, CurrentKnowledge = currentKnowledge };
                await _taskService.AddSubjectAsync(subjectEntry);
                await RefreshSubjectListView();
                RefreshSubjectComboBox();
            }
            else
            {
                MessageBox.Show("Please enter valid subject and current knowledge percentage.");
            }
        }

        private async void editSubjectButton_Click(object sender, EventArgs e)
        {
            if (subjectListView.CurrentCell != null)
            {
                int index = subjectListView.CurrentCell.RowIndex;
                var subject = _taskService.GetSubjectEntries()[index];
                string newSubject = subjectTextBox.Text;
                int newCurrentKnowledge;
                if (int.TryParse(currentKnowledgeTextBox.Text, out newCurrentKnowledge) && !string.IsNullOrWhiteSpace(newSubject))
                {
                    subject.Subject = newSubject;
                    subject.CurrentKnowledge = newCurrentKnowledge;
                    await _taskService.EditSubjectAsync(index, subject);
                    await RefreshSubjectListView();
                    RefreshSubjectComboBox();
                }
                else
                {
                    MessageBox.Show("Please enter valid subject and current knowledge percentage.");
                }
            }
        }

        private async void removeSubjectButton_Click(object sender, EventArgs e)
        {
            if (subjectListView.CurrentCell != null)
            {
                int index = subjectListView.CurrentCell.RowIndex;
                await _taskService.RemoveSubjectAsync(index);
                await RefreshSubjectListView();
                RefreshSubjectComboBox();
            }
        }

        private async Task RefreshSubjectListView()
        {
            await _taskService.LoadSubjectEntriesAsync();
            subjectListView.DataSource = null;
            subjectListView.DataSource = _taskService.GetSubjectEntries();
            subjectListView.Columns["Subject"].Width = 150;
            subjectListView.Columns["CurrentKnowledge"].Width = 100;
        }

        private void RefreshSubjectComboBox()
        {
            subjectComboBox.DataSource = null;
            subjectComboBox.DataSource = _taskService.GetSubjectEntries();
            subjectComboBox.DisplayMember = "Subject";
            subjectComboBox.ValueMember = "Id";
        }

        private void recordStopButton_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                startTime = DateTime.Now;
                recordStopButton.Text = "Stop";
                isRecording = true;
            }
            else
            {
                DateTime endTime = DateTime.Now;
                TimeSpan duration = endTime - startTime;

                durationTextBox.Text = $"{(int)duration.TotalHours} h {(int)duration.Minutes} m";

                recordStopButton.Text = "Record";
                isRecording = false;
            }
        }
    }
}
