using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class NotificationManager : INotificationService
{
    INotificationDal _notificationDal;
    
    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void Add(Notification entity)
    {
        _notificationDal.Add(entity);
    }

    public void Update(Notification entity)
    {
        _notificationDal.Update(entity);
    }

    public void Delete(Notification entity)
    {
        _notificationDal.Delete(entity);
    }

    public List<Notification> GetAll()
    {
        return _notificationDal.GetListAll();
    }

    public Notification GetById(Guid id)
    {
        return _notificationDal.GetById(id);
    }
}