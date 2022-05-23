using LiepaLimitedTest.Applicaion.Api.Models;
using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<UserEntity, User> _genericService;
        public UserController(IGenericService<UserEntity, User> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _genericService.GetByIdAsync(id);

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            var user = await _genericService.CreateAsync(model);

            return Ok(user);
        }

        [HttpPost("/[controller]/status")]
        public async Task<IActionResult> SetStatus(User model)
        {
            var user = await _genericService.UpdateAsync(model);

            return Ok(user);
        }
              
        [HttpPost("/[controller]/remove")]
        public async Task<IActionResult> Delete(User model)
        {
            await _genericService.DeleteAsync(model);

            return NoContent();
        }       
    }
}
