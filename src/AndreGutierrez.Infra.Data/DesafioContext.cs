using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreGutierrez.Infra.Data;

/// <summary>
/// Referência de artigo para conseguir criar modelos de configuração
/// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
/// Rererência de artigo para conseguir criar migration a partir de dominios
/// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
/// </summary>
public class DesafioContext : DbContext
{
    public DbSet<Cidade> Cidade { get; set; } = null!;
    public DbSet<Pessoa> Pessoa { get; set; } = null!;

    public DesafioContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioContext).Assembly);
        }
}