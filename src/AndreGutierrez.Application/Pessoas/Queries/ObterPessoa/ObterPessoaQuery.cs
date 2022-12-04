using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Queries;

namespace AndreGutierrez.Application.Pessoas.Queries;

public class ObterPessoaQuery : IQuery<PessoaDto>
{
    public int PessoaId { get; private set; }

    public ObterPessoaQuery(int pessoaId)
    {
        PessoaId = pessoaId;
    }
}
