using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfContactRepository : GenericRepository<Contact>, IContactDal
{
    public EfContactRepository(Context context) : base(context)
    {
    }
}