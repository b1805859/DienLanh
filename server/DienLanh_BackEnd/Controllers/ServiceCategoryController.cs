using DienLanh_BackEnd.Models;
using JLPT_API.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly S_ServiceCategory _IServiceCategory;

        public ServiceCategoryController(S_ServiceCategory IServiceCategory)
        {
            _IServiceCategory = IServiceCategory;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<ServiceCategory> serviceCategorys = _IServiceCategory.GetServiceCategorys();

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = serviceCategorys });
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
                var serviceCategorys = await Task.FromResult(_IServiceCategory.GetServiceCategoryDetails(id));

                if (serviceCategorys != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = serviceCategorys });
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
        public ActionResult Post(ServiceCategory serviceCategory)
        {
            try
            {
                bool result = _IServiceCategory.AddServiceCategory(serviceCategory);

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = serviceCategory });
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
        public async Task<ActionResult> Put(string id, ServiceCategory serviceCategory)
        {
            try
            {
                if (id != serviceCategory.ServiceCategoryID)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
                }

                var result = _IServiceCategory.UpdateServiceCategory(serviceCategory);

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                bool result = _IServiceCategory.DeleteServiceCategory(id);

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
