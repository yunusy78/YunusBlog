using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class BlogManager: IBlogService
{
    IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public void Add(Blog blog)
    {
        _blogDal.Add(blog);
    }

    public void Update(Blog blog)
    {
        _blogDal.Update(blog);
    }

    public void Delete(Blog blog)
    {
        _blogDal.Delete(blog);
    }

    public List<Blog> GetAll()
    {
        return _blogDal.GetListAll();
    }

    public Blog GetById(Guid id)
    {
        return _blogDal.GetById(id);
    }

    public List<Blog> GetListWithCategory()
    {
        return _blogDal.GetListWithCategory();
    }
    
    public List<Blog> GetBlogById(Guid id)
    {
        return _blogDal.GetListAll(x=>x.Id==id);
    }


}