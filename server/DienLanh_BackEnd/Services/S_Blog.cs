using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_Blog
    {
        public List<Blog> GetBlogs();
        public Blog GetBlogDetails(string id);
        public bool AddBlog(Blog blog);
        public bool UpdateBlog(Blog blog);
        public bool DeleteBlog(string id);
    }
}
