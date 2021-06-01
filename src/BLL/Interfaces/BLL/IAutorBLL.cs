using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface IAutorBLL
    {
        ValidationResultDTO Add(Autor livro);
        ValidationResultDTO Update(Autor livro);
        int Remove(int autorId);
        List<AutorDTO> GetAll();
        Autor GetById(int autorId);
    }
}
