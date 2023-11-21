using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Commands.Models;
using CQRSWithMediatR.Services.Abstracts;
using CQRSWithMediatR.UnitOfWork;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Handlers
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmnetCommand, DepartmentUpdateDTO>
    {
        private readonly IDepartmentService _departmentService;

        public UpdateDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public Task<DepartmentUpdateDTO> Handle(UpdateDepartmnetCommand request, CancellationToken cancellationToken)
        {
            var department = new DepartmentUpdateDTO
            {
                Name = request.Name,
                Code = request.Code
            };
            _departmentService.UpdateDepartment(request.Id,department); 
            return Task.FromResult(department);
        }
    }
}
