using System;

namespace BLL.Models
{
    public class LocacaoLivro : ValidationModelResult
    {
        public int LocacaoId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime? DataLiberacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public bool Devolvido { get; set; }

        public LocacaoLivro()
        { }

        public LocacaoLivro(int locacaoId, DateTime dataLocacao, DateTime dataEntrega, int usuarioId, int livroId)
        {
            LocacaoId = locacaoId;
            DataLocacao = dataLocacao;
            DataEntrega = dataEntrega;
            UsuarioId = usuarioId;
            LivroId = livroId;
        }

        public LocacaoLivro(DateTime dataLocacao, DateTime dataEntrega, int usuarioId, int livroId)
        {
            DataLocacao = dataLocacao;
            DataEntrega = dataEntrega;
            UsuarioId = usuarioId;
            LivroId = livroId;

        }

        public void SetarDataLiberacao(DateTime dataLiberacao)
        {
            DataLiberacao = dataLiberacao;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
