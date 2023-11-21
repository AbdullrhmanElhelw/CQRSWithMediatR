using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Models;

public class DeleteDepartmentCommand : IRequest
{
    public int Id { get; set; }
}
