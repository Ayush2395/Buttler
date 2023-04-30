﻿using Buttler.Application.DTOs;
using Domain.Data;
using Domain.Models;

namespace Buttler.Application.Repository
{
    public class CustomerDetailsRepo : ICustomerDetailsRepo
    {
        readonly ButtlerContext _context;

        public CustomerDetailsRepo(ButtlerContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomerDetails(CustomerDto customer)
        {
            if (customer != null)
            {
                var result = _context.Customer.Add(new()
                {
                    CustomerName = customer.CustomerName,
                    CustomerGender = customer.CustomerGender,
                    CustomerPhoneNumber = customer.CustomerPhoneNumber,
                });

                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null!;
        }
    }
    public interface ICustomerDetailsRepo
    {
        Task<Customer> AddCustomerDetails(CustomerDto customer);
    }
}