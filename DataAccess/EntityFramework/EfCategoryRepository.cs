using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryRepository(Context context) : base(context)
    {
    }
}