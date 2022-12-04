namespace AndreGutierrez.Domain.Cidades;

public interface ICidadeRepository
{
    Task CreateAsync(Cidade cidade);
    void Delete(Cidade cidade);
    Task<Cidade?> GetByIdAsync(int id);
    Task<List<Cidade>> GetAllAsync();
}