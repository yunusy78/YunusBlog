using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfMessageRepository : GenericRepository<Message2>, IMessageDal
{
    private Context _context;

    public EfMessageRepository(Context context) : base(context)
    {
        _context = context;
    }

    public List<Message2> GetMessageListWithByWriter(Guid id)
    {
        return _context.Message2S.Include(x => x.SenderWriter).Where(x=>x.ReceiverId==id).ToList();
    }
    
    public List<Message2> GetMessageListWithByWriterSendBox(Guid id)
    {
        return _context.Message2S.Include(x => x.ReceiverWriter).Where(x=>x.SenderId==id).ToList();
    }
}