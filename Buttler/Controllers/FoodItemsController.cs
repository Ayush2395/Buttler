using Buttler.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FoodItemsController : ControllerBase
    {
        readonly ISender _mediator;

        public FoodItemsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("FoodItems")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetFoodItems()
        {
            var foodItem = await _mediator.Send(new GetAllFoodItemsQuery());
            return foodItem != null ? Ok(foodItem) : NotFound("Don't have any food items.");
        }

        [HttpGet]
        [Route("CustomerOrders")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CustomerOrders()
        {
            var customerOrders = await _mediator.Send(new GetAllCustomerOrdersQuery());
            return customerOrders != null ? Ok(customerOrders) : BadRequest();
        }

    }
}
