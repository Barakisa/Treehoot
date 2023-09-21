using Microsoft.AspNetCore.Mvc;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]

        public ActionResult<Question> Get(Guid Id)
        {
            return Ok();
        }
    }
}
