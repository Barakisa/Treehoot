using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Controllers;

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
