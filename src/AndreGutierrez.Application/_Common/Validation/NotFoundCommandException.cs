using System;

namespace AndreGutierrez.Application.Common.Validation
{
    public class NotFoundCommandException : Exception
    {
        public string Details { get; }
        
        public NotFoundCommandException(string message, string details) : base(message)
        {
            this.Details = details;
        }
    }
}