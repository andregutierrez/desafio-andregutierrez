using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Domain.Cidades.Rules;

public class UfValidoRule : IBusinessRule
{
    public string Message => "Um UF válido deve ser informado";
    private string _uf;

    public UfValidoRule(string uf)
    {
        _uf = uf;
    }

    public bool IsBroken() => !ValidaDados();

    private bool ValidaDados()
    {
        if(_uf.Length == 2)
            return true;
        else
            return false;
    }
}