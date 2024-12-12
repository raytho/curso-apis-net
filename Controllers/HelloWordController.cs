using Microsoft.AspNetCore.Mvc;
using proyectoef;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    TareasContext dbcontext;

    public HelloWorldController(TareasContext db)
    {
        dbcontext = db;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}