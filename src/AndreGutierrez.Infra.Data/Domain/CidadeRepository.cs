using AndreGutierrez.Domain.Cidades;
using Microsoft.EntityFrameworkCore;

namespace AndreGutierrez.Infra.Data.Domain;

public class CidadeRepository : ICidadeRepository
{
    private readonly DesafioContext _context;

    public CidadeRepository(DesafioContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateAsync(Cidade cidade)
    {
        await this._context.Cidade.AddAsync(cidade);
    }

    public void Delete(Cidade cidade)
    {
        this._context.Cidade.Remove(cidade);
    }

    public async Task<Cidade?> GetByIdAsync(int id)
    {
        var query = from o in this._context.Cidade where o.Id == id select o;
        return await query.SingleOrDefaultAsync();
    }

    public Task<List<Cidade>> GetAllAsync()
    {
        return this._context.Cidade.ToListAsync();
    }
}
