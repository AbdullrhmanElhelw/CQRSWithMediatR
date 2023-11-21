namespace CQRSWithMediatR.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<EmployeeProject> Projects { get; set; } = new HashSet<EmployeeProject>();
}
