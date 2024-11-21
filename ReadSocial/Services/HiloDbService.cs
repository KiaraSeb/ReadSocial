using Microsoft.EntityFrameworkCore;

public class HiloDbService : IHiloService
{
    private readonly ForoDbContext _context;

    public HiloDbService(ForoDbContext context)
    {
        _context = context;
    }

    // Obtener todos los hilos
    public IEnumerable<Hilo> GetAll()
    {
        return _context.Hilos.AsNoTracking().ToList();
    }

    // Obtener un hilo por su ID
    public Hilo? GetById(int id)
    {
        return _context.Hilos.AsNoTracking().FirstOrDefault(h => h.Id == id);
    }

    // Crear un nuevo hilo
    public Hilo Create(HiloDTO hiloDto)
    {
        var hilo = new Hilo
        {
            Titulo = hiloDto.Titulo,
            Descripcion = hiloDto.Descripcion,
            FechaCreacion = DateTime.UtcNow // Ajusta según la lógica de tu aplicación
        };

        _context.Hilos.Add(hilo);
        _context.SaveChanges(); // Guarda en la base de datos

        return hilo;
    }

    // Actualizar un hilo existente
    public Hilo Update(int id, Hilo hilo)
    {
        var existingHilo = _context.Hilos.FirstOrDefault(h => h.Id == id);

        if (existingHilo == null)
        {
            return null; // O lanzar una excepción si prefieres
        }

        existingHilo.Titulo = hilo.Titulo;
        existingHilo.Descripcion = hilo.Descripcion;
        existingHilo.FechaCreacion = hilo.FechaCreacion;

        _context.Hilos.Update(existingHilo);
        _context.SaveChanges();

        return existingHilo;
    }

    // Eliminar un hilo por su ID
    public bool Delete(int id)
    {
        var hilo = _context.Hilos.FirstOrDefault(h => h.Id == id);

        if (hilo == null)
        {
            return false; // No se encontró el hilo
        }

        _context.Hilos.Remove(hilo);
        _context.SaveChanges();

        return true;
    }
}
