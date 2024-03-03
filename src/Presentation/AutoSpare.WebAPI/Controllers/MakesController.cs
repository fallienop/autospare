using AutoSpare.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IMakeService _makeService;

        public MakesController(IMakeService makeService)
        {
            _makeService = makeService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var makes=_makeService.GetMakes();
            return Ok(makes);
        }
    }
}
