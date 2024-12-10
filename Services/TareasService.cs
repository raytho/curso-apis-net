using proyectoef;
using proyectoef.Models;

namespace webapi.Services;

public class TareasService : ITareasService
{
    TareasContext _context;

    public TareasService(TareasContext context)
    {
        _context = context;
    }

    public IEnumerable<Tarea> Get()
    {
        return _context.Tareas;
    }

    public async Task SaveAsync(Tarea tarea)
    {
        _context.Add(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = _context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.Resumen = tarea.Resumen;
            tareaActual.Titulo = tarea.Titulo;
        }
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var tarea = _context.Tareas.Find(id);

        if (tarea != null)
        {
            _context.Remove(tarea);
            await _context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task SaveAsync(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}