using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Queries.Models;
using CQRSWithMediatR.Services.Abstracts;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Queries.Handlers
{
    public class FindDepartmentByNameHandler : IRequestHandler<FindDepartmentByNameQuery, IQueryable<DepartmentReadDTO>>
    {
        private readonly IDepartmentService _departmentService;

        public FindDepartmentByNameHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public Task<IQueryable<DepartmentReadDTO>> Handle(FindDepartmentByNameQuery request, CancellationToken cancellationToken)
        {
            var departments = _departmentService.FindDepartments(n =>
                n.Name.IndexOf(request.Name, StringComparison.OrdinalIgnoreCase) >= 0
            );
            return Task.FromResult(departments);
        }
    }
}
