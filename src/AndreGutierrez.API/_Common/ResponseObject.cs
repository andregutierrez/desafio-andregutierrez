using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.API.Common
{
    public class ResponseObject<T> : ResponseBase
    {
        public T? Value { get; private set; } = default(T);

        public ResponseObject(T? value)
        {
            Value = value;
        }

        public ResponseObject(Exception error) : base(error)
        {
            
        }

        public ResponseObject(BusinessValidationException error) : base(error)
        {
        }

        public ResponseObject(NotFoundCommandException error) : base(error)
        {
        }
    }
}