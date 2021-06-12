using System;
using System.Collections.Generic;
using System.Text;
using SistemaOficinas.Domain.Entities;
using SistemaOficinas.Domain.Enums;

namespace SistemaOficinas.Domain.Models
{
    public class Cliente : EntityBase
    {
        public Cliente()
        {
            this.DataCadastro = DateTime.Now;
            this.Situacao = Situacao.Ativa;
        }

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Situacao Situacao { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CNPJ { get; set; }
        public Sexo Sexo { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        //telefoneresidencial,celular,,insc,rg,email
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Observacoes { get; set; }
    }
}
