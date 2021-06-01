using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using UI.Models;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoBLL _instituicaoBLL;

        public InstituicaoController(IInstituicaoBLL instituicaoBLL)
        {
            _instituicaoBLL = instituicaoBLL;
        }

        // GET: Model
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_instituicaoBLL.GetAll());
        }


        // GET: Model/GetById/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var instituicao = _instituicaoBLL.GetById(id);

            var instituicaoViewModel = new InstituicaoViewModel
            {
                InstituicaoId = instituicao.InstituicaoId,
                Nome = instituicao.Nome,
                Endereco = instituicao.Endereco,
                CNPJ = instituicao.CNPJ,
                Telefone = instituicao.Telefone
            };

            if (instituicaoViewModel == null)
            {
                return NotFound();
            }

            return Ok(instituicaoViewModel);
        }

        // POST: Model/Create        
        [HttpPost]
        public IActionResult Create(InstituicaoViewModel instituicaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var instituicao = new Instituicao(instituicaoViewModel.Nome,
                                                  instituicaoViewModel.Endereco,
                                                  instituicaoViewModel.CNPJ,
                                                  instituicaoViewModel.Telefone,
                                                  instituicaoViewModel.Ativo);

                try
                {
                    var result = _instituicaoBLL.Add(instituicao);
                    if (result.Success)
                        return Ok(instituicaoViewModel);
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
        public IActionResult Edit([FromRoute]int id, InstituicaoViewModel instituicaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var instituicao = new Instituicao(id,
                                                  instituicaoViewModel.Nome,
                                                  instituicaoViewModel.Endereco,
                                                  instituicaoViewModel.CNPJ,
                                                  instituicaoViewModel.Telefone);

                try
                {
                    var result = _instituicaoBLL.Update(instituicao);
                    if (result.Success)
                        return Ok(instituicaoViewModel);
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
        [HttpDelete, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _instituicaoBLL.Remove(id);
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
                var result = _instituicaoBLL.InativarOuAtivar(id, ativo);
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
