using Entity.Concrete;

namespace Business.Abstract;

public interface ICommentService
{
    void Add(Comment comment);
    void Update(Comment comment);
    void Delete(Comment comment);
    List<Comment> GetAll(Guid id);
    Comment GetById(Guid id);
   
    
}