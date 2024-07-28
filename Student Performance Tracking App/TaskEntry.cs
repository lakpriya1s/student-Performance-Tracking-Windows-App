using System;

public class TaskEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Breaking { get; set; }
    public string Task { get; set; }
    public int Duration { get; set; }
    public int SubjectId { get; set; }
    public SubjectEntry Subject { get; set; }

    public TaskEntry()
    {
        // Default constructor for serialization
    }

    public TaskEntry(DateTime date, bool BreakingTime, string task, int duration, SubjectEntry subject)
    {
        Date = date;
        Breaking = BreakingTime;
        Task = task;
        Duration = duration;
        Subject = subject;
        SubjectId = subject.Id;
    }
}