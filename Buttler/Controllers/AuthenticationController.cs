using Buttler.API.Models;
using Buttler.Application.DTOs;
using Buttler.Application.Query;
using Buttler.Application.Repository;
using MediatR;
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
            var token = _token.GenerateAccessToken(id, email, pwd);
            return token != null ? Ok(token) : BadRequest("Wrong credentials");
        }
    }
}
