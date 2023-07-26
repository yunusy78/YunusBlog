using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class WriterManager: IWriterService
{
    IWriterDal _writerDal;

    public WriterManager(IWriterDal writerDal)
    {
        _writerDal = writerDal;
    }

    public void Add(Writer writer)
    {
        _writerDal.Add(writer);
    }

    public void Delete(Writer writer)
    {
        _writerDal.Delete(writer);
    }

    public void Update(Writer writer)
    {
        _writerDal.Update(writer);
    }

    public List<Writer> GetList()
    {
        return _writerDal.GetListAll();
    }

    public Writer GetById(Guid id)
    {
        return _writerDal.GetById(id);
    }
}