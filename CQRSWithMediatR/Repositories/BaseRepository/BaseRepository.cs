
using CQRSWithMediatR.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatR.Repositories.BaseRepository;

public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<TModel> GetAll => _context.Set<TModel>().AsQueryable().AsNoTracking();

    public void Add(TModel entity) => _context.Add(entity);

    public void Delete(TModel entity) => _context.Remove(entity);

    public TModel? GetById(int id) => _context.Set<TModel>().Find(id);

    public void Update(TModel entity) => _context.Update(entity);
}
