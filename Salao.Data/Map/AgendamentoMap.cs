using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao.Domain.Model;

namespace Salao.Data.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Cliente)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(a => a.ClienteId)
                .IsRequired();

            builder.HasOne(a => a.Servico)
                .WithMany(s => s.Agendamentos)
                .HasForeignKey(a => a.ServicoId)
                .IsRequired();

            builder.Property(x => x.Data)
                .HasColumnType("datetime")
                .IsRequired();


            builder.Property(x => x.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Anotacao)
                .HasColumnType("varchar(500)");
        }
    }
}