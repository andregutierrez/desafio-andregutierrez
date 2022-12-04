using AndreGutierrez.Domain.Estados;
using AndreGutierrez.Domain.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace AndreGutierrez.Infra.Data.Domain;

public class EstadoRepository : IEstadoRepository
{
    private readonly DesafioContext _context;

    public EstadoRepository(DesafioContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<Estado>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Estado> GetByUfAsync(int id)
    {
        throw new NotImplementedException();
    }
}