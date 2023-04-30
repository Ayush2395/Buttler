namespace Buttler.Application.DTOs
{
    public class FoodDto
    {
        public int FoodId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string FoodPlateSize { get; set; }
        public int Qty { get; set; }
    }
}
