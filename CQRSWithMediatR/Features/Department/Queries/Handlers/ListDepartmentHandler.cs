using CQRSWithMediatR.DTOs.DepartmentDTOs;
using CQRSWithMediatR.Features.Department.Queries.Models;
using CQRSWithMediatR.Services.Abstracts;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Queries.Handlers;

public class ListDepartmentHandler : IRequestHandler<ListDepartmentQuery, IQueryable<DepartmentReadDTO>>
{
    private readonly IDepartmentService _departmentService;

    public ListDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public Task<IQueryable<DepartmentReadDTO>> Handle(ListDepartmentQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_departmentService.GetAll);
    }
}
