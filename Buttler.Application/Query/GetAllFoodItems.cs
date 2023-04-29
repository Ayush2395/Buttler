using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using MediatR;

namespace Buttler.Application.Query
{
    public class GetAllFoodItems : IRequest<IList<FoodDto>>
    {
        public class Handler : IRequestHandler<GetAllFoodItems, IList<FoodDto>>
        {
            readonly IGetAllFoodItemsQueryRepo _repo;

            public Handler(IGetAllFoodItemsQueryRepo repo)
            {
                _repo = repo;
            }

            public Task<IList<FoodDto>> Handle(GetAllFoodItems request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_repo.GetAllFood());
            }
        }
    }
}
