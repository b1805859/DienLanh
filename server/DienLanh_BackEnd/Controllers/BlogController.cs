using DienLanh_BackEnd.Models;
using JLPT_API.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly S_Blog _IBlog;

        public BlogController(S_Blog IBlog)
        {
            _IBlog = IBlog;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<Blog> blogs = await Task.FromResult(_IBlog.GetBlogs());

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = blogs });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var blogs = await Task.FromResult(_IBlog.GetBlogDetails(id));

                if (blogs != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = blogs });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Blog blog)
        {
            try
            {
                bool result = await Task.FromResult(_IBlog.AddBlog(blog));

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = blog });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Blog blog)
        {
            try
            {
                if (id != blog.BlogID)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }

                var result = await Task.FromResult(_IBlog.UpdateBlog(blog));

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                bool result = await Task.FromResult(_IBlog.DeleteBlog(id));

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });

            }
        }
    }
}
