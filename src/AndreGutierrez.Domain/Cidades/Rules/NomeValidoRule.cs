using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Domain.Cidades.Rules;

public class NomeValidoRule : IBusinessRule
{
    public string Message => "Um Nome válido deve ser informado";
    private string _nome;

    public NomeValidoRule(string nome)
    {
        _nome = nome;
    }

    public bool IsBroken() => !ValidaDados();

    private bool ValidaDados()
    {
        if(String.IsNullOrWhiteSpace(_nome))
            return false;
        else if(_nome.Length < 3)
            return false;
        else
            return true;
    }
}