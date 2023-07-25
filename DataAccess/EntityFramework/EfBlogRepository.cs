using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
{
    public List<Blog> GetListWithCategory()
    {
        using var context = new Context();
        return context.Blogs.Include(x => x.Category).ToList();
    }
}