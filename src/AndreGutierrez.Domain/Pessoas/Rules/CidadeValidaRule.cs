using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.Domain.Pessoas.Rules;

public class CidadeValidaRule : IBusinessRule
{
    public string Message => "Uma cidade válida deve ser informada";
    private Cidade _cidade;

    public CidadeValidaRule(Cidade cidade)
    {
        _cidade = cidade;
    }

    public bool IsBroken() => !ValidaDados();

    private bool ValidaDados()
    {
        if(_cidade.Id == null)
            return false;
        else
            return true;
    }
}