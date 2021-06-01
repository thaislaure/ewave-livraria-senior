using System.ComponentModel;

namespace BLL.DTO
{
    public class LivroDTO 
    {
        [DisplayName("Código")]
        public int LivroId { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Gênero")]
        public string NomeGenero { get; set; }

        [DisplayName("Autor")]
        public string NomeAutor { get; set; }

        public string Sinopse { get; set; }

        public string UrlCapa { get; set; }

        public bool Ativo { get; set; }

        public string GeneroId { get; set; }
        public string AutorId { get; set; }
    }
}
