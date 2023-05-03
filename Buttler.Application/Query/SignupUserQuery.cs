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
    public class SignupUserQuery : IRequest<ResultDto<string>>
    {
        public StaffsDto Staffs { get; set; }
        public StaffDetailsDto StaffDetails { get; set; }
        public class Handler : IRequestHandler<SignupUserQuery, ResultDto<string>>
        {
            readonly ILoginRepo _login;

            public Handler(ILoginRepo login)
            {
                _login = login;
            }

            public Task<ResultDto<string>> Handle(SignupUserQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_login.SignupStaff(request.Staffs, request.StaffDetails));
            }
        }
    }
}
