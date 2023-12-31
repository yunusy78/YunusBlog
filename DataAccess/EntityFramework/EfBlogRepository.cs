﻿using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
{
    private Context _context;


    public EfBlogRepository(Context context) : base(context)
    {
        _context = context;
    }

    public List<Blog> GetListWithCategory()
    {
        
        return _context.Blogs.Include(x => x.Category).Include(x=>x.Comments).ToList();
    }
    
    public List<Blog> GetListWithCategoryAndComment(Guid id)
    {
        
        return _context.Blogs.Where(x => x.Id == id).Include(x => x.Category).Include(x=>x.Comments).ToList();
    }

    public List<Blog> GetListByWriterId(Guid id)
    {
        
        return _context.Blogs.Include(x => x.Category).Where(x => x.WriterId == id).ToList();
    }
    
}