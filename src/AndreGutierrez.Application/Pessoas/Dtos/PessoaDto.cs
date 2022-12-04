using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Pessoas;

namespace AndreGutierrez.Application.Pessoas.Dtos;

public class PessoaDto
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cpf { get; set; }
    
    public CidadeDto Cidade { get; set; }

    public PessoaDto(int? id, string nome, int idade, string cpf, CidadeDto cidade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        Cpf = cpf;
        Cidade = cidade;
    }

    public static explicit operator PessoaDto(Pessoa pessoa)
    {
        if (pessoa is null)
            throw new ArgumentNullException(nameof(pessoa));

        return new PessoaDto(
            pessoa.Id,
            pessoa.Nome ?? "",
            pessoa.Idade, 
            pessoa.Cpf.Numero,
            (CidadeDto)pessoa.Cidade
        );
    }
}