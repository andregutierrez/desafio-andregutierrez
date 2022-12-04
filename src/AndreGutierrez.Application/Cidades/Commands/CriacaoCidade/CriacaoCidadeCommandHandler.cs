using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Application.Cidades.Commands;

public class CriacaoCidadeCommandHandler: ICommandHandler<CriacaoCidadeCommand, CidadeDto>
{
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriacaoCidadeCommandHandler(ICidadeRepository cidadeRepository, IUnitOfWork unitOfWork)
    {
        _cidadeRepository = cidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CidadeDto> Handle(CriacaoCidadeCommand request, CancellationToken cancellationToken)
    {
        var cidade = Cidade.Create(request.Nome, request.Uf);
        await _cidadeRepository.CreateAsync(cidade);
        await _unitOfWork.CommitAsync();
        
        return (CidadeDto)cidade;
    }
}