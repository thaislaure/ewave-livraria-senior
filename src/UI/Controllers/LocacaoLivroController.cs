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
    public class LocacaoLivroController : ControllerBase
    {
        private readonly ILocacaoLivroBLL _locacaoLivroBLL;

        public LocacaoLivroController(ILocacaoLivroBLL locacaoLivroBLL)
        {
            _locacaoLivroBLL = locacaoLivroBLL;
        }

        // GET: Model
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_locacaoLivroBLL.GetAll());
        }

        // GET: Model/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var locacaoLivro = _locacaoLivroBLL.GetById(id);

            var locacaoLivroViewModel = new LocacaoLivroViewModel
            {
                LocacaoId = locacaoLivro.LocacaoId,
                DataEntrega = locacaoLivro.DataEntrega,
                DataLocacao = locacaoLivro.DataLocacao,
                DataDevolucao = locacaoLivro.DataDevolucao,
                LivroId = locacaoLivro.LivroId,
                UsuarioId = locacaoLivro.UsuarioId
            };

            if (locacaoLivroViewModel == null)
            {
                return NotFound();
            }

            return Ok(locacaoLivroViewModel);
        }

        // POST: LivroViewModels/Create        
        [HttpPost]
        public IActionResult Create(LocacaoLivroViewModel locacaoLivroViewModel)
        {
            ModelState.Remove(nameof(LocacaoLivroViewModel.DataDevolucao));

            if (ModelState.IsValid)
            {

                var locacaoLivro = new LocacaoLivro(locacaoLivroViewModel.DataLocacao,
                                                    locacaoLivroViewModel.DataEntrega,
                                                    locacaoLivroViewModel.UsuarioId,
                                                    locacaoLivroViewModel.LivroId);

                try
                {
                    var result = _locacaoLivroBLL.Add(locacaoLivro);
                    if (result.Success)
                        return Ok(locacaoLivro);
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

        // POST: Model/Edit/5        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit([FromRoute] int id, LocacaoLivroViewModel locacaoLivroViewModel)
        {
            if (ModelState.IsValid)
            {
                var locacaoLivro = new LocacaoLivro(id,
                                                    locacaoLivroViewModel.DataLocacao,
                                                    locacaoLivroViewModel.DataEntrega,
                                                    locacaoLivroViewModel.UsuarioId,
                                                    locacaoLivroViewModel.LivroId);

                try
                {
                    var result = _locacaoLivroBLL.Update(locacaoLivro);
                    if (result.Success)
                        return Ok(locacaoLivro);
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


        // POST: Model/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _locacaoLivroBLL.Remove(id);
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

        [HttpPatch("{id}/devolver")]
        public IActionResult Devolver(int id)
        {
            try
            {
                var result = _locacaoLivroBLL.Devolver(id);
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
