using System.ComponentModel;

namespace BLL.DTO
{
    public class UsuarioDTO
    {
        [DisplayName("Código")]
        public int UsuarioId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Endereco")]
        public string Endereco { get; set; }

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("InstituicaoId")]
        public int InstituicaoId { get; set; }


        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Bloqueado")]
        public bool Bloqueado { get; set; }

        public string Senha { get; set; }

        public string NomeInstituicao { get; set; }


        public bool Ativo { get; set; }
    }
}
