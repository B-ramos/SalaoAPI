using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao.Domain.Model;

namespace Salao.Data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>

    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.MinutosParaExecucao)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }

    }
}
