using CQRSWithMediatR.DTOs.DepartmentDTOs;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Models
{
    public class CreateDepartmentCommand :IRequest<DepartmentCreateDTO>
    {
        public string  Name { get; set; }
        public string Code { get; set; }
    }
}
