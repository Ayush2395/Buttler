using Buttler.Application.Enums;
using System.Text.Json.Serialization;

namespace Buttler.Application.DTOs
{
    public class StaffsDto
    {
        [JsonIgnore]
        public string StaffId { get; set; }
        [JsonIgnore]
        public string StaffType { get; set; } = UserType.UserTypeEnum.staff.ToString();

        [JsonIgnore]
        public DateTime? StaffLastLogin { get; set; }

        [JsonIgnore]
        public string StaffSq { get; set; }
        [JsonIgnore]
        public string StaffSa { get; set; }
        public string StaffPwd { get; set; }
        public string Email { get; set; }
    }

    public class StaffDetailsDto
    {
        [JsonIgnore]
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffGender { get; set; }
        public string StaffPhoneNumber { get; set; }
        public DateTime? StaffDob { get; set; }
        public string StaffAddress { get; set; }
        public byte[] StaffImg { get; set; }
    }

    public class StaffSqsDto
    {
        public string StaffSq { get; set; }

    }
}
