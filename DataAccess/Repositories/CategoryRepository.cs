using System.Linq.Expressions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;

namespace DataAccess.Repositories;

public class CategoryRepository : ICategoryDal
{
    Context _context = new Context();
    
    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public void Add(Category category)
    {
        _context.Add(category);
        _context.SaveChanges();
        
    }

    public void Update(Category category)
    {
       _context.Update(category);
         _context.SaveChanges();
         
    }

    public void Delete(Category category)
    {
        _context.Remove(category);
        _context.SaveChanges();
    }

    public List<Category> GetList()
    {
        throw new NotImplementedException();
    }

    public List<Category> GetListAll()
    {
        throw new NotImplementedException();
    }

    public Category GetById(Guid id)
    {
        return _context.Categories.Find(id);
    }

    public List<Category> GetList(Expression<Func<Category, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Category> GetListAll(Expression<Func<Category, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Category> List(Expression<Func<Category, bool>> filter)
    {
        throw new NotImplementedException();
    }
}