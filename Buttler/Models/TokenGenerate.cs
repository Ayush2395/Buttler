using Buttler.Application.DTOs;
using Domain.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Buttler.API.Models
{

    public class TokenGenerate : ITokenGenerate
    {
        readonly ButtlerContext _context;
        readonly JWTsettings _jwtsettings;

        public TokenGenerate(ButtlerContext context, IOptions<JWTsettings> Jwt)
        {
            _context = context;
            _jwtsettings = Jwt.Value;
        }

        public ResultDto<AuthenticationModel> GenerateAccessToken(string id, string email, string pwd)
        {
            var staffUser = _context.Staffs.FirstOrDefault(rec => rec.StaffId == id);
            if (staffUser != null)
            {
                if (staffUser.StaffEmail == email && staffUser.StaffPwd == pwd)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, staffUser.StaffEmail),
                        new Claim("staffPwd", staffUser.StaffPwd),
                        new Claim(JwtRegisteredClaimNames.Sub, _jwtsettings.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    };

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key));
                    var signIn = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_jwtsettings.Issuer,
                        _jwtsettings.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(2),
                        signingCredentials: signIn
                        );
                    var tokenCreated = new JwtSecurityTokenHandler().WriteToken(token);
                    var authData = new AuthenticationModel() { AccessToken = tokenCreated, Email = staffUser.StaffEmail, ExpiresIn = DateTime.UtcNow.AddMinutes(2) };
                    return new ResultDto<AuthenticationModel>(authData);
                }
            }
            else
            {
                return new ResultDto<AuthenticationModel>(null!, "Invalid credential", false);
            }
            return null!;
        }
    }

    public interface ITokenGenerate
    {
        ResultDto<AuthenticationModel> GenerateAccessToken(string id, string email, string pwd);
    }
}
