using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class AutorViewModel
    {

        [DisplayName("Código")]
        public int AutorId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O nome deve ter entre 2 e 200 caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }
    }
}
