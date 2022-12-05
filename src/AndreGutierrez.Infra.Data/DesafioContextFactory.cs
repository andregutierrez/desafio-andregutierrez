using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AndreGutierrez.Infra.Data;

public class DesafioContextFactory : IDesignTimeDbContextFactory<DesafioContext>
{
    public DesafioContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DesafioContext>();
        optionsBuilder.UseSqlServer("");
        return new DesafioContext(optionsBuilder.Options);
    }
}