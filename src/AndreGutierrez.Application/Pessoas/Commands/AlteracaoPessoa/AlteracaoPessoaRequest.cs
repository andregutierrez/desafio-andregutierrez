
namespace AndreGutierrez.Application.Pessoas.Commands;

public class AlteracaoPessoaRequest
{
    public string Nome { get; set; } = "";
    public int Idade { get; set; }
    public string Cpf { get; set; } = "";
    public int CidadeId { get; set; }
}