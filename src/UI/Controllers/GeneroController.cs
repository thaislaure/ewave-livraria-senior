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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroBLL _generoBLL;

        public GeneroController(IGeneroBLL generoBLL)
        {
            _generoBLL = generoBLL;
        }

        // GET: model
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_generoBLL.GetAll());
        }

        // GET: model/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _generoBLL.GetById(id);

            var autorViewModel = new AutorViewModel
            {
                AutorId = livro.GeneroId,
                Nome = livro.Nome
            };

            if (autorViewModel == null)
            {
                return NotFound();
            }
                
            return Ok(autorViewModel);
        }

        //// POST: model/Create        
        [HttpPost]
        public IActionResult Create(GeneroViewModel generoViewModel)
        {
            if (ModelState.IsValid)
            {

                var genero = new Genero(generoViewModel.Nome);

                    try
                    {
                    var result = _generoBLL.Add(genero);
                    if (result.Success)
                        return Ok(generoViewModel);
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


        // POST: model/Edit/5 
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit([FromRoute] int id, GeneroViewModel generoViewModel)
        {
            if (ModelState.IsValid)
            {

                var genero = new Genero(id,
                                        generoViewModel.Nome);

                try
                {
                    var result = _generoBLL.Update(genero);
                    if (result.Success)
                        return Ok(generoViewModel);
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

        // POST: model/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _generoBLL.Remove(id);
                if (result > 0)
                  return Ok(true);
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
