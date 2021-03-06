﻿using Salao.Domain.Interface;
using System.Collections.Generic;

namespace Salao.Domain.Model
{
    public class Endereco : IBaseEntity
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
