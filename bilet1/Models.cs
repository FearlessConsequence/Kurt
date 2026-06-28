using System;

namespace bilet1;

public class Circles
{
    public int CircleId {get; set;} = 0;
    public string CircleName {get; set;} = "";
    public string EducationLevel {get; set;} = "";
}

public class Leaders
{
    public int LeaderId {get; set;} = 0; 
    public string FullName {get; set;} = "";
    public int CircleId {get; set;} = 0;
    public string CircleName {get; set;} = "";
}

public class Visit
{
    public int VisitId {get; set;} = 0;
    public int LeaderId {get; set;} = 0;
    public DateTime VisitDate { get; set; } = DateTime.Now;
    public int ChildrenCount {get; set;} = 0;
}