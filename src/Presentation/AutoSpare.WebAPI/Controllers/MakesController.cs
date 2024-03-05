using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Domain.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    { 
        private readonly IMakeReadRepository _makeReadRepository;
        private readonly IMakeWriteRepository _makeWriteRepository;

        public MakesController(IMakeReadRepository makeReadRepository, IMakeWriteRepository makeWriteRepository)
        {
            _makeReadRepository = makeReadRepository;
            _makeWriteRepository = makeWriteRepository;
        }
        [HttpGet("/add")]
        public async Task<IActionResult> AddMakes()
        {
            var makesToAdd = new List<Make>
        {
            new Make
            {
                Id = Guid.NewGuid(),
                Name = "Mercedes",
                CreatedDate = DateTime.Now
            },
            new Make
            {
                Id = Guid.NewGuid(),
                Name = "Honda",
                CreatedDate = DateTime.Now
            }
        };
            await _makeWriteRepository.AddRangeAsync(makesToAdd);
            await _makeWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]   
        public async Task<IActionResult> GetMakes()
        {
           return Ok( await _makeReadRepository.GetAllAsync());
        }
        
    }
}
