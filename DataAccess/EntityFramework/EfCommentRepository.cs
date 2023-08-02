using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfCommentRepository: GenericRepository<Comment>, ICommentDal
{
    public EfCommentRepository(Context context) : base(context)
    {
    }
}