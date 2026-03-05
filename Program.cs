public class UniversityMember
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrEmpty(value) ? throw new Exception("Invalid name") : value;
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

    public int ActionCount => ActionLog.Count;
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

public class UndergraduateStudent : UniversityMember
{
    public UndergraduateStudent(string name, string id) : base(name, id) { }

    public override void PerformDuties()
    {
        base.PerformDuties();
        ActionLog.Add("Lab work completed");
    }
}

public class GraduateStudent : UndergraduateStudent
{
    public GraduateStudent(string name, string id ) : base(name, id) {}

    public override void PerformDuties()
    {
        base.PerformDuties();
        ActionLog.Add("Thesis research update");
    }
}

public class UniversityRegistry
{
    private List<UniversityMember> _members = new List<UniversityMember>();
    public void AddMember(UniversityMember m) => _members.Add(m);

    public void ExecuteAllDuties()
    {
        foreach (var member in _members)
        {
            member.PerformDuties();
        }
    }

    public void GetMemberStatictics()
    {
        int totalactions = 0;
        foreach (var member in _members)
        {
            totalactions += member.ActionCount;
        }
        Console.WriteLine($"Total actions across students --> {totalactions}");
    }
}

