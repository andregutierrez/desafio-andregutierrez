using AndreGutierrez.Domain.Cidades;

namespace AndreGutierrez.Domain.Pessoas
{
    public class CPF
    {
        public string Numero {get; set;}

        public CPF(string numero)
        {
            Numero = numero;
        }
    }
}