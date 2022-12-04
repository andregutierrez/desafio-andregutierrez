using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Queries;

namespace AndreGutierrez.Application.UFs.Queries;

public class ObterCidadeQuery : IQuery<CidadeDto>
{
    public int CidadeId { get; private set; }

    public ObterCidadeQuery(int cidadeId)
    {
        CidadeId = cidadeId;
    }
}
