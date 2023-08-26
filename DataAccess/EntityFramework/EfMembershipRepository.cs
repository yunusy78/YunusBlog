using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfMembershipRepository : GenericRepository<Membership>, IMembershipDal
{
    private readonly Context _context;
    public EfMembershipRepository(Context context) : base(context)
    {
        _context = context;
    }

   
}