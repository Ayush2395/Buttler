﻿using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using Domain.Models;
using MediatR;

namespace Buttler.Application.Command
{
    public class CustomerDetailCommand : IRequest<Customer>
    {
        public TablesDto Tables { get; set; }
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }

        public class Handler : IRequestHandler<CustomerDetailCommand, Customer>
        {
            readonly ICustomerDetailsRepo _repo;

            public Handler(ICustomerDetailsRepo repo)
            {
                _repo = repo;
            }

            public Task<Customer> Handle(CustomerDetailCommand request, CancellationToken cancellationToken)
            {
                return _repo.AddCustomerDetails(request.Customer);
            }
        }
    }
}
