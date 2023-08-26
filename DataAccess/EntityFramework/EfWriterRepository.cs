using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
{
    Context _context;
    
    public EfWriterRepository(Context context) : base(context)
    {
        _context = context;
    }

    public bool CheckIfEmailExists(string email)
    {
        return _context.Writers.Any(x => x.Email == email);
    }
}