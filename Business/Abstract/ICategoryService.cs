using Entity.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
    List<Category> GetAll();
    Category GetById(Guid id);
}