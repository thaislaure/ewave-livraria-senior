using System.ComponentModel;

namespace BLL.DTO
{
    public class InstituicaoDTO
    {
        [DisplayName("Código")]
        public int InstituicaoId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Endereco")]
        public string Endereco { get; set; }

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
