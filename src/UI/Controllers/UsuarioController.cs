using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.Models;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;

        public UsuarioController(IUsuarioBLL usuarioBLL)
        {
            _usuarioBLL = usuarioBLL;
        }

        // GET: LivroViewModels
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usuarioBLL.GetAll());
        }

        // GET: LivroViewModels/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioBLL.GetById(id);

            var usuarioViewModel = new UsuarioViewModel
            {
                Nome = usuario.Nome,
                Endereco = usuario.Endereco,
                CPF = usuario.CPF,
                InstituicaoId = usuario.InstituicaoId,
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                Bloqueado = usuario.Bloqueado,
                Senha = usuario.Senha

            };

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return Ok(usuarioViewModel);
        }

        // POST: LivroViewModels/Create        
        [HttpPost]
        public IActionResult Create(UsuarioViewModel usuarioViewModel)
        {

            if (ModelState.IsValid)
            {

                var usuario = new Usuario(usuarioViewModel.Nome,
                                                    usuarioViewModel.Endereco,
                                                    usuarioViewModel.CPF,
                                                    usuarioViewModel.InstituicaoId,
                                                    usuarioViewModel.Telefone,
                                                    usuarioViewModel.Email,
                                                    usuarioViewModel.Senha,
                                                    true
                                                    );

                try
                {
                    var result = _usuarioBLL.Add(usuario);
                    if (result.Success)
                        return Ok(usuario);
                    else
                        return BadRequest();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        // POST: LivroViewModels/Edit/5        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit([FromRoute] int id, UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario(id,
                                          usuarioViewModel.Nome,
                                          usuarioViewModel.Endereco,
                                          usuarioViewModel.CPF,
                                          usuarioViewModel.InstituicaoId,
                                          usuarioViewModel.Telefone,
                                          usuarioViewModel.Email,
                                          usuarioViewModel.Senha);

                try
                {
                    var result = _usuarioBLL.Update(usuario);
                    if (result.Success)
                        return Ok(usuario);
                    else
                        return BadRequest();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }


        // POST: LivroViewModels/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _usuarioBLL.Remove(id);
                if (result > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: LivroViewModels/Delete/5
        [HttpPatch("{id}/{ativo}/InativarOuAtivar")]
        public IActionResult InativarOuAtivar(int id, bool ativo)
        {
            try
            {
                var result = _usuarioBLL.InativarOuAtivar(id, ativo);
                if (result > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
