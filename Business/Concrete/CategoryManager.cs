using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using Entity.Concrete;

namespace Business.Concrete;

public class CategoryManager:ICategoryService
{
    ICategoryDal _categoryDal;
    
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void Add(Category category)
    {
        _categoryDal.Add(category);
    }

    public void Update(Category category)
    {
        _categoryDal.Update(category);
    }

    public void Delete(Category category)
    {
        
        _categoryDal.Delete(category);
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetListAll();
    }

    public Category GetById(Guid id)
    {
        return _categoryDal.GetById(id);
    }
}