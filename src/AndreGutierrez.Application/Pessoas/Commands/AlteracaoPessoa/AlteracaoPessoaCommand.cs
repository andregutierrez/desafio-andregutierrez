using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Common.Commands;

namespace AndreGutierrez.Application.Pessoas.Commands;

public class AlteracaoPessoaCommand : CommandBase<PessoaDto>
{
    public int PessoaId { get; set; }
    public string Nome { get; private set; }
    public int Idade { get; private set; }
    public string Cpf { get; private set; }
    public int CidadeId { get; private set; }
 
    public AlteracaoPessoaCommand(string nome, int idade, string cpf, int cidadeId)
    {
        Nome = nome;
        Idade = idade;
        Cpf = cpf;
        CidadeId = cidadeId;
    }

    public static explicit operator AlteracaoPessoaCommand(AlteracaoPessoaRequest request) => new AlteracaoPessoaCommand(
        request.Nome,
        request.Idade,
        request.Cpf,
        request.CidadeId
    );
}