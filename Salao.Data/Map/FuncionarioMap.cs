using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao.Domain.Model;

namespace Salao.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(f => f.Endereco)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.EnderecoId);
        }

    }
}
