using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttler.Application.Query
{
    public class LoginUserQuery : IRequest<ResultDto<string>>
    {
        public LoginDto Login { get; set; }
        public class Handler : IRequestHandler<LoginUserQuery, ResultDto<string>>
        {
            readonly ILoginRepo _login;

            public Handler(ILoginRepo login)
            {
                _login = login;
            }

            public Task<ResultDto<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_login.LoginStaffAndAdmin(request.Login));
            }
        }
    }
}
