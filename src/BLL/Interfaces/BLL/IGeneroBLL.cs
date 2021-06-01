using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface IGeneroBLL
    {
        ValidationResultDTO Add(Genero genero);
        ValidationResultDTO Update(Genero genero);
        int Remove(int generoId);
        List<GeneroDTO> GetAll();
        Genero GetById(int generoId);
    }
}
