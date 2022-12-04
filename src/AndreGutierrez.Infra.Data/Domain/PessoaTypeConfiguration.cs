using AndreGutierrez.Domain.Cidades;
using AndreGutierrez.Domain.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleProject.Infrastructure.Domain.Customers
{
    internal sealed class PessoaTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa", "dbo");
            builder.HasKey(o => o.Id);
            
            builder.Property(o => o.Id)
                .UseIdentityColumn();
            
            builder.Property(o => o.Nome)
                .IsRequired();
            
            builder.OwnsOne(x => x.Cpf)
                .Property(x => x.Numero)
                .HasColumnName("Cpf")
                .IsRequired(true);
            
            builder.HasOne(o => o.Cidade)
                .WithMany()
                .IsRequired();

        }
    }
}