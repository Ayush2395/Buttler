using Buttler.Application.DTOs;
using Buttler.Application.Enums;
using Buttler.Application.Repository;
using Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Buttler.Application.Command
{
    public class OrderItemsCommand : IRequest<OrdersDto>
    {
        public OrdersDto Order { get; set; }

        public class Handler : IRequestHandler<OrderItemsCommand, OrdersDto>
        {
            readonly IOrderItemsRepo _repo;

            public Handler(IOrderItemsRepo repo)
            {
                _repo = repo;
            }

            public Task<OrdersDto> Handle(OrderItemsCommand request, CancellationToken cancellationToken)
            {
                return _repo.OrderByCustomer(request.Order);
            }
        }
    }
}
