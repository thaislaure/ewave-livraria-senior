using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface ILivroBLL
    {
        ValidationResultDTO Add(Livro livro);        
        ValidationResultDTO Update(Livro livro);
        int Remove(int livroId);
        List<LivroDTO> GetAll(string pesquisa = "");
        Livro GetById(int livroId);
        int InativarOuAtivar(int livroId, bool ativo);

    }
}
