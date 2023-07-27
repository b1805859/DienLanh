using JLPT_API.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly S_Employee _IEmployee;

        public EmployeeController(S_Employee IEmployee)
        {
            _IEmployee = IEmployee;
        }


        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<Employee> employees = _IEmployee.GetEmployeeDetails();

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = employees });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }


        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var employees = await Task.FromResult(_IEmployee.GetEmployeeDetails(id));

                if (employees != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = employees });
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

        // POST api/employee
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            try
            {
                bool result = _IEmployee.AddEmployee(employee);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = employee });
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

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
                }

                var result = _IEmployee.UpdateEmployee(employee);

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var employee = _IEmployee.DeleteEmployee(id);

                if (employee)
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

        private bool EmployeeExists(int id)
        {
            try
            {
                if (_IEmployee.CheckEmployee(id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
