namespace CQRSWithMediatR.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public ICollection<Project> Projects { get; set; }   = new HashSet<Project>();

}
