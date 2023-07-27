using Entity.Concrete;

namespace Business.Abstract;

public interface IBlogService:IGenericService<Blog>
{
    
    List<Blog> GetListWithCategory();
    
    List<Blog> GetListByWriterId(Guid id);
}