using CQRSWithMediatR.DTOs.DepartmentDTOs;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Queries.Models;

public class GetDepartmentQuery : IRequest<DepartmentReadDTO>
{
    public int Id { get; set; }
}
