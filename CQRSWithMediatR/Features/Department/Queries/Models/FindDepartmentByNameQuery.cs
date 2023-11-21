using CQRSWithMediatR.DTOs.DepartmentDTOs;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Queries.Models
{
    public class FindDepartmentByNameQuery :IRequest<IQueryable<DepartmentReadDTO>>
    {
        public string Name { get;set; }
    }
}
