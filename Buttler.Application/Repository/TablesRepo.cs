using Buttler.Application.DTOs;
using Domain.Data;
using Domain.Models;

namespace Buttler.Application.Repository
{
    public class TablesRepo : ITablesRepo
    {
        readonly ButtlerContext _context;

        public TablesRepo(ButtlerContext context)
        {
            _context = context;
        }

        public async Task<Tables> AssignTableToCustomer(TablesDto tables, int customerId)
        {
            if (tables != null)
            {
                var result = _context.Tables.Add(new()
                {
                    TableNumber = tables.TableNumber,
                    CustomerId = customerId,
                });

                await _context.SaveChangesAsync();

                return result.Entity;
            }
            return null!;
        }
    }

    public interface ITablesRepo
    {
        Task<Tables> AssignTableToCustomer(TablesDto tables, int customerId);
    }
}
