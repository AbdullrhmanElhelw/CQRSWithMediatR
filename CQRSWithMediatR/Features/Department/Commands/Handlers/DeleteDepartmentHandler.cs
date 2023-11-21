using CQRSWithMediatR.Features.Department.Commands.Models;
using CQRSWithMediatR.Services.Abstracts;
using MediatR;

namespace CQRSWithMediatR.Features.Department.Commands.Handlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            _departmentService.DeleteDepartment(request.Id);
            return Task.CompletedTask;
        }
    }
}
