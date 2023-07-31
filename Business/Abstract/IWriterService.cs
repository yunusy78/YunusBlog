using Entity.Concrete;

namespace Business.Abstract;

public interface IWriterService:IGenericService<Writer>
{
    List<Writer> GetWriterById(Guid id);

}