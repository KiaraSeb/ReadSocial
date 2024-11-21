public interface IHiloService
{
    IEnumerable<Hilo> GetAll(); // Obtiene todos los hilos
    Hilo? GetById(int id); // Obtiene un hilo por su ID
    Hilo Create(HiloDTO hiloDto); // Crea un nuevo hilo
    Hilo Update(int id, Hilo hilo); // Actualiza un hilo existente
    bool Delete(int id); // Elimina un hilo por su ID
}
