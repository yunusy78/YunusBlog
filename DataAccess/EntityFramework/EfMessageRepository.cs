using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfMessageRepository : GenericRepository<Message2>, IMessageDal
{
    public List<Message2> GetMessageListWithByWriter(Guid id)
    {
        using var context = new Context();
        return context.Message2S.Include(x => x.SenderWriter).Where(x=>x.ReceiverId==id).ToList();
    }
}