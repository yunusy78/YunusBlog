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
        throw new NotImplementedException();
    }

    public void Update(Comment comment)
    {
        throw new NotImplementedException();
    }

    public void Delete(Comment comment)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetAll(Guid id)
    {
        return _commentDal.GetListAll(x=>x.BlogId==id);
    }
    

    public Comment GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    
}