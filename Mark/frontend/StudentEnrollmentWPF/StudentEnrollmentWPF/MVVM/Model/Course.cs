using System;

namespace StudentEnrollmentWPF.MVVM.Model;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Fees { get; set; }
    public string LocationAddress { get; set; }
    public string ContactPerson { get; set; }
}