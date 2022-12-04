using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AndreGutierrez.Infra.Data;

public class DesafioContextFactory : IDesignTimeDbContextFactory<DesafioContext>
{
    public DesafioContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DesafioContext>();
        optionsBuilder.UseSqlServer("Server=tcp:flt-sqlserver.database.windows.net,1433;Initial Catalog=flt-database;Persist Security Info=False;User ID=fltadmin;Password=!R@m0n3s#$#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        return new DesafioContext(optionsBuilder.Options);
    }
}