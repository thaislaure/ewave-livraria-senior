using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface ILocacaoLivroBLL
    {
        public ValidationResultDTO Add(LocacaoLivro locacaolivro);

        public ValidationResultDTO Update(LocacaoLivro locacaolivro);
        public int Remove(int livroId);

        public List<LocacaoLivroDTO> GetAll(string pesquisa = "");

        public LocacaoLivroDTO GetLocaoDTOById(int locacaoId);

        public LocacaoLivro GetById(int locacaoId);

        public bool CheckQuantidadeDiasLivroEmprestimo(int livroId, int usuarioId);

        public int RetornaQuantidadeLivroEmprestimo(int usuarioId);

        int Devolver(int locacaoId);
    }
}
