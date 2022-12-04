
using AndreGutierrez.Domain.Estados;

namespace AndreGutierrez.Application.UFs.Dtos;

public class EstadoDto
{
    public string Uf { get; set; } = "";
    public string Nome { get; set; } = "";

    public EstadoDto(string uf, string nome)
    {
        Uf = uf;
        Nome = nome;
    }

    public static explicit operator EstadoDto(Estado estado) => new EstadoDto(
        estado?.Uf ?? "",
        estado?.Nome ?? ""
    );
}
