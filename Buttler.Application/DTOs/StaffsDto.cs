namespace Buttler.Application.DTOs
{
    public class StaffsDto : StaffDetails
    {
        public string StaffId { get; set; }
        public string StaffType { get; set; } = "staff";
        public DateTime? StaffLastLogin { get; set; }
        public string StaffSq { get; set; }
        public string StaffSa { get; set; }
        public string StaffPwd { get; set; }
    }

    public class StaffDetails
    {
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
