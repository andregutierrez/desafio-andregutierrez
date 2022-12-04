namespace AndreGutierrez.Domain.Pessoas;

public interface IPessoaRepository
{
    Task CreateAsync(Pessoa pessoa);
    void Delete(Pessoa cidade);
    Task<Pessoa?> GetByIdAsync(int id);
    Task<List<Pessoa>> GetAllAsync();
}