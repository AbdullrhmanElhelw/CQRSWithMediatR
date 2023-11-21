namespace CQRSWithMediatR.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<EmployeeProject> Employees { get; set; } = new List<EmployeeProject>();

    public int DepartmentId { get; set; }
    public Department? Department { get; set; } 

}
