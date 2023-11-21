using CQRSWithMediatR.Repositories.DpartmentRepo;

namespace CQRSWithMediatR.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IDepartmentRepository DepartmentRepository { get; }
    int Complete();
}
