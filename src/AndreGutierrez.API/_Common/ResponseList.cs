using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Domain.Common;

namespace AndreGutierrez.API.Common
{
    public class ResponseList<T> : ResponseBase
    {
        public T[]? List { get; private set; }

        public ResponseList(T[] list)
        {
            List = list;
        }

        public ResponseList(IEnumerable<T> list)
        {
            List = list.ToArray();
        }

        public ResponseList(Exception error) : base(error)
        {
        }

        public ResponseList(BusinessValidationException error) : base(error)
        {
        }

        public ResponseList(NotFoundCommandException error) : base(error)
        {
        }
    }
}