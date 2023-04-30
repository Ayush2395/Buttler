using Buttler.Application.DTOs;
using Domain.Data;

namespace Buttler.Application.Repository
{
    public class CustomersOrderRepo : ICustomersOrderRepo
    {
        readonly ButtlerContext _context;

        public CustomersOrderRepo(ButtlerContext context)
        {
            _context = context;
        }

        public Task<List<CustomersOrderDto>> GetAllOrders()
        {
            var orders = (from customer in _context.Customer
                          join tables in _context.Tables
                          on customer.CustomerId equals tables.CustomerId
                          select new CustomersOrderDto
                          {
                              CustomerId = customer.CustomerId,
                              CustomerName = customer.CustomerName,
                              TableNumber = tables.TableNumber,
                          }).ToList();
            return Task.FromResult(orders);
        }
    }

    public interface ICustomersOrderRepo
    {
        Task<List<CustomersOrderDto>> GetAllOrders();
    }
}
