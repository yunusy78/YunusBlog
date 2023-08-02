using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework;

public class EfNotificationRepository : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationRepository(Context context) : base(context)
    {
    }
}