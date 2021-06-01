using BLL.DTO;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using System.Collections.Generic;

namespace BLL.Bussiness
{
    public class AutorBLL : IAutorBLL
    {
        private readonly IAutorRepository _autorRepository;

        public AutorBLL(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public ValidationResultDTO Add(Autor autor)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = _autorRepository.Add(autor);
                validation.AffectedLines = 1;
            }
            
            return validation;
        }

        public ValidationResultDTO Update(Autor autor)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = autor.AutorId;
                validation.AffectedLines = _autorRepository.Update(autor);
            }
            return validation;
        }

        public int Remove(int autorId)
        {
            return _autorRepository.Remove(autorId);
        }

        public List<AutorDTO> GetAll()
        {
            return _autorRepository.GetAll();
        }

        public Autor GetById(int autorId)
        {
            return _autorRepository.GetById(autorId);
        }        
    }
}
