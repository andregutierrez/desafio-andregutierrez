namespace AndreGutierrez.Domain.Estados;

public interface IEstadoRepository
{
    Task<Estado> GetByUfAsync(int id);
    Task<List<Estado>> GetAllAsync();
}