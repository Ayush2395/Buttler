using System.Text.Json.Serialization;

namespace Buttler.Application.DTOs
{
    public class CustomerDto
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }


    public class TablesDto
    {
        [JsonIgnore]
        public int TableId { get; set; }
        public string TableNumber { get; set; }
        [JsonIgnore]
        public int CustomerId { get; set; }

    }
}
