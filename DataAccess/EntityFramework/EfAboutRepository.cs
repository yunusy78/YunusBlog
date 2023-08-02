using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfAboutRepository : GenericRepository<About>, IAboutDal
{
    public EfAboutRepository(Context context) : base(context)
    {
    }
}