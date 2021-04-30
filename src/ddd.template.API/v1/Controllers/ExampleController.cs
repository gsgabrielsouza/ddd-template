using ddd.template.Application.Service.v1;
using ddd.template.Domain.Command.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd.template.API.v1.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ExampleAppService appService;

        public ExampleController(ExampleAppService appService) =>
            this.appService = appService ?? throw new ArgumentNullException(nameof(appService));

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get(
                                      [FromQuery] int page = 1,
                                      [FromQuery] int count = 10,
                                      [FromQuery] string name = null,
                                      [FromQuery] decimal? amount = null)
        {
            var result = await appService.GetBy(page, count, name, amount);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id) =>
            Ok(await appService.GetBy(id));

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ExampleAddCommand example)
        {
            var result = await appService.Add(example);
            if (result.IsValid)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] ExampleUpdateCommand example)
        {
            var result = await appService.Update(example);
            if (result.IsValid)
                return Ok(result);

            return BadRequest(result.Errors);
        }
    }
}
