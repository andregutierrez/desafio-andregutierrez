using AndreGutierrez.Application.Queries;
using AndreGutierrez.Application.UFs.Dtos;
using AndreGutierrez.Domain.Estados;

namespace AndreGutierrez.Application.UFs.Queries;


public class ListaEstadoQueryHandler : IQueryHandler<ListaEstadosQuery, IEnumerable<EstadoDto>>
{
    private readonly IEstadoRepository _estadoRepository;

    public ListaEstadoQueryHandler(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }

    public async Task<IEnumerable<EstadoDto>> Handle(ListaEstadosQuery request, CancellationToken cancellationToken)
    {
        var estados = await _estadoRepository.GetAllAsync();
        return from o in estados select (EstadoDto)o;
    }
}
