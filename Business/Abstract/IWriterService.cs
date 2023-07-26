using Entity.Concrete;

namespace Business.Abstract;

public interface IWriterService
{
    void Add(Writer writer);
    void Delete(Writer writer);
    void Update(Writer writer);
    List<Writer> GetList();
    Writer GetById(Guid id);
    
    
}