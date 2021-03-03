using Microsoft.EntityFrameworkCore;
using Salao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Data.Context
{
    public class SalaoContext : DbContext
    {
        public SalaoContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioServico> FuncionariosServicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
