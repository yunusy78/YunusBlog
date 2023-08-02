using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfNewsLetterRepository : GenericRepository<Newsletter>, INewsLetterDal
{
    public EfNewsLetterRepository(Context context) : base(context)
    {
    }
}