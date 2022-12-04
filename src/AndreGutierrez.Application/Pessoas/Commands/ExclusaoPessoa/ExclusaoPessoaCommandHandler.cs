using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Domain.Pessoas;
using AndreGutierrez.Domain.Common;
using AndreGutierrez.Application.Common.Validation;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class ExclusaoPessoaCommandHandler: ICommandHandler<ExclusaoPessoaCommand, PessoaDto>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExclusaoPessoaCommandHandler(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PessoaDto> Handle(ExclusaoPessoaCommand request, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaRepository.GetByIdAsync(request.PessoaId);
        if(pessoa == null)
            throw new NotFoundCommandException("A pessoa não foi encontrada", $"Nehum registro foi retornado para o identificador {request.PessoaId}");
            
        _pessoaRepository.Delete(pessoa);
        
        await _unitOfWork.CommitAsync();
        
        return (PessoaDto)pessoa;
    }
}