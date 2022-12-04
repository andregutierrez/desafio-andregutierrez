namespace AndreGutierrez.Domain.Estados;

public class Estado
{
    public string Uf { get; protected set; }
    public string Nome { get; protected set; }

    public Estado(string uf, string nome)
    {
        Uf = uf;
        Nome = nome;
    }

    public static Estado Create(string uf, string nome)
    {
        return new Estado(uf, nome);
    }
}
