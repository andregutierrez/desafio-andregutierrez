using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;

namespace AndreGutierrez.Application.Cidades.Commands;

public class ExclusaoCidadeCommand : CommandBase<CidadeDto>
{
    public int CidadeId { get; private set; }

    public ExclusaoCidadeCommand(int cidadeId)
    {
        CidadeId = cidadeId;
    }

    public static explicit operator ExclusaoCidadeCommand(ExclusaoCidadeRequest request) => new ExclusaoCidadeCommand(
        request.CidadeId
    );
}