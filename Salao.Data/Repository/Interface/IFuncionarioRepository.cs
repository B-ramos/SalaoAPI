﻿using Salao.Domain.Model;

namespace Salao.Data.Repository.Interface
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        public Funcionario FindByEnderco(int id);
    }
}
