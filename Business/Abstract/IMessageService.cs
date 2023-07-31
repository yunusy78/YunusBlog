using Entity.Concrete;

namespace Business.Abstract;

public interface IMessageService : IGenericService<Message2>
{
    public List<Message2> GetInboxListByWriter(Guid id);
}