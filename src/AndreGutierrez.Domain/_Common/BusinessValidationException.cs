namespace AndreGutierrez.Domain.Common;

public class BusinessValidationException : Exception
{
    public IBusinessRule BrokenRule { get; }

    public string Details { get; }

    public BusinessValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        this.Details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}