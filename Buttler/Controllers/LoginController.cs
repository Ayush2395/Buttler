using Buttler.Application.DTOs;
using Buttler.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ISender _sender;

        public LoginController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("LoginUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ResultDto<string>>> LoginUser(LoginDto loginDto)
        {
            var login = await _sender.Send(new LoginUserQuery { Login = loginDto });
            return login != null ? Ok(login) : BadRequest(login);
        }

        [HttpPost("SignupUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ResultDto<string>>> Signup(StaffsDto staffs, StaffDetailsDto staffDetails)
        {
            var signup = await _sender.Send(new SignupUserQuery { Staffs = staffs, StaffDetails = staffDetails });
            return signup != null ? Ok(signup) : BadRequest(signup);
        }
    }
}
