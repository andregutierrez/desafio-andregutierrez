using AndreGutierrez.Domain.Cidades.Rules;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Domain.Cidades
{
    public class Cidade: Entity
    {
        public int? Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Uf { get; protected set; }

        public Cidade(string nome, string uf)
        {
            Nome = nome;
            Uf = uf;
        }

        public static Cidade Create(string nome, string uf)
        {
            CheckRule(new NomeValidoRule(nome));
            CheckRule(new UfValidoRule(uf));

            return new Cidade(nome, uf);
        }

        public void Update(string nome, string uf)
        {
            CheckRule(new NomeValidoRule(nome));
            CheckRule(new UfValidoRule(uf));

            this.Nome = nome;
            this.Uf = uf;
        }
    }
}