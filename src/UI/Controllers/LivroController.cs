using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.Extension;
using UI.Models;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LivroController : ControllerBase
    {
        private readonly ILivroBLL _livroBLL;

        public LivroController(ILivroBLL livroBLL)
        {
            _livroBLL = livroBLL;
        }

        // GET: LivroViewModels
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_livroBLL.GetAll());
        }

        // GET: LivroViewModels/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _livroBLL.GetById(id);

            var livroViewModel = new LivroViewModel
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                GeneroId = livro.GeneroId,
                AutorId = livro.AutorId,
                Sinopse = livro.Sinopse,
                UrlCapa = livro.UrlCapa,
                Ativo = livro.Ativo
            };

            if (livroViewModel == null)
            {
                return NotFound();
            }
                
            return Ok(livroViewModel);
        }

        //// POST: LivroViewModels/Create        
        [HttpPost]
        public IActionResult Create(LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {

                var livro = new Livro(livroViewModel.Titulo,
                                      livroViewModel.GeneroId,
                                      livroViewModel.AutorId,
                                      livroViewModel.Sinopse,
                                      livroViewModel.UrlCapa);

                    try
                    {
                    var result = _livroBLL.Add(livro);
                    if (result.Success)
                        return Ok(livroViewModel);
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
        public IActionResult Edit([FromRoute] int id, LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {

                var livro = new Livro(id,
                                      livroViewModel.Titulo,
                                      livroViewModel.GeneroId,
                                      livroViewModel.AutorId,
                                      livroViewModel.Sinopse,
                                      livroViewModel.UrlCapa
                                      );

                try
                {
                    var result = _livroBLL.Update(livro);
                    if (result.Success)
                        return Ok(livroViewModel);
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
                var result = _livroBLL.Remove(id);
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

        [HttpPatch("{id}/{ativo}/InativarOuAtivar")]
        public IActionResult InativarOuAtivar(int id, bool ativo)
        {
            try
            {
                var result = _livroBLL.InativarOuAtivar(id, ativo);
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
