using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class TaskService
{
    private readonly HttpClient _httpClient;
    private readonly BindingList<TaskEntry> _taskEntries;
    private readonly BindingList<SubjectEntry> _subjectEntries;
    private const string ApiBaseAddress = "https://studentperformanceapigateway.azurewebsites.net/api";

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _taskEntries = new BindingList<TaskEntry>();
        _subjectEntries = new BindingList<SubjectEntry>();
    }

    public BindingList<TaskEntry> GetTaskEntries()
    {
        return _taskEntries;
    }

    public async Task LoadTaskEntriesAsync()
    {
        try
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskEntry>>($"{ApiBaseAddress}/tasks");
            if (tasks != null)
            {
                _taskEntries.Clear();
                foreach (var task in tasks)
                {
                    _taskEntries.Add(task);
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while loading tasks.", ex);
        }
    }

    public async Task AddTaskAsync(TaskEntry taskEntry)
    {
        try
        {
            var taskEntryToSend = new
            {
                taskEntry.Id,
                taskEntry.Date,
                taskEntry.Breaking,
                taskEntry.Task,
                taskEntry.Duration,
                taskEntry.SubjectId
            };
            var response = await _httpClient.PostAsJsonAsync($"{ApiBaseAddress}/tasks", taskEntryToSend);

            if (response.IsSuccessStatusCode)
            {
                var createdTask = await response.Content.ReadFromJsonAsync<TaskEntry>();
                _taskEntries.Add(createdTask);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while adding the task. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the task.", ex);
        }
    }

    public async Task EditTaskAsync(int index, TaskEntry taskEntry)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiBaseAddress}/tasks/{taskEntry.Id}", taskEntry);
            if (response.IsSuccessStatusCode)
            {
                _taskEntries[index] = taskEntry;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while editing the task. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while editing the task.", ex);
        }
    }

    public async Task DeleteTaskAsync(int index)
    {
        try
        {
            var taskEntry = _taskEntries[index];
            var response = await _httpClient.DeleteAsync($"{ApiBaseAddress}/tasks/{taskEntry.Id}");
            if (response.IsSuccessStatusCode)
            {
                _taskEntries.RemoveAt(index);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while deleting the task. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while deleting the task.", ex);
        }
    }

    public BindingList<SubjectEntry> GetSubjectEntries()
    {
        return _subjectEntries;
    }

    public async Task LoadSubjectEntriesAsync()
    {
        try
        {
            var subjects = await _httpClient.GetFromJsonAsync<List<SubjectEntry>>($"{ApiBaseAddress}/subjects");
            if (subjects != null)
            {
                _subjectEntries.Clear();
                foreach (var subject in subjects)
                {
                    _subjectEntries.Add(subject);
                    Console.WriteLine(subject.Subject);
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while loading subjects.", ex);
        }
    }

    public async Task AddSubjectAsync(SubjectEntry subjectEntry)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiBaseAddress}/subjects", subjectEntry);
            if (response.IsSuccessStatusCode)
            {
                var createdSubject = await response.Content.ReadFromJsonAsync<SubjectEntry>();
                _subjectEntries.Add(createdSubject);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while adding the subject. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the subject.", ex);
        }
    }

    public async Task EditSubjectAsync(int index, SubjectEntry subjectEntry)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiBaseAddress}/subjects/{subjectEntry.Id}", subjectEntry);
            if (response.IsSuccessStatusCode)
            {
                _subjectEntries[index] = subjectEntry;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while editing the subject. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while editing the subject.", ex);
        }
    }

    public async Task RemoveSubjectAsync(int index)
    {
        try
        {
            var subjectEntry = _subjectEntries[index];
            var response = await _httpClient.DeleteAsync($"{ApiBaseAddress}/subjects/{subjectEntry.Id}");
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                _subjectEntries.RemoveAt(index);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while deleting the subject. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while deleting the subject.", ex);
        }
    }

    public async Task<string> GenerateWeeklyReportAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{ApiBaseAddress}/tasks/report?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while generating the weekly report. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while generating the weekly report.", ex);
        }
    }

    public async Task<string> GetGradePredictionReportAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{ApiBaseAddress}/tasks/gradeprediction?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred while getting the grade prediction report. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while getting the grade prediction report.", ex);
        }
    }
}
