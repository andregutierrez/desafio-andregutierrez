namespace AndreGutierrez.Domain.Common;

public abstract class Entity
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessValidationException(rule);
        }
    }
}