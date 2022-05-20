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
        public async Task<IActionResult> Get()
        {
            var user = await _genericService.CreateAsync(new UserEntity { Name = "test", Status = Domain.DataTypes.Status.New });

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserEntity userEntity)
        {
            var user = await _genericService.CreateAsync(new UserEntity { Name = "test", Status = Domain.DataTypes.Status.New });

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserEntity userEntity)
        {
            var user = await _genericService.CreateAsync(new UserEntity { Name = "test", Status = Domain.DataTypes.Status.New });

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> SetStatus(UserEntity userEntity)
        {
            var user = await _genericService.CreateAsync(new UserEntity { Name = "test", Status = Domain.DataTypes.Status.New });

            return Ok(user);
        }
    }
}
