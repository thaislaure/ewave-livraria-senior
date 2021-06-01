using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public int InstituicaoId { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public bool Bloqueado { get; set; }

        public string Senha { get; set; }

    }
}
