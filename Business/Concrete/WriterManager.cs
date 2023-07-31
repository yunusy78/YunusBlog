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

    public List<Writer> GetAll()
    {
        return _writerDal.GetList();
    }

    public void Update(Writer writer)
    {
        _writerDal.Update(writer);
    }
    

    public Writer GetById(Guid id)
    {
        return _writerDal.GetById(id);
    }

    public List<Writer> GetWriterById(Guid id)
    {
        return _writerDal.GetListAll(x => x.Id == id);
    }
}