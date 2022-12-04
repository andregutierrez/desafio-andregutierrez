using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Commands;
using AndreGutierrez.Application.Pessoas.Dtos;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class CriacaoPessoaCommand : CommandBase<PessoaDto>
{
    public string Nome { get; private set; }
    public int Idade { get; private set; }
    public string Cpf { get; private set; }
    public int CidadeId { get; private set; }

    public CriacaoPessoaCommand(string nome, int idade, string cpf, int cidadeId)
    {
        Nome = nome;
        Idade = idade;
        Cpf = cpf;
        CidadeId = cidadeId;
    }

    public static explicit operator CriacaoPessoaCommand(CriacaoPessoaRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return new CriacaoPessoaCommand(
            request.Nome ?? "",
            request.Idade, 
            request.Cpf,
            request.CidadeId
        );
    }
}