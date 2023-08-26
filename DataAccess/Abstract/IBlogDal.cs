using Entity.Concrete;

namespace DataAccess.Abstract;

public interface IBlogDal: IGenericDal<Blog>
{
    List<Blog> GetListWithCategory();
    List<Blog> GetListByWriterId(Guid id);
    
    List<Blog> GetListWithCategoryAndComment(Guid id);
}

