using AndreGutierrez.Domain.Common;
using AndreGutierrez.Infra.Data;

namespace FLT.Core.Infra.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioContext _dbContext;

        public UnitOfWork(DesafioContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}