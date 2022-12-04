using AndreGutierrez.Domain.Cidades;

namespace AndreGutierrez.Application.Cidades.Dtos;

public class CidadeDto
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Uf { get; set; }

    public CidadeDto(int? id, string nome, string uf)
    {
        Id = id;
        Nome = nome;
        Uf = uf;
    }

    public static explicit operator CidadeDto(Cidade Cidade) => new CidadeDto(
        Cidade?.Id,
        Cidade?.Nome ?? "",
        Cidade?.Uf ?? ""
    );
}