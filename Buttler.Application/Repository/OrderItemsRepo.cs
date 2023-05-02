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

        public async Task<ResultDto<OrdersDto>> OrderByCustomer(OrdersDto order)
        {
            var table = await _context.Tables
                .FirstOrDefaultAsync(rec => rec.CustomerId == order.CustomerId);
            if (table != null)
            {
                _context.OrderMaster
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
                            OrderMasterId = ordMstId.OrderMasterId,
                            Qty = foodItems.Qty,
                        });
                        bill += foodItems.Qty * foodItems.Price;
                        //_context.SaveChanges();
                    }
                    ordMstId.Bill = bill;
                    _context.SaveChanges();
                }
                return new ResultDto<OrdersDto>("Order booked", true);
            }
            return new ResultDto<OrdersDto>();
        }
    }

    public interface IOrderItemsRepo
    {
        Task<ResultDto<OrdersDto>> OrderByCustomer(OrdersDto order);
    }
}
