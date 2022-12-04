using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Application.Queries;
using AndreGutierrez.Domain.Cidades;

namespace AndreGutierrez.Application.UFs.Queries;

public class ObterCidadeHandler : IQueryHandler<ObterCidadeQuery, CidadeDto>
{
    private readonly ICidadeRepository _cidadeRepository;

    public ObterCidadeHandler(ICidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }

    public async Task<CidadeDto> Handle(ObterCidadeQuery request, CancellationToken cancellationToken)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(request.CidadeId);
        if(cidade == null)
            throw new NotFoundCommandException("A cidade não foi encontrada", $"Nehum registro foi retornado para o identificador {request.CidadeId}");
            
        return (CidadeDto)cidade;
    }
}
