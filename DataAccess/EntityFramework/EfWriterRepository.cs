using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
{
    public EfWriterRepository(Context context) : base(context)
    {
    }
}