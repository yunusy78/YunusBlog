using Entity.Concrete;

namespace DataAccess.Abstract;

public interface IMessageDal : IGenericDal<Message2>
{
    List<Message2> GetMessageListWithByWriter(Guid id);
    
    List<Message2> GetMessageListWithByWriterSendBox(Guid id);
}