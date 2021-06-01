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
    public class AutorController : ControllerBase
    {
        private readonly IAutorBLL _autorBLL;

        public AutorController(IAutorBLL autorBLL)
        {
            _autorBLL = autorBLL;
        }

        // GET: model
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_autorBLL.GetAll());
        }

        // GET: model/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _autorBLL.GetById(id);

            var autorViewModel = new AutorViewModel
            {
                AutorId = livro.AutorId,
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
        public IActionResult Create(AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {

                var autor = new Autor(autorViewModel.Nome);

                try
                {
                    var result = _autorBLL.Add(autor);
                    if (result.Success)
                        return Ok(autorViewModel);
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
        public IActionResult Edit([FromRoute] int id, AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {

                var autor = new Autor(id,
                                      autorViewModel.Nome);

                try
                {
                    var result = _autorBLL.Update(autor);
                    if (result.Success)
                        return Ok(autorViewModel);
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
                var result = _autorBLL.Remove(id);
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
