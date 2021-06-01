using System;

namespace BLL.Models
{
    public class Instituicao : ValidationModelResult
    {
        public Instituicao(int instituicaoId, string nome, string endereco, string cNPJ, string telefone)
        {
            InstituicaoId = instituicaoId;
            Nome = nome;
            Endereco = endereco;
            CNPJ = cNPJ;
            Telefone = telefone;
        }

        public Instituicao(string nome, string endereco, string cNPJ, string telefone, bool ativo)
        {
            Nome = nome;
            Endereco = endereco;
            CNPJ = cNPJ;
            Telefone = telefone;
            Ativo = ativo;
        }

        public Instituicao(int instituicaoId, string nome, string endereco, string cNPJ, string telefone, bool ativo)
        {
            InstituicaoId = instituicaoId;
            Nome = nome;
            Endereco = endereco;
            CNPJ = cNPJ;
            Telefone = telefone;
            Ativo = ativo;
        }

        public int InstituicaoId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string CNPJ { get; private set; }
        public string Telefone { get; private set; }

        public bool Ativo { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
