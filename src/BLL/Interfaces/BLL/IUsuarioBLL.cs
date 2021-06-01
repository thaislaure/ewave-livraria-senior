using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface IUsuarioBLL
    {
        ValidationResultDTO Add(Usuario usuario);
        ValidationResultDTO Update(Usuario usuario);
        int Remove(int usuarioId);
        List<UsuarioDTO> GetAll(string pesquisa = "");
        Usuario GetById(int usuarioId);

        int InativarOuAtivar(int usuarioId, bool ativo);
    }
}
