using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.API.Common
{
    public class ResponseBase
    {
        public bool Success { get; set; } = true;

        public object? Error { get; private set; } = null;

        public ResponseBase()
        {
        }

        public ResponseBase(Exception error)
        {
            Error = new { Message = error.Message };
            Success = false;
        }

        public ResponseBase(BusinessValidationException error)
        {
            Error = new { Message = error.Message, Details = error.Details };
            Success = false;
        }

        public ResponseBase(InvalidCommandException error)
        {
            Error = new { Message = error.Message, Details = error.Details };
            Success = false;
        }

        public ResponseBase(NotFoundCommandException error)
        {
            Error = new { Message = error.Message, Details = error.Details };
            Success = false;
        }
    }
}