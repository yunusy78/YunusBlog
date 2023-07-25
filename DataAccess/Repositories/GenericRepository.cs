using System.Linq.Expressions;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    Context _context = new Context();
    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

 

    public List<T> GetListAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }
    

    public List<T> GetListAll(Expression<Func<T, bool>> filter)
    {
        return _context.Set<T>().Where(filter).ToList();
    }
}