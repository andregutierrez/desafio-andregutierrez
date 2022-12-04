using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;

namespace AndreGutierrez.Application.Cidades.Commands;

public class CriacaoCidadeCommand : CommandBase<CidadeDto>
{
    public string Nome { get; private set; }
    public string Uf { get; private set; }

    public CriacaoCidadeCommand(string nome, string uf)
    {
        Nome = nome;
        Uf = uf;
    }

    public static explicit operator CriacaoCidadeCommand(CriacaoCidadeRequest request) => new CriacaoCidadeCommand(
        request?.Nome ?? "",
        request?.Uf ?? ""
    );
}