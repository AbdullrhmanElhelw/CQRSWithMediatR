namespace CQRSWithMediatR.DTOs.DepartmentDTOs;

public record DepartmentCreateDTO
{
    public string Name { get; init; }
    public string Code { get; init; }
}