using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WitchSaga.Application.Dto;
using WitchSaga.Application.Services;

namespace WitchSaga.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class WitchController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IKillService _service;

        public WitchController(ILogger<WitchController> logger, IKillService killService)
        {
            _logger = logger;
            _service = killService;
        }

        [HttpPost]
        [Route("get-summary")]
        public IActionResult PostDetail([FromBody] List<PersonDto> requests)
        {
            if (requests == null || requests.Count == 0)
                return BadRequest();

            try
            {
                _logger.LogInformation("API Running");
                var response = _service.GetPeopleKilledInfo(requests);
                return Ok(new { result = response });
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong");
                return Ok(new { result = false, message = e.Message });
            }
        }
    }
}
