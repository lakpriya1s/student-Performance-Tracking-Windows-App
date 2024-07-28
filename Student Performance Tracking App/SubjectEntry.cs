using System;

public class SubjectEntry : IComparable<SubjectEntry>
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public int CurrentKnowledge { get; set; }

    public SubjectEntry()
    {
        // Default constructor for serialization
    }

    public SubjectEntry(int id, string subject, int currentKnowledge)
    {
        Id = id;
        Subject = subject;
        CurrentKnowledge = currentKnowledge;
    }

    public override string ToString()
    {
        return Subject;
    }

    public int CompareTo(SubjectEntry other)
    {
        if (other == null) return 1;
        return this.Subject.CompareTo(other.Subject);
    }
}