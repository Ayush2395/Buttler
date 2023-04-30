using Buttler.Application.Enums;
using System.Text.Json.Serialization;

namespace Buttler.Application.DTOs
{
    public class OrdersDto : OrderItemsDto
    {
        [JsonIgnore]
        public int OrderMasterId { get; set; }
        public int? CustomerId { get; set; }
        [JsonIgnore]
        public int? TableId { get; set; }
        public string StaffId { get; set; }
        [JsonIgnore]
        public string OrderStatus { get; set; } = OrderStatusEnum.StatusEnum.pending.ToString();
        [JsonIgnore]
        public decimal? Bill { get; set; }

    }

    public class OrderItemsDto
    {
        [JsonIgnore]
        public int OrderItemsId { get; set; }
        public IList<FoodDto>? FoodItems { get; set; }
        [JsonIgnore]
        public int? Qty { get; set; }
    }
}
