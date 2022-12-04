using AndreGutierrez.Domain.Cidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleProject.Infrastructure.Domain.Customers
{
    internal sealed class CidadeTypeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade", "dbo");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(o => o.Nome).IsRequired();
            builder.Property(o => o.Uf).IsRequired();
        }
    }
}