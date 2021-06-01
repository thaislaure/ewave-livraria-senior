using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IAutorRepository : IRepositoryBase, IDisposable
    {
        int Add(Autor autor);
        int Update(Autor autorId);
        int Remove(int autorId);
        List<AutorDTO> GetAll();
        Autor GetById(int autorId);
    }
}
