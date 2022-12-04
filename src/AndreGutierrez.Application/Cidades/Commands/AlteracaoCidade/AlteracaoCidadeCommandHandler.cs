using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Application.Cidades.Commands;

public class AlteracaoCidadeCommandHandler: ICommandHandler<AlteracaoCidadeCommand, CidadeDto>
{
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AlteracaoCidadeCommandHandler(ICidadeRepository cidadeRepository, IUnitOfWork unitOfWork)
    {
        _cidadeRepository = cidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CidadeDto> Handle(AlteracaoCidadeCommand request, CancellationToken cancellationToken)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(request.CidadeId);
        if(cidade == null)
            throw new NotFoundCommandException("A cidade não foi encontrada", $"Nehum registro foi retornado para o identificador {request.CidadeId}");
            
        cidade.Update(request.Nome, request.Uf);
        await _unitOfWork.CommitAsync();

        return (CidadeDto)cidade;
    }
}