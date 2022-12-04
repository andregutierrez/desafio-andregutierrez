using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Queries;
using AndreGutierrez.Domain.Pessoas;

namespace AndreGutierrez.Application.Pessoas.Queries;

public class ListaPessoaQueryHandler : IQueryHandler<ListaPessoasQuery, IEnumerable<PessoaDto>>
{
    private readonly IPessoaRepository _pessoaRepository;

    public ListaPessoaQueryHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<IEnumerable<PessoaDto>> Handle(ListaPessoasQuery request, CancellationToken cancellationToken)
    {
        var pessoas = await _pessoaRepository.GetAllAsync();
        return from o in pessoas select (PessoaDto)o;
    }
}
