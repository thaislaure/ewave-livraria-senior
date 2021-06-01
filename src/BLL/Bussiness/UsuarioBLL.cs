using BLL.DTO;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using System.Collections.Generic;

namespace BLL.Bussiness
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBLL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ValidationResultDTO Add(Usuario usuario)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = _usuarioRepository.Add(usuario);
                validation.AffectedLines = 1;
            }
            
            return validation;
        }

        public ValidationResultDTO Update(Usuario genero)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = genero.UsuarioId;
                validation.AffectedLines = _usuarioRepository.Update(genero);
            }
            return validation;
        }

        public int Remove(int usuarioId)
        {
            return _usuarioRepository.Remove(usuarioId);
        }

        public List<UsuarioDTO> GetAll(string pesquisa = "")
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(int usuarioId)
        {
            return _usuarioRepository.GetById(usuarioId);
        }

        public int InativarOuAtivar(int usuarioId, bool ativo)
        {
            return _usuarioRepository.InativarOuAtivar(usuarioId, ativo);
        }
    }
}
