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

            builder.HasOne(fs => fs.Funcionario)
                .WithMany(f => f.FuncionarioServico)
                .HasForeignKey(fs => fs.FuncionarioId);

            builder.HasOne(fc => fc.Servico)
               .WithMany(c => c.FuncionarioServico)
               .HasForeignKey(fc => fc.FuncionarioId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }

    }
}
