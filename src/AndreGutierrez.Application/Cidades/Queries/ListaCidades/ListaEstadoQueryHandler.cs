using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Queries;
using AndreGutierrez.Domain.Cidades;

namespace AndreGutierrez.Application.UFs.Queries;

public class ListaCidadeQueryHandler : IQueryHandler<ListaCidadesQuery, IEnumerable<CidadeDto>>
{
    private readonly ICidadeRepository _cidadeRepository;

    public ListaCidadeQueryHandler(ICidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }

    public async Task<IEnumerable<CidadeDto>> Handle(ListaCidadesQuery request, CancellationToken cancellationToken)
    {
        var cidades = await _cidadeRepository.GetAllAsync();
        return from o in cidades select (CidadeDto)o;
    }
}
