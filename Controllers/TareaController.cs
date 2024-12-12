using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasService _tareasService;

    public TareaController(ITareasService tareasService)
    {
        _tareasService = tareasService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tareasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _tareasService.SaveAsync(tarea);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        _tareasService.Update(id, tarea);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _tareasService.Delete(id);
        return Ok();
    }
}