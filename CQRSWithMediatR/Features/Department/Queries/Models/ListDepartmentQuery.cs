using CQRSWithMediatR.DTOs.DepartmentDTOs;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Queries.Models
{
    public class ListDepartmentQuery : IRequest<IQueryable<DepartmentReadDTO>>
    {

    }
}
