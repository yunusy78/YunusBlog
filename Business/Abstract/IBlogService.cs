using Entity.Concrete;

namespace Business.Abstract;

public interface IBlogService
{
    void Add(Blog blog);
    void Update(Blog blog);
    void Delete(Blog blog);
    List<Blog> GetAll();
    Blog GetById(Guid id);
    
    List<Blog> GetListWithCategory();
}