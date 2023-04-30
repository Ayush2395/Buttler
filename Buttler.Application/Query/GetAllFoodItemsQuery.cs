using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using MediatR;

namespace Buttler.Application.Query
{
    public class GetAllFoodItemsQuery : IRequest<IList<FoodDto>>
    {
        public class Handler : IRequestHandler<GetAllFoodItemsQuery, IList<FoodDto>>
        {
            readonly IGetAllFoodItemsRepo _repo;

            public Handler(IGetAllFoodItemsRepo repo)
            {
                _repo = repo;
            }

            public Task<IList<FoodDto>> Handle(GetAllFoodItemsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_repo.GetAllFood());
            }
        }
    }
}
