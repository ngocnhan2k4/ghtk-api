using Ghtk.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghtk.Api.Controllers
{
    [Route("services/shipment")]
    [ApiController]
    public class ShipmentServiceController : ControllerBase
    {
        [HttpPost("orders")]
        [Authorize]
        public IActionResult CreateOrder(CreateOrder createOrder)
        {
            return Ok();
        }
    }
}
