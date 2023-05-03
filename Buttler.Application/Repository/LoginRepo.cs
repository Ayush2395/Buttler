using Buttler.Application.DTOs;
using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttler.Application.Repository
{
    public class LoginRepo : ILoginRepo
    {
        readonly ButtlerContext _context;

        public LoginRepo(ButtlerContext context)
        {
            _context = context;
        }

        public bool IsUserExist(string userId)
        {
            return _context.Staffs.Any(rec => rec.StaffId == userId);
        }

        public ResultDto<string> LoginStaffAndAdmin(LoginDto loginDto)
        {
            if (!IsUserExist(loginDto.UserId))
            {
                return new ResultDto<string>("User not found.", false);
            }
            else
            {
                return new ResultDto<string>("User logged in.", true);
            }
        }

        public ResultDto<string> SignupStaff(StaffsDto staffsDto, StaffDetailsDto staffDetailsDto)
        {
            if (IsUserExist(staffsDto.StaffId))
            {
                return new ResultDto<string>("User Already exist.", false);
            }
            else
            {
                _context.Staffs.Add(new()
                {
                    StaffId = staffsDto.StaffId,
                    StaffEmail = staffsDto.Email,
                    StaffPwd = staffsDto.StaffPwd,
                    StaffSq = staffsDto.StaffSq,
                    StaffSa = staffsDto.StaffSa,
                });
                _context.StaffDetails.Add(new()
                {
                    StaffName = staffDetailsDto.StaffName,
                    StaffGender = staffDetailsDto.StaffGender,
                    StaffDob = staffDetailsDto.StaffDob,
                    StaffPhoneNumber = staffDetailsDto.StaffPhoneNumber,
                    StaffId = staffDetailsDto.StaffId,
                });
                _context.SaveChanges();
                return new ResultDto<string>("Staff has been registered.");
            }
        }
    }

    public interface ILoginRepo
    {
        ResultDto<string> LoginStaffAndAdmin(LoginDto loginDto);
        ResultDto<string> SignupStaff(StaffsDto staffsDto, StaffDetailsDto staffDetailsDto);
    }
}
