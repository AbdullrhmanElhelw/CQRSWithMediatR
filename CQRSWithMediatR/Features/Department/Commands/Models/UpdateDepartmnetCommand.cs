using CQRSWithMediatR.DTOs.DepartmentDTOs;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Models
{
    public class UpdateDepartmnetCommand : IRequest<DepartmentUpdateDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
