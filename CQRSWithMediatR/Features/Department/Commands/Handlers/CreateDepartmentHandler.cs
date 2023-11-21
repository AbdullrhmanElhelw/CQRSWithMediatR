using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Commands.Models;
using CQRSWithMediatR.Services.Abstracts;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Handlers;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, DepartmentCreateDTO>
{
    private readonly IDepartmentService _departmentService;

    public CreateDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public Task<DepartmentCreateDTO> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
         var departmentToAdd = new DepartmentCreateDTO { Name = request.Name , Code = request.Code };
        _departmentService.CreateDepartment(departmentToAdd);
        return Task.FromResult(departmentToAdd); 
    }
}
