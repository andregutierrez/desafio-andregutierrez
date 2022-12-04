using MediatR;

namespace AndreGutierrez.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}