using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao.Domain.Model;

namespace Salao.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.CEP)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.UF)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Complemento)
                .HasColumnType("varchar(150)");
        }

    }
}
