using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Models;
using CQRSWithMediatR.Services.Abstracts;
using CQRSWithMediatR.UnitOfWork;

namespace CQRSWithMediatR.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IQueryable<DepartmentReadDTO> GetAll =>
        _unitOfWork.DepartmentRepository.GetAll
        .Select(d => new DepartmentReadDTO { Id = d.Id, Name = d.Name , Code = d.Code });


    public DepartmentCreateDTO CreateDepartment(DepartmentCreateDTO departmentCreateDTO)
    {
       if(departmentCreateDTO is not null)
        {
            var departmentToCreate = new Department
            {
                Name = departmentCreateDTO.Name,
                Code = departmentCreateDTO.Code
            };
            _unitOfWork.DepartmentRepository.Add(departmentToCreate);
            _unitOfWork.Complete();
        }
        return departmentCreateDTO;
    }

    public void DeleteDepartment(int id)
    {
        var departmentToDelete = _unitOfWork.DepartmentRepository.GetById(id);
        if(departmentToDelete is not null)
        {
            _unitOfWork.DepartmentRepository.Delete(departmentToDelete);
            _unitOfWork.Complete();
        }
    }

    public IQueryable<DepartmentReadDTO> FindDepartments(Func<DepartmentReadDTO, bool> criteria)
    {
        Func<Department,bool> condation = d=> criteria(new DepartmentReadDTO 
        {
            Id=d.Id, Name=d.Name,Code =d.Code 
        });

        var  departments = _unitOfWork.DepartmentRepository.GetAll.Where(condation).AsQueryable();
        return MappingToDepartmentsReadDTO(departments);
    }

    public DepartmentReadDTO? GetDepartment(int id) =>
        _unitOfWork.DepartmentRepository
        .GetById(id) is Department department ?
         new DepartmentReadDTO()
         {
             Id = department.Id,
             Name = department.Name,
             Code = department.Code
         } : null;

    public void UpdateDepartment(int id, DepartmentUpdateDTO departmentUpdateDTO)
    {
        var department = _unitOfWork.DepartmentRepository.GetById(id);
        if(department is not null)
        {
            department.Name = departmentUpdateDTO.Name;
            department.Code = departmentUpdateDTO.Code;
        }
        _unitOfWork.Complete();
    }

    private Department MappingToDepartment(DepartmentReadDTO departmentReadDTO) =>
        new Department { Id = departmentReadDTO.Id, Name = departmentReadDTO.Name,Code = departmentReadDTO.Code };

    private IQueryable<DepartmentReadDTO> MappingToDepartmentsReadDTO(IQueryable<Department> departments)=>

         departments.Select(d=> new DepartmentReadDTO
        {
            Id = d.Id
            ,Name = d.Name,
            Code = d.Code 
        });

}
