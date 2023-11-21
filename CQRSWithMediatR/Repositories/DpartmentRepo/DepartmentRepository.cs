using CQRSWithMediatR.Context;
using CQRSWithMediatR.Models;
using CQRSWithMediatR.Repositories.BaseRepository;

namespace CQRSWithMediatR.Repositories.DpartmentRepo;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
