using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfNewsLetterRepository : GenericRepository<Newsletter>, INewsLetterDal
{
    private Context _context;
    
    public EfNewsLetterRepository(Context context) : base(context)
    {
        _context = context;
    }
    
    public bool CheckIfEmailExists(string email)
    {
        return _context.Newsletters.Any(x => x.Email == email);
    }
}