using Buttler.Application.DTOs;
using Domain.Data;

namespace Buttler.Application.Repository
{
    public class GetAllFoodItemsRepo : IGetAllFoodItemsRepo
    {
        readonly ButtlerContext _context;

        public GetAllFoodItemsRepo(ButtlerContext context)
        {
            _context = context;
        }

        public IList<FoodDto> GetAllFood()
        {
            return _context.Foods.Select(rec => new FoodDto
            {
                FoodId = rec.FoodId,
                Title = rec.Title,
                Description = rec.Description,
                FoodPlateSize = rec.FoodPlateSize,
                Price = rec.Price
            }).ToList();
        }
    }

    public interface IGetAllFoodItemsRepo
    {
        IList<FoodDto> GetAllFood();
    }
}
