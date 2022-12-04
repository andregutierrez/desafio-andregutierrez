
namespace AndreGutierrez.Domain.Common;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}