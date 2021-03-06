using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao.Domain.Model;

namespace Salao.Data.Map
{
    public class FuncionarioServicoMap : IEntityTypeConfiguration<FuncionarioServico>
    {
        public void Configure(EntityTypeBuilder<FuncionarioServico> builder)
        {
            builder.ToTable("FuncionariosServicos");

            builder.HasKey(fc => new { fc.FuncionarioId, fc.ServicoId });

            builder.HasOne(f => f.Funcionario)
                .WithMany(fs => fs.FuncionarioServico)
                .HasForeignKey(f => f.FuncionarioId);

            builder.HasOne(s => s.Servico)
               .WithMany(fs => fs.FuncionarioServico)
               .HasForeignKey(s => s.ServicoId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }

    }
}
