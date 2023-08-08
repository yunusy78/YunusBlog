using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class MessageManager :IMessageService
{
    IMessageDal _messageDal;
    
    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }
    
    public void Add(Message2 entity)
    {
        _messageDal.Add(entity);
    }

    public void Update(Message2 entity)
    {
        _messageDal.Update(entity);
    }

    public void Delete(Message2 entity)
    {
        _messageDal.Delete(entity);
    }

    public List<Message2> GetAll()
    {
        return _messageDal.GetList();
    }

    public Message2 GetById(Guid id)
    {
        return _messageDal.GetById(id);
    }
    
    public List<Message2> GetInboxListByWriter(Guid id)
    {
        return _messageDal.GetMessageListWithByWriter(id);
    }
    
    public List<Message2> GetSendBoxListByWriter(Guid id)
    {
        return _messageDal.GetMessageListWithByWriterSendBox(id);
    }
}