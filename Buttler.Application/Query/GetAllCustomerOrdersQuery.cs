using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using MediatR;

namespace Buttler.Application.Query
{
    public class GetAllCustomerOrdersQuery : IRequest<List<CustomersOrderDto>>
    {
        public class Handler : IRequestHandler<GetAllCustomerOrdersQuery, List<CustomersOrderDto>>
        {
            readonly ICustomersOrderRepo _repo;

            public Handler(ICustomersOrderRepo repo)
            {
                _repo = repo;
            }

            public Task<List<CustomersOrderDto>> Handle(GetAllCustomerOrdersQuery request, CancellationToken cancellationToken)
            {
                return _repo.GetAllOrders();
            }
        }
    }
}
