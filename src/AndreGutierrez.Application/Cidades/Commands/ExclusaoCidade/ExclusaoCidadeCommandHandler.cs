using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AndreGutierrez.Application.Cidades.Commands;

public class ExclusaoCidadeCommandHandler: ICommandHandler<ExclusaoCidadeCommand, CidadeDto>
{
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExclusaoCidadeCommandHandler(ICidadeRepository cidadeRepository, IUnitOfWork unitOfWork)
    {
        _cidadeRepository = cidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CidadeDto> Handle(ExclusaoCidadeCommand request, CancellationToken cancellationToken)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(request.CidadeId);
        if(cidade == null)
            throw new NotFoundCommandException("A cidade não foi encontrada", $"Nehum registro foi retornado para o identificador {request.CidadeId}");
            
        _cidadeRepository.Delete(cidade);


        try
        {
            await _unitOfWork.CommitAsync();
        }
        catch(DbUpdateException)
        {
            throw new InvalidCommandException("A cidade não foi excluída", $"Possívelmente ela está vinculada a uma pessoa, identificador da cidade {request.CidadeId}");
        }
        
        
        return (CidadeDto)cidade;
    }
}