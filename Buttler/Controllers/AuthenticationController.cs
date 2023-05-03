using Buttler.API.Models;
using Buttler.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly ITokenGenerate _token;

        public AuthenticationController(ITokenGenerate token)
        {
            _token = token;
        }

        [HttpPost("GenerateToken")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public ActionResult<ResultDto<AuthenticationModel>> GenerateToken(string id, string email, string pwd)
        {
            return Ok(_token.GenerateAccessToken(id, email, pwd));
        }
    }
}
