using granado_clinica_veterinaria_business.Services;
using granado_clinica_veterinaria_business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        protected readonly AtendimentoService atendimentoService;

        public AtendimentoController(AtendimentoService atendimentoService)
        {
            this.atendimentoService = atendimentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtendimentoViewModel>>> Get()
        {
            try
            {
                return Ok(await this.atendimentoService.GetListAtendimentoAsync());
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtendimentoViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.atendimentoService.GetAtendimentoAsync(Id));
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AtendimentoViewModel viewModel)
        {
            try
            {
                await this.atendimentoService.InsertAsync(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AtendimentoViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                await this.atendimentoService.UpdateAsync(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await this.atendimentoService.RemocaAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }
    }
}
