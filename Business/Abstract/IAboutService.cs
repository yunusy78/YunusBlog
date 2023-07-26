using Entity.Concrete;

namespace Business.Abstract;

public interface IAboutService
{
    void Add(About about);
    void Delete(About about);
    void Update(About about);
    List<About> GetAll();
    About GetById(Guid id);
    
}