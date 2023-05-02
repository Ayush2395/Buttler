using Buttler.Application.DTOs;
using Buttler.Application.Enums;
using Buttler.Application.Repository;
using Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Buttler.Application.Command
{
    public class OrderItemsCommand : IRequest<ResultDto<OrdersDto>>
    {
        public OrdersDto Order { get; set; }

        public class Handler : IRequestHandler<OrderItemsCommand, ResultDto<OrdersDto>>
        {
            readonly IOrderItemsRepo _repo;

            public Handler(IOrderItemsRepo repo)
            {
                _repo = repo;
            }

            public Task<ResultDto<OrdersDto>> Handle(OrderItemsCommand request, CancellationToken cancellationToken)
            {
                return _repo.OrderByCustomer(request.Order);
            }
        }
    }
}
