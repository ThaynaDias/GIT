using Microsoft.AspNetCore.Mvc;
using ms_travel_easy.src.Models;
using ms_travel_easy.src.Services;

namespace ms_travel_easy.src.Controllers
{
    [ApiController]
    [Route("api/v1/Customer/[controller]")]
    public class BookingsController : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            return Ok();

        }

    }
}

