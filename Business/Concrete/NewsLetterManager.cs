using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class NewsLetterManager : INewsLetterService
{
    INewsLetterDal _newsLetterDal;

    public NewsLetterManager(INewsLetterDal newsLetterDal)
    {
        _newsLetterDal = newsLetterDal;
    }

    public void Add(Newsletter newsletter)
    {
        _newsLetterDal.Add(newsletter);
    }

    public void Update(Newsletter newsletter)
    {
        _newsLetterDal.Update(newsletter);
    }

    public void Delete(Newsletter newsletter)
    {
        _newsLetterDal.Delete(newsletter);
    }

    public List<Newsletter> GetAll()
    {
        return _newsLetterDal.GetList();
    }

    public List<Newsletter> GetListAll()
    {
        return _newsLetterDal.GetList();
    }

    public Newsletter GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}