
namespace AndreGutierrez.Application.Pessoas.Commands;

public class CriacaoPessoaRequest
{
    public string Nome { get; set; } = "";
    public int Idade { get; set; }
    public string Cpf { get; set; } = "";
    public int CidadeId { get; set; }
}