using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class CommentManager: ICommentService
{
    ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public void Add(Comment comment)
    {
        _commentDal.Add(comment);
    }

    public void Update(Comment comment)
    {
        _commentDal.Update(comment);
    }

    public void Delete(Comment comment)
    {
        _commentDal.Delete(comment);
    }

    public List<Comment> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetAll2(Guid id)
    {
        return _commentDal.GetListAll(x=>x.BlogId==id);
    }
    

    public Comment GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    
}