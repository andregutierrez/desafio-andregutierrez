using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Queries;
using AndreGutierrez.Domain.Pessoas;

namespace AndreGutierrez.Application.Pessoas.Queries;

public class ObterPessoaQueryHandler : IQueryHandler<ObterPessoaQuery, PessoaDto>
{
    private readonly IPessoaRepository _pessoaRepository;

    public ObterPessoaQueryHandler(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<PessoaDto> Handle(ObterPessoaQuery request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(request.PessoaId);
        if(pessoa == null)
            throw new NotFoundCommandException("A pessoa não foi encontrada", $"Nehum registro foi retornado para o identificador {request.PessoaId}");
            
        
        return (PessoaDto)pessoa;
    }
}
