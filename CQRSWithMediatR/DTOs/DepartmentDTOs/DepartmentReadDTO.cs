namespace CQRSWithMediatR.DTOs.DepartmentDTOs;

public record DepartmentReadDTO 
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Code {  get; init; }
}
