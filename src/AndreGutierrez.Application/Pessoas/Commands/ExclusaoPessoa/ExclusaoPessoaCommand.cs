using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Common.Commands;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class ExclusaoPessoaCommand : CommandBase<PessoaDto>
{
    public int PessoaId { get; private set; }

    public ExclusaoPessoaCommand(int pessoaId)
    {
        PessoaId = pessoaId;
    }

    public static explicit operator ExclusaoPessoaCommand(ExclusaoPessoaRequest request) => new ExclusaoPessoaCommand(
        request.PessoaId
    );
}