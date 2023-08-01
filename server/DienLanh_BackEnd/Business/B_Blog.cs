using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_Blog : S_Blog
    {
        readonly DatabaseContext _dbContext = new();

        public B_Blog(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddBlog(Blog blog)
        {
            try
            {
                blog.BlogID = C_Function.randomID();
                blog.CreatedDate = DateTime.Now;
                blog.UpdatedDate = DateTime.Now;

                while (_dbContext.Blogs!.Any(blogDB => blogDB.BlogID == blog.BlogID))
                {
                    blog.BlogID = C_Function.randomID();
                }
                _dbContext.Blogs!.Add(blog);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteBlog(string id)
        {
            bool result = false;
            try
            {
                Blog blogs = _dbContext.Blogs!.Find(id)!;

                if (blogs != null)
                {
                    _dbContext.Blogs.Remove(blogs);
                    _dbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        public Blog GetBlogDetails(string id)
        {
            try
            {
                Blog blog = _dbContext.Blogs!.Find(id)!;

                return blog;

            }
            catch
            {
                return null;
            }
        }

        public List<Blog> GetBlogs()
        {
            try
            {
                return _dbContext.Blogs!.OrderBy(x => x.Title).ToList();
            }
            catch
            {
                return new List<Blog>();
            }
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                blog.UpdatedDate = DateTime.Now;

                _dbContext.Entry(blog).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
