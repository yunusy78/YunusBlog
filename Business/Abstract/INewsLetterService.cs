using Entity.Concrete;

namespace Business.Abstract;

public interface INewsLetterService
{
    void Add(Newsletter newsletter);
    void Update(Newsletter newsletter);
    void Delete(Newsletter newsletter);
    List<Newsletter> GetListAll();
    Newsletter GetById(Guid id);
    
}