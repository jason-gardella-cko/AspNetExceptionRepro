using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExceptionRepro.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpPost("repro")]
        public async Task<IActionResult> Post()
        {
            // Call to Request.ReadFormAsync throws an exception if form value contains null character (`%00`).
            var form = await Request.ReadFormAsync();
            return Ok();
        }
    }
}