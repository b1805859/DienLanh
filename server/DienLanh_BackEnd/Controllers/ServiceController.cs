using DienLanh_BackEnd.Models;
using JLPT_API.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_JWT_NET6_Base.Services;

namespace DienLanh_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly S_Service _IService;

        public ServiceController(S_Service IService)
        {
            _IService = IService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<Service> services = await Task.FromResult(_IService.GetServices());

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = services });
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
                var services = await Task.FromResult(_IService.GetServiceDetails(id));

                if (services != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = services });
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


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(Service service)
        {
            try
            {
                bool result = await Task.FromResult(_IService.AddService(service));

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = service });
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


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Service service)
        {
            try
            {
                if (id != service.ServiceID)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }

                var result = await Task.FromResult(_IService.UpdateService(service));

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                bool result = await Task.FromResult(_IService.DeleteService(id));

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
