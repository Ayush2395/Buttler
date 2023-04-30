using Buttler.Application.DTOs;
using Buttler.Application.Enums;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Buttler.Application.Repository
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        readonly ButtlerContext _context;

        public OrderItemsRepo(ButtlerContext context)
        {
            _context = context;
        }

        public async Task<OrdersDto> OrderByCustomer(OrdersDto order)
        {
            var table = await _context.Tables
                .FirstOrDefaultAsync(rec => rec.CustomerId == order.CustomerId);
            dynamic orderbyCustomer = null!;
            if (table != null)
            {
                orderbyCustomer = _context.OrderMaster
                    .Add(new()
                    {
                        CustomerId = order.CustomerId,
                        StaffId = order.StaffId,
                        TableId = table.TableId,
                        OrderStatus = OrderStatusEnum.StatusEnum.pending.ToString(),
                    });

                _context.SaveChanges();

                var ordMstId = await _context.OrderMaster
                    .FirstOrDefaultAsync(rec => rec.CustomerId == order.CustomerId);

                if (ordMstId != null && order.FoodItems != null)
                {
                    decimal? bill = 0.0M;
                    foreach (var foodItems in order.FoodItems)
                    {
                        _context.OrderItems.Add(new()
                        {
                            FoodId = foodItems.FoodId,
                            OrderItemsId = ordMstId.OrderMasterId,
                            Qty = foodItems.Qty,
                        });
                        bill += foodItems.Qty * foodItems.Price;
                        _context.SaveChanges();
                    }
                    ordMstId.Bill = bill;
                    _context.SaveChanges();
                }
            }
            return Task.FromResult(orderbyCustomer);
        }
    }

    public interface IOrderItemsRepo
    {
        Task<OrdersDto> OrderByCustomer(OrdersDto order);
    }
}
