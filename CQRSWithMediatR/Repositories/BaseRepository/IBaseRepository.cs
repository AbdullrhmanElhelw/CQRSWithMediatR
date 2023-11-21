namespace CQRSWithMediatR.Repositories.BaseRepository;

public interface IBaseRepository<T> where T : class
{
    T? GetById(int id);    
    IQueryable<T> GetAll { get; }
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
