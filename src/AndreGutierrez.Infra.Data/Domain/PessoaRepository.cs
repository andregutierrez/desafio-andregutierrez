using AndreGutierrez.Domain.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace AndreGutierrez.Infra.Data.Domain;

public class PessoaRepository : IPessoaRepository
{
    private readonly DesafioContext _context;

    public PessoaRepository(DesafioContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateAsync(Pessoa pessoa)
    {
        await this._context.Pessoa.AddAsync(pessoa);
    }

    public void Delete(Pessoa pessoa)
    {
        this._context.Pessoa.Remove(pessoa);
    }

    public async Task<Pessoa?> GetByIdAsync(int id)
    {
        var query = from o in this._context.Pessoa where o.Id == id select o;
        return await query.SingleOrDefaultAsync();
    }

    public Task<List<Pessoa>> GetAllAsync()
    {
        return this._context.Pessoa.ToListAsync();
    }
}