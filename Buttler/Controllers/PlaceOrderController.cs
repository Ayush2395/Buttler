using Buttler.Application.Command;
using Buttler.Application.DTOs;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOrderController : ControllerBase
    {
        readonly ISender _mediator;

        public PlaceOrderController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddCustomerDetails")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerDto customer)
        {
            var details = await _mediator.Send(new CustomerDetailCommand { Customer = customer });
            return details != null ? Ok("Customer details saved.") : BadRequest("Please fill the customer details.");
        }

        [HttpPost]
        [Route("AssignTable")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Tables>> AssignTable(TablesDto tables, int customerId)
        {
            var data = await _mediator.Send(new AssignTableCommand { CustomerId = customerId, Tables = tables });
            return data != null ? Ok("") : BadRequest();
        }

        [HttpPost]
        [Route("PlaceOrderByOrder")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<OrdersDto>> PlaceOrderByCustomer(OrdersDto orders)
        {
            var result = await _mediator.Send(new OrderItemsCommand { Order = orders });
            return result != null ? Ok("Order has been booked.") : BadRequest();
        }
    }
}
