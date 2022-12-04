using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;
using AndreGutierrez.Domain.Pessoas.Rules;

namespace AndreGutierrez.Domain.Pessoas
{
    public class Pessoa : Entity
    {
        public int? Id { get; protected set; }
        public string Nome { get; set; } = "";
        public int Idade { get; set; }
        public CPF Cpf { get; set; } = null!;
        public virtual Cidade Cidade { get; set; } = null!;

        protected Pessoa() { }

        private Pessoa(string nome, int idade, CPF cpf, Cidade cidade)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Cidade = cidade;
        }

        public static Pessoa Create (string nome, int idade, string numeroCpf, Cidade cidade)
        {
            CheckRule(new NomeValidoRule(nome));
            CheckRule(new CpfValidoRule(numeroCpf));
            CheckRule(new CidadeValidaRule(cidade));

            return new Pessoa(nome, idade, new CPF(numeroCpf), cidade);;
        }

        public void Update (string nome, int idade, string numeroCpf, Cidade cidade)
        {
            CheckRule(new NomeValidoRule(nome));
            CheckRule(new CpfValidoRule(numeroCpf));
            CheckRule(new CidadeValidaRule(cidade));

            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = new CPF(numeroCpf);
            this.Cidade = cidade;
        }
    }
}