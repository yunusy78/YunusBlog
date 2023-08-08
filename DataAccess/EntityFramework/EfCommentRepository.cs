using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfCommentRepository: GenericRepository<Comment>, ICommentDal
{
    private Context _context;
    public EfCommentRepository(Context context) : base(context)
    {
        _context = context;
    }

    public List<Comment> GetListWithBlog()
    {
        return _context.Comments.Include(x=>x.Blog).ToList();
    }
}