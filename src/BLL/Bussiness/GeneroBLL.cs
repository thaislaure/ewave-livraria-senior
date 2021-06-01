using BLL.DTO;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using System.Collections.Generic;

namespace BLL.Bussiness
{
    public class GeneroBLL : IGeneroBLL
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroBLL(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public ValidationResultDTO Add(Genero genero)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = _generoRepository.Add(genero);
                validation.AffectedLines = 1;
            }
            
            return validation;
        }

        public ValidationResultDTO Update(Genero genero)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = genero.GeneroId;
                validation.AffectedLines = _generoRepository.Update(genero);
            }
            return validation;
        }

        public int Remove(int generoId)
        {
            return _generoRepository.Remove(generoId);
        }

        public List<GeneroDTO> GetAll()
        {
            return _generoRepository.GetAll();
        }

        public Genero GetById(int generorId)
        {
            return _generoRepository.GetById(generorId);
        }        
    }
}
