using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Domain.Pessoas;
using AndreGutierrez.Domain.Common;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Application.Common.Validation;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class CriacaoPessoaCommandHandler: ICommandHandler<CriacaoPessoaCommand, PessoaDto>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriacaoPessoaCommandHandler(Domain.Pessoas.IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, ICidadeRepository cidadeRepository)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
        _cidadeRepository = cidadeRepository;
    }

    public async Task<PessoaDto> Handle(CriacaoPessoaCommand request, CancellationToken cancellationToken)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(request.CidadeId);
        if(cidade == null)
            throw new NotFoundCommandException("A cidade não foi encontrada", $"Nehum registro foi retornado para o identificador {request.CidadeId}");
            
        var pessoa = Pessoa.Create(request.Nome, request.Idade, request.Cpf, cidade);
        
        await _pessoaRepository.CreateAsync(pessoa);
        await _unitOfWork.CommitAsync();
        
        return (PessoaDto)pessoa;
    }
}