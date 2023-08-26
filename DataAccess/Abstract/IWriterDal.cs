using Entity.Concrete;

namespace DataAccess.Abstract;

public interface IWriterDal : IGenericDal<Writer>
{
    public bool CheckIfEmailExists(string email);
}