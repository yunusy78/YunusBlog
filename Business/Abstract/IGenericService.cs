namespace Business.Abstract;

public interface IGenericService<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll();
    T GetById(Guid id);
    
    
}