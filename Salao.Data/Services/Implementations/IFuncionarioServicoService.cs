using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salao.Data.Services.Implementations
{
    public class FuncionarioServicoService : IFuncionarioServicoService
    {
        private readonly IFuncionarioServicoRepository _repoFuncionarioServico;
        private readonly IFuncionarioRepository _repoFuncionario;
        private readonly IServicoRepository _repoServico;

        public FuncionarioServicoService(IFuncionarioServicoRepository repoFuncionarioServcio,
                                         IFuncionarioRepository repoFuncionario, 
                                         IServicoRepository repoServico)
        {
            _repoFuncionarioServico = repoFuncionarioServcio;            
            _repoFuncionario = repoFuncionario;            
            _repoServico = repoServico;
        }

        public List<FuncionarioServico> FindAll()
        {
            return _repoFuncionarioServico.FindAll();
        }

        public List<FuncionarioServico> FindByIdServico(int id)
        {
            var servicos = _repoFuncionarioServico.FindByIdServico(id);
            if (servicos.Count < 1)
                return null;

            return servicos;
        }

        public List<FuncionarioServico> FindByIdFuncionario(int id)
        {
            var funcionarios = _repoFuncionarioServico.FindByIdFuncionario(id);
            if (funcionarios.Count < 1)
                return null;

            return funcionarios;
        }

        public FuncionarioServico Create(FuncionarioServico funcionarioServico)
        {
            var funcionario = _repoFuncionario.FindById(funcionarioServico.FuncionarioId);
            var servico = _repoServico.FindById(funcionarioServico.ServicoId);

            if (funcionario == null || servico == null)
                return null;

            var f = funcionario.FuncionarioServico.Find(fs => fs.ServicoId == funcionarioServico.ServicoId);
            if (f != null)
                return null;
            
            return _repoFuncionarioServico.Create(funcionarioServico);
        }
               

        public bool Delete(int funcionarioId, int servicoId)
        {
            var funcionarioServico = _repoFuncionarioServico.FindByIdFuncionarioServico(funcionarioId, servicoId);

            if (funcionarioServico == null)
                return false;

            _repoFuncionarioServico.Delete(funcionarioServico);
            return true;
        }

        
    }
}
