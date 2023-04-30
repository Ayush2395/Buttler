using System.Text.Json.Serialization;

namespace Buttler.Application.DTOs
{
    public class CustomersOrderDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TableNumber { get; set; }

        [JsonIgnore]
        public IList<FoodDto> FoodItems { get; set; }
        [JsonIgnore]
        public decimal? Bill { get; set; }
    }
}
