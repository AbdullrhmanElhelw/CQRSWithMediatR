using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Queries.Models;
using CQRSWithMediatR.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CQRSWithMediatR.Features.Department.Queries.Handlers;

public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, DepartmentReadDTO>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentQueryHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService; 
    }


    public Task<DepartmentReadDTO> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = _departmentService.GetDepartment(request.Id);

        var departmentDto = department is not null
            ? new DepartmentReadDTO { Id = department.Id, Name = department.Name }
            : new DepartmentReadDTO();

        return Task.FromResult(departmentDto);
    }
}
