using CQRSWithMediatR.DTOs.DepartmentDTOs;

namespace CQRSWithMediatR.Services.Abstracts;

public interface IDepartmentService
{
    DepartmentReadDTO? GetDepartment(int id);
    IQueryable<DepartmentReadDTO> GetAll { get; }
    IQueryable<DepartmentReadDTO> FindDepartments(Func<DepartmentReadDTO, bool> criteria);
    DepartmentCreateDTO CreateDepartment(DepartmentCreateDTO departmentCreateDTO);
    void UpdateDepartment(int id , DepartmentUpdateDTO departmentUpdateDTO);
    void DeleteDepartment(int id);
}
