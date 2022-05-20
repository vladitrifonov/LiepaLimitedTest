using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<UserEntity> _genericService;
        public UserController(IGenericService<UserEntity> genericService)
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
        public async Task<IActionResult> Create(UserEntity userEntity)
        {
            var user = await _genericService.CreateAsync(userEntity);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> SetStatus(UserEntity userEntity)
        {
            var user = await _genericService.UpdateAsync(userEntity);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserEntity userEntity)
        {
            await _genericService.DeleteAsync(userEntity);

            return NoContent();
        }       
    }
}
