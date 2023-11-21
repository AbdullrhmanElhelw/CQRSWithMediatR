using CQRSWithMediatR.Context;
using CQRSWithMediatR.Repositories.DpartmentRepo;

namespace CQRSWithMediatR.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IDepartmentRepository DepartmentRepository { get;private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        DepartmentRepository = new DepartmentRepository(_context);
    }

    public int Complete() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}
