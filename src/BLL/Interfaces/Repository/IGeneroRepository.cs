using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IGeneroRepository : IRepositoryBase
    {
        int Add(Genero genero);
        int Update(Genero generoId);
        int Remove(int generoId);
        List<GeneroDTO> GetAll();
        Genero GetById(int generoId);

    }
}
