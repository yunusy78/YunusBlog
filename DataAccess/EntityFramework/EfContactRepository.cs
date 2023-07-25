using DataAccess.Abstract;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfContactRepository : GenericRepository<Contact>, IContactDal
{
    
}