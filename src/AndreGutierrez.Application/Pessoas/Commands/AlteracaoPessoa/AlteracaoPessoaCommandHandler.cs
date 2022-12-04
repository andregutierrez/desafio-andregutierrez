using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Domain.Pessoas;
using AndreGutierrez.Domain.Common;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Application.Common.Validation;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class AlteracaoPessoaCommandHandler: ICommandHandler<AlteracaoPessoaCommand, PessoaDto>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AlteracaoPessoaCommandHandler(IPessoaRepository pessoaRepository, ICidadeRepository cidadeRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _cidadeRepository = cidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PessoaDto> Handle(AlteracaoPessoaCommand request, CancellationToken cancellationToken)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(request.CidadeId);
        if(cidade == null)
            throw new NotFoundCommandException("A cidade não foi encontrada", $"Nehum registro foi retornado para o identificador {request.CidadeId}");
            
        var pessoa = await _pessoaRepository.GetByIdAsync(request.PessoaId);
        if(pessoa == null)
            throw new NotFoundCommandException("A pessoa não foi encontrada", $"Nehum registro foi retornado para o identificador {request.PessoaId}");
            
        pessoa.Update(request.Nome, request.Idade, request.Cpf, cidade);
        await _unitOfWork.CommitAsync();

        return (PessoaDto)pessoa;
    }
}