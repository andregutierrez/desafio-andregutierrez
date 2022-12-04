using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;

namespace AndreGutierrez.Application.Cidades.Commands;

public class AlteracaoCidadeCommand : CommandBase<CidadeDto>
{
    public int CidadeId { get; set; }
    public string Nome { get; private set; }
    public string Uf { get; private set; }

    public AlteracaoCidadeCommand(string nome, string uf)
    {
        Nome = nome;
        Uf = uf;
    }

    public static explicit operator AlteracaoCidadeCommand(AlteracaoCidadeRequest request) => new AlteracaoCidadeCommand(
        request?.Nome ?? "",
        request?.Uf ?? ""
    );
}