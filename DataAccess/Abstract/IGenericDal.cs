using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IGenericDal<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetListAll();
    T GetById(Guid id);
    
    List<T> GetListAll(Expression<Func<T, bool>> filter);
}