using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class AboutManager : IAboutService
{
    IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void Add(About about)
    {
        _aboutDal.Add(about);
    }

    public void Delete(About about)
    {
        _aboutDal.Delete(about);
    }

    public void Update(About about)
    {
        _aboutDal.Update(about);
    }

    public List<About> GetAll()
    {
        return _aboutDal.GetListAll();
    }

    public About GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}