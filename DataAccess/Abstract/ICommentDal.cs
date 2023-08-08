﻿using Entity.Concrete;

namespace DataAccess.Abstract;

public interface ICommentDal: IGenericDal<Comment>
{
    List<Comment> GetListWithBlog();
}