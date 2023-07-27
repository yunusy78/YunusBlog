using Entity.Concrete;

namespace Business.Abstract;

public interface ICommentService: IGenericService<Comment>
{
    List<Comment> GetAll2(Guid id);

}