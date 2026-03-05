public class UniversityMember
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrEmpty(value) ? 
            throw new Exception("Invalid name") : value;
    }
    public string MemberId { get; }
    protected List<string> ActionLog { get; set; }

    public UniversityMember(string name, string id)
    {
        Name = name;
        MemberId = id;

    }

    public virtual void PerformDuties()
    {
        if (ActionLog.Count >= 5)
        {
            throw new Exception("Daily limit is reached");
        }
    }
}

public class Professor : UniversityMember
{
    public Professor(string name, string id) : base(name, id) { }

    public override void PerformDuties()
    {
        base.PerformDuties();
        ActionLog.Add("Lecture delivered");
    }

    public void ConductResearch(string topic)
    {
        Console.WriteLine($"{Name}, research --> {topic}");
    }
}